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

using Dottext.Framework;
using Dottext.Framework.Components;

namespace Dottext.Web.Admin.Pages
{
	public class EditCategories : AdminPage
	{
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Edit;
		protected System.Web.UI.WebControls.TextBox txbNewTitle;
		protected System.Web.UI.WebControls.CheckBox ckbNewIsActive;
		protected System.Web.UI.WebControls.LinkButton lkbPost;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Add;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected System.Web.UI.WebControls.RequiredFieldValidator valtxbNewTitleRequired;
		protected System.Web.UI.WebControls.DataGrid dgrItems;
		protected System.Web.UI.WebControls.TextBox txbNewDescription;
		protected System.Web.UI.WebControls.Label BlogID;
		protected System.Web.UI.WebControls.Label blogID;
			
		private CategoryType _categoryType
		{
			get
			{
				if(ViewState["_categoryType"] == null)
				{
					return CategoryType.LinkCollection;
				}
				return (CategoryType)ViewState["_categoryType"];
			}
			set
			{
				ViewState["_categoryType"] = value;
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{			
			if (!IsPostBack)
			{
				if (null != Request.QueryString[Keys.QRYSTR_CATEGORYID])
					_categoryType = (CategoryType)Convert.ToInt32(Request.QueryString[Keys.QRYSTR_CATEGORYID]);
				ckbNewIsActive.Checked = Preferences.AlwaysCreateIsActive;
				
				BindLocalUI();				
				BindList();
				
			}			
		}

		// REFACTOR: Maybe. Some sections can be inferred from the catType, but not the not cat pages.
		private void BindLocalUI()
		{
			BlogID.Text=Dottext.Framework.Configuration.Config.CurrentBlog().BlogID.ToString();
			HyperLink lkNewAction;
			switch (_categoryType)
			{
				case CategoryType.PostCollection : 
					PageContainer.TabSectionID = "Posts";
					lkNewAction = Utilities.CreateHyperLink("New Post","EditPosts.aspx?opt=1");
					PageContainer.AddToActions(lkNewAction);
					break;
				case CategoryType.StoryCollection : 
					PageContainer.TabSectionID = "Articles";
					lkNewAction = Utilities.CreateHyperLink("New Article","EditArticles.aspx?opt=1");
					PageContainer.AddToActions(lkNewAction);
					break;
				case CategoryType.LinkCollection : 
					PageContainer.TabSectionID = "Links";
					lkNewAction = Utilities.CreateHyperLink("New Link","EditLinks.aspx?opt=1");
					PageContainer.AddToActions(lkNewAction);
					break;
				case CategoryType.FavoriteCollention: 
					PageContainer.TabSectionID = "Favorites";
					lkNewAction = Utilities.CreateHyperLink("Ìí¼ÓÊÕ²ØÎÄÕÂ","EditFavorite.aspx?opt=1");
					PageContainer.AddToActions(lkNewAction);
					break;
				case CategoryType.ImageCollection : 
					PageContainer.TabSectionID = "Galleries";
					// TODO: redirect to galleries? or just have original link stay there?
					break;
				case CategoryType.Global: 
					PageContainer.TabSectionID = "ManageSite";
					BlogID.Text="-1";
					
					
					// TODO: redirect to galleries? or just have original link stay there?
					break;
				case CategoryType.Picked: 
					PageContainer.TabSectionID = "ManageSite";
					BlogID.Text="-1";
					// TODO: redirect to galleries? or just have original link stay there?
					break;
				default :
					PageContainer.TabSectionID = "Posts";
					break;
			}
		}

		private void BindList()
		{
			LinkCategoryCollection cats = Links.GetCategoriesByType(int.Parse(BlogID.Text),_categoryType, false);
			dgrItems.DataSource = cats;
			dgrItems.DataKeyField = "CategoryID";
			dgrItems.DataBind();
		}

		private void ToggleAddNew(bool showAddNew)
		{
			Add.Visible = showAddNew;
			valtxbNewTitleRequired.Enabled = showAddNew;
		}

		private void PersistCategory(LinkCategory category)
		{
			try
			{
				if (category.CategoryID > 0)
				{
					Links.UpdateLinkCategory(category);
					this.Messages.ShowMessage(String.Format("Category \"{0}\" was updated.", category.Title));
				}
				else
				{
					category.CategoryID = Links.CreateLinkCategory(category);
					this.Messages.ShowMessage(String.Format("Category \"{0}\" was added.", category.Title));
				}					
			}
			catch(Exception ex)
			{
				this.Messages.ShowError(String.Format(Constants.RES_EXCEPTION, "TODO...", ex.Message));
			}
		}

		private void ConfirmDelete(int categoryID, string categoryTitle)
		{
			BindLocalUI();
			this.Command = new DeleteCategoryCommand(categoryID, categoryTitle);
			this.Command.RedirectUrl = Request.Url.ToString();
			this.Command.TabSectionID=this.PageContainer.TabSectionID;
			Server.Transfer(Constants.URL_CONFIRM);
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
			this.dgrItems.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrCategories_CancelCommand);
			this.dgrItems.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrCategories_EditCommand);
			this.dgrItems.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrCategories_UpdateCommand);
			this.dgrItems.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrCategories_DeleteCommand);
			this.ckbNewIsActive.CheckedChanged += new System.EventHandler(this.ckbNewIsActive_CheckedChanged);
			this.lkbPost.Click += new System.EventHandler(this.lkbPost_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgrCategories_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgrItems.EditItemIndex = e.Item.ItemIndex;
			BindLocalUI();
			BindList();
			this.Messages.Clear();
			ToggleAddNew(false);
		}

