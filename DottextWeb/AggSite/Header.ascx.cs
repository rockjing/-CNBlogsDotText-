namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Configuration;

	/// <summary>
	///		Header ��ժҪ˵����
	/// </summary>
	public class Header : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink TitleLink;

		private void Page_Load(object sender, System.EventArgs e)
		{
			TitleLink.Text = UI.UIText.SiteTitle;
			TitleLink.NavigateUrl = UI.UIText.SiteUrl;
			if(Dottext.Framework.Configuration.Config.Settings.Logo!=null&&Dottext.Framework.Configuration.Config.Settings.Logo!="")
			{
				TitleLink.ImageUrl="~/images/"+Dottext.Framework.Configuration.Config.Settings.Logo;
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
