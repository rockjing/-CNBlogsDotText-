#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// 
// .Text is an open source weblog system started by Scott Watermasysk. 
// Blog: http://ScottWater.com/blog 
// RSS: http://scottwater.com/blog/rss.aspx
// Email: Dottext@ScottWater.com
//
// For updated news and information please visit http://scottwater.com/dottext and subscribe to 
// the Rss feed @ http://scottwater.com/dottext/rss.aspx
//
// On its release (on or about August 1, 2003) this application is licensed under the BSD. However, I reserve the 
// right to change or modify this at any time. The most recent and up to date license can always be fount at:
// http://ScottWater.com/License.txt
// 
// Please direct all code related questions to:
// GotDotNet Workspace: http://www.gotdotnet.com/Community/Workspaces/workspace.aspx?id=e99fccb3-1a8c-42b5-90ee-348f6b77c407
// Yahoo Group http://groups.yahoo.com/group/DotText/
// 
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Data;
using System.Globalization;
using Dottext.Framework.Components;
using Dottext.Framework.Util;
using Dottext.Framework.Configuration;
using System.Text.RegularExpressions;

//Need to remove Global.X calls ...just seems unclean
//Maybe create a another class formatter ...Format.Entry(ref Entry entry) 
//or, Instead of Globals.PostUrl(int id) --> Globals.PostUrl(ref Entry entry)
//...

namespace Dottext.Framework.Data
{
	/// <summary>
	/// Summary description for DataHelper.
	/// </summary>
	public class DataHelper
	{
		public DataHelper()
		{
		}

		#region Service Formattings
//		public static void FormatDataSet(ref DataSet ds)
//		{
//			if(ds != null && ds.Tables[0] != null)
//			{
//				int offset = BlogTime.ServerToClientTimeZoneFactor;
//				DataColumn dc = new DataColumn("Link",typeof(System.String));
//				ds.Tables[0].Columns.Add(dc);
//
//				int count = ds.Tables[0].Rows.Count;
//				for(int i = 0; i<count; i++)
//				{
//					switch((PostType)ds.Tables[0].Rows[i]["PostType"])
//					{
//						case PostType.BlogPost:
//						case PostType.Story:
//							ds.Tables[0].Rows[i]["Link"] = Config.CurrentBlog().UrlFormats.PostUrl( Globals.PostsUrl((int)ds.Tables[0].Rows[i]["ID"]);
//							break;
//						case PostType.Comment:
//						case PostType.PingTrack:
//							ds.Tables[0].Rows[i]["Link"] = Globals.PostsUrl((int)ds.Tables[0].Rows[i]["ParentID"]) + "#" + ds.Tables[0].Rows[i]["ID"].ToString();
//							break;
//					}
//					ds.Tables[0].Rows[i]["dateadded"] = ((DateTime)ds.Tables[0].Rows[i]["dateadded"]).AddHours(offset);
//					ds.Tables[0].Rows[i]["DateUpdated"] = ((DateTime)ds.Tables[0].Rows[i]["DateUpdated"]).AddHours(offset);
//				}
//			}
//		}
		#endregion

		#region Statisitics

		public static ViewStat LoadSingleViewStat(IDataReader reader)
		{
			ViewStat vStat = new ViewStat();


			if (reader["Title"] != DBNull.Value)
			{
				vStat.PageTitle = (string) reader["Title"];
			}

			if (reader["Count"] != DBNull.Value)
			{
				vStat.ViewCount = (int) reader["Count"];
			}

			if (reader["Day"] != DBNull.Value)
			{
				vStat.ViewDate = (DateTime) reader["Day"];
			}

			if (reader["PageType"] != DBNull.Value)
			{
				vStat.PageType = (PageType)((byte)reader["PageType"]);
			}

            return vStat;
		}

