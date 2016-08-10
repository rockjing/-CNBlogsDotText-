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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Dottext.Framework;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Web.Admin.WebUI;
using Dottext.Framework.Util;

namespace Dottext.Web.Admin
{
	public abstract class PageTemplate : System.Web.UI.UserControl
	{
		protected Dottext.Web.Admin.WebUI.PlaceHolder PageTitle;
		protected Dottext.Web.Admin.WebUI.PlaceHolder PageContent;
		protected Dottext.Web.Admin.WebUI.PlaceHolder LabelCategories;
		protected Dottext.Web.Admin.WebUI.PlaceHolder LabelActions;
		protected HyperLink BlogTitle;
		protected HeaderLink Css1;
		protected LinkList LinksCategories;
		protected LinkList LinksActions;
		protected System.Web.UI.WebControls.LinkButton LogoutLink;
		protected System.Web.UI.WebControls.HyperLink BlogTitleLink;
		protected Dottext.Web.Admin.WebUI.BreadCrumbs BreadCrumbs;		
		protected HeaderBase Base1;
		protected Literal LoggedInUser;
		protected System.Web.UI.HtmlControls.HtmlGenericControl GalleryTab;
		protected System.Web.UI.HtmlControls.HtmlGenericControl AdminTab;
		protected System.Web.UI.HtmlControls.HtmlGenericControl FilesTab;
		protected System.Web.UI.WebControls.Literal HeaderSubTitle;
		protected System.Web.UI.WebControls.HyperLink TitleLink;
		
		

		#region Accessors

		private string _resourcePath;
		
		public string ResourcePath
		{
			get
			{
				if(this._resourcePath == null)
				{
					this._resourcePath = Globals.WebPathCombine(Request.ApplicationPath,  "/admin/");
				}
				return this._resourcePath;
			}
			set
			{
			}
		}

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			GalleryTab.Visible = Config.Settings.AllowImages;
			LoggedInUser.Text = Config.CurrentBlog().Author;
			TitleLink.NavigateUrl=Dottext.Framework.Configuration.Config.Settings.AggregateUrl;
			TitleLink.ImageUrl = Dottext.Framework.Util.Globals.GetWebConfig("Admin.Logo","adminlogo.gif");
			AdminTab.Visible=Security.IsInRole("administrators");
			FilesTab.Visible=Security.IsInRole("UploadUsers")||Config.Settings.EnableAllUserUpload;
			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e) 
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent() 
		{
			this.LogoutLink.Click += new System.EventHandler(this.LogoutLink_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LogoutLink_Click(object sender, System.EventArgs e)
		{
			System.Web.Security.FormsAuthentication.SignOut();
			
		}

		}
}

