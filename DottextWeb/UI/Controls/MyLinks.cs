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
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework;
	using Dottext.Framework.Util;
	using Dottext.Framework.Components;
	using Dottext.Framework.Configuration;
	

	/// <summary>
	///		Summary description for Header.
	/// </summary>
	public class MyLinks : BaseControl
	{
		protected System.Web.UI.WebControls.HyperLink Admin;
		protected System.Web.UI.WebControls.HyperLink XMLLink;
		protected System.Web.UI.WebControls.HyperLink Syndication;
		protected System.Web.UI.WebControls.HyperLink HomeLink;
		protected System.Web.UI.WebControls.HyperLink ContactLink;
		protected System.Web.UI.WebControls.HyperLink MyHomeLink;
		protected System.Web.UI.WebControls.HyperLink NewPostLink;
		protected System.Web.UI.WebControls.HyperLink NewArticleLink;
		
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			if(Context != null)
			{
				this.HomeLink.Text=UI.UIText.SiteTitle;
				if(MyHomeLink!=null)
				{
					MyHomeLink.NavigateUrl = CurrentBlog.FullyQualifiedUrl;
					MyHomeLink.Text="首页";
					
				}
				if(NewPostLink!=null)
				{
					NewPostLink.NavigateUrl = CurrentBlog.FullyQualifiedUrl+"admin/EditPosts.aspx?opt=1";
				}
				/*if(NewArticleLink!=null)
				{
					NewArticleLink.NavigateUrl = CurrentBlog.FullyQualifiedUrl+"admin/EditArticles.aspx?opt=1";
				}*/

				this.ContactLink.Text="联系";
				this.Syndication.Text="聚合";				
				
				ContactLink.NavigateUrl = string.Format("{0}contact.aspx",CurrentBlog.FullyQualifiedUrl);
				HomeLink.NavigateUrl = Dottext.Framework.Configuration.Config.Settings.AggregateUrl;

				if(Request.IsAuthenticated && Security.IsAdmin)
				{
					Admin.Text = "管理";
					Admin.NavigateUrl = string.Format("{0}admin/default.aspx",CurrentBlog.FullyQualifiedUrl);
				}
				else
				{
					Admin.Text = "登录";
					//Add By dudu 
					//Dottext.Web.Pages.login.RedirectUrl=CurrentBlog.FullyQualifiedUrl+"/admin/default.aspx";
					string ReturnURL=CurrentBlog.FullyQualifiedUrl+"admin/default.aspx";
					Admin.NavigateUrl = string.Format("{0}login.aspx?ReturnURL={1}","~/",ReturnURL);
				}

				Syndication.NavigateUrl = XMLLink.NavigateUrl = string.Format("{0}Rss.aspx",CurrentBlog.FullyQualifiedUrl);
				//SearchLink.Text="搜索";
				//SearchLink.NavigateUrl=CurrentBlog.FullyQualifiedUrl+"BlogSearch.aspx";
				//this.Controls.AddAt(0,lnkSearch);

			}
		}

		
	}
}

