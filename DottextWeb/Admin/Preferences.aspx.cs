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

using Dottext.Web.Admin;
using Dottext.Framework;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;

namespace Dottext.Web.Admin.Pages
{
	public class EditPreferences : AdminPage
	{
		protected System.Web.UI.WebControls.DropDownList ddlPageSize;
		protected System.Web.UI.WebControls.DropDownList ddlPublished;
		protected System.Web.UI.WebControls.DropDownList ddlExpandAdvanced;
		protected System.Web.UI.WebControls.LinkButton lkbUpdate;
		protected System.Web.UI.WebControls.LinkButton lkbCancel;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Edit;
		protected System.Web.UI.WebControls.CheckBox EnableComments;
		protected System.Web.UI.WebControls.CheckBoxList cklSkinControl;
		protected System.Web.UI.WebControls.CheckBox EnableMailNotify;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected System.Web.UI.WebControls.CheckBox chkOnlyTitle;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
//			if (!AreCookiesAllowed())
//			{
//				// TODO -- display an errormsg indicating cookies are required
//				// with a link to FinishCookieTest on the off chance this is the
//				// first page accessed and cookies are in fact on.
//				Controls.Add(new LiteralControl("Cookies NOT ALLOWED"));
//			}
//			else if (!IsPostBack)
//			{
//				BindLocalUI();
//			}
			if (!IsPostBack)
			{
				BindLocalUI();
			}
			
		}

		private void BindLocalUI()
		{
			ddlPageSize.SelectedIndex = -1;
			ddlPageSize.Items.FindByValue(Preferences.ListingItemCount.ToString()).Selected = true;

			ddlPublished.SelectedIndex = -1;
			ddlPublished.Items.FindByValue(Preferences.AlwaysCreateIsActive ? "true" : "false").Selected = true;

			ddlExpandAdvanced.SelectedIndex = -1;
			ddlExpandAdvanced.Items.FindByValue(Preferences.AlwaysExpandAdvanced ? "true" : "false").Selected = true;

			BlogConfig config=Config.CurrentBlog(Context);
			this.EnableComments.Checked = config.EnableComments;
			this.EnableMailNotify.Checked= config.IsMailNotify;
			this.chkOnlyTitle.Checked=config.IsOnlyListTitle;
			
			try
			{
				ddlPageSize.SelectedValue=config.ItemCount.ToString();
			}
			catch
			{
				ddlPageSize.SelectedValue="10";
			}
			if(!this.IsPostBack)
			{
				SkinControlCollection scc=SkinControls.GetSkinControlCollection(Config.CurrentBlog().BlogID);
				for(int i=0;i<scc.Count;i++)
				{
					ListItem item=new ListItem();
					item.Text=scc[i].Name;
					item.Value=scc[i].ID.ToString();
					item.Selected=scc[i].Visible;
					cklSkinControl.Items.Add(item);
				}
				/*cklSkinControl.DataSource=skinControlCollection;
				cklSkinControl.DataValueField = "Visible";
				cklSkinControl.DataTextField = "Name";
				cklSkinControl.DataBind();
				for(int i=0;i<cklSkinControl.Items.Count;i++)
				{
					if(!bool.Parse(cklSkinControl.Items[i].Value))
					{
						cklSkinControl.Items[i].Selected=false;
					}
					else
					{
						cklSkinControl.Items[i].Selected=true;
					}
				}
				ViewState["SkinControl"]=skinControlCollection;*/
			}

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
			this.cklSkinControl.PreRender += new System.EventHandler(this.cklSkinControl_PreRender);
			this.lkbUpdate.Click += new System.EventHandler(this.lkbUpdate_Click);
			this.lkbCancel.Click += new System.EventHandler(this.lkbCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lkbUpdate_Click(object sender, System.EventArgs e)
		{
			int pageSize = Int32.Parse(ddlPageSize.SelectedItem.Value);
			if (pageSize > 0)
				Preferences.ListingItemCount = pageSize;	
	
			bool published = Boolean.Parse(ddlPublished.SelectedItem.Value);
			Preferences.AlwaysCreateIsActive = published;

			bool alwaysExpand = Boolean.Parse(ddlExpandAdvanced.SelectedItem.Value);
			Preferences.AlwaysExpandAdvanced = alwaysExpand;

			BlogConfig config  = Config.CurrentBlog(Context);
			config.EnableComments = this.EnableComments.Checked;
			config.IsMailNotify=this.EnableMailNotify.Checked;
			config.IsOnlyListTitle=this.chkOnlyTitle.Checked;
			config.ItemCount=int.Parse(ddlPageSize.SelectedValue);
			Config.UpdateConfigData(config);
			
			for(int i=0;i<cklSkinControl.Items.Count;i++)
			{
				ListItem item=cklSkinControl.Items[i];
				SkinControls.UpdateSingleSkinControl(int.Parse(item.Value),item.Selected,Config.CurrentBlog().BlogID);
				
			}			
			Messages.ShowMessage("±£´æ³É¹¦!");

//			BindLocalUI();
		}

		private void lkbCancel_Click(object sender, System.EventArgs e)
		{
			BindLocalUI();
		}

		private void cklSkinControl_PreRender(object sender, System.EventArgs e)
		{
			
		}
	}
}

