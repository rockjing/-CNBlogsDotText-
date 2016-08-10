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
using System.Web;
using System.Web.Caching;
using Dottext.Framework;
using Dottext.Framework.Util;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Framework.Syndication;
using System.IO;

using DTCF = Dottext.Framework.Configuration;

namespace Dottext.Common.Syndication
{
	/// <summary>
	/// Summary description for RssHandler.
	/// </summary>
	public class RssHandler : Dottext.Framework.Syndication.BaseSyndicationHandler
	{
		public RssHandler(){}
		private string key = "IndividualMainFeed:FQU{0}";

		protected override string CacheKey()
		{
			return string.Format(key,CurrentBlog.FullyQualifiedUrl);
		}

		protected override CachedFeed BuildFeed()
		{
			this.key+="BlogID"+CurrentBlog.BlogID.ToString();
			CachedFeed feed = new CachedFeed();
			feed.LastModified = this.ConvertLastUpdatedDate(CurrentBlog.LastUpdated);

			EntryQuery query = new EntryQuery();
			query.PostConfig = PostConfig.IncludeInMainSyndication|PostConfig.IsActive;
			query.ItemCount = CurrentBlog.ItemCount;
			query.PostType = PostType.BlogPost;
			if(HttpContext.Current.Request.QueryString["cateid"]!=null&&HttpContext.Current.Request.QueryString["cateid"]!="")
			{
				query=Dottext.Framework.Util.Globals.BuildEntryQuery(query,CurrentBlog);
			}
			/*
			if(CurrentBlog is SiteBlogConfig)
			{
				query.CategoryID=((SiteBlogConfig)CurrentBlog).CategoryID;
				this.key+="CateogryID"+query.CategoryID.ToString();
			}*/
			/*if(HttpContext.Current.Request.QueryString["cateid"]!=null)
			{
				if(WebPathStripper.IsNumeric(HttpContext.Current.Request.QueryString["cateid"]))
				{
					query.CategoryID=int.Parse(HttpContext.Current.Request.QueryString["cateid"]);
					this.key+="CateogryID"+HttpContext.Current.Request.QueryString["cateid"];

				}
			}*/
			RssWriter writer = new RssWriter(Entries.GetEntryCollection(query));
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

