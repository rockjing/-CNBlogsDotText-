#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// Blog:		http://ScottWater.com/blog 
// RSS:			http://scottwater.com/blog/rss.aspx
// License:		http://scottwater.com/License
// Email:		Scott@TripleASP.NET
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Data;
using System.Reflection;
using System.Collections;

using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Framework.Format;
using Dottext.Framework.Providers;
using Dottext.Framework.Tracking;
using Dottext.Framework.Util;
using Dottext.Framework.Logger;



namespace Dottext.Framework.Data
{
	/// <summary>
	/// Summary description for DataDTOProvider.
	/// </summary>
	public class DataDTOProvider : Dottext.Framework.Data.IDTOProvider
	{
		public DataDTOProvider()
		{
		}		


		#region Entries

		#region EntryCollections

		/// <summary>
		/// EntryCollection returned can contain CategoryEntries if a categoryid or categoryname is supplied.
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public EntryCollection GetEntryCollection(EntryQuery query)
		{
			IDataReader reader = null;
			try
			{
				reader = DbProvider.Instance().GetEntriesReader(query);
				EntryCollection ec = DataHelper.LoadEntryCollection(reader);
				return ec;
			}
			finally
			{
				reader.Close();
			}
			
		}

		public CategoryEntryCollection GetCategoryEntryCollection(EntryQuery query)
		{
			CategoryEntryCollection ec = new CategoryEntryCollection();
			DataSet ds = DbProvider.Instance().GetCategoryEntriesDataSet(query);
			this.SetCategoryReleation(ds);
			int count = ds.Tables[0].Rows.Count;
			for(int i =0;i<count;i++)
			{
				DataRow row = ds.Tables[0].Rows[i];
				CategoryEntry ce = DataHelper.LoadSingleCategoryEntry(row);
				ec.Add(ce);
			}
			return ec;		
		}

		public EntryDayCollection GetEntryDayCollection(EntryQuery query)
		{
			IDataReader reader = DbProvider.Instance().GetEntriesReader(query);
			try
			{
				EntryDayCollection edc = DataHelper.LoadEntryDayCollection(reader);
				return edc;
			}
			finally
			{
				reader.Close();
			}
		}

		public PagedEntryCollection GetPagedEntryCollection(PagedEntryQuery query)
		{
			IDataReader reader = DbProvider.Instance().GetPagedEntriesReader(query);
			try
			{
				PagedEntryCollection pec = new PagedEntryCollection();
				while(reader.Read())
				{
					pec.Add(DataHelper.LoadSingleEntryStatsView(reader));
				}
				reader.NextResult();
				pec.MaxItems = DataHelper.GetMaxItems(reader);
				return pec;
				
			}
			finally
			{
				reader.Close();
			}
		}

		public EntryDay GetEntryDay(EntryQuery query)
		{
			IDataReader reader = DbProvider.Instance().GetEntriesReader(query);
			try
			{
				EntryDay ed = new EntryDay(query.StartDate);
				while(reader.Read())
				{
					ed.Add(DataHelper.LoadSingleEntry(reader));
				}
				return ed;
			}
			finally
			{
				reader.Close();
			}
		}


		public EntryCollection GetFeedBack(int ParrentID)
		{
			IDataReader reader = DbProvider.Instance().GetFeedBack(ParrentID);
			try
			{
				EntryCollection ec = DataHelper.LoadEntryCollection(reader);
				return ec;
			}
			finally
			{
				reader.Close();
			}
		}

		public EntryCollection GetFeedBack(Entry ParentEntry)
		{
			IDataReader reader = DbProvider.Instance().GetFeedBack(ParentEntry.EntryID);
			UrlFormats formats = Config.CurrentBlog().UrlFormats;
			try
			{
				EntryCollection ec = new EntryCollection();
				Entry entry = null;
				while(reader.Read())
				{
					entry = DataHelper.LoadSingleEntry(reader,false);
					entry.Link = formats.CommentUrl(ParentEntry,entry);
					ec.Add(entry);
				}
				return ec;
			}
			finally
			{
				reader.Close();
			}
		}



		#endregion

		#region Single Entry

