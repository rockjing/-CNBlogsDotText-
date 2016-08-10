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

namespace Dottext.Web.Admin.UserControls
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Xml;

	using Dottext.Framework;
	using Dottext.Framework.Util;
	using Dottext.Framework.Components;
	using Dottext.Framework.Configuration;

	using Dottext.Web.Admin;
	using Dottext.Web.Admin.Pages;
	using Dottext.Web.Admin.WebUI;
	using Microsoft.Web.UI.WebControls;


	public class EntryEditor : System.Web.UI.UserControl
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
		protected System.Web.UI.WebControls.TextBox txbBody;
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
		protected System.Web.UI.WebControls.CheckBox chkIsMoveTo;

		protected System.Web.UI.WebControls.CheckBoxList cklCategories;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Results;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Advanced;
		protected System.Web.UI.WebControls.TextBox txbSourceName;
		protected System.Web.UI.WebControls.TextBox txbSourceUrl;
		protected System.Web.UI.WebControls.LinkButton lkbPost;
		protected System.Web.UI.WebControls.LinkButton lkbCancel;
		protected System.Web.UI.WebControls.LinkButton lkbPriview;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Edit;
		protected System.Web.UI.WebControls.RequiredFieldValidator valtbBodyRequired;
		protected System.Web.UI.WebControls.RequiredFieldValidator valftbBodyRequired;
		protected System.Web.UI.WebControls.RequiredFieldValidator valTitleRequired;
		protected System.Web.UI.WebControls.LinkButton lkbNewPost;	
		protected System.Web.UI.WebControls.TextBox txbEntryName;
		protected System.Web.UI.WebControls.LinkButton LkbPreview;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel GlobalCategory;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel MyCategory;
		protected System.Web.UI.WebControls.Panel GlobalCategoryPanel;
		protected System.Web.UI.WebControls.RegularExpressionValidator vRegexEntryName;
        //protected string RefreshID;
		private ArrayList al;

	
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
				if(Request.QueryString["opt"]=="1")
				{
					EditNewEntry();
				}
				if(Request.QueryString["postid"]!=null)
				{
					PostID=Convert.ToInt32(Request.QueryString["postid"]);
					BindPostEdit();
				}
				
			}
			BindGlobalCategoryList();
		
			
		}

		public void SetFreeTextBox()
		{
			string imgname,tmpstr;
			ftbBody.ButtonPath =  Globals.WebPathCombine(Request.ApplicationPath,FTB_RESOURCE_PATH);
			tmpstr=Config.CurrentBlog(Context).ImagePath;
			tmpstr=tmpstr.Substring(tmpstr.IndexOf("images"));
			ftbBody.ImageGalleryPath=tmpstr;//Config.CurrentBlog(Context).ImagePath;
			FreeTextBoxControls.Toolbar msntb=new FreeTextBoxControls.Toolbar();
			msntb.Items.Add(FreeTextBoxControls.ToolbarItems.Separator);
			FreeTextBoxControls.ToolbarButton tbButton;

			#region 插入msn表情
			XmlDocument myxml=new XmlDocument();
			myxml.Load(Server.MapPath(ftbBody.ButtonPath)+"emoticons.xml");
			XmlNodeList nodes=myxml.SelectNodes("/emoticons/emoticon");
			foreach(XmlNode node in nodes)
			{
				tbButton=new FreeTextBoxControls.ToolbarButton();
				tbButton.Title=node.Attributes["title"].InnerText;
				tbButton.Name=node.Attributes["name"].InnerText;
				imgname=ftbBody.ButtonPath+tbButton.Name+".gif";
				System.Drawing.Image myimg=System.Drawing.Image.FromFile(Server.MapPath(imgname));
				imgname=Globals.WebPathCombine(Request.ApplicationPath,"/Emoticons/")+tbButton.Name+".gif";
				tbButton.Height=myimg.Height;
				tbButton.Width=myimg.Width;
				tbButton.Function="FTB_"+tbButton.Name+"_ShowFace";
				tbButton.ScriptBlock = @"<script language=""JavaScript"">
				function "+tbButton.Function+@"(editor,htmlmode) {
				editor.focus();
				sel = editor.document.selection.createRange();
				sel.pasteHTML(""<img src='"+imgname+@"'>"");
				}
				</script>";
				msntb.Items.Add(tbButton);
				
				msntb.Items.Add(FreeTextBoxControls.ToolbarItems.Separator);				
					
			}

				#endregion

			#region 插入QQ表情
			
			FreeTextBoxControls.ToolbarButton qqButton = new FreeTextBoxControls.ToolbarButton("插入QQ表情","qq","FTB_InsertQQEmoticon");
			qqButton.ScriptBlock = @"<script language=""JavaScript"">
			function FTB_InsertQQEmoticon(editor,htmlmode) {
			if (htmlmode) return;
			editor.focus();

			obj = FTB_GetRangeReference(editor);
			if (obj.tagName == 'IMG') 
			{
				editor.document.execCommand('insertimage',1,'');
				return;
			}

			var folder = 'Emoticons/QQ';
			var galleryscript = '../../EmoticonsGallery.aspx?rif='+folder+'&cif='+folder;
			if (FTB_HelperFilesParameters != '') galleryscript += '&' + FTB_HelperFilesParameters;
			imgArr = showModalDialog(galleryscript,window,'help:0;status:0;resizeable:1;');

			if (imgArr != null) 
				{
					imagestring = '<IMG SRC=""' + imgArr['filename'] + '"" HEIGHT=' + imgArr['height'] + ' WIDTH=' + imgArr['width'] + ' BORDER=0>';
					sel = editor.document.selection.createRange();
					sel.pasteHTML(imagestring);
				} 
			else 
				{
			
				}
			}
			</script>";
			
			
			FreeTextBoxControls.Toolbar qqtb=new FreeTextBoxControls.Toolbar();
			qqtb.Items.Add(qqButton);				
			#endregion
			
			#region InserCode 插入代码

			
			FreeTextBoxControls.ToolbarButton CodeButton = new FreeTextBoxControls.ToolbarButton("插入代码","Code","FTB_InsertCode");
			Unit width=new Unit("50");
			CodeButton.Width=width;
			//CodeButton.ButtonTitleMode
			CodeButton.ScriptBlock = @"<script language=""JavaScript"">
			function FTB_InsertCode(editor,htmlmode)
			 {
			if (htmlmode) return;
			editor.focus();		
			var galleryscript = '../../InsertCode.aspx';
			CodeString = showModalDialog(galleryscript,window,'dialogWidth:500px; dialogHeight:400px;help:0;status:0;resizeable:1;');
			if (CodeString != null) 
			{
				sel = editor.document.selection.createRange();
				sel.pasteHTML(CodeString);
			}
			}
			</script>";
			
			
			FreeTextBoxControls.Toolbar Codetb=new FreeTextBoxControls.Toolbar();
			Codetb.Items.Add(CodeButton);	
			#endregion

			#region 恢复上次提交内容
			FreeTextBoxControls.ToolbarButton RestoreButton = new FreeTextBoxControls.ToolbarButton("恢复上次提交","restore","FTB_RestoreLastSubmit");
			width=new Unit("70");
			RestoreButton.Width=width;
			RestoreButton.ScriptBlock = @"<script language=""JavaScript"">
			function FTB_RestoreLastSubmit(editor,htmlmode)
			 {
				if(confirm('真的要恢复吗?'))
				{
					Restore(editor);
				}
			}
			</script>";
			FreeTextBoxControls.Toolbar Restoretb=new FreeTextBoxControls.Toolbar();
			Restoretb.Items.Add(RestoreButton);	
			#endregion

			#region ToolbarStr
			string toolbarStr=@"ParagraphMenu, FontFacesMenu, FontSizesMenu, FontForeColorsMenu, FontForeColorPicker, FontBackColorsMenu, FontBackColorPicker, Bold, 
			Italic, Underline, Strikethrough, Superscript, Subscript;InsertImageFromGallery, CreateLink, Unlink, RemoveFormat| 
			JustifyLeft, JustifyRight, JustifyCenter, JustifyFull;BulletedList, NumberedList, Indent, Outdent, Cut, Copy, Paste, 
			Delete;Undo, Redo, Print,ieSpellCheck, SymbolsMenu,  InsertRule, InsertDate, InsertTime, InsertTable,WordCount";
			ftbBody.Toolbars=FreeTextBoxControls.ToolbarGenerator.ToolbarsFromString(toolbarStr);//.EnableAll;
			#endregion	
		
			ftbBody.Toolbars.Add(qqtb);
			ftbBody.Toolbars.Add(Codetb);
			ftbBody.Toolbars.Add(Restoretb);
			ftbBody.Toolbars.Add(msntb);						
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
			//	PagedEntryCollection selectionList = Entries.GetPagedEntries(_entryType, _filterCategoryID, 
			//	_resultsPageNumber, ResultsPager.PageSize,true);		

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
			//显示个人分类
			cklCategories.DataSource = Links.GetCategoriesByType(CategoryType,false);
			cklCategories.DataValueField = "CategoryID";
			cklCategories.DataTextField = "Title";
			cklCategories.DataBind();
							
		}

		private void BindGlobalCategoryList()
		{
			
			//显示网站分类
			Dottext.Framework.Components.CategoryTree ct=new Dottext.Framework.Components.CategoryTree(-1);
			AbstractComponent rootnode=ct.Build();
			//GlobalCategoryTreeView.Nodes.Clear();
			//BuildCategoryTree(rootnode,GlobalCategoryTreeView.Nodes);
			GlobalCategoryPanel.Controls.Clear();
			BuildCategoryList(rootnode);
				
		}

		protected void BuildCategoryTree(AbstractComponent composite,TreeNodeCollection nodes)
		{
			TreeNode n = new TreeNode();
			TreeNodeType tnt=new TreeNodeType();
			n.Text=((LinkCategory)composite.GetObject()).Title;
			if(composite.isLeaf())
			{
				n.CheckBox=true;
				
				
			}
			nodes.Add(n);
			while(composite.GoNextChild())
			{
				BuildCategoryTree(composite.GetChild(),nodes[nodes.Count-1].Nodes);
				
			}
	
		}

		private void BuildCategoryList(AbstractComponent node)
		{
			
			if(!node.isRoot()&&!node.isLeaf())
			{
				AdvancedPanel ap=new AdvancedPanel();
				ap.ID="AdvancedPanel"+((LinkCategory)node.GetObject()).CategoryID.ToString();
				ap.HeaderText=((LinkCategory)node.GetObject()).Title;
				ap.Collapsed=false;
				ap.Collapsible=true;
				ap.LinkStyle=CollapseLinkStyle.Image;
				ap.LinkBeforeHeader=true;
				ap.DisplayHeader=true;
				ap.LinkText="[toggle]";
				ap.BodyCssClass="Edit";
				ap.HeaderCssClass="CategoryHeader";
				ap.HeaderTextCssClass="CategoryHeader";
				LinkCategoryCollection lcc=new LinkCategoryCollection();
				while(node.GoNextChild())
				{
					AbstractComponent child=node.GetChild();
					if(child.isLeaf())
					{
						lcc.Add((LinkCategory)child.GetObject());
					}
				}
				if(lcc!=null)
				{
						
					if(Config.Settings.GlobalCategorySingleSelect)
					{
						RadioButtonList rbl=new RadioButtonList();
						rbl.ID=((LinkCategory)node.GetObject()).CategoryID.ToString();
						rbl.RepeatDirection=RepeatDirection.Horizontal;
						rbl.RepeatColumns=4;
						rbl.Width=new Unit("98%");
						rbl.DataTextField="Title";
						rbl.DataValueField="CategoryID";
						rbl.DataSource=lcc;
						rbl.DataBind();
						ap.Controls.Add(rbl);
					}
					else
					{
						CheckBoxList cbl=new CheckBoxList();
						cbl.ID=((LinkCategory)node.GetObject()).CategoryID.ToString();
						cbl.RepeatDirection=RepeatDirection.Horizontal;
						cbl.RepeatColumns=4;
						cbl.Width=new Unit("98%");
						cbl.DataTextField="Title";
						cbl.DataValueField="CategoryID";
						cbl.DataSource=lcc;
						cbl.DataBind();
						ap.Controls.Add(cbl);
					}
				}
				GlobalCategoryPanel.Controls.Add(ap);
				
			}
			else
			{
				while(node.GoNextChild())
				{
					BuildCategoryList(node.GetChild());
				}
			}

		}


		private void SetConfirmation()
		{
			ConfirmationPage confirmPage = (ConfirmationPage)this.Page;
			confirmPage.IsInEdit = true;
			confirmPage.Message = "You will lose any unsaved content";

			this.lkbPost.Attributes.Add("OnClick",ConfirmationPage.ByPassFuncationName);
			this.lkbCancel.Attributes.Add("OnClick",ConfirmationPage.ByPassFuncationName);
			this.LkbPreview.Attributes.Add("OnClick",ConfirmationPage.ByPassFuncationName);
		}

		private void BindPostEdit()
		{

			SetConfirmation();
			
			Entry currentPost = Entries.GetEntry(PostID, PostConfig.Empty);
		
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
			chkSyndicateDescriptionOnly.Checked    = currentPost.SyndicateDescriptionOnly ; 
			chkIsAggregated.Checked                = currentPost.IsAggregated;

			if(currentPost.PostType==PostType.BlogPost)
			{
				chkIsMoveTo.Text="Move to Article";
				chkIsMoveTo.Visible=true;
			}
			else if(currentPost.PostType==PostType.Article)
			{
				chkIsMoveTo.Text="Move to Post";
				chkIsMoveTo.Visible=true;
			}
			else
			{
				chkIsMoveTo.Visible=false;
			}


			SetEditorText(currentPost.Body);
			ckbPublished.Checked = currentPost.IsActive;

			for (int i =0; i < cklCategories.Items.Count;i++)
				cklCategories.Items[i].Selected = false;
			
			LinkCollection postCategories = Links.GetLinkCollectionByPostID(PostID);
			
			if (postCategories.Count > 0)
			{
				for (int i = 0; i < postCategories.Count; i++)
				{
					try
					{
						cklCategories.Items.FindByValue(postCategories[i].CategoryID.ToString()).Selected = true;
						
					}
					catch{}
				}
			}
			if (postCategories.Count > 0)
			{
				for (int i = 0; i < postCategories.Count; i++)
				{
					try
					{
						TraversalControlNLR(GlobalCategoryPanel,false,postCategories[i].CategoryID.ToString());
					}
				
					catch
					{
						
					}
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
					CategoryType == CategoryType.StoryCollection ? "Article" : "Post", currentPost.Title);

				page.BreadCrumbs.AddLastItem(title);
				page.Title = title;
			}

			if(currentPost.HasEntryName)
			{
				this.Advanced.Collapsed = false;
				txbEntryName.Text = currentPost.EntryName;
			}
		}

		private void SetSelecedControl(Control control,string selectedValue)
		{
			if(control is RadioButtonList)
			{
				RadioButtonList rbl=(RadioButtonList)control;
				ListItem li=rbl.Items.FindByValue(selectedValue);
				if(li!=null)
				{
					li.Selected=true;
				}
			}
			else if(control is CheckBoxList)
			{
				CheckBoxList cbl=(CheckBoxList)control;
				ListItem li=cbl.Items.FindByValue(selectedValue);
				if(li!=null)
				{
					li.Selected=true;
				}
									
			}
			else
			{
				for(int i=0;i<control.Controls.Count;i++)
				{
					SetSelecedControl(control.Controls[i],selectedValue);
				}
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
			chkIsMoveTo.Checked=false;
			

			ftbBody.Text = String.Empty;
			txbBody.Text = String.Empty;
			
			for(int i =0; i < cklCategories.Items.Count;i++)
				cklCategories.Items[i].Selected = false;
			
			
			Advanced.Collapsed = !Preferences.AlwaysExpandAdvanced;
			BindGlobalCategoryList();
			SetEditorMode();
		}
	
		private void UpdatePost()
		{	
			if(Page.IsValid)
			{
				string successMessage = Constants.RES_SUCCESSNEW;
				try
				{
					Entry entry = new Entry(EntryType);

					entry.Title = txbTitle.Text;
					entry.Body = Globals.StripRTB(Utilities.CheckIsIE55() ? ftbBody.Text : txbBody.Text,Request.Url.Host);
					//Response.Write(entry.Body);
					entry.IsActive = ckbPublished.Checked;
					entry.SourceName = txbSourceName.Text;
					entry.Author = Config.CurrentBlog().Author;
					entry.Email = Config.CurrentBlog().Email;
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
					
					if (PostID > 0)
					{
						successMessage = Constants.RES_SUCCESSEDIT;
						entry.DateUpdated = DateTime.Now;//BlogTime.CurrentBloggerTime;
						entry.EntryID = PostID;
						entry.Link=Dottext.Framework.Configuration.Config.CurrentBlog().UrlFormats.EntryUrl(entry);
						if(chkIsMoveTo.Checked)
						{
							entry.PostType=entry.PostType^((PostType)3);
							
						}
						Entries.Update(entry);

						//Add by dudu
						if(Request.QueryString["pg"]!=null)
						{
							_resultsPageNumber=int.Parse(Request.QueryString["pg"]);
						}

						if (null != Request.QueryString[Keys.QRYSTR_CATEGORYID])
							_filterCategoryID = Convert.ToInt32(Request.QueryString[Keys.QRYSTR_CATEGORYID]);
					}
					else
					{
						entry.DateCreated = DateTime.Now;//BlogTime.CurrentBloggerTime;
						PostID = Entries.Create(entry);
					}

					if (PostID > 0)
					{
						//LinkCollection lc = new LinkCollection();
						al = new ArrayList();
						int count = cklCategories.Items.Count;
						if(chkIsMoveTo.Checked)
						{
							count=0;
						}
						//文章分类
						for (int i =0; i<count;i++)
						{
							if (cklCategories.Items[i].Selected)
							{
								al.Add(Int32.Parse(cklCategories.Items[i].Value));
							}
						}
						
						#region 网站分类
						if(CategoryType == CategoryType.PostCollection)
						{
							TraversalControlNLR(GlobalCategoryPanel,true,null);
						}
					
						#endregion
						
						int[] Categories = (int[])al.ToArray(typeof(int));
						Entries.SetEntryCategoryList(PostID,Categories);
									
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

		private void FindSelecedControl(Control control)
		{
			if(control is RadioButtonList)
			{
				RadioButtonList rbl=(RadioButtonList)control;
				al.Add(int.Parse(rbl.SelectedValue));
			}
			else if(control is CheckBoxList)
			{
				CheckBoxList cbl=(CheckBoxList)control;
				for(int j=0;j<cbl.Items.Count;j++)
				{
					if(cbl.Items[j].Selected)
					{
						al.Add(int.Parse(cbl.Items[j].Value));
					}
				}
									
			}
			else
			{
				for(int i=0;i<control.Controls.Count;i++)
				{
					FindSelecedControl(control.Controls[i]);
				}
			}
		}

		private void TraversalControlNLR(Control control,bool IsGet,string selectedValue)//深度优先前序遍历
		{
			Stack   stk = new Stack(); 
			Control ctlCurrent = control; // 当前访问的控件 
			Control ctlParent = null;  // 父控件 
			int     index = 0; // 当前控件是父控件的第i个子控件 

			do 
			{ 
				if(ctlCurrent is RadioButtonList)
				{
					RadioButtonList rbl=(RadioButtonList)ctlCurrent;
					if(IsGet)
					{
						al.Add(int.Parse(rbl.SelectedValue));
					}
					else
					{
						ListItem li=rbl.Items.FindByValue(selectedValue);
						if(li!=null)
						{
							li.Selected=true;
						}
					}
				}
				else if(ctlCurrent is CheckBoxList)
				{
					CheckBoxList cbl=(CheckBoxList)ctlCurrent;
					if(IsGet)
					{
						for(int j=0;j<cbl.Items.Count;j++)
						{
							if(cbl.Items[j].Selected)
							{
								al.Add(int.Parse(cbl.Items[j].Value));
							}
						}
					}
					else
					{
						ListItem li=cbl.Items.FindByValue(selectedValue);
						if(li!=null)
						{
							li.Selected=true;
						}
					}

									
				}

				if(ctlCurrent.Controls.Count != 0) // 访问完当前控件，优先访问子控件 
				{ 
					stk.Push(index); 
					index = 0; 
					ctlParent = ctlCurrent;  
					ctlCurrent = ctlCurrent.Controls[0];
				} 
				else if(ctlParent != null && index + 1 < ctlParent.Controls.Count)  // 存在下一个兄弟控件 
				{ 
					ctlCurrent = ctlParent.Controls[++index]; 
				} 
				else  // 没有子控件和下一个兄弟控件 
				{ 
					while(true) 
					{ 
						if(ctlParent == null || ctlParent.Equals(control)) 
						{ 
							ctlCurrent = control; 
							break; 
						} 

						ctlCurrent = ctlParent; 
						ctlParent = ctlCurrent.Parent; 
						index = (int)stk.Pop(); 

						if(ctlParent != null && index + 1 < ctlParent.Controls.Count) 
						{ 
							ctlCurrent = ctlParent.Controls[++index]; 
							break; 
						} 
					} 
				} 
			}while(!ctlCurrent.Equals(control)); 

		}

		private void SetEditorMode()
		{
			valftbBodyRequired.Visible = ftbBody.Visible = true;//Utilities.CheckIsIE55();
			valtbBodyRequired.Visible = txbBody.Visible = !ftbBody.Visible;

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
			if (Utilities.CheckIsIE55())
				ftbBody.Text = bodyValue;
			else
				txbBody.Text = bodyValue;
		}

		private void ConfirmDelete(int postID)
		{
			(Page as AdminPage).Command = new DeletePostCommand(postID);
			(Page as AdminPage).Command.RedirectUrl = Request.Url.ToString();
			(Page as AdminPage).Command.TabSectionID= ((Dottext.Web.Admin.WebUI.Page)this.Parent.Page.FindControl("PageContainer")).TabSectionID;
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
			this.rprSelectionList.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.rprSelectionList_ItemCommand);
			this.lkbPost.Click += new System.EventHandler(this.lkbPost_Click);
			this.lkbCancel.Click += new System.EventHandler(this.lkbCancel_Click);
			this.LkbPreview.Click += new System.EventHandler(this.LkbPreview_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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

		private void LkbPreview_Click(object sender, System.EventArgs e)
		{
			
			//ConfirmationPage confirmPage = (ConfirmationPage)this.Page;
			//confirmPage.IsInEdit = false;
			Entry entry=new Entry();
			entry.Title=txbTitle.Text;
			entry.Body=this.ftbBody.Text;
			Context.Cache.Insert("PreviewPost",entry);
			System.Web.UI.Page thisPage=this.Page;
			//string url=Config.CurrentBlog().FullyQualifiedUrl+"PreviewPost.aspx";
			Dottext.Framework.Util.Globals.ShowModalDialog(ref thisPage,"PreviewPost.aspx","800","600");
			SetConfirmation();
			
		
		}

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

		

	}
}

