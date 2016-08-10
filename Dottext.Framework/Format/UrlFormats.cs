using System;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;

namespace Dottext.Framework.Format
{
	/// <summary>
	/// Default Implemenation of UrlFormats
	/// </summary>
	public class UrlFormats
	{
		public UrlFormats()
		{
		}
		
		protected string fullyQualifiedUrl = null;

		public UrlFormats(string fullyQualifiedUrl)
		{
			this.fullyQualifiedUrl = fullyQualifiedUrl;
		}

		public virtual string PostCategoryUrl(string categoryName, int categoryID)
		{
			return GetUrl("category/{0}.{1}",categoryID,Config.Settings.UrlFormat);
		}
		
		public virtual string ArticleCategoryUrl(string categoryName, int categoryID)
		{
			return GetUrl("category/{0}.{1}",categoryID,Config.Settings.UrlFormat);
		}

		public virtual string FavoriteCategoryUrl(string categoryName, int categoryID)
		{
			return GetUrl("favorite/{0}.{1}",categoryID,Config.Settings.UrlFormat);
		}

		public virtual string EntryUrl(Entry entry)
		{
			return GetUrl("archive/" + entry.DateCreated.ToString("yyyy'/'MM'/'dd") + "/{0}.{1}", entry.HasEntryName ? entry.EntryName : entry.EntryID.ToString(),Config.Settings.UrlFormat);
		}

		public virtual string MessageUrl(Entry entry)
		{
			return GetUrl("Messages/" + entry.DateCreated.ToString("yyyy'/'MM'/'dd") + "/{0}.{1}", entry.HasEntryName ? entry.EntryName : entry.EntryID.ToString(),Config.Settings.UrlFormat);
		}

		public virtual string ImageUrl(string category, int ImageID)
		{
			return GetUrl("gallery/image/{0}.{1}",ImageID,Config.Settings.UrlFormat);
		}

		public virtual string YearUrl(DateTime dt)
		{
			return GetUrl("archive/{0}.{1}",dt.ToString("yyyy"),Config.Settings.UrlFormat);
		}

		public virtual string DayUrl(DateTime dt)
		{
			//return GetUrl("archive/{0}/{1}/{2}.aspx",dt.Year,dt.Month,dt.Day);
			return GetUrl("archive/{0}.{1}",dt.ToString("yyyy'/'MM'/'dd"),Config.Settings.UrlFormat);
		}

		public virtual string GalleryUrl(string category, int GalleryID)
		{
			return GetUrl("gallery/{0}.{1}",GalleryID,Config.Settings.UrlFormat);
		}

		public virtual string ArticleUrl(Entry entry)
		{
			if(entry.HasEntryName)
			{
				return GetUrl("articles/{0}.{1}",entry.EntryName,Config.Settings.UrlFormat);
			}

			return GetUrl("articles/{0}.{1}",entry.EntryID,Config.Settings.UrlFormat);
			
		}

		public virtual string MonthUrl(DateTime dt)
		{
			Logger.LogManager.Log("MonthUrl2",GetUrl("{archive}/{0}.aspx",dt.ToString("yyyy'/'MM")));
			return GetUrl("{archive}/{0}.{1}",dt.ToString("yyyy'/'MM"),Config.Settings.UrlFormat);
		}

		public virtual string MonthUrl(DateTime dt,string path)
		{
			return GetUrl("{0}/{1}.{2}",path,dt.ToString("yyyy'/'MM"),Config.Settings.UrlFormat);
		}

		public virtual string CommentRssUrl(int EntryID)
		{
			return GetUrl("comments/commentRss/{0}.{1}",EntryID,Config.Settings.UrlFormat);
		}

		public virtual string CommentUrl(Entry ParentEntry, Entry ChildEntry)
		{
			return string.Format("{0}#{1}",ParentEntry.Link,ChildEntry.EntryID);
			//return PostUrl(dt,EntryID) + "#FeedBack";
		}

		public virtual string CommentUrl(Entry entry)
		{
			return 	GetUrl("archive/" + entry.DateCreated.ToString("yyyy'/'MM'/'dd") + "/{0}.{2}#{1}", entry.HasEntryName ? entry.EntryName : entry.ParentID.ToString(),entry.EntryID,Config.Settings.UrlFormat);
		}

		public virtual string CommentApiUrl(int EntryID)
		{
			return GetUrl("comments/{0}.{1}",EntryID,Config.Settings.UrlFormat);
		}

		public virtual string TrackBackUrl(int EntryID)
		{
			return GetUrl("services/trackbacks/{0}.{1}",EntryID,Config.Settings.UrlFormat);
		}

		public virtual string AggBugkUrl(int EntryID)
		{
			return GetUrl("aggbug/{0}.{1}",EntryID,Config.Settings.UrlFormat);
		}

		protected virtual string GetUrl(string pattern, params object[] items)
		{
			return this.fullyQualifiedUrl + string.Format(pattern,items);
		}


	}
}