		public Entry GetEntry(int EntryID)
		{
			IDataReader reader = DbProvider.Instance().GetEntry(EntryID);
			try
			{
				Entry entry = null;
				while(reader.Read())
				{
				
					entry = DataHelper.LoadSingleEntry(reader);
					break;
				}
				return entry;
			}
			finally
			{
				reader.Close();
			}
		}

		public Entry GetEntry(int EntryID,int BlogID)
		{
			IDataReader reader = DbProvider.Instance().GetEntry(EntryID,BlogID);
			try
			{
				Entry entry = null;
				while(reader.Read())
				{
				
					entry = DataHelper.LoadSingleEntry(reader);
					break;
				}
				return entry;
			}
			finally
			{
				reader.Close();
			}
		}

		public EntryStatsView GetEntryStatsView(int EntryID)
		{
			IDataReader reader = DbProvider.Instance().GetEntryStatsView(EntryID);
			try
			{
				EntryStatsView entry = null;
				while(reader.Read())
				{
				
					entry = DataHelper.LoadSingleEntryView(reader);
					break;
				}
				return entry;
			}
			finally
			{
				reader.Close();
			}
		}

		public Entry GetEntry(int EntryID, string EntryName, PostConfig config)
		{
			IDataReader reader = DbProvider.Instance().GetEntry(EntryID,EntryName,config,false);
			try
			{
				Entry entry = null;
				while(reader.Read())
				{
				
					entry = DataHelper.LoadSingleEntry(reader);
					break;
				}
				return entry;
			}
			finally
			{
				reader.Close();
			}
		}

		public CategoryEntry GetCategoryEntry(int EntryID, string EntryName, PostConfig config)
		{
			IDataReader reader = DbProvider.Instance().GetEntry(EntryID,EntryName,config,true);
			try
			{
				CategoryEntry entry = null;
				while(reader.Read())
				{
				
					entry = DataHelper.LoadSingleCategoryEntry(reader);
					break;
				}
				return entry;
			}
			finally
			{
				reader.Close();
			}
		}


		#endregion

		#region Delete

		public bool Delete(int PostID)
		{
			return DbProvider.Instance().DeleteEntry(PostID);
		}

		#endregion

		#region Create Entry

		public int Create(Entry entry)
		{
			return Create(entry,null);
		}

		public int Create(Entry entry, int[] CategoryIDs)
		{
			if(entry.PostType == PostType.PingTrack)
			{
				return DbProvider.Instance().InsertPingTrackEntry(entry);
			}

			FormatEntry(ref entry);

			if(entry is CategoryEntry)
			{
				entry.EntryID = DbProvider.Instance().InsertCategoryEntry(((CategoryEntry)entry));
			}
			else
			{
				entry.EntryID = DbProvider.Instance().InsertEntry(entry);	
		
				if(CategoryIDs != null)
				{
					DbProvider.Instance().SetEntryCategoryList(entry.EntryID,CategoryIDs);
				}
			}

			if(entry.EntryID > -1)// && Config.Settings.Tracking.UseTrackingServices)
			{
				entry.Link = Dottext.Framework.Configuration.Config.CurrentBlog().UrlFormats.EntryUrl(entry);
				Config.CurrentBlog().LastUpdated = entry.DateCreated;

			}
			else
			{
				//we need to fail here to stop the PostCommits?
				throw new BlogFailedPostException("Your entry could not be added to the datastore");
			}

			return entry.EntryID;
		}

		#endregion

		#region Update

		public bool Update(Entry entry)
		{
			return Update(entry,null);
		}

		public bool Update(Entry entry, int[] CategoryIDs)
		{
			
			FormatEntry(ref entry);

			if(entry is CategoryEntry)
			{
				if(!DbProvider.Instance().UpdateCategoryEntry(((CategoryEntry)entry)))
				{
					return false;
				}
			}
			else
			{
				if(!DbProvider.Instance().UpdateEntry(entry))
				{
					return false;
				}

				DbProvider.Instance().SetEntryCategoryList(entry.EntryID,CategoryIDs);
			}

			Config.CurrentBlog().LastUpdated = entry.DateUpdated;

			return true;
		}

		#endregion

		#region SetCategoriesList

		public bool SetEntryCategoryList(int EntryID, int[] Categories)
		{
			return DbProvider.Instance().SetEntryCategoryList(EntryID,Categories);
		}

		#endregion
        
		#region Format Helper
		