		public static Referrer LoadSingleReferrer(IDataReader reader)
		{
			Referrer refer = new Referrer();


			if (reader["URL"] != DBNull.Value)
			{
				refer.ReferrerURL = (string) reader["URL"];
			}

			if (reader["Title"] != DBNull.Value)
			{
				refer.PostTitle = (string) reader["Title"];
			}

			if (reader["EntryID"] != DBNull.Value)
			{
				refer.EntryID = (int) reader["EntryID"];
			}

			if (reader["LastUpdated"] != DBNull.Value)
			{
				refer.LastReferDate = (DateTime) reader["LastUpdated"];
			}

			if (reader["Count"] != DBNull.Value)
			{
				refer.Count = (int) reader["Count"];
			}

			return refer;
		}

		#endregion

		#region EntryDayCollection

		private static bool IsNewDay(DateTime dtCurrent, DateTime dtDay)
		{
			return !(dtCurrent.DayOfYear == dtDay.DayOfYear && dtCurrent.Year == dtDay.Year);
		}

		public static EntryDayCollection LoadEntryDayCollection(IDataReader reader)
		{
			DateTime dt = new DateTime(1900,1,1);
			EntryDayCollection edc = new EntryDayCollection();
			EntryDay day = null;

			while(reader.Read())
			{
				if(IsNewDay(dt,(DateTime)reader["DateAdded"]))
				{
					dt = (DateTime)reader["DateAdded"];
					day = new EntryDay(dt);
					edc.Add(day);
				}
				day.Add(DataHelper.LoadSingleEntry(reader));
			}
			return edc;

		}


		#endregion

		#region EntryCollection

		public static EntryCollection LoadEntryCollection(IDataReader reader)
		{
			EntryCollection ec = new EntryCollection();
			while(reader.Read())
			{
				//ec.Add(LoadSingleEntryStatsView(reader));//Add by dudu at 2004-10-04
				ec.Add(LoadSingleEntry(reader));
			}
			return ec;	
		}

		#endregion

		#region Single Entry
		//Crappy. Need to clean up all of the entry references
		public static EntryStatsView LoadSingleEntryStatsView(IDataReader reader)
		{
			EntryStatsView entry = new EntryStatsView();

			entry.PostType = ((PostType)(int)reader["PostType"]);
			if(reader["BlogID"] != DBNull.Value)
			{
				entry.BlogID = (int)reader["BlogID"];	
			}

			if(reader["WebCount"] != DBNull.Value)
			{
				entry.WebCount = (int)reader["WebCount"];	
			}

			if(reader["AggCount"] != DBNull.Value)
			{
				entry.AggCount = (int)reader["AggCount"];	
			}

			if(reader["WebLastUpdated"] != DBNull.Value)
			{
				entry.WebLastUpdated = (DateTime)reader["WebLastUpdated"];	
			}
			
			if(reader["AggLastUpdated"] != DBNull.Value)
			{
				entry.AggLastUpdated = (DateTime)reader["AggLastUpdated"];	
			}

			if(reader["Author"] != DBNull.Value)
			{
				entry.Author = (string)reader["Author"];
			}
			if(reader["Email"] != DBNull.Value)
			{
				entry.Email = (string)reader["Email"];
			}
			entry.DateCreated = (DateTime)reader["DateAdded"];
			entry.DateUpdated = (DateTime)reader["DateUpdated"];

			entry.EntryID = (int)reader["ID"];

			if(reader["TitleUrl"] != DBNull.Value)
			{
				entry.TitleUrl = (string)reader["TitleUrl"];
			}
			
			if(reader["SourceName"] != DBNull.Value)
			{
				entry.SourceName = (string)reader["SourceName"];
			}
			if(reader["SourceUrl"] != DBNull.Value)
			{
				entry.SourceUrl = (string)reader["SourceUrl"];
			}

			if(reader["Description"] != DBNull.Value)
			{
				entry.Description = (string)reader["Description"];
			}

			if(reader["EntryName"] != DBNull.Value)
			{
				entry.EntryName = (string)reader["EntryName"];
			}

			entry.FeedBackCount = (int)reader["FeedBackCount"];
			if(reader["Text"]!=DBNull.Value)
			{
				entry.Body = (string)reader["Text"];
			}
			else
			{
				entry.Body="";
			}
			entry.Title =(string)reader["Title"];

			entry.PostConfig = (PostConfig)((int)reader["PostConfig"]);

			entry.ParentID = (int)reader["ParentID"];

			SetUrlPattern(entry);
			BlogConfig config=Config.CurrentBlog();
			if(Config.CurrentBlog() is SiteBlogConfig && reader["Application"] != DBNull.Value)
			{
				string url=config.FullyQualifiedUrl;
				//string url=Util.Globals.GetSiteQualifiedUrl();
				if(!url.EndsWith("/"))
				{
					url+="/";
				}
				
				entry.Link=Regex.Replace(entry.Link,url,url+reader["Application"]+"/");
			}
			
			return entry;
		}

