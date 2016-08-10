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
	/// GetMyPassword ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
					Message.Text = "�û������ʼ���ַ��һ��,�޷�ȡ������";
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
				
				string message = "��ĵ�¼�ʻ�:\n�û���: {0}\n����: {1}\n\n����԰:{2}";
				string mainurl=Dottext.Framework.Configuration.Config.Settings.AggregateUrl;//ConfigurationSettings.AppSettings["AggregateUrl"];
				IMailProvider mail = Dottext.Framework.Providers.EmailProvider.Instance();
			
				string To = config.Email;
				string From = mail.AdminEmail;
				string Subject = "��Ĳ���԰��¼��Ϣ";
				string Body = string.Format(message,config.UserName,password,mainurl);
				mail.Send(To,From,Subject,Body);
				//Message.Text = "Login Credentials Sent<br>";
				Message.Text = "�������ѷ����������";
			}
			else
			{
				Message.Text = "���û�������";
			}
		}

	}
}