		private void FormatEntry(ref Entry e)
		{
			if((e.PostType & (PostType.Article | PostType.BlogPost)) == e.PostType)
			{
				if(Config.Settings.UseXHTML)
				{
					Globals.IsValidXHTML(ref e);
				}
			}
		}

		#endregion

		#endregion

		#region Links/Categories

		#region Paged Links

		public PagedLinkCollection GetPagedLinks(int categoryTypeID, int pageIndex, int pageSize, bool sortDescending)
		{
			IDataReader reader = DbProvider.Instance().GetPagedLinks(categoryTypeID,pageIndex,pageSize,sortDescending);
			try
			{
				PagedLinkCollection plc = new PagedLinkCollection();
				while(reader.Read())
				{
					plc.Add(DataHelper.LoadSingleLink(reader));
				}
				reader.NextResult();
				plc.MaxItems = DataHelper.GetMaxItems(reader);
				return plc;
			}
			finally
			{
				reader.Close();
			}

		}

		#endregion

		#region LinkCollection

		public LinkCollection GetLinkCollectionByPostID(int PostID)
		{
			IDataReader reader = DbProvider.Instance().GetLinkCollectionByPostID(PostID);
			try
			{
				LinkCollection lc = new LinkCollection();
				while(reader.Read())
				{
					lc.Add(DataHelper.LoadSingleLink(reader));
				}
				return lc;
			}
			finally
			{
				reader.Close();
			}
		}
		
		public LinkCollection GetLinkCollectionByPostID(int BlogID,int PostID)
		{
			IDataReader reader = DbProvider.Instance().GetLinkCollectionByPostID(BlogID,PostID);
			try
			{
				LinkCollection lc = new LinkCollection();
				while(reader.Read())
				{
					lc.Add(DataHelper.LoadSingleLink(reader));
				}
				return lc;
			}
			finally
			{
				reader.Close();
			}
		}
		

		public LinkCollection GetLinksByCategoryID(int catID, bool ActiveOnly)
		{
			IDataReader reader = DbProvider.Instance().GetLinksByCategoryID(catID,ActiveOnly);
			LinkCollection lc = new LinkCollection();
			try
			{
				while(reader.Read())
				{
					lc.Add(DataHelper.LoadSingleLink(reader));
				}
				return lc;
			}
			finally
			{
				reader.Close();
			}
		}

		#endregion

		#region Single Link

		public Link GetSingleLink(int linkID)
		{
			IDataReader reader = DbProvider.Instance().GetSingleLink(linkID);
			try
			{
				Link link = null;
				while(reader.Read())
				{
					link = DataHelper.LoadSingleLink(reader);
					break;
				}
				return link;
			}
			finally
			{
				reader.Close();
			}			
		}

		#endregion

		#region LinkCategoryCollection

		public LinkCategoryCollection GetCategoriesByType(CategoryType catType, bool ActiveOnly)
		{
			IDataReader reader = DbProvider.Instance().GetCategoriesByType(catType,ActiveOnly);
			LinkCategoryCollection lcc = new LinkCategoryCollection();
			try
			{
				while(reader.Read())
				{
					lcc.Add(DataHelper.LoadSingleLinkCategory(reader));
				}
				return lcc;
			}
			finally
			{
				reader.Close();
			}
		}

		public LinkCategoryCollection GetCategoriesByParentID(CategoryType catType,int ParentID,bool ActiveOnly)
		{
			IDataReader reader = DbProvider.Instance().GetCategoriesByParentID(catType,ParentID,ActiveOnly);
			LinkCategoryCollection lcc = new LinkCategoryCollection();
			try
			{
				while(reader.Read())
				{
					lcc.Add(DataHelper.LoadSingleLinkCategory(reader));
				}
				return lcc;
			}
			finally
			{
				reader.Close();
			}
		}
		
		public LinkCategoryCollection GetCategoriesByType(int BlogID,CategoryType catType, bool ActiveOnly)
		{
			IDataReader reader = DbProvider.Instance().GetCategoriesByType(BlogID,catType,ActiveOnly);
			LinkCategoryCollection lcc = new LinkCategoryCollection();
			try
			{
				while(reader.Read())
				{
					lcc.Add(DataHelper.LoadSingleLinkCategory(reader));
				}
				return lcc;
			}
			finally
			{
				reader.Close();
			}
		}



