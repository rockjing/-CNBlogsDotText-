namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using Dottext.Framework;
	using Dottext.Framework.Tracking;
	using Dottext.Framework.Components;
	using Dottext.Framework.Util;
	using Dottext.Common.Data;
	using Dottext.Framework.Configuration;
	using System.Xml;
	/// <summary>
	///		LoginPostComment 的摘要说明。
	/// </summary>
	public class LoginPostComment : BaseControl
	{
		protected System.Web.UI.WebControls.TextBox tbTitle;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected FreeTextBoxControls.FreeTextBox ftbComment;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Label Message;

		private const string FTB_RESOURCE_PATH = "/admin/resources/ftb/DotText/";
		protected System.Web.UI.WebControls.HyperLink linkReturn;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.LinkButton btnSubscibe;
		protected System.Web.UI.WebControls.LinkButton btnUnSubscibe;
		private BlogConfig blog_config=null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
		}

		protected override void OnLoad(EventArgs e)
		{
			SetFreeTextBox();		
			if(Request.QueryString["login"]=="1")
			{
				this.Visible=true;
				string tmpurl=Request.Url.AbsoluteUri;
				int index=tmpurl.IndexOf("?");
				if(index>0)
				{
					linkReturn.NavigateUrl=tmpurl.Substring(0,tmpurl.IndexOf("?"))+"#Post";
				}
			}
			else
			{
				this.Visible=false;
				return;

			}
			base.OnLoad (e);

			//tbComment.MaxLength = 4000;
			//string UserName=HttpContext.Current.User.Identity.Name;
			if(!HttpContext.Current.Request.IsAuthenticated)
			{
				string url=Dottext.Framework.Util.Globals.GetAppUrl(Request);
				Response.Redirect(url+"login.aspx?ReturnURL="+Request.Url.AbsoluteUri);
			}
			else
			{
				blog_config=Config.GetConfig(HttpContext.Current.User.Identity.Name,Context);
				//this.SetFreeTextBox();
			}
		
			if(!IsPostBack)
			{
								
				Entry entry = Cacher.GetEntryFromRequest(Context,CacheTime.Short);	
				if(Config.CurrentBlog().EnableComments && entry !=null && entry.AllowComments)
				{
					
					//Need to get this without a db hit?
					tbTitle.Text = "re: " + entry.Title;
				}
				else
				{
					this.Visible = false;
				}
			}
			
			
		}
		
		#region SetFreeTextBox
		#region 插入QQ/MSN表情
		protected FreeTextBoxControls.ToolbarButton CreateQQEmoticon()
		{
			FreeTextBoxControls.ToolbarButton qqButton = new FreeTextBoxControls.ToolbarButton("插入QQ表情","FTB_InsertQQEmoticon","qq");
			return qqButton;
		}
		protected FreeTextBoxControls.ToolbarButton CreateMSNEmoticon()
		{
			FreeTextBoxControls.ToolbarButton msnButton = new FreeTextBoxControls.ToolbarButton("插入MSN表情","FTB_InsertMSNEmoticon","msn");
			return msnButton;
		}
		protected void CreateEmoticon()
		{
			FreeTextBoxControls.Toolbar tb=new FreeTextBoxControls.Toolbar();
			tb.Items.Add(CreateMSNEmoticon());
			tb.Items.Add(CreateQQEmoticon());
			ftbComment.Toolbars.Add(tb);	
		}
	
		#endregion

		#region 插入msn表情
		protected void CreateMSNEmoticonOld()
		{
			
			FreeTextBoxControls.ToolbarButton tbButton;
			string imageName;
			FreeTextBoxControls.Toolbar msntb=new FreeTextBoxControls.Toolbar();
			XmlDocument myxml=new XmlDocument();
			myxml.Load(Server.MapPath("~/Emoticons/")+"emoticons.xml");
			XmlNodeList nodes=myxml.SelectNodes("/emoticons/emoticon");
			foreach(XmlNode node in nodes)
			{
				tbButton=new FreeTextBoxControls.ToolbarButton();
				tbButton.Title=node.Attributes["title"].InnerText;
				tbButton.ButtonImage="Emoticons/"+node.Attributes["name"].InnerText;
				imageName = Globals.WebPathCombine(Request.ApplicationPath,"/Emoticons/")+node.Attributes["name"].InnerText+".gif";
				tbButton.FunctionName="FTB_InsertMSNEmoticon_"+node.Attributes["name"].InnerText;
				tbButton.ScriptBlock = @"<script language=""JavaScript"">
						function "+tbButton.FunctionName+@"(ftbName) {
						editor=eval(ftbName + '_Editor');
						
						}
						</script>";
				msntb.Items.Add(tbButton);
			}
			ftbComment.Toolbars.Add(msntb);
		}
		#endregion

		public void SetFreeTextBox()
		{
			string app=Request.ApplicationPath;
			if(!app.EndsWith("/"))
			{
				app+="/";
			}
			FreeTextBoxControls.Toolbar tb=new FreeTextBoxControls.Toolbar();
			ftbComment.SupportFolder = app+"FreeTextBox/";
			string code = @"
			returnstr=showModalDialog( '../../InsertCode.aspx',window,'dialogWidth:500px; dialogHeight:400px;help:0;status:0;resizeable:1;');
			if(returnstr!=null&&returnstr!='')
			{ 
			FTB_InsertText('"+ftbComment.ClientID+"',returnstr)}";
			FreeTextBoxControls.ToolbarButton CodeButton = new FreeTextBoxControls.ToolbarButton("插入代码",code,"Code");
			CodeButton.ButtonImage="Code";
			tb.Items.Add(CodeButton);
			CreateEmoticon();
			ftbComment.Toolbars.Add(tb);
		}
		#endregion

		

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
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnSubscibe.Click += new System.EventHandler(this.btnSubscibe_Click);
			this.btnUnSubscibe.Click += new System.EventHandler(this.btnUnSubscibe_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				try
				{

					Entry currentEntry =  Cacher.GetEntryFromRequest(Context,CacheTime.Short);	
					Entry entry = new Entry(PostType.Comment);
					
					entry.Author = blog_config.Author;
					entry.TitleUrl =blog_config.FullyQualifiedUrl;
					entry.Body =Dottext.Framework.Util.Globals.FilterScript(ftbComment.Text);
					entry.Title = tbTitle.Text;
					entry.ParentID = currentEntry.EntryID;
					entry.SourceName = Dottext.Framework.Util.Globals.GetUserIpAddress(Context);
					entry.SourceUrl = currentEntry.Link;
					entry.PostType = PostType.Comment;
					entry.BlogID=blog_config.BlogID;
					
					Entries.Create(entry);
					//Dottext.Framework.Entries.InsertComment(entry);
					
					/*if(chkPostAdvanced.Checked)
					{
						HttpCookie CommentMode = new HttpCookie("CommentMode","1");
						CommentMode.Expires = DateTime.Now.AddDays(30);
						Response.Cookies.Add(CommentMode);
					}*/
					Response.Redirect(string.Format("{0}?Pending=true#Post",Request.Path));
					//Response.Write(ftbComment.Text);
				}
				catch{}
			}
		}

		private void btnSubscibe_Click(object sender, System.EventArgs e)
		{
			BlogConfig SenderBlogConfig=Config.GetConfig(System.Web.HttpContext.Current.User.Identity.Name);
			Entry entry =  Cacher.GetEntryFromRequest(Context,CacheTime.Short);
			Entries.InsertNotifySubscibe(entry.EntryID,entry.BlogID,SenderBlogConfig.BlogID,SenderBlogConfig.NotifyMail);
			Message.Text="订阅成功";
		}

		private void btnUnSubscibe_Click(object sender, System.EventArgs e)
		{
			BlogConfig SenderBlogConfig=Config.GetConfig(System.Web.HttpContext.Current.User.Identity.Name);
			Entry entry =  Cacher.GetEntryFromRequest(Context,CacheTime.Short);
			Entries.DeleteMailNotify(entry.EntryID,SenderBlogConfig.BlogID);
			Message.Text="已取消订阅";
		}
	}
}
