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
	///		TrackBackTemplate 的摘要说明。
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
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
