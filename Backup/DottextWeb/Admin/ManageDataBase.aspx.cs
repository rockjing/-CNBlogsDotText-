using System;
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

namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// ManageDataBase 的摘要说明。
	/// </summary>
	public class ManageDataBase : ManagePage
	{
		protected System.Web.UI.WebControls.TextBox tbSqlText;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel SqlPanel;
		protected System.Web.UI.WebControls.Button btnExecSql;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnExecSql.Click += new System.EventHandler(this.btnExecSql_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnExecSql_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection(Dottext.Framework.Providers.DbProvider.Instance().ConnectionString);
			conn.Open();
			SqlTransaction myTrans;
			string transactionName = "CnDotText";
			myTrans = conn.BeginTransaction(IsolationLevel.RepeatableRead, transactionName);
			string[] sqlCommands = System.Text.RegularExpressions.Regex.Split(tbSqlText.Text, "\\sGO\\s", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			try
			{
				for (int s = 0; s <= sqlCommands.GetUpperBound(0); s++)
				{
					string mySqlText = sqlCommands[s].Trim();
					if (mySqlText.Length > 0)
					{
						Dottext.Framework.Data.SqlHelper.ExecuteNonQuery(myTrans,CommandType.Text,mySqlText);
					}
				}
				myTrans.Commit();
			}
			finally
			{
				if (conn.State == ConnectionState.Open)
					conn.Close();
			}
			Messages.ShowMessage("执行成功");
			
		}
	}
}