		private void dgrCategories_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{	
			TextBox title = e.Item.FindControl("txbTitle") as TextBox;
			CheckBox isActive = e.Item.FindControl("ckbIsActive") as CheckBox;
			TextBox txbDescription = e.Item.FindControl("txbDescription") as TextBox;

			if (null == title || null == isActive)
				throw new ApplicationException("Update failed, could not located either the item Title or IsActive");			

			if (Page.IsValid)
			{
				if (Utilities.IsNullorEmpty(title.Text))
				{
					Messages.ShowError("You cannot have a category with a blank description");
					return;
				}

				int id = Convert.ToInt32(dgrItems.DataKeys[e.Item.ItemIndex]);
				
				LinkCategory existingCategory = Links.GetLinkCategory(id,false);
				existingCategory.Description = txbDescription.Text;
				existingCategory.Title = title.Text;
				existingCategory.IsActive = isActive.Checked;
				existingCategory.BlogID=int.Parse(BlogID.Text);
				
		
				if (id != 0) 
					PersistCategory(existingCategory);

				dgrItems.EditItemIndex = -1;
				
				BindLocalUI();
				BindList();
				ToggleAddNew(true);
			}
		}

		private void dgrCategories_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int id = Convert.ToInt32(dgrItems.DataKeys[e.Item.ItemIndex]);
			LinkCategory lc = Links.GetLinkCategory(id,false);
			ConfirmDelete(id, lc.Title);
		}

		private void dgrCategories_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgrItems.EditItemIndex = -1;			
			BindList();
			this.Messages.Clear();
			ToggleAddNew(true);
		}

		private void lkbPost_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
			
				LinkCategory newCategory = new LinkCategory();
				newCategory.CategoryType = _categoryType;
				newCategory.Title = txbNewTitle.Text;
				newCategory.IsActive = ckbNewIsActive.Checked;
				newCategory.Description = txbNewDescription.Text;
				newCategory.BlogID=int.Parse(BlogID.Text);
				PersistCategory(newCategory);

				BindLocalUI();
				BindList();	
				txbNewTitle.Text = string.Empty;
				ckbNewIsActive.Checked = Preferences.AlwaysCreateIsActive;
				txbNewDescription.Text = string.Empty;
			}
		}

		private void ckbNewIsActive_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}

