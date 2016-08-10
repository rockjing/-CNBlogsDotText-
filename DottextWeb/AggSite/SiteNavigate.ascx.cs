namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Text.RegularExpressions;

	/// <summary>
	///		SiteNavigate ��ժҪ˵����
	/// </summary>
	public class SiteNavigate : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink RegisterLink;
		protected System.Web.UI.WebControls.HyperLink AdminLink;
		protected System.Web.UI.WebControls.HyperLink EnterMyBlogLink;
		protected System.Web.UI.WebControls.HyperLink TopReadLink;
		protected System.Web.UI.WebControls.HyperLink lnkAdvView;
		protected System.Web.UI.WebControls.Literal NavTitle;
		protected System.Web.UI.WebControls.HyperLink NewPost;
		protected System.Web.UI.WebControls.HyperLink Hyperlink5;
		protected System.Web.UI.WebControls.HyperLink lnkBlogList;
		protected System.Web.UI.WebControls.HyperLink lnkChat;
		protected System.Web.UI.WebControls.HyperLink lnkLogin;
		protected System.Web.UI.WebControls.HyperLink lnkBloggerRead;
		protected System.Web.UI.WebControls.HyperLink lnkCategoryList;
		protected System.Web.UI.WebControls.HyperLink lnkCnblogs;
		protected System.Web.UI.WebControls.HyperLink Hyperlink8;

		private void Page_Load(object sender, System.EventArgs e)
		{
			NavTitle.Text=Dottext.Framework.Configuration.Config.CurrentBlog().Title;
			if(Request.IsAuthenticated)
			{
				lnkLogin.Text="ע��";
				lnkLogin.NavigateUrl="~/Logout.aspx";
			}
			else
			{
				lnkLogin.Text="��¼";
				lnkLogin.NavigateUrl="~/Login.aspx?ReturnURL="+Request.RawUrl;
			}

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