		public LinkCategoryCollection GetCategoriesWithLinks(bool IsActive)
		{
			DataSet ds = DbProvider.Instance().GetCategoriesWithLinks(IsActive);
			LinkCategoryCollection lcc = new LinkCategoryCollection();
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
				LinkCategory lc = DataHelper.LoadSingleLinkCategory(dr);
				lc.Links = new LinkCollection();
				foreach(DataRow drLink in dr.GetChildRows("CategoryID"))
				{
					lc.Links.Add(DataHelper.LoadSingleLink(drLink));
				}
				lcc.Add(lc);				
			}
			return lcc;
		}

		#endregion

		#region LinkCategory

		public LinkCategory GetLinkCategory(int CategoryID, bool IsActive)
		{
			IDataReader reader = DbProvider.Instance().GetLinkCategory(CategoryID,null,IsActive);
			try
			{
				LinkCategory lc=null;
				while(reader.Read())
				{
					lc = DataHelper.LoadSingleLinkCategory(reader);
				}
				return lc;
			}
			finally
			{
				reader.Close();
			}
		}

		public LinkCategory GetLinkCategory(int CategoryID, bool IsActive,int BlogID)
		{
			IDataReader reader = DbProvider.Instance().GetLinkCategory(CategoryID,null,IsActive,BlogID);
			try
			{
				LinkCategory lc=null;
				while(reader.Read())
				{
					lc = DataHelper.LoadSingleLinkCategory(reader);
				}
				return lc;
			}
			finally
			{
				reader.Close();
			}
		}

		public LinkCategory GetLinkCategory(string categoryName,bool IsActive)
		{
			IDataReader reader = DbProvider.Instance().GetLinkCategory(0,categoryName,IsActive);
			
			try
			{
				LinkCategory lc=null;
				while(reader.Read())
				{
					lc = DataHelper.LoadSingleLinkCategory(reader);
				}
				return lc;
			}
			finally
			{
				reader.Close();
			}
		}

		#endregion

		#region Edit Links/Categories

		public bool UpdateLink(Link link)
		{
			return DbProvider.Instance().UpdateLink(link);
		}

		public int CreateLink(Link link)
		{
			return DbProvider.Instance().InsertLink(link);
		}

		public bool UpdateLinkCategory(LinkCategory lc)
		{
			return DbProvider.Instance().UpdateCategory(lc);
		}
		
		public int CreateLinkCategory(LinkCategory lc)
		{
			return DbProvider.Instance().InsertCategory(lc);
		}

		public bool DeleteLinkCategory(int CategoryID)
		{
			return DbProvider.Instance().DeleteCategory(CategoryID);
		}

		public bool DeleteLinkCategory(int CategoryID,int BlogID)
		{
			return DbProvider.Instance().DeleteCategory(CategoryID,BlogID);
		}

		public bool DeleteLink(int LinkID)
		{
			return DbProvider.Instance().DeleteLink(LinkID);
		}

		#endregion

		#endregion

		#region Stats

//		public PagedViewStatCollection GetPagedViewStats(int pageIndex, int pageSize, DateTime beginDate, DateTime endDate)
//		{
//
//			IDataReader reader = DbProvider.Instance().GetPagedViewStats(pageIndex,pageSize,beginDate,endDate);
//			try
//			{
//				PagedViewStatCollection vs = new PagedViewStatCollection();
//				while(reader.Read())
//				{
//					vs.Add(DataHelper.LoadSingleViewStat(reader));
//				}
//				reader.NextResult();
//				vs.MaxItems = DataHelper.GetMaxItems(reader);
//				return vs;
//			}
//			finally
//			{
//				reader.Close();
//			}	
//		}

		public PagedReferrerCollection GetPagedReferrers(int pageIndex, int pageSize)
		{
			IDataReader reader = DbProvider.Instance().GetPagedReferrers(pageIndex,pageSize);
			try
			{
				PagedReferrerCollection prc = new PagedReferrerCollection();
				while(reader.Read())
				{
					prc.Add(DataHelper.LoadSingleReferrer(reader));
				}
				reader.NextResult();
				prc.MaxItems = DataHelper.GetMaxItems(reader);
				return prc;
			}
			finally
			{
				reader.Close();
			}	
		}

