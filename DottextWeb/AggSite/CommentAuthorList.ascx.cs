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
	///		CommentAuthorList ��ժҪ˵����
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
