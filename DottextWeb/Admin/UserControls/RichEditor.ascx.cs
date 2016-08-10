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
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Dottext.Framework;
using Dottext.Framework.Util;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;

using Dottext.Web.Admin;
using Dottext.Web.Admin.Pages;
using Dottext.Web.Admin.WebUI;

namespace Dottext.Web.Admin.UserControls
{
	public class RichEditor : System.Web.UI.UserControl
	{
		private const string FTB_RESOURCE_PATH = "/admin/resources/ftb/DotText/";
		private const string VSKEY_POSTID = "PostID";
		private const string VSKEY_CATEGORYID = "CategoryID";
		private const string VSKEY_CATEGORYTYPE = "CategoryType";

		private int _filterCategoryID = Constants.NULL_CATEGORYID;
		private int _resultsPageNumber = 1;
		private PostType _entryType = PostType.BlogPost;
		private bool _isListHidden = false;

		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected System.Web.UI.WebControls.Repeater rprSelectionList;
		protected System.Web.UI.HtmlControls.HtmlGenericControl NoMessagesLabel;
		protected Dottext.Web.Admin.WebUI.Pager ResultsPager;
		protected System.Web.UI.WebControls.HyperLink hlEntryLink;
		protected System.Web.UI.WebControls.TextBox txbTitle;
		protected FreeTextBoxControls.FreeTextBox ftbBody;
		protected System.Web.UI.WebControls.Button Post;
		protected System.Web.UI.WebControls.TextBox txbExcerpt;
		protected System.Web.UI.WebControls.TextBox txbTitleUrl;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.CheckBox ckbPublished;
		protected System.Web.UI.WebControls.CheckBox chkComments;
		protected System.Web.UI.WebControls.CheckBox chkDisplayHomePage;
		protected System.Web.UI.WebControls.CheckBox chkMainSyndication;
		protected System.Web.UI.WebControls.CheckBox chkSyndicateDescriptionOnly;
		protected System.Web.UI.WebControls.CheckBox chkIsAggregated;

		protected System.Web.UI.WebControls.CheckBoxList cklCategories;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Results;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Advanced;
		protected System.Web.UI.WebControls.TextBox txbSourceName;
		protected System.Web.UI.WebControls.TextBox txbSourceUrl;
		protected System.Web.UI.WebControls.LinkButton lkbPost;
		protected System.Web.UI.WebControls.LinkButton lkbCancel;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Edit;
		protected System.Web.UI.WebControls.RequiredFieldValidator valftbBodyRequired;
		protected System.Web.UI.WebControls.RequiredFieldValidator valTitleRequired;
		protected System.Web.UI.WebControls.LinkButton lkbNewPost;	
		protected System.Web.UI.WebControls.TextBox txbEntryName;

		protected System.Web.UI.WebControls.Panel GlobalCategoriesSection;
		protected System.Web.UI.WebControls.RegularExpressionValidator vRegexEntryName;
		protected System.Web.UI.WebControls.CheckBoxList chkGlobalCategories;
	
		#region Accessors
		// REFACTOR: are all of these still relevant when done?
		public PostType EntryType
		{
			get { return _entryType; }
			set { _entryType = value; }
		}

		public int PostID
		{
			get
			{
				if(ViewState[VSKEY_POSTID] != null)
					return (int)ViewState[VSKEY_POSTID];
				else
					return Constants.NULL_POSTID;
			}
			set { ViewState[VSKEY_POSTID] = value; }
		}

		private int CategoryID
		{
			get
			{
				if(ViewState[VSKEY_CATEGORYID] != null)
					return (int)ViewState[VSKEY_CATEGORYID];
				else
					return Constants.NULL_CATEGORYID;
			}
			set { ViewState[VSKEY_CATEGORYID] = value; }
		}

		public CategoryType CategoryType
		{
			get
			{
				if(ViewState[VSKEY_CATEGORYTYPE] != null)
					return (CategoryType)ViewState[VSKEY_CATEGORYTYPE];
				else
					throw new ApplicationException("CategoryType was not set");
			}
			set 
			{ 
				ViewState[VSKEY_CATEGORYTYPE] = value; 
			}
		}