		public PagedReferrerCollection GetPagedReferrers(int pageIndex, int pageSize, int EntryID)
		{
			IDataReader reader = DbProvider.Instance().GetPagedReferrers(pageIndex,pageSize,EntryID);
			try
			{
				PagedReferrerCollection prc = new PagedReferrerCollection();
				while(reader.Read())
				{
					prc.Add(DataHelper.LoadSingleReferrer(reader));
				}
				reader.NextResult();
				prc.MaxItems = DataHelper.GetMaxItems(reader);
				return prc;
			}
			finally
			{
				reader.Close();
			}
		}

		public bool TrackEntry(EntryView ev)
		{
			return DbProvider.Instance().TrackEntry(ev);
		}

		public bool TrackEntry(EntryViewCollection evc)
		{
			return DbProvider.Instance().TrackEntry(evc);
		}

		#endregion

		#region  Configuration

		public bool UpdateConfigData(BlogConfig config)
		{
			return DbProvider.Instance().UpdateConfigData(config);
		}

		public BlogConfig GetConfig(string hostname, string application)
		{
			IDataReader reader = DbProvider.Instance().GetConfig(hostname,application);
			try
			{
				BlogConfig config = null;
				while(reader.Read())
				{
					config = DataHelper.LoadConfigData(reader);
					break;
				}
				return config;
			}
			finally
			{
				reader.Close();
			}

		}
		
		public BlogConfig GetConfig(int BlogID)
		{
			IDataReader reader = DbProvider.Instance().GetConfig(BlogID);
			try
			{
				BlogConfig config = null;
				while(reader.Read())
				{
					config = DataHelper.LoadConfigData(reader);
					break;
				}
				return config;
			}
			finally
			{
				reader.Close();
			}
		}
		public BlogConfig[] GetConfigByRoleID(int RoleID)
		{
			IDataReader reader = DbProvider.Instance().GetConfigByRoleID(RoleID);
			try
			{
				BlogConfig config = null;
				ArrayList al=new ArrayList();
				while(reader.Read())
				{
					config = DataHelper.LoadConfigData(reader);
					al.Add(config);
				}

				return (BlogConfig[])al.ToArray(typeof(BlogConfig));
			}
			finally
			{
				reader.Close();
			}
		}

		public string[] GetBlogGroup(int BlogID)
		{
			System.Collections.ArrayList list=new System.Collections.ArrayList();
			IDataReader reader = DbProvider.Instance().GetBlogGroup(BlogID);
			try
			{
				while(reader.Read())
				{
					list.Add(reader["GroupName"]);
				}
				string[] groups=new string[list.Count];
				list.CopyTo(0,groups,0,list.Count);
				return groups;
			}
			finally
			{
				reader.Close();
			}
		}

		public BlogConfig GetConfig(string UserName)
		{
			IDataReader reader = DbProvider.Instance().GetConfig(UserName);
			try
			{
				BlogConfig config = null;
				while(reader.Read())
				{
					config = DataHelper.LoadConfigData(reader);
					break;
				}
				return config;
			}
			finally
			{
				reader.Close();
			}
		}

		public BlogConfig GetConfigByApp(string app)
		{
			IDataReader reader = DbProvider.Instance().GetConfigByApp(app);
			try
			{
				BlogConfig config = null;
				while(reader.Read())
				{
					config = DataHelper.LoadConfigData(reader);
					break;
				}
				return config;
			}
			finally
			{
				reader.Close();
			}
		}

		public SkinControlCollection GetSkinControlCollection(int BlogID)
		{
			IDataReader reader = null;
			try
			{
				reader = DbProvider.Instance().GetSkinControlCollection(BlogID);
				SkinControlCollection scc = DataHelper.LoadSkinControlCollection(reader);
				
				return scc;
			}
			finally
			{
				reader.Close();
			}
		}

		public bool UpateSkinControl(SkinControl sc)
		{
			return DbProvider.Instance().UpateSkinControl(sc);
		}

		public bool UpdateSingleSkinControl(int ControlID,bool visible,int BlogID)
		{
			return DbProvider.Instance().UpdateSingleSkinControl(ControlID,visible,BlogID);
		}

		#endregion

		#region KeyWords

