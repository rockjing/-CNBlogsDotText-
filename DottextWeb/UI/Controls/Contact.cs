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

namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Web.UI;
	using Dottext.Framework;
	using Dottext.Framework.Components;
	using Dottext.Framework.Configuration;
	using Dottext.Framework.Email;


	public  class Contact : Dottext.Web.UI.Controls.BaseControl
	{
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnSend;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox tbMessage;
		protected System.Web.UI.WebControls.TextBox tbSubject;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox tbEmail;
		protected System.Web.UI.WebControls.TextBox tbName;

		override protected void OnInit(EventArgs e)
		{
			if(HttpContext.Current.Request.IsAuthenticated)
			{
				BlogConfig config=Config.GetConfig(HttpContext.Current.User.Identity.Name);
				tbName.Text=config.Author;
				tbEmail.Text=config.Email;
			}
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			base.OnInit(e);
			if(Request.QueryString["id"]=="1")
			{
				btnSend.Text="发送留言";
				CheckBox ckb=new CheckBox();
				ckb.Text="私人留言";
				ckb.ID="chkIsPrivate";
				Controls.Add(ckb);
			}
		}
		

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				if(Request.QueryString["id"]=="1")
				{
					SendMessage();
					
				}
				else
				{
					SendMail();
				}
			}
		}

		private void SendMail()
		{
			IMailProvider email = Dottext.Framework.Providers.EmailProvider.Instance();
			BlogConfig config = Config.CurrentBlog(Context);
			string To = config.Email;
			string From = tbEmail.Text;
				
			string Subject = String.Format("{0} (via {1})", tbSubject.Text, 
				config.Title);
			//Response.Write(email.SmtpServer);
			string sendersIpAddress = Dottext.Framework.Util.Globals.GetUserIpAddress(Context);

			// \n by itself has issues with qmail (unix via openSmtp), \r\n should work on unix + wintel
			string Body = String.Format("Mail from {0}:\r\n\r\nSender: {1}\r\nEmail: {2}\r\nIP Address: {3}\r\n=====================================\r\n{4}", 
				config.Title,
				tbName.Text,
				tbEmail.Text,
				sendersIpAddress,
				tbMessage.Text);				

			if(email.Send(To,From,Subject,Body))
			{
				lblMessage.Text = "你的邮件已经被发送.";
				tbName.Text = "";
				tbEmail.Text = "";
				tbSubject.Text = "";
				tbMessage.Text = "";
			}
			else
			{
				lblMessage.Text = "你的邮件不能被发送, 可能是邮件服务器出现了问题.";
			}

		}

		private void SendMessage()
		{
			Entry entry = new Entry();
			entry.Author = Dottext.Framework.Util.Globals.SafeFormat(tbName.Text);
			entry.Title=Dottext.Framework.Util.Globals.SafeFormat(tbSubject.Text);
			entry.Body = Dottext.Framework.Util.Globals.SafeFormat(tbMessage.Text);
			entry.PostType = PostType.Message;
			entry.Email=tbEmail.Text;
			entry.DateCreated=DateTime.Now;
            Control con=FindControl("chkIsPrivate");
			if(con!=null)
			{
				if(!((CheckBox)con).Checked)
				{
					entry.PostConfig=PostConfig.DisplayOnHomePage|PostConfig.IsActive|PostConfig.AllowComments;
				}
			}
			int PostID=Entries.Create(entry);
			if(PostID>0)
			{
				lblMessage.Text = "你的留言已经被发送.";
				IMailProvider email = Dottext.Framework.Providers.EmailProvider.Instance();
				BlogConfig config = Config.CurrentBlog(Context);
				string To = config.Email;
				string From = email.AdminEmail;
				string Subject = "你有新留言";
				string viewmsg=config.FullyQualifiedUrl+"admin/MyMessages.aspx";
				string Body = String.Format("发送者: {0}\r\nEmail: {1}\r\n标题: {2}\r\n留言内容: {3}\r\n进入留言管理: {4}", 
					tbName.Text,
					tbEmail.Text,
					tbSubject.Text,
					tbMessage.Text,
					viewmsg);
				email.Send(To,From,Subject,Body);
				tbName.Text = "";
				tbEmail.Text = "";
				tbSubject.Text = "";
				tbMessage.Text = "";
			}
			
			
		}
	}
}

