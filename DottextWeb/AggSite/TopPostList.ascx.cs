namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Data.SqlClient;
	using System.Text.RegularExpressions;

	using System.Configuration;
	using Dottext.Framework.Configuration;
	using Dottext.Framework.Data;
	/// <summary>
	///		Summary description for RecentPosts.
	/// </summary>
	public class TopPostList : System.Web.UI.UserControl
	{

		protected Repeater RecentPostsRepeater;
		
		private string _StoredProcedureName;
		public string StoredProcedureName
		{
			set
			{
				_StoredProcedureName=value;
			}
		}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
           string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;
            DataSet ds = SqlHelper.ExecuteDataset(conn,CommandType.StoredProcedure,_StoredProcedureName);
            RecentPostsRepeater.DataSource = ds.Tables[0];
            RecentPostsRepeater.DataBind();
		    ds.Clear();
            ds.Dispose();
		}

        #region GetFullUrl Method
        private string appPath = null;
        const string fullUrl = "http://{0}{1}{2}/";
		protected Dottext.Web.UI.WebControls.Pager ResultsPager;
        string host = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="app"></param>
        /// <returns></returns>
        protected string GetFullUrl(string app)
        {
            if(appPath == null)
            {
                appPath = Request.ApplicationPath;
                if(!appPath.ToLower().EndsWith("/"))
                {
                    appPath += "/";
                }
            }
            if(host == null)
            {
                host = Request.Url.Host.ToLower();//.Replace("www.",string.Empty);
            }
            return string.Format(fullUrl,host,appPath,app);
        }
        #endregion

        #region GetEntryUrl Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="app"></param>
        /// <param name="entryName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected string GetEntryUrl(string host, string app, string entryName, DateTime dt)
        {
            return string.Format("{0}archive/{1}/{2}.aspx",GetFullUrl(app),dt.ToString("yyyy'/'MM'/'dd"),entryName);
        }
        #endregion

		protected string CheckViewCount(string count)
		{
			return count==""?"0":count;
		}


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
			this.RecentPostsRepeater.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.RecentPostsRepeater_ItemCommand);
			this.ID = "RecentPostsRepeater";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void RecentPostsRepeater_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
		
		}
	}
}