		public static EntryStatsView LoadSingleEntryView(IDataReader reader)
		{
			EntryStatsView entry = new EntryStatsView();

			if(reader["WebCount"] != DBNull.Value)
			{
				entry.WebCount = (int)reader["WebCount"];	
			}
			

			if(reader["AggCount"] != DBNull.Value)
			{
				entry.AggCount = (int)reader["AggCount"];	
			}

			if(reader["WebLastUpdated"] != DBNull.Value)
			{
				entry.WebLastUpdated = (DateTime)reader["WebLastUpdated"];	
			}
			
			if(reader["AggLastUpdated"] != DBNull.Value)
			{
				entry.AggLastUpdated = (DateTime)reader["AggLastUpdated"];	
			}

			return entry;
		}


		private static void LoadSingleEntry(ref Entry entry, IDataReader reader)
		{
			entry= LoadSingleEntry(reader,true);
		}

		public static Entry LoadSingleEntry(IDataReader reader)
		{
			return LoadSingleEntry(reader,true);
		}

		public static Entry LoadSingleEntry(IDataReader reader, bool BuildLinnks)
		{
			Entry entry = new Entry((PostType)(int)reader["PostType"]);
			
			if(reader["BlogID"] != DBNull.Value)
			{
				entry.BlogID = (int)reader["BlogID"];
			}
			
			if(reader["Author"] != DBNull.Value)
			{
				entry.Author = (string)reader["Author"];
			}
			if(reader["Email"] != DBNull.Value)
			{
				entry.Email = (string)reader["Email"];
			}
			entry.DateCreated = (DateTime)reader["DateAdded"];
			entry.DateUpdated = (DateTime)reader["DateUpdated"];

			entry.EntryID = (int)reader["ID"];

			if(reader["TitleUrl"] != DBNull.Value)
			{
				entry.TitleUrl = (string)reader["TitleUrl"];
			}
			
			if(reader["SourceName"] != DBNull.Value)
			{
				entry.SourceName = (string)reader["SourceName"];
			}
			if(reader["SourceUrl"] != DBNull.Value)
			{
				entry.SourceUrl = (string)reader["SourceUrl"];
			}

			if(reader["Description"] != DBNull.Value)
			{
				entry.Description = (string)reader["Description"];
			}

			if(reader["EntryName"] != DBNull.Value)
			{
				entry.EntryName = (string)reader["EntryName"];
			}

			entry.FeedBackCount = (int)reader["FeedBackCount"];
			if(reader["Text"]!=DBNull.Value)
			{
				entry.Body = (string)reader["Text"];
			}
			else
			{
				entry.Body="";
			}
			entry.Title =(string)reader["Title"];

			entry.PostConfig = (PostConfig)((int)reader["PostConfig"]);

			entry.ParentID = (int)reader["ParentID"];

			if(reader["WebCount"] != DBNull.Value)
			{
				entry.WebCount = (int)reader["WebCount"];	
			}

			if(reader["AggCount"] != DBNull.Value)
			{
				entry.AggCount = (int)reader["AggCount"];	
			}

			if(BuildLinnks)
			{
				SetUrlPattern(entry);
				
				if(Config.CurrentBlog().BlogID<0 && reader["Application"] != DBNull.Value)
				{
					BlogConfig config=Config.CurrentBlog();
					string url=config.FullyQualifiedUrl;
					if(!url.EndsWith("/"))
					{
						url+="/";
					}
				
					entry.Link=Regex.Replace(entry.Link,url,url+reader["Application"]+"/");
				}
			}

			return entry;
		}

