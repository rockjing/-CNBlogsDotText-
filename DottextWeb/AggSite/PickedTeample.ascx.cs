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
	///		PickedRecentPosts 的摘要说明。
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
