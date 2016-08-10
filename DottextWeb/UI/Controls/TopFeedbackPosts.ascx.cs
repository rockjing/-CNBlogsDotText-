namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework.Data;
	using Dottext.Framework.Configuration;


	/// <summary>
	///		TopFeedbackPosts ��ժҪ˵����
	/// </summary>
	public class TopFeedbackPosts : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Repeater TopList;

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.Visible=Dottext.Web.UI.Globals.CheckContorVisible("TopFeedBackPosts");
			if(!Visible)
			{
				return;
			}
			BlogConfig config=Config.CurrentBlog();
			string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;
			SqlParameter[] p=
						{
							SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,config.BlogID),
							SqlHelper.MakeInParam("@ItemCount",SqlDbType.Int,4,config.ItemCount)
						};
			string sql="blog_GetTopFeedbackPostsByBlogID";
			DataSet ds = SqlHelper.ExecuteDataset(conn,CommandType.StoredProcedure,sql,p);
			TopList.DataSource=ds.Tables[0];
			TopList.DataBind();
		}

		protected string BuildUrl(string datestr,string id)
		{
			return Config.CurrentBlog().FullyQualifiedUrl+"archive/"+DateTime.Parse(datestr).ToString("yyyy'/'MM'/'dd")+"/"+id+".aspx";
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