		private static void SetUrlPattern(Entry entry)
		{
			switch(entry.PostType)
			{
				case PostType.BlogPost:
					entry.Link = Config.CurrentBlog().UrlFormats.EntryUrl(entry);
					break;
				case PostType.Article:
					entry.Link = Config.CurrentBlog().UrlFormats.ArticleUrl(entry);
					break;
				case PostType.Message:
					entry.Link = Config.CurrentBlog().UrlFormats.MessageUrl(entry);
					break;

				case PostType.Comment:
				case PostType.PingTrack:
					entry.Link = Config.CurrentBlog().UrlFormats.CommentUrl(entry);
					break;
			}
			
		}



		public static Entry LoadSingleEntry(DataRow dr)
		{
			Entry entry = new Entry((PostType)(int)dr["PostType"]);

			if(dr["Author"] != DBNull.Value)
			{
				entry.Author = (string)dr["Author"];
			}
			if(dr["Email"] != DBNull.Value)
			{
				entry.Email = (string)dr["Email"];
			}

			
			entry.DateCreated = (DateTime)dr["DateAdded"];
			entry.DateUpdated = (DateTime)dr["DateUpdated"];
			entry.EntryID = (int)dr["ID"];

			if(dr["TitleUrl"] != DBNull.Value)
			{
				entry.TitleUrl = (string)dr["TitleUrl"];
			}
			
			if(dr["SourceName"] != DBNull.Value)
			{
				entry.SourceName = (string)dr["SourceName"];
			}
			if(dr["SourceUrl"] != DBNull.Value)
			{
				entry.SourceUrl = (string)dr["SourceUrl"];
			}

			if(dr["Description"] != DBNull.Value)
			{
				entry.Description = (string)dr["Description"];
			}

			if(dr["EntryName"] != DBNull.Value)
			{
				entry.EntryName = (string)dr["EntryName"];
			}

			entry.FeedBackCount = (int)dr["FeedBackCount"];
			entry.Body = (string)dr["Text"];
			entry.Title =(string)dr["Title"];

			entry.PostConfig = (PostConfig)((int)dr["PostConfig"]);

			entry.ParentID = (int)dr["ParentID"];

			if(dr["WebCount"] != DBNull.Value)
			{
				entry.WebCount = (int)dr["WebCount"];	
			}

			if(dr["AggCount"] != DBNull.Value)
			{
				entry.AggCount = (int)dr["AggCount"];	
			}

			SetUrlPattern(entry);
			return entry;
		}

		public static void LoadSingleEntry(ref Entry entry, DataRow dr)
		{
			entry.PostType = ((PostType)(int)dr["PostType"]);

			if(dr["Author"] != DBNull.Value)
			{
				entry.Author = (string)dr["Author"];
			}
			if(dr["Email"] != DBNull.Value)
			{
				entry.Email = (string)dr["Email"];
			}

			
			entry.DateCreated = (DateTime)dr["DateAdded"];
			entry.DateUpdated = (DateTime)dr["DateUpdated"];
			entry.EntryID = (int)dr["ID"];

			if(dr["TitleUrl"] != DBNull.Value)
			{
				entry.TitleUrl = (string)dr["TitleUrl"];
			}
			
			if(dr["SourceName"] != DBNull.Value)
			{
				entry.SourceName = (string)dr["SourceName"];
			}
			if(dr["SourceUrl"] != DBNull.Value)
			{
				entry.SourceUrl = (string)dr["SourceUrl"];
			}

			if(dr["Description"] != DBNull.Value)
			{
				entry.Description = (string)dr["Description"];
			}

			if(dr["EntryName"] != DBNull.Value)
			{
				entry.EntryName = (string)dr["EntryName"];
			}

			entry.FeedBackCount = (int)dr["FeedBackCount"];
			entry.Body = (string)dr["Text"];
			entry.Title =(string)dr["Title"];

			entry.PostConfig = (PostConfig)((int)dr["PostConfig"]);

			entry.ParentID = (int)dr["ParentID"];

			SetUrlPattern(entry);


		}		

