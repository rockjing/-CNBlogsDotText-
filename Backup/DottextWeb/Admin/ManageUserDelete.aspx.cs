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

using Dottext.Framework.Configuration;
using Dottext.Framework.Data;
namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// ManageUserDelete 的摘要说明。
	/// </summary>
	public class ManageUserDelete : ManagePage
	{
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected System.Web.UI.WebControls.TextBox tbUserName;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnReadBlog;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel BlogInfo;
		protected System.Web.UI.WebControls.Literal ltBlogID;
		protected System.Web.UI.WebControls.Literal ltTitle;
		protected System.Web.UI.WebControls.Literal ltSubTitle;
		protected System.Web.UI.WebControls.Literal ltAuthor;
		protected System.Web.UI.WebControls.Literal ltPostCount;
		protected System.Web.UI.WebControls.Literal ltStorycount;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel SqlPanel;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				btnDelete.Attributes.Add("onclick", "if(!confirm('您真的要删除吗?')) return false;if(!confirm('该操作将会删除该帐号的所有数据, 你确信吗?')) return false;return true;");
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
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnReadBlog.Click += new System.EventHandler(this.btnReadBlog_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnReadBlog_Click(object sender, System.EventArgs e)
		{
			BlogConfig config=Config.GetConfig(tbUserName.Text);
			if(config!=null)
			{
				ltBlogID.Text=config.BlogID.ToString();
				ltAuthor.Text=config.Author;
				ltTitle.Text=config.Title;
				ltSubTitle.Text=config.SubTitle;
				ltPostCount.Text=config.PostCount.ToString();
				ltStorycount.Text=config.StoryCount.ToString();
				BlogInfo.Visible=true;
			}
			else
			{
				Messages.ShowMessage("该帐户不存在!");
				Reset();
			}
		}
		
		private void Reset()
		{
			ltBlogID.Text=string.Empty;
			ltAuthor.Text=string.Empty;
			ltTitle.Text=string.Empty;
			ltSubTitle.Text=string.Empty;
			ltPostCount.Text=string.Empty;
			ltStorycount.Text=string.Empty;
			BlogInfo.Visible=false;
		}

		private void DeleteBlog(int BlogID)
		{
			string conn=Config.Settings.BlogProviders.DbProvider.ConnectionString;
			SqlParameter[] p=
			{
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,BlogID)
			};
			Dottext.Framework.Data.SqlHelper.ExecuteNonQuery(conn,"blog_DeleteBlogger",p);
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			DeleteBlog(Convert.ToInt32(ltBlogID.Text));
			Messages.ShowMessage("成功删除"+tbUserName.Text+"帐号!");
			Reset();
		}
	}
}
