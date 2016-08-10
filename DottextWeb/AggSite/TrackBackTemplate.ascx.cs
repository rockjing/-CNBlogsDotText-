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
	///		TrackBackTemplate ��ժҪ˵����
	/// </summary>
	public class TrackBackTemplate : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Literal Style;
		protected Dottext.Web.UI.WebControls.ContentRegion HeaderRegion;
		protected System.Web.UI.WebControls.HyperLink TitleLink;
		protected Dottext.Web.UI.WebControls.ContentRegion MainBodyRegion;
		protected Literal TitleTag;

		private void Page_Load(object sender, System.EventArgs e)
		{
			TitleTag.Text=TitleLink.Text = ConfigurationSettings.AppSettings["AggregateTitle"] as string;
			TitleLink.NavigateUrl = Dottext.Framework.Configuration.Config.Settings.AggregateUrl;//ConfigurationSettings.AppSettings["AggregateUrl"] as string;

			//const string style = "<LINK href=\"{0}{1}\" type=\"text/css\" rel=\"stylesheet\">";
			//string apppath = Request.ApplicationPath.EndsWith("/") ? Request.ApplicationPath : Request.ApplicationPath + "/";
			//Style.Text = string.Format(style,apppath,"Style.css") + "\n" + string.Format(style,apppath,"blue.css");
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
