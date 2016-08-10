namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Configuration;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Data.SqlClient;

	using Dottext.Framework.Data;

	/// <summary>
	///		Summary description for BlogList.
	/// </summary>
	public class BlogList : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Repeater Bloggers;

		private string _storedProcedureName="blog_GetAggregatedBloggers";
		protected System.Web.UI.WebControls.Literal LiteralTitle;
	
		public string StoredProcedureName
		{
			set
			{
				this._storedProcedureName=value;				
			}
		}

		private string _title="≤©øÕ≈≈––∞Ò";
		public string Title
		{
			set
			{
				this._title=value;
			}
		}

		private int _groupID=-1;
        public int GroupID
		{
			get
			{
				return this._groupID;
			}
			set
			{
				this._groupID=value;
			}
		}

		private int _bloggerListCount=200;
		public int BlogListCount
		{
			get
			{
				return this._bloggerListCount;
			}
			set
			{
				this._bloggerListCount=value;
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
           					
			this.LiteralTitle.Text=this._title;
            string sql = this._storedProcedureName;
            string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;

            SqlParameter[] p = 
                {
                    SqlHelper.MakeInParam("@ItemCount",SqlDbType.Int,4,BlogListCount), 
					SqlHelper.MakeInParam("@GroupID",SqlDbType.Int,4,GroupID)
                };

            DataSet ds = SqlHelper.ExecuteDataset(conn,CommandType.StoredProcedure,sql,p);
            Bloggers.DataSource = ds.Tables[0];
			literalBloggerCount.Text=ds.Tables[0].Rows.Count.ToString();
            Bloggers.DataBind();

            ds.Clear();
            ds.Dispose();
		}

		#region GetFullUrl Method
		//private string appPath = null;
		const string fullUrl = "{0}/{1}/";
		protected System.Web.UI.WebControls.Literal literalBloggerCount;
		//string host = null;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <param name="app"></param>
		/// <returns></returns>
		protected string GetFullUrl(string app)
		{
			string host = "~";
			return string.Format(fullUrl,host,app);
		}
		#endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		}
}