		/// <summary>
		/// Returns a single CategoryEntry from a DataReader. Expects the data reader to have
		/// two sets of results. Should only be used to load 1 ENTRY
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static CategoryEntry LoadSingleCategoryEntry(IDataReader reader)
		{
			//This method is quite disgusting. Either clean up the helpers or remove them :)
			CategoryEntry entry = new CategoryEntry();

			if(reader["Author"] != DBNull.Value)
			{
				entry.Author = (string)reader["Author"];
			}
			if(reader["Email"] != DBNull.Value)
			{
				entry.Email = (string)reader["Email"];
			}
			entry.DateCreated = (DateTime)reader["DateAdded"];
			entry.DateUpdated = (DateTime)reader["DateUpdated"];

			entry.EntryID = (int)reader["ID"];

			if(reader["TitleUrl"] != DBNull.Value)
			{
				entry.TitleUrl = (string)reader["TitleUrl"];
			}
			
			if(reader["SourceName"] != DBNull.Value)
			{
				entry.SourceName = (string)reader["SourceName"];
			}
			if(reader["SourceUrl"] != DBNull.Value)
			{
				entry.SourceUrl = (string)reader["SourceUrl"];
			}

			if(reader["Description"] != DBNull.Value)
			{
				entry.Description = (string)reader["Description"];
			}

			if(reader["EntryName"] != DBNull.Value)
			{
				entry.EntryName = (string)reader["EntryName"];
			}

			entry.FeedBackCount = (int)reader["FeedBackCount"];
			entry.Body = (string)reader["Text"];
			entry.Title =(string)reader["Title"];

			entry.PostConfig = (PostConfig)((int)reader["PostConfig"]);

			entry.ParentID = (int)reader["ParentID"];


			SetUrlPattern(entry);
				
			 

			reader.NextResult();

			System.Collections.ArrayList al = new System.Collections.ArrayList();
			while(reader.Read())
			{
				al.Add((string)reader["Title"]);
			}

			if(al.Count > 0)
			{
				entry.Categories = (string[])al.ToArray(typeof(string));
			}

			return entry;
		}


		public static CategoryEntry LoadSingleCategoryEntry(DataRow dr)
		{
			Entry entry = new CategoryEntry();
			LoadSingleEntry(ref entry,dr);
			
 
			DataRow[] child = dr.GetChildRows("cats");
			if(child != null && child.Length > 0)
			{
				int count = child.Length;
				string[] cats = new string[count];
				for(int i=0;i<count;i++)
				{
					cats[i] = (string)child[i]["Title"];
				}
				((CategoryEntry)entry).Categories = cats;	
			}

			return (CategoryEntry)entry;
		}

		public static int GetMaxItems(IDataReader reader)
		{
			reader.Read();
			return (int)reader["TotalRecords"];
		}

		#endregion

		#region Categories

		public static LinkCategory LoadSingleLinkCategory(IDataReader reader)
		{
			LinkCategory lc = new LinkCategory();
			lc.CategoryID = (int)reader["CategoryID"];
			lc.Title = (string)reader["Title"];
			lc.IsActive = (bool)reader["Active"];
			lc.CategoryType = (CategoryType)((byte)reader["CategoryType"]);
			if(reader["ParentID"] != DBNull.Value)
			{
				lc.ParentID = (int)reader["ParentID"];
			}
			if(reader["Description"] != DBNull.Value)
			{
				lc.Description = (string)reader["Description"];
			}
			return lc;
		}

		public static LinkCategory LoadSingleLinkCategory(DataRow dr)
		{
			LinkCategory lc = new LinkCategory();
			lc.CategoryID = (int)dr["CategoryID"];
			lc.Title = (string)dr["Title"];
			lc.IsActive = (bool)dr["Active"];
			lc.CategoryType = (CategoryType)((byte)dr["CategoryType"]);
			if(dr["Description"] != DBNull.Value)
			{
				lc.Description = (string)dr["Description"];
			}
			return lc;
		}

		#endregion

		#region Links