		public KeyWord GetKeyWord(int KeyWordID)
		{
			IDataReader reader = DbProvider.Instance().GetKeyWord(KeyWordID);
			try
			{
				KeyWord kw = null;
				while(reader.Read())
				{
					kw = DataHelper.LoadSingleKeyWord(reader);
					break;
				}
				return kw;
			}
			finally
			{
				reader.Close();
			}
		}
		
		public KeyWordCollection GetKeyWords()
		{
			IDataReader reader = DbProvider.Instance().GetKeyWords();
			try
			{
				KeyWordCollection kwc = new KeyWordCollection();
				while(reader.Read())
				{
					kwc.Add(DataHelper.LoadSingleKeyWord(reader));
				}
				return kwc;
			}
			finally
			{
				reader.Close();
			}
		}

		public PagedKeyWordCollection GetPagedKeyWords(int pageIndex, int pageSize,bool sortDescending)
		{
			IDataReader reader = DbProvider.Instance().GetPagedKeyWords(pageIndex,pageSize,sortDescending);
			try
			{
				PagedKeyWordCollection pkwc = new PagedKeyWordCollection();
				while(reader.Read())
				{
					pkwc.Add(DataHelper.LoadSingleKeyWord(reader));
				}
				reader.NextResult();
				pkwc.MaxItems = DataHelper.GetMaxItems(reader);

				return pkwc;
			}
			finally
			{
				reader.Close();
			}
		}
		
		public bool UpdateKeyWord(KeyWord kw)
		{
			return DbProvider.Instance().UpdateKeyWord(kw);
		}

		public int InsertKeyWord(KeyWord kw)
		{
			return DbProvider.Instance().InsertKeyWord(kw);
		}

		public bool DeleteKeyWord(int KeyWordID)
		{
			return DbProvider.Instance().DeleteKeyWord(KeyWordID);
		}

		#endregion

		#region Images

		public ImageCollection GetImagesByCategoryID(int catID, bool ActiveOnly)
		{
			IDataReader reader = DbProvider.Instance().GetImagesByCategoryID(catID,ActiveOnly);
			try
			{
				ImageCollection ic = new ImageCollection();
				while(reader.Read())
				{
					ic.Category = DataHelper.LoadSingleLinkCategory(reader);
					break;
				}
				reader.NextResult();
				while(reader.Read())
				{
					ic.Add(DataHelper.LoadSingleImage(reader));
				}
				return ic;
			}
			finally
			{
				reader.Close();
			}
		}

		public Image GetSingleImage(int imageID, bool ActiveOnly)
		{
			IDataReader reader = DbProvider.Instance().GetSingleImage(imageID,ActiveOnly);
			try
			{
				Image image = null;
				while(reader.Read())
				{
					image = DataHelper.LoadSingleImage(reader);
				}
				return image;
			}
			finally
			{
				reader.Close();
			}
		}

		public int InsertImage(Dottext.Framework.Components.Image _image)
		{
			return DbProvider.Instance().InsertImage(_image);
		}

		public bool UpdateImage(Dottext.Framework.Components.Image _image)
		{
			return DbProvider.Instance().UpdateImage(_image);
		}

		public bool DeleteImage(int ImageID)
		{
			return DbProvider.Instance().DeleteImage(ImageID);
		}

		#endregion

		#region Archives

		public ArchiveCountCollection GetPostsByMonthArchive(PostType postType)
		{
			IDataReader reader = DbProvider.Instance().GetPostsByMonthArchive(postType);
			try
			{
				ArchiveCountCollection acc = DataHelper.LoadArchiveCount(reader);
				return acc;
			}
			finally
			{
				reader.Close();
			}
		}

		public ArchiveCountCollection GetPostsByYearArchive(PostType postType)
		{
			IDataReader reader = DbProvider.Instance().GetPostsByYearArchive(postType);
			try
			{
				ArchiveCountCollection acc = DataHelper.LoadArchiveCount(reader);
				return acc;
			}
			finally
			{
				reader.Close();
			}
		}

		#endregion

		#region Helpers
		private void SetCategoryReleation(DataSet ds)
		{
			DataRelation dr = new DataRelation("cats",ds.Tables[0].Columns["ID"],ds.Tables[1].Columns["PostID"],false);
			ds.Relations.Add(dr);
		}

