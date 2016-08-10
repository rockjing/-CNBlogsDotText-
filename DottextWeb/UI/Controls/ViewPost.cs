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
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Dottext.Framework;	
using Dottext.Framework.Tracking;
using Dottext.Framework.Components;
using Dottext.Framework.Util;

using Dottext.Common.Data;

namespace Dottext.Web.UI.Controls
{
	/// <summary>
	///		Summary description for ViewStory.
	/// </summary>
	public class ViewPost : BaseControl
	{
		protected System.Web.UI.WebControls.HyperLink TitleUrl;
		protected System.Web.UI.WebControls.Literal Body;
		protected System.Web.UI.WebControls.Literal PostDescription;
		protected System.Web.UI.WebControls.Literal PingBack;
		protected System.Web.UI.WebControls.Literal TrackBack;
		private string strFavoriteLink="";//@"&nbsp;<a href=""{0}AddToFavorite.aspx?id={1}"">ÊÕ²Ø</a>";
		private string strEditLink="";

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
			//Get the entry
			Entry entry = Cacher.GetEntryFromRequest(Context,CacheTime.Medium);	
				
			
			//if found
			if(entry != null)
			{
				//Track this entry
				EntryTracker.Track(Context,entry.EntryID,CurrentBlog.BlogID);
				
				//Set the page title
				Globals.SetTitle(entry.Title,Context);

				//Sent entry properties
				TitleUrl.Text =entry.Title; //Server.HtmlEncode(entry.Title);
				TitleUrl.NavigateUrl = entry.TitleUrl;
				Body.Text = Framework.Util.Globals.FilterScript(entry.Body);
				strFavoriteLink=String.Format(UIData.FavoriteLink,CurrentBlog.FullyQualifiedUrl,entry.EntryID);
				if(entry.PostType==PostType.BlogPost)
				{
					strEditLink=string.Format(UIData.EditPostsLink,CurrentBlog.FullyQualifiedUrl,entry.EntryID);
				}
				if(entry.PostType==PostType.Article)
				{
					strEditLink=string.Format(UIData.EditArticleLink,CurrentBlog.FullyQualifiedUrl,entry.EntryID);
				}
				
				PostDescription.Text = string.Format("{0} {1} ÔÄ¶Á({5}) <a href='#Post'>ÆÀÂÛ({2})</a> {3}{4}",BlogTime.ConvertToBloggerTime(entry.DateCreated,CurrentBlog.TimeZone).ToString("yyyy-MM-dd HH:mm"),entry.Author,entry.FeedBackCount.ToString(),strEditLink,strFavoriteLink,entry.ViewCount);//string.Format("{0} {1}",entry.DateCreated.ToLongDateString(),entry.DateCreated.ToShortTimeString());
				
				//Set Pingback/Trackback 
				PingBack.Text = TrackHelpers.PingPackTag;
				TrackBack.Text = TrackHelpers.TrackBackTag(entry);

			}
			else 
			{
				//No post? Deleted? Help :)
				this.Controls.Clear();
				this.Controls.Add(new LiteralControl("<p><strong>The entry could not be found or has been removed</strong></p>"));
			}
		}

	}
}

