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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Dottext.Web.Admin.Pages
{
	public class EditImports : ConfirmationPage
	{
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Edit;
		protected Dottext.Web.Admin.UserControls.EntryEditor Editor;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Editor.SetFreeTextBox();
			BindLocalUI();
		}

		private void BindLocalUI()
		{

			Editor.ResultsUrlFormat = "EditArticles.aspx?pg={0}";

			// REFACTOR: we're duplicating this in both Articles and Posts for the sake
			// of wireup. There's a structural issue btw Page and Container.
			LinkButton lkbNewPost = Utilities.CreateLinkButton("New Article");
			lkbNewPost.CausesValidation = false;
			lkbNewPost.Click += new System.EventHandler(lkbNewPost_Click);
			PageContainer.AddToActions(lkbNewPost);

			// REFACTOR: Structural issue btw Page and Container.
			HyperLink lnkEditCategories = Utilities.CreateHyperLink("Edit Categories", 
				String.Format("{0}?{1}={2}", Constants.URL_EDITCATEGORIES, Keys.QRYSTR_CATEGORYID, 
				(int)PageContainer.CategoryType));
			PageContainer.AddToActions(lnkEditCategories);
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lkbNewPost_Click(object sender, System.EventArgs e)
		{
			Editor.EditNewEntry();
		}
	}
}

