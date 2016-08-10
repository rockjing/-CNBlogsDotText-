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
	/// <summary>
	///		AllBlogList 的摘要说明。
	/// </summary>
	public class AllBlogList : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Repeater RecentbloggerRepeater;
		protected System.Web.UI.WebControls.Literal literalBloggerCount;
		protected Dottext.Web.UI.WebControls.Pager ResultsPager;
		protected Dottext.Web.UI.WebControls.Pager ResultsPager2;
		protected System.Web.UI.WebControls.Literal ltTitle;
		private int _resultsPageNumber=1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			int TotalItems;
			string sql = "blog_GetAggregatedPagedBloggerList";
			if(Request.QueryString["id"]=="1")
			{
				sql = "blog_GetAggregatedPagedBloggerListByRegisterTime";
				ltTitle.Text="按注册时间";

			}
			string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;

			if (null != Request.QueryString["page"])
				_resultsPageNumber = Convert.ToInt32(Request.QueryString["page"]);
			ResultsPager2.PageIndex=ResultsPager.PageIndex=_resultsPageNumber;
			int PageIndex = _resultsPageNumber;
			int PageSize = ResultsPager.PageSize=ResultsPager2.PageSize=100;
			SqlParameter[] p=
						{
							SqlHelper.MakeInParam("@PageIndex",SqlDbType.Int,4,PageIndex),
							SqlHelper.MakeInParam("@PageSize",SqlDbType.Int,4,PageSize)
						 };
			ResultsPager2.UrlFormat=ResultsPager.UrlFormat=Dottext.Framework.Util.Globals.AddParamToUrl(Request.RawUrl,"page","{0}");
			DataSet ds = SqlHelper.ExecuteDataset(conn,CommandType.StoredProcedure,sql,p);
			TotalItems=int.Parse(ds.Tables[1].Rows[0][0].ToString());
			ResultsPager2.ItemCount=ResultsPager.ItemCount=TotalItems;
			ResultsPager2.PrefixText=ResultsPager.PrefixText="共"+ResultsPager.MaxPages+"页:";
			RecentbloggerRepeater.DataSource=ds.Tables[0];
			RecentbloggerRepeater.DataBind();
			literalBloggerCount.Text=TotalItems.ToString();

			
		}

		protected string GetFullUrl(string app)
		{
			string host = UI.UIText.SiteUrl;
			if(!host.EndsWith("/"))
			{
				host+="/";
			}
			return string.Format("{0}{1}",host,app);
		}

		protected string CheckContent(string content)
		{
			content=Dottext.Framework.Util.Globals.FilterIFrame(content);
			return Dottext.Framework.Util.Globals.RemoveHtmlTag(content,"h1,h2,h3,bgsound,script");
		}

		protected string GetTimeText()
		{
			if(Request.QueryString["id"]=="1")
			{
				return "注册时间:";
			}
			else
			{
				return "更新时间:";
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
