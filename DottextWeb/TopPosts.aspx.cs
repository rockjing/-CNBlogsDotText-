using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
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

namespace Dottext.Web
{
	/// <summary>
	/// TopPosts ��ժҪ˵����
	/// </summary>
	public class TopPosts : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal Style;
		protected System.Web.UI.WebControls.Repeater RecentPosts;
		protected int TitleSN=0;
		protected System.Web.UI.WebControls.Literal TopTitle;
		protected System.Web.UI.WebControls.HyperLink RegisterLink;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink4;
		protected System.Web.UI.WebControls.HyperLink Hyperlink5;
		protected Dottext.Web.UI.WebControls.ContentRegion LeftColumn;
		protected System.Web.UI.WebControls.HyperLink Hyperlink6;
		protected System.Web.UI.WebControls.HyperLink Hyperlink7;
		private string sql;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//Title.Text = ConfigurationSettings.AppSettings["AggregateTitle"] as string;
			//TitleLink.NavigateUrl = ConfigurationSettings.AppSettings["AggregateUrl"] as string;
			if(!IsPostBack)
			{
				//string SearchString=Request.Form["SearchKey"];
				//_default dpage=(_default)Context.Handler;
				//string SearchString=Session["SearchKey"].ToString();//=dpage.SearchKey;
				//Session.Abandon();
				BindData();
				//SetStyle();
			}
		}

		protected string GetEntryUrl(string host, string app, string entryName, DateTime dt)
		{
			
			return string.Format("{0}archive/{1}/{2}.aspx",GetFullUrl(host,app),dt.ToString("yyyy'/'MM'/'dd"),entryName);
		}

		protected string CheckViewCount(string count)
		{
			return count==""?"0":count;
		}

		

		private string appPath = null;
		const string fullUrl = "http://{0}{1}{2}/";
		protected string GetFullUrl(string host, string app)
		{
			if(appPath == null)
			{
				appPath = Request.ApplicationPath;
				if(!appPath.ToLower().EndsWith("/"))
				{
					appPath += "/";
				}
			}
			return string.Format(fullUrl,host,appPath,app);

		}

		private void BindData()
		{
			
			if(Request.QueryString["id"]=="1")
			{
				TopTitle.Text="���»ظ�����";
				sql = "Blog_GetTopCommentPostsByMonth";
			}
			else if(Request.QueryString["id"]=="2")
			{
				TopTitle.Text="�ظ�����";
				sql = "Blog_GetTopCommentPosts";
			}
			else if(Request.QueryString["id"]=="3")
			{
				TopTitle.Text="�Ķ�����";
				sql = "Blog_GetTopPosts";
			}
			else if(Request.QueryString["id"]=="4")
			{
				TopTitle.Text="�����Ķ�����";
				sql = "Blog_GetTopPostsByDay";
			}
			else if(Request.QueryString["id"]=="5")
			{
				TopTitle.Text="���ջظ�����";
				sql = "Blog_GetTopCommentPostsByDay";
			}
			else
			{
				
				TopTitle.Text="�����Ķ�����";
				sql = "Blog_GetTopPostsByMonth";
			}
			string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;
		
			DataSet ds = SqlHelper.ExecuteDataset(conn,CommandType.StoredProcedure,sql);

			RecentPosts.DataSource = ds.Tables[0];

			RecentPosts.DataBind();

			ds.Clear();
			ds.Dispose();

		}

		protected string FormatDate(string date)
		{
			DateTime dt = DateTime.Parse(date);
			return dt.ToString("MMddyyyy");
		}

		protected string AddSn(string title)
		{
			return (++TitleSN).ToString()+"��"+title;
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
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.RecentPosts.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.RecentPosts_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void RecentPosts_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
		
		}
	}
}