		public static Link LoadSingleLink(IDataReader reader)
		{
			Link link = new Link();
			link.IsActive = (bool)reader["Active"];
			link.NewWindow = (bool)reader["NewWindow"];
			link.LinkID = (int)reader["LinkID"];
			if(reader["Rss"] != DBNull.Value)
			{
				link.Rss = (string)reader["Rss"];
			}
			if(reader["Url"] != DBNull.Value)
			{
				link.Url = (string)reader["Url"];
			}
			if(reader["Title"] != DBNull.Value)
			{
				link.Title = (string)reader["Title"];
			}
			if(reader["UpdateTime"] != DBNull.Value)
			{
				link.UpdateTime = (DateTime)reader["UpdateTime"];
			}
			link.CategoryID = (int)reader["CategoryID"];
			link.PostID = (int)reader["PostID"];
			return link;
		}

		public static Link LoadSingleLink(DataRow dr)
		{
			Link link = new Link();
			link.IsActive = (bool)dr["Active"];
			link.NewWindow = (bool)dr["NewWindow"];
			link.LinkID = (int)dr["LinkID"];
			if(dr["Rss"] != DBNull.Value)
			{
				link.Rss = (string)dr["Rss"];
			}
			if(dr["Url"] != DBNull.Value)
			{
				link.Url = (string)dr["Url"];
			}
			if(dr["Title"] != DBNull.Value)
			{
				link.Title = (string)dr["Title"];
			}
			if(dr["UpdateTime"] != DBNull.Value)
			{
				link.UpdateTime = (DateTime)dr["UpdateTime"];
			}
			link.CategoryID = (int)dr["CategoryID"];
			link.PostID = (int)dr["PostID"];
			return link;
		}

		#endregion

		#region Config

		public static BlogConfig LoadConfigData(IDataReader reader)
		{
			BlogConfig config = new BlogConfig();
			config.Author = (string)reader["Author"];
			config.BlogID = (int)reader["BlogID"];
			config.Email = (string)reader["Email"];
			config.Password = (string)reader["Password"];

			config.SubTitle = (string)reader["SubTitle"];
			config.Title = (string)reader["Title"];
			config.UserName = (string)reader["UserName"];
			config.TimeZone = (int)reader["TimeZone"];
			config.ItemCount = (int)reader["ItemCount"];
			config.Language = (string)reader["Language"];
			

			/*config.PostCount = (int)reader["PostCount"];
			config.CommentCount = (int)reader["CommentCount"];
			config.StoryCount = (int)reader["StoryCount"];
			config.PingTrackCount = (int)reader["PingTrackCount"];*/
			if(reader["PostCount"]!=DBNull.Value)
			{
				config.PostCount = (int)reader["PostCount"];
			}
			if(reader["CommentCount"]!=DBNull.Value)
			{
				config.CommentCount = (int)reader["CommentCount"];
			}
			if(reader["StoryCount"]!=DBNull.Value)
			{
				config.StoryCount = (int)reader["StoryCount"];
			}
			if(reader["PingTrackCount"]!=DBNull.Value)
			{
				config.PingTrackCount = (int)reader["PingTrackCount"];
			}

			if(reader["News"] != DBNull.Value)
			{
				config.News = (string)reader["News"];
			}

			if(reader["LastUpdated"] != DBNull.Value)
			{
				config.LastUpdated = (DateTime)reader["LastUpdated"];
			}
			else
			{
				config.LastUpdated = new DateTime(2003,1,1);
			}
			config.Host = (string)reader["Host"];
			config.Application = (string)reader["Application"];

			config.Flag = (ConfigurationFlag)((int)reader["Flag"]);

			config.Skin = new SkinConfig();
			config.Skin.SkinName = (string)reader["Skin"];

			if(reader["SkinCssFile"] != DBNull.Value)
			{
				config.Skin.SkinCssFile = (string)reader["SkinCssFile"];
			}
		
			if(reader["SecondaryCss"] != DBNull.Value)
			{
				config.Skin.SkinCssText = (string)reader["SecondaryCss"];
			}
			if(reader["IsMailNotify"]!=DBNull.Value)
			{
				config.IsMailNotify=(bool)reader["IsMailNotify"];
			}
			else
			{
				config.IsMailNotify=true;
			}
			
			if(reader["IsOnlyListTitle"]!=DBNull.Value)
			{
				config.IsOnlyListTitle=(bool)reader["IsOnlyListTitle"];
			}
			else
			{
				config.IsOnlyListTitle=false;
			}

			if(reader["NotifyMail"]==DBNull.Value)
			{
				config.NotifyMail=config.Email;
			}
			else
			{
				config.NotifyMail=(string)reader["NotifyMail"];
			}

			//Wait till v2.0
			//config.ExtendedProperties = new ExtendedProperties((byte[])reader["NVC"]);

			return config;
		}
		
