namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework.Configuration;

	/// <summary>
	///		MySearch 的摘要说明。
	/// </summary>
	public class MySearch : BaseControl
	{
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.Visible=Dottext.Web.UI.Globals.CheckContorVisible("MySearch");
			Control con=this.FindControl("SearchForm1");
			if(con!=null&& con is AggSite.SearchForm)
			{
				((AggSite.SearchForm)con).SearchUrl=string.Format("{0}BlogSearch.aspx?q=",CurrentBlog.FullyQualifiedUrl);
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

		/*private void ButtonSearch_Click(object sender, System.EventArgs e)
		{
			
			string searchText = tbSearch.Text;
            if(searchText.Trim().Length > 0)
			{
				Response.Redirect(string.Format("{0}BlogSearch.aspx?q={1}",CurrentBlog.FullyQualifiedUrl,Server.UrlEncode(searchText)));
				Response.End();
			}
			else
			{
				Response.Redirect(string.Format("{0}BlogSearch.aspx",CurrentBlog.FullyQualifiedUrl));
				Response.End();
			}
		}*/
	}
}