		public bool IsListHidden
		{
			get { return _isListHidden; }
			set { _isListHidden = value; }
		}

		public string ResultsTitle 
		{
			get
			{
				return Results.HeaderText;
			}
			set 
			{ 
				Results.HeaderText = value; 
			}
		}

		public string ResultsUrlFormat
		{
			set
			{
				this.ResultsPager.UrlFormat = value;
			}
		}
		
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{	
			if (!IsPostBack)
			{
				if (null != Request.QueryString[Keys.QRYSTR_PAGEINDEX])
					_resultsPageNumber = Convert.ToInt32(Request.QueryString[Keys.QRYSTR_PAGEINDEX]);

				if (null != Request.QueryString[Keys.QRYSTR_CATEGORYID])
					_filterCategoryID = Convert.ToInt32(Request.QueryString[Keys.QRYSTR_CATEGORYID]);

				ResultsPager.PageSize = Preferences.ListingItemCount;
				ResultsPager.PageIndex = _resultsPageNumber;
				Results.Collapsible = false;

				if (Constants.NULL_CATEGORYID != _filterCategoryID)
					ResultsPager.UrlFormat += String.Format("&{0}={1}",
						Keys.QRYSTR_CATEGORYID, _filterCategoryID);
				
				BindList();
				BindCategoryList();
				SetEditorMode();

				// TODO: Replace
				//ftbBody.ButtonPath =  Globals.WebPathCombine(Request.ApplicationPath, FTB_RESOURCE_PATH);
			}			
		}
		
		private void BindList()
		{
			Edit.Visible = false;

			PagedEntryQuery query = new	PagedEntryQuery();
			query.PostType = _entryType;
			query.CategoryID = _filterCategoryID;
			query.PageIndex = _resultsPageNumber;
			query.PageSize = ResultsPager.PageSize;
			query.PostConfig = PostConfig.Empty;
			
			PagedEntryCollection selectionList = Entries.GetPagedEntryCollection(query);

			if (selectionList.Count > 0)
			{				
				ResultsPager.ItemCount = selectionList.MaxItems;
				rprSelectionList.DataSource = selectionList;
				rprSelectionList.DataBind();
				NoMessagesLabel.Visible = false;
			}

			NoMessagesLabel.Visible = selectionList.Count <= 0;
			ResultsPager.Visible = selectionList.Count > 0;
			
		}

		private void BindCategoryList()
		{
			cklCategories.DataSource = Links.GetCategoriesByType(CategoryType,false);
			cklCategories.DataValueField = "CategoryID";
			cklCategories.DataTextField = "Title";
			cklCategories.DataBind();

			if(Config.Settings.EnableGlobalCategories)
			{
				this.GlobalCategoriesSection.Visible = true;
				this.chkGlobalCategories.DataSource = Links.GetGlobalCategoriesByType(CategoryType,true);
				chkGlobalCategories.DataValueField = "CategoryID";
				chkGlobalCategories.DataTextField = "Title";
				chkGlobalCategories.DataBind();
			}
		}

		private void SetConfirmation()
		{
			ConfirmationPage confirmPage = (ConfirmationPage)this.Page;
			confirmPage.IsInEdit = true;
			confirmPage.Message = "You will lose any unsaved content";

			this.lkbPost.Attributes.Add("OnClick",ConfirmationPage.ByPassFuncationName);
			this.lkbCancel.Attributes.Add("OnClick",ConfirmationPage.ByPassFuncationName);
		}

