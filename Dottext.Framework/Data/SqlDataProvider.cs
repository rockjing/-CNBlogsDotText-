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
using System.Data.SqlClient;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Framework;
using Dottext.Framework.Logger;



namespace Dottext.Framework.Data
{
	/// <summary>
	/// Summary description for SqlDataProvider.
	/// </summary>
	public class SqlDataProvider : IDbProvider
	{
		static SqlDataProvider()
		{
			//Two sets of parameters will be used over and over again. Initialize them just once
			//DefaultEntryQueryParameters = BuildDefaultEntryQueryParameters();
			//DefaultEntryParameters = BuildDefaultEntryParameters();
		}

		public SqlDataProvider()
		{
		}


		private string _connectionString;
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}


		#region Parameters

		private SqlParameter BlogIDParam
		{
			get
			{
				return  SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,Config.CurrentBlog().BlogID);
			}
		}

		public static SqlParameter[] DefaultEntryParameters
		{
			get
			{
				return BuildDefaultEntryParameters();
			}
		}

		private static SqlParameter[] BuildDefaultEntryParameters()
		{
			SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@EntryID",SqlDbType.Int,4);
			p[0].IsNullable = true;
			p[0].Direction = ParameterDirection.Input;

			p[1] = new SqlParameter("@EntryName",SqlDbType.NVarChar,150);
			p[1].IsNullable = true;
			p[1].Direction = ParameterDirection.Input;

			p[2] = new SqlParameter("@PostConfig",SqlDbType.Int,4);
			p[2].IsNullable = false;
			p[2].Direction = ParameterDirection.Input;

			p[3] = new SqlParameter("@IncludeCategories",SqlDbType.Bit,1);
			p[3].IsNullable = false;
			p[3].Direction = ParameterDirection.Input;

			p[4] = new SqlParameter("@BlogID",SqlDbType.Int,4);
			p[4].IsNullable = false;
			p[4].Direction = ParameterDirection.Input;

			return p;
		}

		private SqlParameter[] EntryParameters(int EntryID, string EntryName, PostConfig pc, bool IncludeCategories)
		{
			
			SqlParameter[] p = new SqlParameter[5];
			Array.Copy(DefaultEntryParameters,0,p,0,5);
			p[0].Value = NullCheck(EntryID>0,EntryID);
			p[1].Value = NullCheck(EntryName != null,EntryName);
			p[2].Value = pc;
			p[3].Value = IncludeCategories;
			p[4].Value = Config.CurrentBlog().BlogID;
			return p;
		}

		public static SqlParameter[] DefaultEntryQueryParameters 
		{
			get
			{
				return BuildDefaultEntryQueryParameters();
			}
		}

		private static SqlParameter[] BuildDefaultEntryQueryParameters()
		{
			SqlParameter[] p = new SqlParameter[8];
			try
			{
				p[0] = new SqlParameter("@ItemCount",SqlDbType.Int,4);
				p[0].IsNullable = false;
				p[0].Direction = ParameterDirection.Input;
				
				p[1] = new SqlParameter("@PostType",SqlDbType.Int,4);
				p[1].IsNullable = false;
				p[1].Direction = ParameterDirection.Input;

				p[2] = new SqlParameter("@PostConfig",SqlDbType.Int,4);
				p[2].IsNullable = false;
				p[2].Direction = ParameterDirection.Input;

				p[3] = new SqlParameter("@BlogID",SqlDbType.Int,4);
				p[3].IsNullable = false;
				p[3].Direction = ParameterDirection.Input;

				p[4] = new SqlParameter("@CategoryID",SqlDbType.Int,4);
				p[4].IsNullable = true;
				p[4].Direction = ParameterDirection.Input;

				p[5] = new SqlParameter("@CategoryName",SqlDbType.NVarChar,100);
				p[5].IsNullable = true;
				p[5].Direction = ParameterDirection.Input;

				p[6] = new SqlParameter("@StartDate",SqlDbType.DateTime,8);
				p[6].IsNullable = true;
				p[6].Direction = ParameterDirection.Input;

				p[7] = new SqlParameter("@StopDate",SqlDbType.DateTime,8);
				p[7].IsNullable = true;
				p[7].Direction = ParameterDirection.Input;
			}
			catch(Exception e)
			{
				Logger.LogManager.CreateExceptionLog(e,"BuildDefaultEntryQueryParameters Exception");
				throw e;
			}

			return p;
		}

		private object NullCheck(bool isNotNull, object obj)
		{
			if(isNotNull)
			{
				return obj;
			}
			else
			{
				return DBNull.Value;				
			}
		}

		//use with caution. Using index's can be messy :(
		private SqlParameter[] EntryQueryParameters(EntryQuery query)
		{
		
			SqlParameter[] p = new SqlParameter[11];
			try
			{
				Array.Copy(DefaultEntryQueryParameters,0,p,0,8);
				p[0].Value = query.ItemCount;
				p[1].Value = query.PostType;
				p[2].Value = query.PostConfig;
				p[3].Value =NullCheck(Config.CurrentBlog().BlogID>=0,Config.CurrentBlog().BlogID);
				/*try
				{
					GetBlogID();
				}
				catch(BlogDoesNotExistException e)
				{
					p[3].Value=DBNull.Value;
				}*/
			
				//p[3].Value=Config.CurrentBlog().BlogID;
				p[4].Value = NullCheck(query.HasCategoryID,query.CategoryID);
				p[5].Value = NullCheck(query.HasCategoryTitle,query.CategoryTitle);
				p[6].Value = NullCheck(query.HasStartDate,query.StartDate);
				p[7].Value = NullCheck(query.HasEndDate,query.EndDate);
				p[8] = new SqlParameter("@CategoryType",SqlDbType.Int,4);
				p[8].Direction = ParameterDirection.Input;
				p[8].Value = NullCheck(query.HasCateType,query.CateType);
				p[9] = new SqlParameter("@BlogGroupID",SqlDbType.Int,4);
				p[9].Direction = ParameterDirection.Input;
				p[9].Value = NullCheck(query.HasBlogGroupID,query.BlogGroupID);
				p[10] = new SqlParameter("@Author",SqlDbType.NVarChar,100);
				p[10].Direction = ParameterDirection.Input;
				p[10].Value = NullCheck(query.HasAuthor,query.Author);
			}
			catch(Exception e)
			{
				Logger.LogManager.CreateExceptionLog(e,"EntryQueryParameters Exception");
				throw e;
			}

			return p;
		}


		private SqlParameter[] PagedEntryQueryParameters(PagedEntryQuery query)
		{
			
			SqlParameter[] p = new SqlParameter[13];
			Array.Copy(EntryQueryParameters(query),0,p,0,11);
			
			p[11] = new SqlParameter("@PageIndex",SqlDbType.Int,4);
			p[11].Direction = ParameterDirection.Input;
			p[11].Value = query.PageIndex;

			p[12] = new SqlParameter("@PageSize",SqlDbType.Int,4);
			p[12].Direction = ParameterDirection.Input;
			p[12].Value = query.PageSize;			

			return p;
		}


		#endregion

		#region Statistics

		public bool TrackEntry(EntryViewCollection evc)
		{
			if(evc != null)
			{
				//				System.IO.StringWriter sw = new System.IO.StringWriter();
				//				System.Xml.XmlTextWriter tw = new System.Xml.XmlTextWriter(sw);
				//				tw.WriteStartElement("EntryViews");
				//
				//				
				//				foreach(EntryView ev in evc)
				//				{
				//					tw.WriteStartElement("EV");
				//					tw.WriteAttributeString("E",ev.EntryID.ToString());
				//					tw.WriteAttributeString("B",ev.BlogID.ToString());
				//					//tw.WriteAttributeString("U",ev.ReferralUrl);
				//					tw.WriteAttributeString("W",((int)ev.PageViewType).ToString());
				//					tw.WriteEndElement();
				//					
				//
				//				}
				//				tw.WriteEndElement();
				
				

				SqlConnection conn = new SqlConnection(this.ConnectionString);
				try
				{
									
					//conn.Open();
					foreach(EntryView ev in evc)
					{
				
						SqlParameter[] p =	
										{
											SqlHelper.MakeInParam("@EntryID",SqlDbType.Int,4,ev.EntryID),
											SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,ev.BlogID),
											SqlHelper.MakeInParam("@URL",SqlDbType.NVarChar,255,DataHelper.CheckNull(ev.ReferralUrl)),
											SqlHelper.MakeInParam("@IsWeb",SqlDbType.Bit,1,ev.PageViewType)
										};
						SqlHelper.ExecuteNonQuery(conn,CommandType.StoredProcedure,"blog_TrackEntry",p);
					}
					return true;
				
				}
				finally
				{
					if(conn.State == ConnectionState.Open)
					{
						conn.Close();
					}
				}
			}
			
			
			return false;
		}

		public bool TrackEntry(EntryView ev)
		{
			//blog_TrackEntry
			SqlParameter[] p =	
					{
						SqlHelper.MakeInParam("@EntryID",SqlDbType.Int,4,ev.EntryID),
						SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,ev.BlogID),
						SqlHelper.MakeInParam("@URL",SqlDbType.NVarChar,255,DataHelper.CheckNull(ev.ReferralUrl)),
						SqlHelper.MakeInParam("@IsWeb",SqlDbType.Bit,1,ev.PageViewType)
			};
			return this.NonQueryBool("blog_TrackEntry",p);
		}
		
		#endregion

		#region Images

		public IDataReader GetImagesByCategoryID(int catID, bool ActiveOnly)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,catID),
				SqlHelper.MakeInParam("@IsActive",SqlDbType.Bit,1,ActiveOnly),
				BlogIDParam
			};

			return GetReader("blog_GetImageCategory",p);
		}

		public IDataReader GetSingleImage(int imageID, bool ActiveOnly)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@ImageID",SqlDbType.Int,4,imageID),
				SqlHelper.MakeInParam("@IsActive",SqlDbType.Bit,1,ActiveOnly),
				BlogIDParam
			};
			return GetReader("blog_GetSingleImage",p);
		}

		public int InsertImage(Image _image)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,250,_image.Title),
				SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,_image.CategoryID),
				SqlHelper.MakeInParam("@Width",SqlDbType.Int,4,_image.Width),
				SqlHelper.MakeInParam("@Height",SqlDbType.Int,4,_image.Height),
				SqlHelper.MakeInParam("@File",SqlDbType.NVarChar,50,_image.File),
				SqlHelper.MakeInParam("@Active",SqlDbType.Bit,1,_image.IsActive),
				BlogIDParam,
				SqlHelper.MakeOutParam("@ImageID",SqlDbType.Int,4)
			};
			NonQueryInt("blog_InsertImage",p);
			return (int)p[7].Value;
		}

		public bool UpdateImage(Image _image)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,250,_image.Title),
				SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,_image.CategoryID),
				SqlHelper.MakeInParam("@Width",SqlDbType.Int,4,_image.Width),
				SqlHelper.MakeInParam("@Height",SqlDbType.Int,4,_image.Height),
				SqlHelper.MakeInParam("@File",SqlDbType.NVarChar,50,_image.File),
				SqlHelper.MakeInParam("@Active",SqlDbType.Bit,1,_image.IsActive),
				BlogIDParam,
				SqlHelper.MakeInParam("@ImageID",SqlDbType.Int,4,_image.ImageID)
			};
			return NonQueryBool("blog_UpdateImage",p);
		}

		public bool DeleteImage(int imageID)
		{
			SqlParameter[] p = 
			{
				BlogIDParam,
				SqlHelper.MakeInParam("@ImageID",SqlDbType.Int,4,imageID)
			};
			return NonQueryBool("blog_DeleteImage",p);
		}

		#endregion

		#region Admin 

		public IDataReader GetPagedLinks(int CategoryID, int pageIndex, int pageSize, bool sortDescending)
		{	
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@PageIndex", SqlDbType.Int, 4, pageIndex),
				SqlHelper.MakeInParam("@PageSize", SqlDbType.Int, 4, pageSize),
				SqlHelper.MakeInParam("@SortDesc", SqlDbType.Bit, 1, sortDescending),
				BlogIDParam,
				SqlHelper.MakeInParam("@CategoryID", SqlDbType.Int, 4, NullCheck(CategoryID>=0,CategoryID))
			};
			return GetReader("blog_GetPageableLinks",p);
			
		}
		
		public IDataReader GetPagedReferrers(int pageIndex, int pageSize)
		{
			SqlParameter[] p =
			{
				BlogIDParam,
				SqlHelper.MakeInParam("@PageIndex", SqlDbType.Int, 4, pageIndex),
				SqlHelper.MakeInParam("@PageSize", SqlDbType.Int, 4, pageSize)
			};
			return GetReader("blog_GetPageableReferrers",p);

		}

		public IDataReader GetPagedReferrers(int pageIndex, int pageSize, int EntryID)
		{
			SqlParameter[] p =
			{
				BlogIDParam,
				SqlHelper.MakeInParam("@EntryID", SqlDbType.Int, 4, EntryID),
				SqlHelper.MakeInParam("@PageIndex", SqlDbType.Int, 4, pageIndex),
				SqlHelper.MakeInParam("@PageSize", SqlDbType.Int, 4, pageSize)
			};
			
			return GetReader("blog_GetPageableReferrersByEntryID",p);

		}
		
			//Did not really experiment why, but sqlhelper does not seem to like the output parameter after the reader
		public IDataReader GetPagedFeedback(int pageIndex, int pageSize, bool sortDescending)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@PageIndex", SqlDbType.Int, 4, pageIndex),
				SqlHelper.MakeInParam("@PageSize", SqlDbType.Int, 4, pageSize),
				SqlHelper.MakeInParam("@SortDesc", SqlDbType.Bit, 1, sortDescending),
				BlogIDParam
			};
			return GetReader("blog_GetPageableFeedback",p);

		}


		#endregion		

		#region Get Blog Data

		public IDataReader GetEntriesReader(EntryQuery query)
		{
			return GetReader("blog_GenericGetEntries_10",EntryQueryParameters(query));
		}

		public DataSet GetEntriesDataSet(EntryQuery query)
		{
			return GetDataSet("blog_GenericGetEntries_10",EntryQueryParameters(query));
		}

		//We need to bind the categories and entries. Is it necessary to have the datareader?
		public DataSet GetCategoryEntriesDataSet(EntryQuery query)
		{
			return GetDataSet("blog_GenericGetEntriesWithCategories_10",EntryQueryParameters(query));
		}

		public IDataReader GetPagedEntriesReader(PagedEntryQuery query)
		{
			return GetReader("blog_GenericGetPagedEntries_10",PagedEntryQueryParameters(query));
		}

		public DataSet GetPagedEntriesDataSet(PagedEntryQuery query)
		{
			return GetDataSet("blog_GenericGetPagedEntries_10",PagedEntryQueryParameters(query));
		}

		public IDataReader GetEntry(int EntryID, string EntryName, PostConfig config, bool IncludeCategories)
		{
			return GetReader("blog_GetEntry_10",EntryParameters(EntryID,EntryName,config,IncludeCategories));
		}

		public IDataReader GetEntry(int EntryID)
		{
			SqlParameter[] p = 
				{
					SqlHelper.MakeInParam("@EntryID",SqlDbType.Int,4,EntryID),
					BlogIDParam
				};
			return GetReader("blog_GetEntryByID",p);
		}

		public IDataReader GetEntry(int EntryID,int BlogID)
		{
			SqlParameter[] p = 
				{
					SqlHelper.MakeInParam("@EntryID",SqlDbType.Int,4,EntryID),
					SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,BlogID)
				};
			return GetReader("blog_GetEntryByID",p);
		}
		
		public IDataReader GetEntryStatsView(int EntryID)
		{
			SqlParameter[] p = 
				{
					SqlHelper.MakeInParam("@EntryID",SqlDbType.Int,4,EntryID)
				};
			return GetReader("blog_GetEntryStatViewByEntryID",p);
		}

		public  IDataReader GetEntryCount(EntryQuery query)
		{
			return GetReader("blog_GenericGetEntriesCount_10",EntryQueryParameters(query));
		}

		#endregion

		#region Update Blog Data

		public bool DeleteEntry(int PostID)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@ID",SqlDbType.Int,4,PostID),
				BlogIDParam
			};
			return NonQueryBool("blog_DeletePost",p);
		}

		public int InsertCategoryEntry(CategoryEntry ce)
		{
			int PostID = InsertEntry(ce);
			if(PostID > -1 && ce.Categories != null && ce.Categories.Length > 0)
			{
				SqlConnection conn = new SqlConnection(ConnectionString);
				SqlParameter[] p = new SqlParameter[3];
				p[0] = new SqlParameter("@Title",SqlDbType.NVarChar,150);
				p[1] = SqlHelper.MakeInParam("@PostID",SqlDbType.Int,4,PostID);
				p[2] = ce.BlogID>0?SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,ce.BlogID):BlogIDParam;
				p[3] = SqlHelper.MakeInParam("@CategoryType",SqlDbType.TinyInt,1,ce.PostType == PostType.BlogPost ? CategoryType.PostCollection : CategoryType.StoryCollection);
				conn.Open();
				foreach(string s in ce.Categories)
				{
					p[0].Value = s;
					InsertLinkByCategoryName(p,conn);
				}
				conn.Close();
			}
			return PostID;
		}

		private void InsertLinkByCategoryName(SqlParameter[] p, SqlConnection conn)
		{
			string sql = "blog_InsertPostCategoryByName";
			SqlHelper.ExecuteNonQuery(conn,CommandType.StoredProcedure,sql,p);

		}

		//use interate functions
		public bool UpdateCategoryEntry(CategoryEntry ce)
		{
			bool result = UpdateEntry(ce);
			SqlConnection conn = new SqlConnection(ConnectionString);
			try
			{
				conn.Open();
				DeleteCategoriesByPostID(ce.EntryID,conn);
				if(ce.Categories != null && ce.Categories.Length > 0)
				{

					SqlParameter[] p = new SqlParameter[3];
					p[0] = new SqlParameter("@Title",SqlDbType.NVarChar,150);
					p[1] = SqlHelper.MakeInParam("@PostID",SqlDbType.Int,4,ce.EntryID);
					p[2] = BlogIDParam;
					p[3] = SqlHelper.MakeInParam("@CategoryType",SqlDbType.TinyInt,1,ce.PostType == PostType.BlogPost ? CategoryType.PostCollection : CategoryType.StoryCollection);
					
					
					foreach(string s in ce.Categories)
					{
						p[0].Value = s;
						InsertLinkByCategoryName(p,conn);
					}
				
				}
			}
			finally
			{
				if(conn.State == ConnectionState.Open)
				{
					conn.Close();
				}
			}
			
			return result;
		}

		public bool SetEntryCategoryList(int PostID, int[] Categories)
		{
			if(Categories == null)
			{
				return false;
			}

			string[] cats = new string[Categories.Length];
			for(int i = 0; i<Categories.Length;i++)
			{
				cats[i] = Categories[i].ToString();
			}
			string catList = string.Join(",",cats);
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@PostID",SqlDbType.Int,4,PostID),
				BlogIDParam,
				SqlHelper.MakeInParam("@CategoryList",SqlDbType.NVarChar,4000,catList)
			};
			return NonQueryBool("blog_InsertLinkCategoryList",p);

		}

		//maps to blog_InsertBlog
		public int InsertEntry(Entry entry)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@Title", SqlDbType.NVarChar,255,entry.Title),
				SqlHelper.MakeInParam("@TitleUrl", SqlDbType.NVarChar,255,DataHelper.CheckNull(entry.TitleUrl)),
				SqlHelper.MakeInParam("@Text",SqlDbType.NText,0,entry.Body),
				SqlHelper.MakeInParam("@SourceUrl",SqlDbType.NVarChar,200,DataHelper.CheckNull(entry.SourceUrl)),
				SqlHelper.MakeInParam("@PostType",SqlDbType.Int,4,entry.PostType),
				SqlHelper.MakeInParam("@Author",SqlDbType.NVarChar,50,DataHelper.CheckNull(entry.Author)),
				SqlHelper.MakeInParam("@Email",SqlDbType.NVarChar,50,DataHelper.CheckNull(entry.Email)),
				SqlHelper.MakeInParam("@Description",SqlDbType.NVarChar,500,DataHelper.CheckNull(entry.Description)),
				SqlHelper.MakeInParam("@SourceName",SqlDbType.NVarChar,200,DataHelper.CheckNull(entry.SourceName)),
				SqlHelper.MakeInParam("@DateAdded",SqlDbType.DateTime,8,entry.DateCreated),
				SqlHelper.MakeInParam("@PostConfig",SqlDbType.Int,4,entry.PostConfig),
				SqlHelper.MakeInParam("@ParentID",SqlDbType.Int,4,entry.ParentID),
				SqlHelper.MakeInParam("@EntryName",SqlDbType.NVarChar,150,DataHelper.CheckNull(entry.EntryName)),
				BlogIDParam,
				SqlHelper.MakeOutParam("@ID",SqlDbType.Int,4)
				
			};
			NonQueryInt("blog_InsertEntry",p);
			return (int)p[14].Value;
		}

		

		public bool UpdateEntry(Entry entry)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@Title", SqlDbType.NVarChar,255,entry.Title),
				SqlHelper.MakeInParam("@TitleUrl", SqlDbType.NVarChar,255,DataHelper.CheckNull(entry.TitleUrl)),
				SqlHelper.MakeInParam("@Text",SqlDbType.NText,0,entry.Body),
				SqlHelper.MakeInParam("@SourceUrl",SqlDbType.NVarChar,200,DataHelper.CheckNull(entry.SourceUrl)),
				SqlHelper.MakeInParam("@PostType",SqlDbType.Int,4,entry.PostType),
				SqlHelper.MakeInParam("@Author",SqlDbType.NVarChar,50,DataHelper.CheckNull(entry.Author)),
				SqlHelper.MakeInParam("@Email",SqlDbType.NVarChar,50,DataHelper.CheckNull(entry.Email)),
				SqlHelper.MakeInParam("@Description",SqlDbType.NVarChar,500,DataHelper.CheckNull(entry.Description)),
				SqlHelper.MakeInParam("@SourceName",SqlDbType.NVarChar,200,DataHelper.CheckNull(entry.SourceName)),
				SqlHelper.MakeInParam("@DateUpdated",SqlDbType.SmallDateTime,4,entry.DateUpdated),
				SqlHelper.MakeInParam("@ID",SqlDbType.Int,4,entry.EntryID),
				SqlHelper.MakeInParam("@PostConfig",SqlDbType.Int,4,entry.PostConfig),
				SqlHelper.MakeInParam("@ParentID",SqlDbType.Int,4,entry.ParentID),
				SqlHelper.MakeInParam("@EntryName",SqlDbType.NVarChar,150,DataHelper.CheckNull(entry.EntryName)),
				BlogIDParam
			};
		
			return NonQueryBool("blog_UpdateEntry",p);
		}

		//Not that efficent, but maybe we should just iterage over feedback items?
		public int InsertPingTrackEntry(Entry entry)
		{			
			if(entry.PostType == PostType.PingTrack)
			{
				SqlParameter[] p =
				{
					SqlHelper.MakeInParam("@Title", SqlDbType.NVarChar,255,entry.Title),
					SqlHelper.MakeInParam("@TitleUrl", SqlDbType.NVarChar,255,DataHelper.CheckNull(entry.TitleUrl)),
					SqlHelper.MakeInParam("@Text",SqlDbType.NText,0,entry.Body),
					SqlHelper.MakeInParam("@SourceUrl",SqlDbType.NVarChar,200,DataHelper.CheckNull(entry.SourceUrl)),
					SqlHelper.MakeInParam("@PostType",SqlDbType.Int,4,entry.PostType),
					SqlHelper.MakeInParam("@Author",SqlDbType.NVarChar,50,DataHelper.CheckNull(entry.Author)),
					SqlHelper.MakeInParam("@Email",SqlDbType.NVarChar,50,DataHelper.CheckNull(entry.Email)),
					SqlHelper.MakeInParam("@Description",SqlDbType.NVarChar,500,DataHelper.CheckNull(entry.Description)),
					SqlHelper.MakeInParam("@SourceName",SqlDbType.NVarChar,200,DataHelper.CheckNull(entry.SourceName)),
					SqlHelper.MakeInParam("@DateAdded",SqlDbType.DateTime,8,entry.DateCreated),
					SqlHelper.MakeInParam("@PostConfig",SqlDbType.Int,4,entry.PostConfig),
					SqlHelper.MakeInParam("@ParentID",SqlDbType.Int,4,entry.ParentID),
					SqlHelper.MakeInParam("@EntryName",SqlDbType.NVarChar,150,DataHelper.CheckNull(entry.EntryName)),
					BlogIDParam,
					SqlHelper.MakeOutParam("@ID",SqlDbType.Int,4)
					
				};

					NonQueryInt("blog_InsertPingTrackEntry",p);
					return (int)p[13].Value;
			}
			else
			{
				throw new ArgumentException("PingTracks is the only valid PostType for InsertPingTrackEntry","entry.PostType");
			}

		}


		#endregion

		#region Links

		public IDataReader GetLinkCollectionByPostID(int PostID)
		{
			LinkCollection lc = new LinkCollection();
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@PostID",SqlDbType.Int,4,PostID),
				BlogIDParam
			};
			return GetReader("blog_GetLinkCollectionByPostID",p);
		}

		public IDataReader GetLinkCollectionByPostID(int BlogID,int PostID)
		{
			LinkCollection lc = new LinkCollection();
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@PostID",SqlDbType.Int,4,PostID),
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,BlogID)
			};
			return GetReader("blog_GetLinkCollectionByPostID",p);
		}


		private void DeleteCategoriesByPostID(int postID, SqlConnection conn)
		{
			SqlHelper.ExecuteNonQuery(conn,CommandType.StoredProcedure,"blog_DeleteLinksByPostID",SqlHelper.MakeInParam("@PostID",SqlDbType.Int,4,postID),BlogIDParam);
		}
		
		public bool AddEntryToCategories(int PostID, LinkCollection lc)
		{
			int count = 0;
			if(lc != null)
			{
				count = lc.Count;
			}
			SqlConnection conn = new SqlConnection(ConnectionString);
			conn.Open();

			//
			//DeleteCategoriesByPostID(PostID,conn);
			//we should use the iter_charlist_to_table function instead
			if(count > 0)
			{
				string sql = "blog_InsertLink";
				for(int i = 0; i< count; i++)
				{
					Link link = lc[i];
					SqlParameter[] p = 
					{
						SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,150,DataHelper.CheckNull(link.Title)),
						SqlHelper.MakeInParam("@Url",SqlDbType.NVarChar,255,DataHelper.CheckNull(link.Url)),
						SqlHelper.MakeInParam("@Rss",SqlDbType.NVarChar,255,DataHelper.CheckNull(link.Rss)),
						SqlHelper.MakeInParam("@Active",SqlDbType.Bit,1,link.IsActive),
						SqlHelper.MakeInParam("@NewWindow",SqlDbType.Bit,1,link.NewWindow),
						SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,link.CategoryID),
						SqlHelper.MakeInParam("@PostID",SqlDbType.Int,4,link.PostID),
						BlogIDParam,
						SqlHelper.MakeOutParam("@LinkID",SqlDbType.Int,4)
					};
					return NonQueryBool(sql,p);
				}
               }
			conn.Close();
			return false;
		}

		public bool DeleteLink(int LinkID)
		{
			
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@LinkID",SqlDbType.Int,4,LinkID),
				BlogIDParam
			};
			return NonQueryBool("blog_DeleteLink",p);

		}

		public IDataReader GetSingleLink(int linkID)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@LinkID",SqlDbType.Int,4,linkID),
				BlogIDParam
			};
			return GetReader("blog_GetSingleLink",p);
		}

		public int InsertLink(Link link)
		{
			SqlParameter myBlogIDParam;
			if(link.BlogID==-2)
			{
				myBlogIDParam=BlogIDParam;
			}
			else
			{
				myBlogIDParam=SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,link.BlogID);
			}
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,150,link.Title),
				SqlHelper.MakeInParam("@Url",SqlDbType.NVarChar,255,link.Url),
				SqlHelper.MakeInParam("@Rss",SqlDbType.NVarChar,255,DataHelper.CheckNull(link.Rss)),
				SqlHelper.MakeInParam("@Active",SqlDbType.Bit,1,link.IsActive),
				SqlHelper.MakeInParam("@NewWindow",SqlDbType.Bit,1,link.NewWindow),
				SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,link.CategoryID),
				SqlHelper.MakeInParam("@PostID",SqlDbType.Int,4,link.PostID),
				myBlogIDParam,
				SqlHelper.MakeOutParam("@LinkID",SqlDbType.Int,4)
			};
			NonQueryInt("blog_InsertLink",p);
			return (int)p[8].Value;

		}

		public bool UpdateLink(Link link)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,150,link.Title),
				SqlHelper.MakeInParam("@Url",SqlDbType.NVarChar,255,link.Url),
				SqlHelper.MakeInParam("@Rss",SqlDbType.NVarChar,255,DataHelper.CheckNull(link.Rss)),
				SqlHelper.MakeInParam("@Active",SqlDbType.Bit,1,link.IsActive),
				SqlHelper.MakeInParam("@NewWindow",SqlDbType.Bit,1,link.NewWindow),
				SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,link.CategoryID),
				SqlHelper.MakeInParam("@LinkID",SqlDbType.Int,4,link.LinkID),
				BlogIDParam
			};
			return NonQueryBool("blog_UpdateLink",p);
		}


		public DataSet GetCategoriesWithLinks(bool IsActive)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@IsActive",SqlDbType.Bit,1,IsActive),
				BlogIDParam
			};
			DataSet ds = SqlHelper.ExecuteDataset(ConnectionString,CommandType.StoredProcedure,"blog_CategoriesWithLinks",p);

			DataRelation dl = new DataRelation("CategoryID",ds.Tables[0].Columns["CategoryID"],ds.Tables[1].Columns["CategoryID"],false);
			ds.Relations.Add(dl);

			return ds;
		}

		public IDataReader GetLinksByCategoryID(int catID, bool IsActive)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4 ,catID),
				SqlHelper.MakeInParam("@IsActive",SqlDbType.Bit,1,IsActive),
				BlogIDParam
			};
			return GetReader("blog_GetLinksByCategoryID",p);
		}

		#endregion

		#region Categories


		public bool DeleteCategory(int CatID)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,CatID),
				BlogIDParam
			};
			return NonQueryBool("blog_DeleteCategory",p);

		}

		public bool DeleteCategory(int CatID,int BlogID)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,CatID),
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,BlogID)
			};
			return NonQueryBool("blog_DeleteCategory",p);

		}

		//maps to blog_GetCategory
		public IDataReader GetLinkCategory(int catID, string categoryName, bool IsActive)
		{
			
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,NullCheck(catID>0,catID)),
				SqlHelper.MakeInParam("@CategoryName",SqlDbType.NVarChar,150,NullCheck(categoryName != null,categoryName)),
				SqlHelper.MakeInParam("@IsActive",SqlDbType.Bit,1,IsActive),
				BlogIDParam
			};
			return GetReader("blog_GetCategory",p);
		}

		public IDataReader GetLinkCategory(int catID, string categoryName, bool IsActive,int BlogID)
		{
			
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,NullCheck(catID>0,catID)),
				SqlHelper.MakeInParam("@CategoryName",SqlDbType.NVarChar,150,NullCheck(categoryName != null,categoryName)),
				SqlHelper.MakeInParam("@IsActive",SqlDbType.Bit,1,IsActive),
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,BlogID)
			};
			return GetReader("blog_GetCategory",p);
		}
		
		public IDataReader GetCategoriesByType(CategoryType catType, bool ActiveOnly)
		{
			
			SqlParameter[] p ={SqlHelper.MakeInParam("@CategoryType",SqlDbType.TinyInt,1,catType),
								  SqlHelper.MakeInParam("@IsActive",SqlDbType.Bit,1,ActiveOnly),
								  BlogIDParam};
			return GetReader("blog_GetCategoriesByType",p);
		}

		public IDataReader GetCategoriesByParentID(CategoryType catType, int ParentID, bool ActiveOnly)
		{
			
			SqlParameter[] p ={
								  SqlHelper.MakeInParam("@CategoryType",SqlDbType.TinyInt,1,catType),
								  SqlHelper.MakeInParam("@IsActive",SqlDbType.Bit,1,ActiveOnly),
								  SqlHelper.MakeInParam("@ParentID",SqlDbType.Int,4,ParentID)
							  };							 
			return GetReader("blog_GetCategoriesByType",p);
		}

		public IDataReader GetCategoriesByType(int BlogID,CategoryType catType, bool ActiveOnly)
		{
			
			SqlParameter[] p ={SqlHelper.MakeInParam("@CategoryType",SqlDbType.TinyInt,1,catType),
								  SqlHelper.MakeInParam("@IsActive",SqlDbType.Bit,1,ActiveOnly),
								  SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,BlogID)};
			return GetReader("blog_GetCategoriesByType",p);
		}

