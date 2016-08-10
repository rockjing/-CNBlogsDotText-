namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		ListTitle 的摘要说明。
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
				ListLink.Text="列出全部内容"+ListLink.Text;
			}
			else
			{
				ListLink.NavigateUrl=Dottext.Framework.Util.Globals.AddParamToUrl(Request.RawUrl,"OnlyTitle","1");
				ListLink.Text="仅列出标题"+ListLink.Text;
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
