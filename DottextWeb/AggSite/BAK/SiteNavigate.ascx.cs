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
	///		SiteNavigate 的摘要说明。
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
		protected System.Web.UI.WebControls.HyperLink lnkCategoryList;
		protected System.Web.UI.WebControls.HyperLink lnkCommentRSS;
		protected System.Web.UI.WebControls.HyperLink Hyperlink8;

		private void Page_Load(object sender, System.EventArgs e)
		{
			NavTitle.Text="站点导航";//Dottext.Framework.Configuration.Config.CurrentBlog().Title;
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
