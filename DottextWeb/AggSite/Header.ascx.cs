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
	///		Header 的摘要说明。
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
