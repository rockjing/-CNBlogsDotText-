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

namespace Dottext.Web.UI.Controls
{
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
	
	/// <summary>
	///		Summary description for Comments.
	/// </summary>
	public class Comments : BaseControl
	{
		protected System.Web.UI.WebControls.Repeater CommentList;
		protected System.Web.UI.WebControls.Literal NoCommentMessage;
		protected int CommentsCount;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			if(CurrentBlog.EnableComments)
			{

				Entry entry = Cacher.GetEntryFromRequest(Context,CacheTime.Short);	

				if(entry != null && entry.AllowComments)
				{
					this.CommentsCount=entry.FeedBackCount;
					BindComments(entry);
				}
				else
				{
					this.Visible = false;
				}
			}
			else
			{
				this.Visible = false;
			}
			
		}


		protected void RemoveComment_ItemCommand(Object Sender, RepeaterCommandEventArgs e) 
		{
				int feedbackItem = Int32.Parse(e.CommandName);
				Entries.Delete(feedbackItem);
				Response.Redirect(string.Format("{0}?Pending=true",Request.Path));
		}

		protected void CommentsCreated(object sender,  RepeaterItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Entry entry = (Entry)e.Item.DataItem;
				if(entry != null)
				{
					Literal title = (Literal)(e.Item.FindControl("Title"));
					if(title != null)
					{
						// we should probably change skin format to dynamically wire up to 
						// skin located title and permalinks at some point
						title.Text = String.Format("{2}&nbsp;{0}{1}", Anchor(entry.EntryID), 
							entry.Title, Link(entry.Title, entry.Link));
						if(e.Item.ItemIndex==this.CommentsCount-1)
						{
							title.Text+="<a name=\"Post\"></a>";//+"-"+e.Item.ItemIndex+"-"+CommentList.Items.Count;
						}
						if(entry.PostType == PostType.PingTrack)
						 {
							title.Text+="[TrackBack]";
						 }
					}

					HyperLink namelink = (HyperLink)e.Item.FindControl("NameLink");
					if(namelink != null)
					{
						if(entry.HasTitleUrl)
						{
							namelink.NavigateUrl = Globals.CheckForUrl(entry.TitleUrl);
						}
						if(entry.PostType == PostType.Comment)
						{
							namelink.Text = entry.Author;
						}
						else if(entry.PostType == PostType.PingTrack)
						{
							namelink.Text = entry.Author; //entry.Author != null ? entry.Author : "Pingback/TrackBack";
							//namelink.Attributes.Add("title","PingBack/TrackBack");
						}
						 
					}

					Literal PostDate = (Literal)(e.Item.FindControl("PostDate"));
					if(PostDate != null)
					{
						PostDate.Text = BlogTime.ConvertToBloggerTime(entry.DateCreated,CurrentBlog.TimeZone).ToString("yyyy-MM-dd HH:mm");//ToShortDateString() + " " + entry.DateCreated.ToShortTimeString();
					}

					Literal Post = (Literal)(e.Item.FindControl("PostText"));
					if(Post != null)
					{
						Post.Text = entry.Body;
						if(entry.PostType == PostType.PingTrack)
						{
							if(Post.Text.Length>5)
							{
								Post.Text+="<br>";
							}

							Post.Text=Post.Text+string.Format("{0}引用了该文章,地址:<a href='{1}'>{1}</a>",entry.Author,Globals.CheckForUrl(entry.TitleUrl));
						}
					}
						if(Request.IsAuthenticated && Security.IsAdmin)
						{
							LinkButton editlink = (LinkButton)(e.Item.FindControl("EditLink"));
							if(editlink != null)
							{
								//editlink.CommandName = "Remove";
								editlink.Text = "Remove Comment " + entry.EntryID.ToString();
								editlink.CommandName = entry.EntryID.ToString();
								editlink.Attributes.Add("onclick","return confirm(\"Are you sure you want to delete comment " + entry.EntryID.ToString() + "?\");");
								editlink.Visible = true;
								editlink.CommandArgument = entry.EntryID.ToString();

							}
							else
							{
								editlink.Visible = false;
							}
							/*if(Request.IsAuthenticated)
						{
							bool IsAuthenRemove=false;
							if(Security.IsAdmin)
							{
								IsAuthenRemove=true;
							}
							else
							{
								BlogConfig config=Config.GetConfig(HttpContext.Current.User.Identity.Name);
								if(config.BlogID==entry.BlogID)
								{
									IsAuthenRemove=true;
								}
							}
								
							
							if(IsAuthenRemove)
							{
								LinkButton editlink = (LinkButton)(e.Item.FindControl("EditLink"));
								if(editlink != null)
								{
									//editlink.CommandName = "Remove";
									editlink.Text = "Remove Comment " + entry.EntryID.ToString();
									editlink.CommandName = entry.EntryID.ToString();
									editlink.Attributes.Add("onclick","return confirm(\"Are you sure you want to delete comment " + entry.EntryID.ToString() + "?\");");
									editlink.Visible = true;
									editlink.CommandArgument = entry.EntryID.ToString();

								}
								else
								{
									editlink.Visible = false;
								}
							}*/
						}
				}
			}
		}

		const string linktag = "<a title=\"permalink: {0}\" href=\"{1}\">#</a>";
		private string Link(string title, string link)
		{
			return string.Format(linktag,title,link);
		}

		// GC: xhmtl format wreaking havoc in non-xhtml pages in non-IE, changed to non nullable format
		const string anchortag = "<a name=\"{0}\"></a>";
		private string Anchor(int ID)
		{
			return string.Format(anchortag,ID);
		}

		void BindComments(Entry entry)
		{
				try
				{
					if(Request.QueryString["Pending"] != null)
					{
						Cacher.ClearCommentCache(entry.EntryID,Context);
					}
					CommentList.DataSource = Cacher.GetComments(entry,CacheTime.Short,Context);
					CommentList.DataBind();

					if(CommentList.Items.Count == 0)
					{
						CommentList.Visible = false;
						this.NoCommentMessage.Text = "";
					}

				}
				catch
				{
					this.Visible = false;
				}
		}
	}
}

