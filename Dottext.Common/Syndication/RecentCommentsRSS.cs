using System;
using System.Web;
using System.Web.Caching;
using Dottext.Framework;
using Dottext.Framework.Util;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Framework.Syndication;
using DTCF = Dottext.Framework.Configuration;

using Dottext.Common.Data;
using System.IO;


namespace Dottext.Common.Syndication
{
	/// <summary>
	/// RecentCommentsRSS 的摘要说明。
	/// </summary>
	public class RecentCommentsRSS : Dottext.Framework.Syndication.BaseSyndicationHandler
	{
		public RecentCommentsRSS()
		{
			
		}
		
		protected override string CacheKey()
		{
			const string key = "CommentsMainFeed:FQU{0}";
			return string.Format(key,CurrentBlog.FullyQualifiedUrl);
		}

		protected override CachedFeed BuildFeed()
		{
			CachedFeed feed = new CachedFeed();
			feed.LastModified = DateTime.Now;//this.ConvertLastUpdatedDate(CurrentBlog.LastUpdated);

			EntryQuery eq=new EntryQuery();
			eq.PostType=PostType.Comment;
			eq.ItemCount=CurrentBlog.ItemCount;
			eq.PostConfig=PostConfig.IsActive;
			RssWriter writer = new RssWriter(Entries.GetEntryCollection(eq));
			try
			{
				feed.Xml = writer.GetXml;
			}
			finally
			{
				writer.Close();
			}
			return feed;
		}

		protected override void Cache(CachedFeed feed)
		{
			Context.Cache.Insert(CacheKey(),feed,null,DateTime.Now.AddSeconds((double)Dottext.Common.Data.CacheTime.Medium),TimeSpan.Zero);
		}
	}
}
