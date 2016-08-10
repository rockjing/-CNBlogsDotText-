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
using Dottext.Framework.Components;
using Dottext.Framework.Util;


namespace Dottext.Web.UI.Controls
{
	/// <summary>
	/// Summary description for LastSevenDaysControl.
	/// </summary>
	public class Day : BaseControl
	{
		public Day()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		protected System.Web.UI.WebControls.Repeater DayList;
		protected System.Web.UI.WebControls.HyperLink ImageLink;
		protected System.Web.UI.WebControls.Literal  DateTitle;

		private EntryDay bpd;
		public EntryDay CurrentDay
		{
			set{bpd = value;}
		}

		const string postdescWithComments = "posted @ <a href=\"{0}\" Title = \"permalink\">{1}</a> {2} ÔÄ¶Á({7}) | <a href=\"{3}#FeedBack\" Title = \"comments, pingbacks, trackbacks\">ÆÀÂÛ ({4})</a> |{5}{6}";
		const string postdescWithNoComments = "posted @ <a href=\"{0}\" Title = \"permalink\">{1}</a> {2}|{3}{4}";
		private string strFavoriteLink="";//=@"&nbsp;<a href=""{0}AddToFavorite.aspx?id={1}"">ÊÕ²Ø</a>";
		private string strEditLink="";

		protected void PostCreated(object sender,  RepeaterItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Entry entry = (Entry)e.Item.DataItem;
				if(entry != null)
				{
					HyperLink hl = (HyperLink)e.Item.FindControl("TitleUrl");
					if(hl != null)
					{
						hl.NavigateUrl = entry.TitleUrl;
						hl.Text = entry.Title;
					}

					Literal PostText = (Literal)e.Item.FindControl("PostText");
					if(PostText != null&&!CurrentBlog.IsOnlyListTitle)
					{
						PostText.Text = Framework.Util.Globals.FilterScript(entry.Body);
					}

					Literal desc = (Literal)e.Item.FindControl("PostDescription");
					if(desc != null)
					{
						string link = entry.Link;
					}

					Literal PostDesc = (Literal)e.Item.FindControl("PostDesc");
					
					if(entry.PostType==PostType.BlogPost)
					{
						strEditLink=string.Format(UIData.EditPostsLink,CurrentBlog.FullyQualifiedUrl,entry.EntryID);
					}
					if(entry.PostType==PostType.Article)
					{
						strEditLink=string.Format(UIData.EditArticleLink,CurrentBlog.FullyQualifiedUrl,entry.EntryID);
					}

					strFavoriteLink=String.Format(UIData.FavoriteLink,CurrentBlog.FullyQualifiedUrl,entry.EntryID,entry.TitleUrl);

					if(PostDesc != null)
					{
						if(CurrentBlog.EnableComments && entry.AllowComments)
						{
							PostDesc.Text = string.Format(postdescWithComments,entry.Link,BlogTime.ConvertToBloggerTime(entry.DateCreated,CurrentBlog.TimeZone).ToString("yyyy-MM-dd HH:mm"),entry.Author,entry.Link,entry.FeedBackCount,strEditLink,strFavoriteLink,entry.ViewCount);
						}
						else
						{
							PostDesc.Text = string.Format(postdescWithNoComments,entry.Link,BlogTime.ConvertToBloggerTime(entry.DateCreated,CurrentBlog.TimeZone).ToString("yyyy-MM-dd HH:mm"),entry.Author,strEditLink,strFavoriteLink,entry.ViewCount);
						}
					}
					
				}
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
				if(bpd != null)
				{
					//ImageLink.NavigateUrl = Dottext.Framework.Util.Globals.ArchiveUrl(bpd.BlogDay,"MMddyyyy");// bpd.Link;
					ImageLink.NavigateUrl = Dottext.Framework.Configuration.Config.CurrentBlog(Context).UrlFormats.DayUrl(bpd.BlogDay);
					DateTitle.Text = bpd.BlogDay.ToLongDateString();
					DayList.DataSource = bpd;
					DayList.DataBind();
				}
				else
				{
					this.Visible = false;
				}
			
		}
	}
}

