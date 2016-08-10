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
	using Dottext.Framework.Configuration;
	using Dottext.Common.Data;

	/// <summary>
	///		PostComment1 的摘要说明。
	/// </summary>
	public class AnonymousPostComment : BaseControl
	{
		protected System.Web.UI.WebControls.TextBox tbTitle;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox tbName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox tbUrl;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.TextBox tbComment;
		protected System.Web.UI.WebControls.CheckBox chkRemember;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.HyperLink linkLoginComment;
		protected System.Web.UI.WebControls.Label Message;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.HyperLink lnkLogin;
		private const string navstr="login=1";

		protected override void OnLoad(EventArgs e)
		{
			System.IO.StreamReader sr=new System.IO.StreamReader(MapPath(Request.ApplicationPath+"/Script")+"\\CtrlEnter.js");
			try
			{
				string jsstr=sr.ReadToEnd().Replace("doPostBack();",this.Page.GetPostBackEventReference(this.btnSubmit));
				this.Page.RegisterClientScriptBlock("CtrlEnterScript",jsstr);
			}
			finally
			{
				sr.Close();
			}
			
			string url=Dottext.Framework.Util.Globals.GetAppUrl(Request);
			lnkLogin.NavigateUrl=url+"login.aspx?ReturnURL="+Request.Url.AbsoluteUri;
			tbComment.Attributes.Add("onKeyDown","ctlent()");
			if(Request.QueryString.Count>0)
			{
				linkLoginComment.NavigateUrl=Request.Url.AbsoluteUri+"&"+navstr+"#Post";

			}
			else
			{
				linkLoginComment.NavigateUrl=Request.Url.AbsoluteUri+"?"+navstr+"#Post";
			}
			if(Request.QueryString["login"]=="1")
			{
				this.Visible=false;
				return;
						
			}
			else
			{
				this.Visible=true;

			}
			base.OnLoad (e);
			tbComment.MaxLength = 4000;
		
			if(!IsPostBack)
			{
				HttpCookie user = Request.Cookies["CommentUser"];
				if(user != null)
				{
					tbName.Text = user.Values["Name"];
					tbUrl.Text = user.Values["Url"];
				}
				else
				{
					if(HttpContext.Current.Request.IsAuthenticated)
					{
						BlogConfig config=Config.GetConfig(HttpContext.Current.User.Identity.Name);
						tbName.Text=config.Author;
						tbUrl.Text=Dottext.Framework.Util.Globals.GetAppUrl(Request)+config.UserName;
						lnkLogin.Visible=false;
					}
				}

				Entry entry = Cacher.GetEntryFromRequest(Context,CacheTime.Short);	

				if(CurrentBlog.EnableComments && entry !=null && entry.AllowComments)
				{
					
					//Need to get this without a db hit?
					tbTitle.Text = "re: " + Dottext.Framework.Util.Globals.RemoveHtml(entry.Title);
				}
				else
				{
					this.Visible = false;
				}
			}
			
			
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
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
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
					entry.Author = tbName.Text;
					entry.TitleUrl =  Globals.CheckForUrl(tbUrl.Text);
					entry.Body = tbComment.Text;
					if(Security.IsAuthenticated())
					{
						entry.Body=Globals.SafeFormatWithUrl(entry.Body);
					}
					entry.Title = tbTitle.Text;
					entry.ParentID = currentEntry.EntryID;
					entry.SourceName = Dottext.Framework.Util.Globals.GetUserIpAddress(Context);
					entry.SourceUrl = currentEntry.Link;
					entry.PostType = PostType.Comment;

					try
					{
						Entries.Create(entry);
					}
					catch(BlogFailedPostException ex)
					{
						Message.Text=ex.Message;
						Message.Visible=true;
						return;
					}
					//Dottext.Framework.Entries.InsertComment(entry);

					if(chkRemember.Checked)
					{
						HttpCookie user = new HttpCookie("CommentUser");
						user.Values["Name"] = tbName.Text;
						user.Values["Url"] = tbUrl.Text;
						user.Expires = DateTime.Now.AddDays(30);
						Response.Cookies.Add(user);
					}
					
					Response.Redirect(string.Format("{0}?Pending=true#Post",Request.Path));
					//BindComments();
					
				}
				catch{}
			}
		
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
		
		}

		

	
	}
}
