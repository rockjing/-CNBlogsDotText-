namespace Dottext.Web
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Configuration;

	/// <summary>
	///		PickedRecentPosts ��ժҪ˵����
	/// </summary>
	public class PickedTeample : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink lnkCategoryAll;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected Dottext.Web.UI.WebControls.ContentRegion MPMain;
		protected System.Web.UI.WebControls.HyperLink ListLink;
		protected Dottext.Web.UI.WebControls.ContentRegion LeftColumn;
	

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			
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