//		public IDataReader GetLinkCategory(string categoryName, bool IsActive)
//		{
//			SqlParameter[] p = 
//			{
//				SqlHelper.MakeInParam("@CategoryName",SqlDbType.NVarChar,150,categoryName),
//				SqlHelper.MakeInParam("@IsActive",SqlDbType.Bit,1,IsActive),
//				BlogIDParam
//			};
//			return GetReader("blog_GetCategoryByName",p);
//		}

		public bool UpdateCategory(LinkCategory lc)
		{
			SqlParameter myBlogIDParam;
			if(lc.BlogID==-2)
			{
				myBlogIDParam=BlogIDParam;
				//throw new ApplicationException("BlogID is null");
			}
			else
			{
				myBlogIDParam=SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,lc.BlogID);
			}
			
			SqlParameter[] p =
			{

				SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,150,lc.Title),
				SqlHelper.MakeInParam("@Active",SqlDbType.Bit,1,lc.IsActive),
				SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,lc.CategoryID),
				SqlHelper.MakeInParam("@CategoryType",SqlDbType.TinyInt,1,lc.CategoryType),
				SqlHelper.MakeInParam("@Description",SqlDbType.NVarChar,1000,DataHelper.CheckNull(lc.Description)),
				myBlogIDParam
			};
			return NonQueryBool("blog_UpdateCategory",p);
		}

		//maps to blog_LinkCategory
		public int InsertCategory(LinkCategory lc)
		{
			SqlParameter myBlogIDParam;
			if(lc.BlogID==-2)
			{
				myBlogIDParam=BlogIDParam;
				//throw new ApplicationException("BlogID is null");
			}
			else
			{
				myBlogIDParam=SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,lc.BlogID);
			}
			SqlParameter[] p =
			{

				SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,150,lc.Title),
				SqlHelper.MakeInParam("@Active",SqlDbType.Bit,1,lc.IsActive),
				SqlHelper.MakeInParam("@CategoryType",SqlDbType.TinyInt,1,lc.CategoryType),
				SqlHelper.MakeInParam("@Description",SqlDbType.NVarChar,1000,DataHelper.CheckNull(lc.Description)),
				myBlogIDParam,
				SqlHelper.MakeInParam("@ParentID",SqlDbType.Int,4,lc.ParentID),
				SqlHelper.MakeOutParam("@CategoryID",SqlDbType.Int,4)
			};
			NonQueryInt("blog_InsertCategory",p);
			return (int)p[5].Value;
		}

		#endregion

		#region FeedBack

		//we could pass ParentID with the rest of the sprocs
		//one interface for entry data?
		public IDataReader GetFeedBack(int PostID)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@ParentID",SqlDbType.Int,4,PostID),
				BlogIDParam
			};
			return GetReader("blog_GetFeedBack",p);
		}

		#endregion

		#region Configuration

		public IDataReader GetConfig(string host, string application)
		{
					
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@Host",SqlDbType.NVarChar,100,host),
				SqlHelper.MakeInParam("@Application",SqlDbType.NVarChar,50,application)
			};
			return GetReader("blog_GetConfig",p);
		}

		public IDataReader GetConfigByApp(string app)
		{
					
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@Application",SqlDbType.NVarChar,50,app)
			};
			return GetReader("blog_GetConfigByApp",p);
		}

		
		public IDataReader GetConfig(int BlogID)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,BlogID)
			};
			return GetReader("blog_GetConfigByBlogID",p);
		}

		public IDataReader GetConfigByRoleID(int RoleID)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@RoleID",SqlDbType.Int,4,RoleID)
			};
			return GetReader("blog_GetConfigByRoleID",p);
		}
		
		public IDataReader GetBlogGroup(int BlogID)
		{
			
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,BlogID)
			};
			return GetReader("blog_GetBlogGroupByBlogID",p);
		}

		public IDataReader GetConfig(string UserName)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@UserName",SqlDbType.NVarChar,50,UserName)
			};
			return GetReader("blog_GetConfigByUserName",p);
		}


		public bool UpdateConfigData(BlogConfig config)
		{
				
			SqlParameter[] p = 
					{
						SqlHelper.MakeInParam("@UserName",SqlDbType.NVarChar,50,config.UserName),
						SqlHelper.MakeInParam("@Password",SqlDbType.NVarChar,50,config.Password),
						SqlHelper.MakeInParam("@Author",SqlDbType.NVarChar,100,config.Author),
						SqlHelper.MakeInParam("@Email",SqlDbType.NVarChar,50,config.Email),
						SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,100,config.Title),
						SqlHelper.MakeInParam("@SubTitle",SqlDbType.NVarChar,250,config.SubTitle),
						SqlHelper.MakeInParam("@Skin",SqlDbType.NVarChar,50,config.Skin.SkinName),
						SqlHelper.MakeInParam("@Application",SqlDbType.NVarChar,50,config.CleanApplication),
						SqlHelper.MakeInParam("@Host",SqlDbType.NVarChar,100,config.Host),
						SqlHelper.MakeInParam("@TimeZone",SqlDbType.Int,4,config.TimeZone),
						SqlHelper.MakeInParam("@Language",SqlDbType.NVarChar,10,config.Language),
						SqlHelper.MakeInParam("@News",SqlDbType.Text,0,DataHelper.CheckNull(config.News)),
						SqlHelper.MakeInParam("@ItemCount",SqlDbType.Int, 4,config.ItemCount),
						SqlHelper.MakeInParam("@Flag",SqlDbType.Int, 4,(int)config.Flag),
						SqlHelper.MakeInParam("@LastUpdated",SqlDbType.DateTime, 8,config.LastUpdated),
						SqlHelper.MakeInParam("@SecondaryCss",SqlDbType.Text,0,DataHelper.CheckNull(config.Skin.SkinCssText)),
						SqlHelper.MakeInParam("@SkinCssFile",SqlDbType.VarChar,100,DataHelper.CheckNull(config.Skin.SkinCssFile)),
						SqlHelper.MakeInParam("@BlogID",SqlDbType.Int, 4,config.BlogID),
						SqlHelper.MakeInParam("@NotifyMail",SqlDbType.NVarChar,50,config.NotifyMail),
						SqlHelper.MakeInParam("@IsMailNotify",SqlDbType.Bit, 1,config.IsMailNotify),
						SqlHelper.MakeInParam("@IsOnlyListTitle",SqlDbType.Bit, 1,config.IsOnlyListTitle)
					};


			return NonQueryBool("blog_UpdateConfig",p);

		}

		public IDataReader GetSkinControlCollection(int BlogID)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,BlogID)
			};
			return GetReader("blog_GetSkinControlByBlogID",p);

		}

		public bool UpateSkinControl(SkinControl sc)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@ControlID",SqlDbType.Int,4,sc.ID),
				SqlHelper.MakeInParam("@Visible",SqlDbType.Bit,1,sc.Visible),
				BlogIDParam

			};
			return NonQueryBool("blog_UpdateSkinControl",p);
		}

		public bool UpdateSingleSkinControl(int ControlID,bool visible,int BlogID)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@ControlID",SqlDbType.Int,4,ControlID),
				SqlHelper.MakeInParam("@Visible",SqlDbType.Bit,1,visible),
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,BlogID)

			};
			return NonQueryBool("blog_UpdateSkinControl",p);
		}

		#endregion

		#region Archives

		public IDataReader GetPostsByMonthArchive(PostType postType)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@PostType",SqlDbType.Int,4,postType),
				BlogIDParam
			};
			return GetReader("blog_GetPostsByMonthArchive",p);
		}

		public IDataReader GetPostsByYearArchive(PostType postType)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@PostType",SqlDbType.Int,4,postType),
				BlogIDParam
			};
			return GetReader("blog_GetPostsByYearArchive",p);
		}

		#endregion

		#region KeyWords

		public IDataReader GetKeyWord(int KeyWordID)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@KeyWordID",SqlDbType.Int,4,KeyWordID),
				BlogIDParam
			};
			return GetReader("blog_GetKeyWord",p);
		}

		public bool DeleteKeyWord(int KeyWordID)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@KeyWordID",SqlDbType.Int,4,KeyWordID),
				BlogIDParam
			};
			return NonQueryBool("blog_DeleteKeyWord",p);
		}



		public int InsertKeyWord(KeyWord kw)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@Word",SqlDbType.NVarChar,100,kw.Word),
				SqlHelper.MakeInParam("@Text",SqlDbType.NVarChar,100,kw.Text),
				SqlHelper.MakeInParam("@ReplaceFirstTimeOnly",SqlDbType.Bit,1,kw.ReplaceFirstTimeOnly),
				SqlHelper.MakeInParam("@OpenInNewWindow",SqlDbType.Bit,1,kw.OpenInNewWindow),
				SqlHelper.MakeInParam("@CaseSensitive",SqlDbType.Bit,1,kw.CaseSensitive),
				SqlHelper.MakeInParam("@Url",SqlDbType.NVarChar,255,kw.Url),
				SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,100,kw.Title),
				BlogIDParam,
				SqlHelper.MakeOutParam("@KeyWordID",SqlDbType.Int,4)
			};
			NonQueryInt("blog_InsertKeyWord",p);
			return (int)p[8].Value;
		}

		public bool UpdateKeyWord(KeyWord kw)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@KeyWordID",SqlDbType.Int,4,kw.KeyWordID),
				SqlHelper.MakeInParam("@Word",SqlDbType.NVarChar,100,kw.Word),
				SqlHelper.MakeInParam("@Text",SqlDbType.NVarChar,100,kw.Text),
				SqlHelper.MakeInParam("@ReplaceFirstTimeOnly",SqlDbType.Bit,1,kw.ReplaceFirstTimeOnly),
				SqlHelper.MakeInParam("@OpenInNewWindow",SqlDbType.Bit,1,kw.OpenInNewWindow),
				SqlHelper.MakeInParam("@CaseSensitive",SqlDbType.Bit,1,kw.CaseSensitive),
				SqlHelper.MakeInParam("@Url",SqlDbType.NVarChar,255,kw.Url),
				SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,100,kw.Title),
				BlogIDParam
			};
			return NonQueryBool("blog_UpdateKeyWord",p);
		}



		public IDataReader GetKeyWords()
		{
			SqlParameter[] p =
			{
				BlogIDParam
			};
			return GetReader("blog_GetKeyWords",p);
		}

		public IDataReader GetPagedKeyWords(int pageIndex, int pageSize,bool sortDescending)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@PageIndex", SqlDbType.Int, 4, pageIndex),
				SqlHelper.MakeInParam("@PageSize", SqlDbType.Int, 4, pageSize),
				SqlHelper.MakeInParam("@SortDesc", SqlDbType.Bit, 1, sortDescending),
				BlogIDParam
			};
			return GetReader("blog_GetPageableKeyWords",p);
		}


		#endregion

		#region ScheduledEvents

		public DateTime GetLastExecuteScheduledEventDateTime(string key, string serverName)
		{
			SqlParameter[] p = new SqlParameter[3];
			p[0] = SqlHelper.MakeInParam("@Key",SqlDbType.VarChar,100,key);
			p[1] = SqlHelper.MakeInParam("@ServerName",SqlDbType.VarChar,100,serverName);
			p[2] = SqlHelper.MakeOutParam("@LastExecuted",SqlDbType.DateTime,8);
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.StoredProcedure,"blog_GetLastExecuteScheduledEventDateTime",p);
			return (DateTime)p[2].Value;
		}

		public void SetLastExecuteScheduledEventDateTime(string key, string serverName, DateTime dt)
		{
			SqlParameter[] p = new SqlParameter[3];
			p[0] = SqlHelper.MakeInParam("@Key",SqlDbType.VarChar,100,key);
			p[1] = SqlHelper.MakeInParam("@ServerName",SqlDbType.VarChar,100,serverName);
			p[2] = SqlHelper.MakeInParam("@LastExecuted",SqlDbType.DateTime,8,dt);
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.StoredProcedure,"blog_SetLastExecuteScheduledEventDateTime",p);
		}

		#endregion

		#region Helpers

		private DataSet GetDataSet(string sql, SqlParameter[] p)
		{
			return SqlHelper.ExecuteDataset(ConnectionString,CommandType.StoredProcedure,sql,p);
		}

		private IDataReader GetReader(string sql, SqlParameter[] p)
		{
			return SqlHelper.ExecuteReader(ConnectionString,CommandType.StoredProcedure,sql,p);
		}

		private int NonQueryInt(string sql, SqlParameter[] p)
		{
			return SqlHelper.ExecuteNonQuery(ConnectionString,CommandType.StoredProcedure,sql,p);
		}

		private bool NonQueryBool(string sql, SqlParameter[] p)
		{
			return NonQueryInt(sql,p) > 0;
		}

		#endregion

		#region Logger

		public int CreateLog(Log blogLog)
		{
			SqlParameter[] p =
			{
				SqlHelper.MakeInParam("@Title",SqlDbType.VarChar,100,blogLog.Title),
				SqlHelper.MakeInParam("@Message",SqlDbType.VarChar,8000,blogLog.Message),
				SqlHelper.MakeInParam("@UserName",SqlDbType.VarChar,100,DataHelper.CheckNull(blogLog.UserName)),
				SqlHelper.MakeInParam("@Url",SqlDbType.VarChar,100,DataHelper.CheckNull(blogLog.Url)),
				SqlHelper.MakeInParam("@ServerName",SqlDbType.VarChar,100,blogLog.ServerName),
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,blogLog.BlogID),
				SqlHelper.MakeInParam("@StartDate",SqlDbType.DateTime,8,blogLog.StartDate),
				SqlHelper.MakeInParam("@EndDate",SqlDbType.DateTime,8,blogLog.EndDate),
				SqlHelper.MakeOutParam("@LogID",SqlDbType.Int,4)
			};

			NonQueryBool("blog_InsertLog",p);
			return (int)p[8].Value;
		}

		#endregion

		#region Rate
		public int InsertRate(EntryRate er)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@EntryID",SqlDbType.Int,4,er.EntryID),
				BlogIDParam,
				SqlHelper.MakeInParam("@ClientID",SqlDbType.NVarChar,50,er.ClientID),
				SqlHelper.MakeInParam("@Score",SqlDbType.TinyInt,1,er.Score),
				SqlHelper.MakeOutParam("@ID",SqlDbType.Int,4)
			};
			NonQueryInt("blog_InsertRate",p);
			return (int)p[3].Value;
		}

		public IDataReader GetRatePeople(int entryID,int score)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@EntryID",SqlDbType.Int,4,entryID),
				SqlHelper.MakeInParam("@Score",SqlDbType.TinyInt,1,score),

			};
			return GetReader("blog_GetRatePeople",p);
		}
		#endregion

		#region Security
		public IDataReader GetRoles(int BlogID)
		{
			SqlParameter[] p=
				{
					SqlHelper.MakeInParam("@UserID",SqlDbType.Int,4,BlogID)
				};
			return GetReader("blog_Roles_Get",p);
		}


		public bool AddUserToRole(int BlogID,int RoleID)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@UserID",SqlDbType.Int,4,BlogID),
				SqlHelper.MakeInParam("@RoleID",SqlDbType.Int,4,RoleID)
				
			};
			return NonQueryBool("blog_Role_AddUser",p);
			}

		public bool RemoveUserFromRole(int BlogID,int RoleID)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@UserID",SqlDbType.Int,4,BlogID),
				SqlHelper.MakeInParam("@RoleID",SqlDbType.Int,4,RoleID)
				
			};
			return NonQueryBool("blog_Role_RemoveUser",p);
		}
		#endregion

		#region MailNotify

		public IDataReader GetNotifyMailList(int EntryID)
		{
			SqlParameter [] p =
			{
				SqlHelper.MakeInParam("@EntryID",SqlDbType.Int,4,EntryID)
			};
			return GetReader("blog_MailNotify_GetMailList",p);
		}
		public bool InsertNotifySubscibe(int EntryID,int BlogID,int SendToBlogID,string EMail)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@EntryID",SqlDbType.Int,4,EntryID),
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,BlogID),
				SqlHelper.MakeInParam("@SendToBlogID",SqlDbType.Int,4,SendToBlogID),
				SqlHelper.MakeInParam("@EMail",SqlDbType.NVarChar,150,EMail)
			};
			return NonQueryBool("blog_MailNotify_Insert",p);
		}

		public bool DeleteMailNotify(int EntryID,int SendToBlogID)
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@EntryID",SqlDbType.Int,4,EntryID),
				SqlHelper.MakeInParam("@SendToBlogID",SqlDbType.Int,4,SendToBlogID)				
			};
			return NonQueryBool("blog_MailNotify_Delete",p);
		}

		#endregion

	}
}

