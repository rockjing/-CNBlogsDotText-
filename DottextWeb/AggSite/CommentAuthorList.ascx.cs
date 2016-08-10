namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Data.SqlClient;
	using Dottext.Framework.Data;
	using System.Configuration;

	/// <summary>
	///		CommentAuthorList 的摘要说明。
	/// </summary>
	public class CommentAuthorList : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Literal literalBloggerCount;
		protected System.Web.UI.WebControls.Repeater Authors;

		private void Page_Load(object sender, System.EventArgs e)
		{
			string sql="blog_GetAggregatedCommentAuthors";
			string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;

			DataSet ds = SqlHelper.ExecuteDataset(conn,CommandType.StoredProcedure,sql);
			Authors.DataSource = ds.Tables[0];
			literalBloggerCount.Text=ds.Tables[0].Rows.Count.ToString();
			Authors.DataBind();

			ds.Clear();
			ds.Dispose();
		
		}

		protected string GetUrl(string author)
		{
			return Dottext.Framework.Util.Globals.AddParamToUrl(Request.RawUrl,"author",Server.UrlEncode(author));
			
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
