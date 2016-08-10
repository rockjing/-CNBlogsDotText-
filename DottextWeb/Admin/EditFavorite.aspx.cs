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
using Dottext.Framework.Configuration;


namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// MyFavorite 的摘要说明。
	/// </summary>
	public class EditFavorite : AdminPage
	{
		private const string VSKEY_CATEGORYID = "CategoryID";
		private const string VSKEY_LINKID = "LinkID";

		private int _filterCategoryID
		{
			get
			{
				if(ViewState["_filterCategoryID"] == null)
				{
					return Constants.NULL_CATEGORYID;
				}
				else
				{
					return (int)ViewState["_filterCategoryID"];
				}
			}
			set
			{
				ViewState["_filterCategoryID"] = value;
			}
		}
		private int _resultsPageNumber = 1;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected System.Web.UI.WebControls.Repeater rprSelectionList;
		protected Dottext.Web.Admin.WebUI.Pager ResultsPager;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Results;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
		protected System.Web.UI.WebControls.Label lblEntryID;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txbTitle;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.TextBox txbUrl;
		protected System.Web.UI.WebControls.DropDownList ddlCategories;
		protected System.Web.UI.WebControls.CheckBox ckbIsActive;
		protected System.Web.UI.WebControls.CheckBox chkNewWindow;
		protected System.Web.UI.WebControls.LinkButton lkbPost;
		protected System.Web.UI.WebControls.LinkButton lkbCancel;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Edit;
		protected System.Web.UI.WebControls.TextBox txbRss;
		
		private bool _isListHidden = false;

	
	
		#region Accessors
		private int CategoryID
		{
			get
			{
				if (null != ViewState[VSKEY_CATEGORYID])
					return (int)ViewState[VSKEY_CATEGORYID];
				else
					return Constants.NULL_CATEGORYID;
			}
			set { ViewState[VSKEY_CATEGORYID] = value; }
		}

		public int LinkID
		{
			get
			{
				if(ViewState[VSKEY_LINKID] != null)
					return (int)ViewState[VSKEY_LINKID];
				else
					return Constants.NULL_LINKID;
			}
			set { ViewState[VSKEY_LINKID] = value; }
		}
	
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			BindLocalUI();

			if (!IsPostBack)
			{
				if (null != Request.QueryString[Keys.QRYSTR_PAGEINDEX])
					_resultsPageNumber = Convert.ToInt32(Request.QueryString[Keys.QRYSTR_PAGEINDEX]);

				if (null != Request.QueryString[Keys.QRYSTR_CATEGORYID])
				{
					_filterCategoryID = Convert.ToInt32(Request.QueryString[Keys.QRYSTR_CATEGORYID]);
				}
				//LinkCategoryCollection categorys=Links.GetCategoriesByType(CategoryType.FavoriteCollention,true);
				//Edit.Visible=false;
				//_filterCategoryID=categorys[0].CategoryID;
				ResultsPager.PageSize = Preferences.ListingItemCount;
				ResultsPager.PageIndex = _resultsPageNumber;
				Results.Collapsible = false;

				if (Constants.NULL_CATEGORYID != _filterCategoryID)
					ResultsPager.UrlFormat += String.Format("&{0}={1}", Keys.QRYSTR_CATEGORYID, 
						_filterCategoryID);
				
				BindList();
				if(Request.QueryString["opt"]=="1")
				{
					ResetPostEdit(true);
				}
				//BindImportExportCategories();
			}	
		}

		

		private void BindLocalUI()
		{
			LinkButton lkbNewLink = Utilities.CreateLinkButton("添加收藏文文章");
			lkbNewLink.Click += new System.EventHandler(lkbNewLink_Click);
			lkbNewLink.CausesValidation =false;
			PageContainer.AddToActions(lkbNewLink);
			string strEditCateUrl=String.Format("EditCategories.aspx?{0}={1}",Keys.QRYSTR_CATEGORYID,((int)CategoryType.FavoriteCollention).ToString());
			//ViewState["CategoryType"]=CategoryType.FavoriteCollention;
			HyperLink hlEditCategories = Utilities.CreateHyperLink("Edit Categories",strEditCateUrl);
			PageContainer.AddToActions(hlEditCategories);
		}

		private void BindList()
		{
			Edit.Visible = false;
			PagedLinkCollection selectionList=null,tmp_selectionList=null;
			if(_filterCategoryID==Constants.NULL_CATEGORYID)
			{
				LinkCategoryCollection categorys=null;
				categorys=Links.GetCategoriesByType(CategoryType.FavoriteCollention,false);
				
				if(categorys.Count==0)
				{
					return;
				}
				for(int i=0;i<categorys.Count;i++)
				{
					if(i==0)
					{
						selectionList = Links.GetPagedLinks(categorys[i].CategoryID, _resultsPageNumber,ResultsPager.PageSize,true);
					}
					else
					{
						tmp_selectionList=Links.GetPagedLinks(categorys[i].CategoryID, _resultsPageNumber,ResultsPager.PageSize,true);
						selectionList.AddRange(tmp_selectionList);
					}
				}
			}
			else
			{
				selectionList = Links.GetPagedLinks(_filterCategoryID, _resultsPageNumber,ResultsPager.PageSize,true);
			}
			
		
			if (selectionList.Count > 0)
			{
				ResultsPager.ItemCount = selectionList.MaxItems;
				
				rprSelectionList.DataSource = selectionList;
				rprSelectionList.DataBind();
			}
			else
			{
				// TODO: no existing items handling. add label and indicate no existing items. pop open edit.
			}
		}

		private void BindLinkEdit()
		{
			Link currentLink = Links.GetSingleLink(LinkID);
		
			Results.Collapsed = true;
			Results.Collapsible = true;
			//			ImportExport.Visible = false;
			Edit.Visible = true;

			lblEntryID.Text = currentLink.LinkID.ToString();
			txbTitle.Text = currentLink.Title;
			txbUrl.Text = currentLink.Url;
			//txbRss.Text = currentLink.Rss;
		
			chkNewWindow.Checked = currentLink.NewWindow;
			ckbIsActive.Checked = currentLink.IsActive;

			BindLinkCategories();
			ddlCategories.Items.FindByValue(currentLink.CategoryID.ToString()).Selected = true;

			Control container = Page.FindControl("PageContainer");
			if (null != container && container is Dottext.Web.Admin.WebUI.Page)
			{	
				Dottext.Web.Admin.WebUI.Page page = (Dottext.Web.Admin.WebUI.Page)container;
				string title = String.Format("Editing Link \"{0}\"", currentLink.Title);

				page.BreadCrumbs.AddLastItem(title);
				page.Title = title;
			}
		}

		public void BindLinkCategories()
		{
			LinkCategoryCollection selectionList = Links.GetCategoriesByType(CategoryType.FavoriteCollention, false);
			if(selectionList != null && selectionList.Count != 0)
			{
				ddlCategories.DataSource = selectionList;
				ddlCategories.DataValueField = "CategoryID";
				ddlCategories.DataTextField = "Title";
				ddlCategories.DataBind();
			}
			else
			{
				this.Messages.ShowError("You need to add a category before you can add links! Click \"Edit Categories\"");
				Edit.Visible = false;
			}

		}

		private void UpdateLink()
		{					
			string successMessage = Constants.RES_SUCCESSNEW;

			try
			{
				Link link = new Link();

				link.Title = txbTitle.Text;				
				link.Url = txbUrl.Text;
				//link.Rss = txbRss.Text;
				link.IsActive = ckbIsActive.Checked;
				link.CategoryID = Convert.ToInt32(ddlCategories.SelectedItem.Value);
				link.NewWindow = chkNewWindow.Checked;
				link.BlogID = Config.CurrentBlog().BlogID;
				
				if (LinkID > 0)
				{
					successMessage = Constants.RES_SUCCESSEDIT;
					link.LinkID = LinkID;
					Links.UpdateLink(link);
				}
				else
				{
					LinkID = Links.CreateLink(link);
				}

				if (LinkID > 0)
				{			
					BindList();
					this.Messages.ShowMessage(successMessage);
				}
				else
					this.Messages.ShowError(Constants.RES_FAILUREEDIT 
						+ " There was a baseline problem posting your link.");
			}
			catch(Exception ex)
			{
				this.Messages.ShowError(String.Format(Constants.RES_EXCEPTION, 
					Constants.RES_FAILUREEDIT, ex.Message));
			}
			finally
			{
				Results.Collapsible = false;
			}
		}

		private void ResetPostEdit(bool showEdit)
		{
			LinkID = Constants.NULL_LINKID;

			Results.Collapsible = showEdit;
			Results.Collapsed = showEdit;
			//ImportExport.Visible = !showEdit;
			Edit.Visible = showEdit;

			lblEntryID.Text = String.Empty;
			txbTitle.Text = String.Empty;
			txbUrl.Text = String.Empty;
			//txbRss.Text = String.Empty;
			chkNewWindow.Checked = chkNewWindow.Checked;//false;

			ckbIsActive.Checked = Preferences.AlwaysCreateIsActive;

			if (showEdit)
				BindLinkCategories();
	
			ddlCategories.SelectedIndex = -1;
		}

		private void ConfirmDelete(int linkID, string linkTitle)
		{
			this.Command = new DeleteLinkCommand(linkID, linkTitle);
			this.Command.RedirectUrl = Request.Url.ToString();
			this.Command.TabSectionID=this.PageContainer.TabSectionID;
			Server.Transfer(Constants.URL_CONFIRM);
		}

		

		// REFACTOR
		public string CheckHiddenStyle()
		{
			if (_isListHidden)
				return Constants.CSSSTYLE_HIDDEN;
			else
				return String.Empty;
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.rprSelectionList.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.rprSelectionList_ItemCommand);
			this.lkbPost.Click += new System.EventHandler(this.lkbPost_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void rprSelectionList_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
			switch (e.CommandName.ToLower()) 
			{
				case "edit" :
					LinkID = Convert.ToInt32(e.CommandArgument);
					BindLinkEdit();
					break;
				case "delete" :
					int id = Convert.ToInt32(e.CommandArgument);
					Link link = Links.GetSingleLink(id);
					ConfirmDelete(id, link.Title);
					break;
				default:
					break;
			}			
		}

		private void lkbCancel_Click(object sender, System.EventArgs e)
		{
			ResetPostEdit(false);
		}

		private void lkbPost_Click(object sender, System.EventArgs e)
		{
			UpdateLink();
		}

		private void lkbNewLink_Click(object sender, System.EventArgs e)
		{
			ResetPostEdit(true);
		}
	}
}
