namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		ListTitle ��ժҪ˵����
	/// </summary>
	public class ListTitle : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink ListLink;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["OnlyTitle"]=="1")
			{
				ListLink.NavigateUrl=Dottext.Framework.Util.Globals.RemoveParamFromUrl(Request.RawUrl,"OnlyTitle");
				//ListLink.NavigateUrl=Regex.Replace(Request.RawUrl,@"([&]|[?])OnlyTitle=1",string.Empty,RegexOptions.IgnoreCase);
				ListLink.Text="�г�ȫ������"+ListLink.Text;
			}
			else
			{
				ListLink.NavigateUrl=Dottext.Framework.Util.Globals.AddParamToUrl(Request.RawUrl,"OnlyTitle","1");
				ListLink.Text="���г�����"+ListLink.Text;
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
