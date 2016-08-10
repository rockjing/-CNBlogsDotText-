namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using Dottext.Framework.Components;

	/// <summary>
	///		PreviewPost 的摘要说明。
	/// </summary>
	public class PreviewPost : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink TitleUrl;
		protected System.Web.UI.WebControls.Literal Body;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Entry entry=(Entry)Context.Cache["PreviewPost"];
			if(entry!=null)
			{
				TitleUrl.Text=entry.Title;
				Body.Text=entry.Body;
			}
			Context.Cache.Remove("PreviewPost");
			Response.Expires=-1;
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
