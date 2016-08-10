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
	///		AllRecentPosts 的摘要说明。
	/// </summary>
	public class AllRecentPosts : System.Web.UI.UserControl
	{
		private string appPath = null;
		const string fullUrl = "http://{0}{1}{2}/";
		protected Dottext.Web.UI.WebControls.Pager ResultsPager;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink5;
		protected System.Web.UI.WebControls.HyperLink Hyperlink6;
		protected System.Web.UI.WebControls.Repeater RecentPostsRepeater;
		protected System.Web.UI.WebControls.HyperLink lnkMore;
		string host = null;
		private bool IsOnlyTitle=false;

		private void Page_Load(object sender, System.EventArgs e)
		{
			int GroupID = 1;
			if(Request.QueryString["GroupID"] !=null)
			{
				try
				{
					GroupID = Int32.Parse(Request.QueryString["GroupID"]);
				}
				catch{}
			}
		
			if(Request.QueryString["onlytitle"]=="1")
			{
				this.IsOnlyTitle=true;
			}
			else
			{
				this.IsOnlyTitle=false;
			}

			
			SqlParameter[] p = 
				{
					SqlHelper.MakeInParam("@Host",SqlDbType.NVarChar,100,ConfigurationSettings.AppSettings["AggregateHost"] as string),
					SqlHelper.MakeInParam("@GroupID",SqlDbType.Int,4,GroupID),
					SqlHelper.MakeInParam("@ServerTimeZone",SqlDbType.Int,4,Config.Settings.ServerTimeZone)
				};
			
			string sql="",querystr="";
			;
			//string url=Request.RawUrl.ToLower().Replace(Request.ApplicationPath.ToLower()+"/",string.Empty).ToLower();
			if(Request.QueryString["cate"]!=null)
			{
				querystr="cate='"+Request.QueryString["cate"]+"'";
			}
			else
			{
				querystr="default=1";
			}
			
			DataRow[] row=UI.UIData.SiteCatalogData.Tables[0].Select(querystr);
			//Dottext.Framework.Logger.LogManager.Log("test",row.Length.ToString());
			if(row.Length>0)
			{
				sql=row[0]["sp"].ToString();
			}
			

			if(Request.QueryString["cate"]=="4")
			{
				if(Request.QueryString["cateid"]!=null)
				{
					SqlParameter[] p2 = 
				{
					SqlHelper.MakeInParam("@Host",SqlDbType.NVarChar,100,ConfigurationSettings.AppSettings["AggregateHost"] as string),
					SqlHelper.MakeInParam("@GroupID",SqlDbType.Int,4,GroupID),
					SqlHelper.MakeInParam("@ServerTimeZone",SqlDbType.Int,4,Config.Settings.ServerTimeZone),
					SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,int.Parse(Request.QueryString["cateid"]))
				};
					p=p2;
				}
			}

			#region sql	
			/*
			string sql = "blog_GetAggregatedTechPosts";
			if(Request.QueryString["cate"]=="2")
			{
				sql = "blog_GetAggregatedNoTechPosts";
			}
			else if(Request.QueryString["cate"]=="3")
			{
				sql = "blog_GetAggregatedPosts";
			}
			else if(Request.QueryString["cate"]=="5")
			{
				sql = "blog_GetAggregatedFAQPosts";
			}
			else if(Request.QueryString["cate"]=="6")
			{
				sql = "blog_GetAggregatedVIPPosts";
			}
			else if(Request.QueryString["cate"]=="7")
			{
				sql = "blog_GetAggregatedQuotePosts";
			}
			else if(Request.QueryString["cate"]=="8")
			{
				sql = "blog_GetAggregatedBookPosts";
			}
			else if(Request.QueryString["cate"]=="9")
			{
				sql = "blog_GetAggregatedProjectPosts";
			}
			else if(Request.QueryString["cate"]=="4")
			{
				sql = "blog_GetAggregatedPickedPosts";
				if(Request.QueryString["cateid"]!=null)
				{
					SqlParameter[] p2 = 
				{
					SqlHelper.MakeInParam("@Host",SqlDbType.NVarChar,100,ConfigurationSettings.AppSettings["AggregateHost"] as string),
					SqlHelper.MakeInParam("@GroupID",SqlDbType.Int,4,GroupID),
					SqlHelper.MakeInParam("@ServerTimeZone",SqlDbType.Int,4,Config.Settings.ServerTimeZone),
					SqlHelper.MakeInParam("@CategoryID",SqlDbType.Int,4,int.Parse(Request.QueryString["cateid"]))
				};
					p=p2;
				}
			}
			else
			{
				sql = "blog_GetAggregatedTechPosts";
				
			}*/
			#endregion

			string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;

			DataSet ds = SqlHelper.ExecuteDataset(conn,CommandType.StoredProcedure,sql,p);
			RecentPostsRepeater.DataSource = ds.Tables[0];
			RecentPostsRepeater.DataBind();
			
			ds.Clear();
			ds.Dispose();
		}


		#region GetFullUrl Method
		
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

		protected string CheckLength(string content,string url)
		{
			
			//过滤Script
			//content=Dottext.Framework.Util.Globals.FilterScript(content);
			string NoHtmStr=Dottext.Framework.Util.Globals.RemoveHtml(content);
			//string regexstr="[^<script]*[$</script>]";
			//content=Regex.Replace(content,regexstr,string.Empty,RegexOptions.IgnoreCase);
			content=Dottext.Framework.Util.Globals.RemoveHtmlTag(content,"h1");
			content=Dottext.Framework.Util.Globals.RemoveHtmlTag(content,"h2");
			content=Dottext.Framework.Util.Globals.RemoveHtmlTag(content,"h3");
			content=Dottext.Framework.Util.Globals.RemoveHtmlTag(content,"bgsound");
			if(this.IsOnlyTitle)
			{
				return String.Empty;
			}
			int len=int.Parse(ConfigurationSettings.AppSettings["ArticleLength"]);
			if(NoHtmStr.Length>len)
			{
				string returnurl="&nbsp;&nbsp;&nbsp;&nbsp;内容篇幅较长,请点击<a href='"+url+"'>这里</a>阅读全文";
				return returnurl;//NoHtmStr.Substring(100);//"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color='blue'>内容篇幅太长,请点击标题查看</font>";
			}
			else
			{
				return content;
			}


		}

		protected string CheckViewCount(string count)
		{
			return count==""?"0":count;
		}


		/*public bool IsListTitle
		{
			get
			{
				return this._IsListTitle;
			}
			set
			{
				this._IsListTitle=value;
			}
		}*/

		public void ListTitle(bool IsListTitle)
		{
			RepeaterItem item;
			Control con;
			if(IsListTitle)
			{
				for(int i=0;i<RecentPostsRepeater.Items.Count;i++)
				{
					item=RecentPostsRepeater.Items[i];
					con=item.FindControl("BlogContentLabel");
					if(con!=null)
					{
						((Literal)con).Visible=false;
					}
				}
					
			}
			else
			{
				
				for(int i=0;i<RecentPostsRepeater.Items.Count;i++)
				{
					item=RecentPostsRepeater.Items[i];
					con=item.FindControl("BlogContentLabel");
					if(con!=null)
					{
						((Literal)con).Visible=true;
					}
				}
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
			this.RecentPostsRepeater.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.RecentPostsRepeater_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void RecentPostsRepeater_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
		
		}
	}
}
