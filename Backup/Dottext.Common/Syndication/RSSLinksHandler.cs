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


namespace Dottext.Common.Syndication
{
	/// <summary>
	/// LinksRSSHandler 的摘要说明。
	/// </summary>
	public class RssLinksHandler : Dottext.Framework.Syndication.BaseSyndicationHandler
	{
		public RssLinksHandler()
		{
			
		}

		private string key = "IndividualLinksRSS:FQU{0}";

		protected override string CacheKey()
		{
			return string.Format(key,CurrentBlog.FullyQualifiedUrl);
		}

		protected override CachedFeed BuildFeed()
		{
			int CategoryID;
			CachedFeed feed = new CachedFeed();
			feed.LastModified = DateTime.Now;
			string path = WebPathStripper.RemoveRssSlash(Context.Request.Path);
			string CategoryName = WebPathStripper.GetReqeustedFileName(path);
			if(WebPathStripper.IsNumeric(CategoryName))
			{
				CategoryID =Int32.Parse(CategoryName);
				
			}
			else
			{
				return null;
			}
			LinkCollection lc=Links.GetLinksByCategoryID(CategoryID,true);
			LinksWriter writer = new LinksWriter(lc);
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
			Context.Cache.Insert(CacheKey(),feed,null,DateTime.Now.AddSeconds((double)Dottext.Common.Data.CacheTime.Long),TimeSpan.Zero);
		}
	}
}
