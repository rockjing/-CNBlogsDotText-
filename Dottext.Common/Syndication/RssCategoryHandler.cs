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
using DTCF = Dottext.Framework.Configuration;

using Dottext.Common.Data;
using System.IO;

namespace Dottext.Common.Syndication
{
	/// <summary>
	/// RssCommentHandler is a proposed extention to the CommentApi. This is still beta/etc.
	/// The Main Rss feed now contains an element for each entry, which will generate a rss feed 
	/// containing the comments for each post.
	/// </summary>
	public class RssCategoryHandler : EntryCollectionHandler
	{
		public RssCategoryHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		protected LinkCategory Category = null;
		protected EntryCollection Posts = null;

		protected override EntryCollection GetFeedEntries()
		{
			if(Category == null)
			{
				Category = Cacher.SingleCategory(CacheTime.Short,Context);
			}

			if(Category != null && Posts == null)
			{
				Posts = Cacher.GetEntriesByCategory(10,CacheTime.Short,Context,Category.CategoryID);
			}

			return Posts;
		}


		protected override CachedFeed BuildFeed()
		{
			CachedFeed feed =null;

			EntryCollection posts = GetFeedEntries();

			if(posts != null && posts.Count > 0)
			{
				feed = new CachedFeed();
				CategoryWriter cw = new CategoryWriter(posts,Category,WebPathStripper.RemoveRssSlash(Context.Request.Url.ToString()));
				feed.LastModified = this.ConvertLastUpdatedDate(posts[0].DateCreated);
				try
				{
					feed.Xml = cw.GetXml;
				}
				finally
				{
					cw.Close();
				}
			}
			return feed;
		}

	}
}

