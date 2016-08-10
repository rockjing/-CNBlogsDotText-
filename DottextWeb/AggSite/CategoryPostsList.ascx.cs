namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework.Configuration;


	/// <summary>
	///		显示各个分类的文章列表
	/// </summary>
	public class CategoryPostsList : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Panel PostsPanel;

		private void Page_Load(object sender, System.EventArgs e)
		{
			//Control con=null;
			SiteBlogConfigCollection sbcc=Config.GetSiteBlogConfigCollection();
			for(int i=0;i<sbcc.Count;i++)
			{
				Control con=LoadControl("CategoryPosts.ascx");
				CategoryPosts posts=new CategoryPosts();
				posts.ID="CategoryPosts"+sbcc[i].CategoryID;
				posts.CategoryID=sbcc[i].CategoryID;
				PostsPanel.Controls.Add(posts);
				Response.Write(sbcc.Count.ToString());
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
