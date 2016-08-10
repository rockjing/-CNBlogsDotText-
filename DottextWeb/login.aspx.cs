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
using System.Web.Security;
using System.Configuration;
using Dottext.Framework.Components;
using Dottext.Framework;
using Dottext.Framework.Configuration;
using Dottext.Framework.Email;
using Dottext.Framework.Util;


namespace Dottext.Web.Pages
{
	/// <summary>
	/// Summary description for login.
	/// </summary>
	public class login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Message;
		protected System.Web.UI.WebControls.TextBox tbUserName;
		protected System.Web.UI.WebControls.TextBox tbPassword;
		protected System.Web.UI.WebControls.CheckBox chkRemember;
		protected System.Web.UI.WebControls.LinkButton lblLogin;
		protected System.Web.UI.HtmlControls.HtmlAnchor aspnetLink;
		protected System.Web.UI.WebControls.RequiredFieldValidator Required_UserName;
		protected System.Web.UI.WebControls.HyperLink lbSendPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator Required＿Password;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.Label lblImage;
		protected System.Web.UI.WebControls.TextBox CodeNumberTextBox;
		protected System.Web.UI.HtmlControls.HtmlTable tbAuthenCode;
		protected System.Web.UI.HtmlControls.HtmlImage Img1;
		private string RedirectUrl; 
		private void Page_Load(object sender, System.EventArgs e)
		{
			tbAuthenCode.Visible=Config.Settings.EnableLoginAuhenCode;
			if(!IsPostBack)
			{
				if(Request.IsAuthenticated)
				{
					Response.Redirect(Config.Settings.AggregateUrl+Context.User.Identity.Name);
				}
				
				GenerateRandomCode();

				tbUserName.Attributes.Add("onKeyPress","checkEnter(event,this)");
				tbPassword.Attributes.Add("onKeyPress","checkEnter(event,this)");
				System.IO.StreamReader sr=null;
				try
				{
					sr=new System.IO.StreamReader(MapPath("Script")+"\\LoginScript.js");
					this.RegisterClientScriptBlock("LoginScript",sr.ReadToEnd());
				}
				finally
				{
					sr.Close();
				}
			}
			#if WANRelease
					lbSendPassword.Visible = false;
					aspnetLink.Visible = true;					
			#endif
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
			this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void GenerateRandomCode()
		{
			if(Config.Settings.EnableLoginAuhenCode)
			{
				Response.Cookies["AreYouHuman"].Value = CaptchaImage.CaptchaImage.GenerateRandomCode();
			}
		}
		
		private void lblLogin_Click(object sender, System.EventArgs e)
		{
			if (Config.Settings.EnableLoginAuhenCode&&this.CodeNumberTextBox.Text != Request.Cookies["AreYouHuman"].Value)
			{

				// Display an error message.
				this.lblImage.Text = "ERROR: The code you entered was invalid, try again.";

				// Clear the input and create a new random code.
				this.CodeNumberTextBox.Text = "";
				Response.Cookies["AreYouHuman"].Value = CaptchaImage.CaptchaImage.GenerateRandomCode();
				return;
			}

			BlogConfig config=Config.GetConfig(tbUserName.Text);
			if(config==null)
			{
				Message.Text = "该用户不存在!<br>";
				GenerateRandomCode();
				return;
			}
			
			if(Security.Authenticate(tbUserName.Text,tbPassword.Text,chkRemember.Checked))
			{
				RedirectUrl=Request.QueryString["ReturnURL"];
				if(RedirectUrl != null)
				{
					Response.Redirect(RedirectUrl);
				}
				else
				{
					
					string url= Dottext.Framework.Configuration.Config.Settings.AggregateUrl+tbUserName.Text+"/";
					Response.Redirect(url);
					//Response.Redirect(Session["Login_RedirectUrl"].ToString());
				}
			}
			else
			{
				Message.Text = "密码错误!<br>";
				GenerateRandomCode();
			}
		}

		private void lbGetPassword_Click(object sender, System.EventArgs e)
		{
			tbPassword.Visible=false;
		}
	}
}

