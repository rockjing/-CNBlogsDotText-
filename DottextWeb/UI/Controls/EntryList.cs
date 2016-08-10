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
using Dottext.Framework.Util;
using Dottext.Framework.Components;


namespace Dottext.Web.UI.Controls
{
	/// <summary>
	/// Summary description for LastSevenDaysControl.
	/// </summary>
	public class EntryList : BaseControl
	{
		public EntryList()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		protected System.Web.UI.WebControls.Repeater Entries;
		protected System.Web.UI.WebControls.Literal EntryCollectionTitle;
		protected System.Web.UI.WebControls.Literal EntryCollectionDescription;
		protected System.Web.UI.WebControls.HyperLink EntryCollectionReadMoreLink;


		const string postdescWithComments = "posted @ <a href=\"{0}\" Title = \"permalink\">{1}</a> {2} ÔÄ¶Á({7}) | <a href=\"{3}#FeedBack\" Title = \"comments, pingbacks, trackbacks\">ÆÀÂÛ ({4})</a> {5}{6}";
		const string postdescWithNoComments = "posted @ <a href=\"{0}\" Title = \"permalink\">{1}</a> {2}|{3}{4}";
		private string strFavoriteLink="";//=@"&nbsp;<a href=""{0}AddToFavorite.aspx?id={1}"">ÊÕ²Ø</a>";
		private string strEditLink="";
		
		//const string postdescWithComments = "posted @ <a href=\"{0}\" Title = \"permalink\">{1}</a> {2} | <a href=\"{3}#FeedBack\" Title = \"comments, pingbacks, trackbacks\">ÆÀÂÛ({4})</a>";
		//const string postdescWithNoComments = "posted @ <a href=\"{0}\" Title = \"permalink\">{1}</a> {2}";
		protected void PostCreated(object sender,  RepeaterItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Entry entry = (Entry)e.Item.DataItem;
				if(entry != null)
				{
					HyperLink title = (HyperLink)e.Item.FindControl("TitleUrl");
					if(title != null)
					{
						title.Text = entry.Title;
						title.NavigateUrl = entry.Link;
					}

					Literal PostText = (Literal)e.Item.FindControl("PostText");

					if(DescriptionOnly)
					{
						if(entry.HasDescription)
						{
						
							PostText.Text = string.Format("<p>{0}</p>",entry.Description);
						}
					}
					else
					{
						if(entry.HasDescription)
						{
							PostText.Text = entry.Description;
						}
						else
						{
							PostText.Text = "<br>" + entry.Body;
						}
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


					if(PostDesc != null)
					{
						/*
						if(entry.AllowComments)
						{
							PostDesc.Text = string.Format(postdescWithComments,entry.Link,entry.DateCreated.ToString("f"),entry.Author,entry.Link,entry.FeedBackCount);
						}
						else
						{
							PostDesc.Text = string.Format(postdescWithNoComments,entry.Link,entry.DateCreated.ToString("f"),entry.Author);
						}*/
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

		private EntryCollection entries;
		public EntryCollection EntryListItems
		{
			get{return entries;}
			set{entries = value;}
		}

		private bool displayOnly = true;
		public bool DescriptionOnly
		{
			get{return displayOnly;}
			set{displayOnly = value;}
		}

		private string entryListTitle;
		public string EntryListTitle
		{
			get{return entryListTitle;}
			set{entryListTitle = value;}
		}

		private string _entryListDescription;
		public string EntryListDescription
		{
			get {return this._entryListDescription;}
			set {this._entryListDescription = value;}
		}

		private string _entryListReadMoreText;
		public string EntryListReadMoreText
		{
			get {return this._entryListReadMoreText;}
			set {this._entryListReadMoreText = value;}
		}

		private string _entryListReadMoreUrl;
		public string EntryListReadMoreUrl
		{
			get {return this._entryListReadMoreUrl;}
			set {this._entryListReadMoreUrl = value;}
		}
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

				if(EntryListItems != null)
				{
					EntryCollectionTitle.Text = EntryListTitle;

					if(EntryListDescription != null)
					{
						this.EntryCollectionDescription.Text = EntryListDescription;
					}
					else
					{
						EntryCollectionDescription.Visible = false;
					}

					if(EntryListReadMoreUrl != null && EntryListReadMoreText != null)
					{
						this.EntryCollectionReadMoreLink.Text = EntryListReadMoreText;
						this.EntryCollectionReadMoreLink.NavigateUrl = EntryListReadMoreUrl;
					}
					else
					{
						EntryCollectionReadMoreLink.Visible = false;
					}

					Entries.DataSource = EntryListItems;
					Entries.DataBind();
				}

		}
	}
}

