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

namespace Dottext.Web
{
	/// <summary>
	/// GetMyPassword 的摘要说明。
	/// </summary>
	public class GetMyPassword : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbUserName;
		protected System.Web.UI.WebControls.RequiredFieldValidator Required_UserName;
		protected System.Web.UI.WebControls.TextBox tbMail;
		protected System.Web.UI.WebControls.RequiredFieldValidator Required_tbMail;
		protected System.Web.UI.WebControls.LinkButton lblGetPwd;
		protected System.Web.UI.WebControls.HyperLink hlReturn;
		protected System.Web.UI.WebControls.Label Message;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
			this.lblGetPwd.Click += new System.EventHandler(this.lblGetPwd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lblGetPwd_Click(object sender, System.EventArgs e)
		{
			BlogConfig config = Config.GetConfig(tbUserName.Text);//.CurrentBlog(Context);
			if(config!=null)//string.Compare(tbUserName.Text,config.UserName,true) == 0)
			{
				if(tbMail.Text!=config.Email)
				{
					Message.Text = "用户名与邮件地址不一致,无法取回密码";
					return;
				}
				BlogConfigurationSettings settings = Config.Settings;
				string password = null;
				if(config.IsPasswordHashed)
				{
					password = Security.ResetPassword(config);
					
				}
				else
				{
					password = config.Password;
				}
				
				string message = "你的登录帐户:\n用户名: {0}\n密码: {1}\n\n博客园:{2}";
				string mainurl=Dottext.Framework.Configuration.Config.Settings.AggregateUrl;//ConfigurationSettings.AppSettings["AggregateUrl"];
				IMailProvider mail = Dottext.Framework.Providers.EmailProvider.Instance();
			
				string To = config.Email;
				string From = mail.AdminEmail;
				string Subject = "你的博客园登录信息";
				string Body = string.Format(message,config.UserName,password,mainurl);
				mail.Send(To,From,Subject,Body);
				//Message.Text = "Login Credentials Sent<br>";
				Message.Text = "新密码已发至你的邮箱";
			}
			else
			{
				Message.Text = "该用户不存在";
			}
		}

	}
}
