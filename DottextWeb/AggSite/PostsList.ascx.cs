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
	using System.Globalization;
	using System.Configuration;
	using Dottext.Framework.Configuration;
	using Dottext.Framework.Data;
	using Dottext.Framework.Components;
	using Dottext.Framework;

	/// <summary>
	///		PostsList 的摘要说明。
	/// </summary>
	public class PostsList : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Repeater RecentPostsRepeater;
		protected System.Web.UI.WebControls.HyperLink Title;
		
		private int _blogID=-1;
		public int BlogID
		{
			get
			{
				return _blogID;
			}
			set
			{
				_blogID=value;
			}
		}

		

		private string BlogUrl="";
		private string fullurl="";
		protected string BuildUrl(string titleUrl,string link,string sourceUrl,string postType)
		{
			BlogUrl="";
			if(link!=null && link!="")
			{
				if(!link.ToLower().StartsWith("http://"))
				{
					link="http://"+link;
				}

			}
			this.fullurl=link;
			if(postType==PostType.Comment.ToString())
			{
				if(sourceUrl!=""&&sourceUrl!=null)
				{
					//this.fullurl=sourceUrl;
				}

				if(link!=titleUrl)
				{
					BlogUrl=titleUrl;				
				}
				else
				{
					BlogUrl="";
				}
			}
			else
			{
				BlogUrl=Dottext.Framework.Util.Globals.GetBlogAppUrl(link,Request.ApplicationPath);
			}
				
			return fullurl;
			
			
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

		private void Page_Load(object sender, System.EventArgs e)
		{
			EntryQuery query = new	EntryQuery();
			query.PostType = PostType.BlogPost;
			query.ItemCount=5;
			query.PostConfig = PostConfig.IsActive|PostConfig.IsAggregated;
			SiteBlogConfig config=Config.GetSiteBlogConfig(BlogID);
			query=(EntryQuery)Dottext.Framework.Util.Globals.BuildEntryQuery(query,Config.GetSiteBlogConfig(BlogID));
			DateTime now=DateTime.Now;
			DateTime StartDate=new DateTime(now.Year,now.Month,now.Day,0,0,0,0);
			query.StartDate=StartDate;
			EntryCollection PostList=null;
			try
			{
				PostList = Entries.GetEntryCollection(query);
				if(PostList.Count==0)
				{
					this.Visible=false;
				}
				DataSet ds=new DataSet();
				RecentPostsRepeater.DataSource = PostList;
				RecentPostsRepeater.DataBind();
			}
			finally
			{
				PostList.Clear();
				PostList=null;
			}
			Title.Text=config.Title;
			Title.NavigateUrl="~/default.aspx?id="+BlogID;
		}
	}
}
