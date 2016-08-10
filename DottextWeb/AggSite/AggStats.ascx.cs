using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Dottext.Framework.Data;
using Dottext.Framework.Components;
using Dottext.Framework;
using Dottext.Framework.Util;
using Dottext.Framework.Configuration;

namespace Dottext.Web.AggSite
{

    /// <summary>
	///		Summary description for AggStats.
	/// </summary>
	public class AggStats : System.Web.UI.UserControl
	{
        protected System.Web.UI.WebControls.Literal BlogCount;
        protected System.Web.UI.WebControls.Literal PostCount;
        protected System.Web.UI.WebControls.Literal StoryCount;
		protected System.Web.UI.WebControls.HyperLink PingtrackCount;
        protected System.Web.UI.WebControls.Literal CommentCount;

		private void Page_Load(object sender, System.EventArgs e)
		{
             string sql = "blog_GetAggregatedStats";
            string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;

            DataSet ds = SqlHelper.ExecuteDataset(conn,CommandType.StoredProcedure,sql);
            DataTable dtCounts = ds.Tables[0];
            
            if(dtCounts != null)
            {
                DataRow dr = dtCounts.Rows[0];
                BlogCount.Text = dr["BlogCount"].ToString();
                PostCount.Text = dr["PostCount"].ToString();
                StoryCount.Text = dr["StoryCount"].ToString();
                CommentCount.Text = dr["CommentCount"].ToString();
                PingtrackCount.Text =PingtrackCount.Text+dr["PingtrackCount"].ToString();
            }

            ds.Clear();
            ds.Dispose();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
