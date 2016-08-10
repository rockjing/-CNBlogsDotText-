namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework.Components;
	using Dottext.Framework.Data;
	using Dottext.Framework;

	/// <summary>
	///		MyMessages ��ժҪ˵����
	/// </summary>
	public class MyMessages : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink lnkMessages;
		protected System.Web.UI.WebControls.HyperLink lnkPublicMsgView;
		protected System.Web.UI.WebControls.HyperLink lnkPrivateMsgView;
		protected System.Web.UI.WebControls.Literal ltMsgCount;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			this.Visible=Dottext.Web.UI.Globals.CheckContorVisible("MyMessages");
			if(!Visible)
			{
				return;
			}
			lnkPrivateMsgView.NavigateUrl=Dottext.Framework.Configuration.Config.CurrentBlog().FullyQualifiedUrl+"admin/MyMessages.aspx";
			lnkPublicMsgView.NavigateUrl=Dottext.Framework.Configuration.Config.CurrentBlog().FullyQualifiedUrl+"default.aspx?opt=msg";
			lnkMessages.NavigateUrl=Dottext.Framework.Configuration.Config.CurrentBlog().FullyQualifiedUrl+"Contact.aspx?id=1";
			EntryQuery eq=new EntryQuery();
			eq.PostType=PostType.Message;
			EntryCollection ec=Entries.GetEntryCollection(eq);
			ltMsgCount.Text=ec.Count.ToString();
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
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