		private void BindPostEdit()
		{
			SetConfirmation();
			
			CategoryEntry currentPost = Entries.GetCategoryEntry(PostID, PostConfig.Empty);
		
			Results.Collapsed = true;
			Edit.Visible = true;
			txbTitle.Text = currentPost.Title;

			txbExcerpt.Text = currentPost.Description;
			txbSourceUrl.Text = currentPost.SourceUrl;
			txbSourceName.Text = currentPost.SourceName;	

			hlEntryLink.NavigateUrl = currentPost.Link;
			hlEntryLink.Text = currentPost.Link;
			hlEntryLink.Attributes.Add("title", "view: " + currentPost.Title);
			hlEntryLink.Visible = true;

			chkComments.Checked                    = currentPost.AllowComments;	
			chkDisplayHomePage.Checked             = currentPost.DisplayOnHomePage;
			chkMainSyndication.Checked             = currentPost.IncludeInMainSyndication;  
			chkSyndicateDescriptionOnly.Checked    = currentPost.SyndicateDescriptionOnly; 
			chkIsAggregated.Checked                = currentPost.IsAggregated;
			
			SetEditorText(currentPost.Body);

			ckbPublished.Checked = currentPost.IsActive;

			for (int i =0; i < cklCategories.Items.Count;i++)
				cklCategories.Items[i].Selected = false;

			if (currentPost.Categories != null && currentPost.Categories.Length > 0)
			{
				for (int i = 0; i < currentPost.Categories.Length; i++)
				{
					try
					{
						cklCategories.Items.FindByText(currentPost.Categories[i]).Selected = true;
					}
					catch{}
				}
			}

			string[] currentGlobal = Links.GetGlobalCategoriesByEntryID(currentPost.EntryID,true);
			if(currentGlobal != null && currentGlobal.Length > 0)
			{
				for(int i = 0; i<currentGlobal.Length; i++)
				{
					try
					{
						chkGlobalCategories.Items.FindByText(currentGlobal[i]).Selected = true;
					}
					catch{}
				}
			}

			SetEditorMode();
			Results.Collapsible = true;
			Advanced.Collapsed = !Preferences.AlwaysExpandAdvanced;

			Control container = Page.FindControl("PageContainer");
			if (null != container && container is Dottext.Web.Admin.WebUI.Page)
			{	
				Dottext.Web.Admin.WebUI.Page page = (Dottext.Web.Admin.WebUI.Page)container;
				string title = String.Format("Editing {0} \"{1}\"", 
					CategoryType == CategoryType.StoryCollection ? "Article" : "Post", Server.HtmlEncode(currentPost.Title));

				page.BreadCrumbs.AddLastItem(title);
				page.Title = title;
			}

			if(currentPost.HasEntryName)
			{
				this.Advanced.Collapsed = false;
				txbEntryName.Text = currentPost.EntryName;
			}
		}

		public void EditNewEntry()
		{
			ResetPostEdit(true);
			SetConfirmation();
		}

		private void ResetPostEdit(bool showEdit)
		{
			PostID = Constants.NULL_POSTID;

			Results.Collapsible = showEdit;
			Results.Collapsed = showEdit;
			Edit.Visible = showEdit;
			
			hlEntryLink.NavigateUrl = String.Empty;
			hlEntryLink.Attributes.Clear();
			hlEntryLink.Visible = false;
			txbTitle.Text = String.Empty;
			txbExcerpt.Text = String.Empty;
			txbSourceUrl.Text = String.Empty;
			txbSourceName.Text = String.Empty;
			txbEntryName.Text = string.Empty;

			ckbPublished.Checked = Preferences.AlwaysCreateIsActive;
			chkComments.Checked = true;
			chkDisplayHomePage.Checked = true;
			chkMainSyndication.Checked = true;
			chkSyndicateDescriptionOnly.Checked = false;
			chkIsAggregated.Checked = true;

			ftbBody.Text = String.Empty;

			for(int i =0; i < cklCategories.Items.Count;i++)
				cklCategories.Items[i].Selected = false;

			Advanced.Collapsed = !Preferences.AlwaysExpandAdvanced;

			SetEditorMode();
		}
	