		//通过反射,将数据库中的字段值读取到实体类中
		private void ReaderToObject(IDataReader reader,object targetObj)
		{
			for(int i=0;i<reader.FieldCount;i++)
			{
				System.Reflection.PropertyInfo propertyInfo=targetObj.GetType().GetProperty(reader.GetName(i));
				if(propertyInfo!=null)
				{
					if(reader.GetValue(i)!=DBNull.Value)
					{
						if(propertyInfo.PropertyType.IsEnum)
						{
							propertyInfo.SetValue(targetObj,Enum.ToObject(propertyInfo.PropertyType,reader.GetValue(i)),null);
						}
						else
						{
							propertyInfo.SetValue(targetObj,reader.GetValue(i),null);
						}
					}
				}
			}
		}
		#endregion

		#region ScheduledEvents
		public DateTime GetLastExecuteScheduledEventDateTime(string key, string serverName)
		{
			return DbProvider.Instance().GetLastExecuteScheduledEventDateTime(key,serverName);
		}
		
		public void SetLastExecuteScheduledEventDateTime(string key, string serverName, DateTime dt)
		{
			DbProvider.Instance().SetLastExecuteScheduledEventDateTime(key,serverName,dt);
		}
		#endregion

		#region Logger

		public int CreateLog(Log blogLog)
		{
			return DbProvider.Instance().CreateLog(blogLog);
		}
		
		#endregion

		#region Rate
		public int InsertRate(EntryRate er)
		{
			return DbProvider.Instance().InsertRate(er);
		}
		public int GetRatePeople(int entryID,int score)
		{
			IDataReader reader=DbProvider.Instance().GetRatePeople(entryID,score);
			try
			{
				while(reader.Read())
				{
					return (int)reader["peoples"];
				}
			
			}
			finally
			{
				reader.Close();
			}
			return 0;
		}

		#endregion

		#region EntryCount
		public int GetEntryCount(EntryQuery query)
		{
			IDataReader reader=DbProvider.Instance().GetEntryCount(query);
			try
			{
				while(reader.Read())
				{
					if(reader.FieldCount>0)
					{
						return (int)reader["Count"];
					}
				}
			
			}
			finally
			{
				reader.Close();
			}
			return 0;
		}
		#endregion

		#region Security
		public Role[] GetRoles(int BlogID)
		{
			System.Collections.ArrayList al=new System.Collections.ArrayList();
			IDataReader reader=DbProvider.Instance().GetRoles(BlogID);
			try
			{
				while(reader.Read())
				{
					Role role=new Role();
					/*if(reader["RoleID"]!=DBNull.Value)
					{
						role.RoleID=(int)reader["RoleID"];
					}
					if(reader["Name"]!=DBNull.Value)
					{
						role.Name=(string)reader["Name"];
					}
					if(reader["Description"]!=DBNull.Value)
					{
						role.Description=(string)reader["Description"];
					}*/
					ReaderToObject(reader,role);
					al.Add(role);
				}
			}
			finally
			{
				reader.Close();
			}
			return (Role[])al.ToArray(typeof(Role));
		
		}

		public bool AddUserToRole(int BlogID,int RoleID)
		{
			return DbProvider.Instance().AddUserToRole(BlogID,RoleID);
		}

		public bool RemoveUserFromRole(int BlogID,int RoleID)
		{
			return DbProvider.Instance().RemoveUserFromRole(BlogID,RoleID);
		}

		#endregion

		#region MailNotify

		public ArrayList GetNotifyMailList(int EntryID)
		{
			ArrayList al=new ArrayList(); 
			IDataReader reader=DbProvider.Instance().GetNotifyMailList(EntryID);
			try
			{
				while(reader.Read())
				{
					if(reader["EMail"]!=null)
					{
						al.Add((string)reader["EMail"]);
					}
				}
			
			}
			finally
			{
				reader.Close();
			}
			return al;
		}

		public bool InsertNotifySubscibe(int EntryID,int BlogID,int SendToBlogID,string EMail)
		{
			return DbProvider.Instance().InsertNotifySubscibe(EntryID,BlogID,SendToBlogID,EMail);
		}

		public bool DeleteMailNotify(int EntryID,int SendToBlogID)
		{
			return DbProvider.Instance().DeleteMailNotify(EntryID,SendToBlogID);
		}

		#endregion

		
	}
}