		public static SkinControlCollection LoadSkinControlCollection(IDataReader reader)
		{
			SkinControlCollection scc=new SkinControlCollection();
			while(reader.Read())
			{
				scc.Add(LoadSkinControl(reader));
			}
			return scc;
		}

		public static SkinControl LoadSkinControl(IDataReader reader)
		{
			SkinControl skinControl = new SkinControl();
			skinControl.ID=(int)reader["ID"];
			skinControl.Control=(string)reader["Control"];
			skinControl.Name=(string)reader["ControlName"];
			skinControl.Visible=(bool)reader["Visible"];
			return skinControl;
		}
		#endregion

		#region Archive

		public static ArchiveCountCollection LoadArchiveCount(IDataReader reader)
		{
			const string dateformat = "{0}/{1}/{2}";
			string dt = null; //
			ArchiveCount ac =null;// new ArchiveCount();
			ArchiveCountCollection acc = new ArchiveCountCollection();
			CultureInfo en = new CultureInfo("en-US");
			while(reader.Read())
			{
				ac = new ArchiveCount();
				dt = string.Format(dateformat,(int)reader["Month"],(int)reader["Day"],(int)reader["Year"]);
				ac.Date = DateTime.Parse(dt);
				//ac.Date = DateTime.ParseExact(dt,"MM/dd/yyyy",en);

				ac.Count = (int)reader["Count"];
				acc.Add(ac);
			}
			return acc;
			
		}

		//Needs to be handled else where!
		public static Link LoadArchiveLink(IDataReader reader)
		{
			Link link = new Link();
			int count = (int)reader["Count"];
			DateTime dt = new DateTime((int)reader["Year"],(int)reader["Month"],1);
			link.NewWindow = false;
			link.Title = dt.ToString("y") + " (" + count.ToString() + ")";
			//link.Url = Globals.ArchiveUrl(dt,"MMyyyy");
			link.NewWindow = false;
			link.IsActive = true;
			return link;
		}

		#endregion

		#region Image

		public static Image LoadSingleImage(IDataReader reader)
		{
			Image _image = new Image();
			_image.CategoryID = (int)reader["CategoryID"];
			_image.File = (string)reader["File"];
			_image.Height = (int)reader["Height"];
			_image.Width = (int)reader["Width"];
			_image.ImageID = (int)reader["ImageID"];
			_image.IsActive = (bool)reader["Active"];
			_image.Title = (string)reader["Title"];
			return _image;
		}

		#endregion

		#region Keywords

		public static KeyWord LoadSingleKeyWord(IDataReader reader)
		{
			KeyWord kw = new KeyWord();
			kw.KeyWordID = (int)reader["KeyWordID"];
			kw.BlogID = (int)reader["BlogID"];
			kw.OpenInNewWindow = (bool)reader["OpenInNewWindow"];
			kw.ReplaceFirstTimeOnly = (bool)reader["ReplaceFirstTimeOnly"];
			kw.CaseSensitive = (bool)reader["CaseSensitive"];
			kw.Text = (string)reader["Text"];
			kw.Title = CheckNullString(reader["Title"]);
			kw.Url = (string)reader["Url"];
			kw.Word = (string)reader["Word"];
			return kw;
		}



		#endregion

		#region Helpers

		public static string CheckNullString(object obj)
		{
			if(obj is DBNull)
			{
				return null;
			}
			return (string)obj;
		}

		public static object CheckNull(string text)
		{
			if(text != null && text.Trim().Length > 0)
			{
				return text;
			}
			return DBNull.Value;
		}

		public static string CheckNull(object obj)
		{
			return (string) obj;
		}

		public static string CheckNull(DBNull obj)
		{
			return null;
		}

		#endregion
	}
}