		private void UpdatePost()
		{	
			if(Page.IsValid)
			{
				string successMessage = Constants.RES_SUCCESSNEW;

				try
				{
					BlogUser currentUser = Users.CurrentUser(Context);

					Entry entry = new Entry(EntryType);

					entry.Title = txbTitle.Text;
					entry.Body = Globals.StripRTB(ftbBody.Text, Request.Url.Host);
					entry.IsActive = ckbPublished.Checked;
					entry.SourceName = txbSourceName.Text;

					// GC, ehhh. This should really be something akin to blog_Config.AuthorName...
					entry.Author = currentUser.DisplayName;
					entry.Email = currentUser.DisplayEmail;

					entry.SourceUrl = txbSourceUrl.Text;
					entry.Description = txbExcerpt.Text;
					entry.TitleUrl = txbTitleUrl.Text;

					entry.AllowComments = chkComments.Checked;
					entry.DisplayOnHomePage = chkDisplayHomePage.Checked;
					entry.IncludeInMainSyndication = chkMainSyndication.Checked;
					entry.SyndicateDescriptionOnly = chkSyndicateDescriptionOnly.Checked;
					entry.IsAggregated = chkIsAggregated.Checked;
					entry.EntryName = txbEntryName.Text;

					entry.BlogID = Config.CurrentBlog(Context).BlogID;

					ArrayList al = new ArrayList();
					int count = cklCategories.Items.Count;
						
					for (int i =0; i<count;i++)
					{
						if (cklCategories.Items[i].Selected)
						{
							al.Add(cklCategories.Items[i].Text);
						}
					}						
					string[] Categories = this.CategoryArray(cklCategories);					
					string[] GlobalCategoires = this.CategoryArray(this.chkGlobalCategories);					
				
					if (PostID > 0)
					{
						successMessage = Constants.RES_SUCCESSEDIT;
						entry.DateUpdated = BlogTime.CurrentBloggerTime;
						entry.EntryID = PostID;
						Entries.Update(entry,Categories,GlobalCategoires);
					}
					else
					{
						entry.DateCreated = BlogTime.CurrentBloggerTime;
						PostID = Entries.Create(entry,Categories,GlobalCategoires);
					}

					if (PostID > 0)
					{
					
						BindList();
						this.Messages.ShowMessage(successMessage);
						this.ResetPostEdit(false);
					}
					else
						this.Messages.ShowError(Constants.RES_FAILUREEDIT 
							+ " There was a baseline problem posting your entry.");
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
		}
	

		private string[] CategoryArray(CheckBoxList cbl)
		{
			ArrayList al = new ArrayList();
			int count = cbl.Items.Count;
						
			for (int i =0; i<count;i++)
			{
				if (cbl.Items[i].Selected)
				{
					al.Add(cbl.Items[i].Text);
				}
			}						
			return (string[])al.ToArray(typeof(string));

		}

		private void SetEditorMode()
		{
			valftbBodyRequired.Visible = ftbBody.Visible = Utilities.CheckIsBrowserIEorGecko();

			if(CategoryType == CategoryType.StoryCollection)
			{
				this.chkDisplayHomePage.Visible = false;
				this.chkIsAggregated.Visible = false;
				this.chkMainSyndication.Visible =false;
				this.chkSyndicateDescriptionOnly.Visible = false;				
			}
		}

		private void SetEditorText(string bodyValue)
		{
			ftbBody.Text = bodyValue;
		}

		private void ConfirmDelete(int postID)
		{
			(Page as AdminPage).Command = new DeletePostCommand(postID);
			(Page as AdminPage).Command.RedirectUrl = Request.Url.ToString();
			Server.Transfer(Constants.URL_CONFIRM);
		}

		public string CheckHiddenStyle()
		{
			if (_isListHidden)
				return Constants.CSSSTYLE_HIDDEN;
			else
				return String.Empty;
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

		private void rprSelectionList_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{				
			switch (e.CommandName.ToLower()) 
			{
				case "edit" :
					PostID = Convert.ToInt32(e.CommandArgument);
					BindPostEdit();
					break;
				case "delete" :
					ConfirmDelete(Convert.ToInt32(e.CommandArgument));
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
			UpdatePost();
		}

		private void lkbNewPost_Click(object sender, System.EventArgs e)
		{
			ResetPostEdit(true);
		}
	}
}

