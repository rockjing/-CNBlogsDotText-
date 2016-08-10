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
	///		Summary description for RecentPosts.
	/// </summary>
	public class PagedPosts : System.Web.UI.UserControl
	{

		protected Repeater RecentPostsRepeater;
		protected Dottext.Web.UI.WebControls.Pager ResultsPager;
		private int _resultsPageNumber = 1;
		protected Dottext.Web.UI.WebControls.Pager ResultsPager2;
		//private int _pagesize=40;
		//private DateTime seldate;
		private PostType _entryType=PostType.BlogPost;
		protected System.Web.UI.WebControls.Literal ltListTitle;
		private PostConfig _entryPostConfig=PostConfig.IsAggregated;
		protected System.Web.UI.WebControls.HyperLink ListLink;
		private bool IsOnlyTitle=false;
		private string AppUrl;
		private string BlogUrl="";
		protected System.Web.UI.WebControls.HyperLink NewPost;
		protected System.Web.UI.WebControls.HyperLink Hyperlink5;
		protected System.Web.UI.WebControls.Literal CatalogTitle;
		private int _categoryID;
		
		#region Accessors
	
		public PostType PostType
		{
			get { return _entryType; }
			set { _entryType = value; }
		}
		

		public PostConfig PostConfig
		{
			get { return _entryPostConfig; }
			set { _entryPostConfig = value; }
		}

		public string Title
		{
			get { return ltListTitle.Text; }
			set { ltListTitle.Text = value; }
		}

		public int CatogryID
		{
			get { return this._categoryID; }
			set { this._categoryID = value; }
		}

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			AppUrl=Dottext.Framework.Util.Globals.GetAppUrl(Request);
			AppUrl=AppUrl.Remove(AppUrl.Length-1,1);
			
		
			#region ListControl
			if(Request.QueryString["onlytitle"]=="1")
			{
				this.IsOnlyTitle=true;
			}
			else
			{
				this.IsOnlyTitle=false;
			}
			#endregion

			
			if (null != Request.QueryString["page"])
				_resultsPageNumber = Convert.ToInt32(Request.QueryString["page"]);
			ResultsPager2.PageIndex=ResultsPager.PageIndex=_resultsPageNumber;
			
			#region Paging Format
			ResultsPager2.UrlFormat=ResultsPager.UrlFormat=Dottext.Framework.Util.Globals.AddParamToUrl(Request.RawUrl,"page","{0}");//Request.Path+"?page={0}";
			
			#endregion
				
			PagedEntryQuery query = new	PagedEntryQuery();
			query.PostType = PostType.BlogPost;
			query.ItemCount=100;

			#region Date Query
			/*
			if(null != Request.QueryString["date"])
			{
				string datestr=Request.QueryString["date"];
				seldate=DateTime.ParseExact(datestr,"yyyy'/'MM'/'dd",CultureInfo.CurrentCulture,DateTimeStyles.None);
				query.StartDate=seldate;
				
			}*/
			#endregion
			
			query.PageIndex = _resultsPageNumber;
			query.PageSize = ResultsPager.PageSize=ResultsPager2.PageSize=Config.CurrentBlog(Context).ItemCount;
			query.PostConfig = PostConfig.IsActive|this._entryPostConfig;//PostConfig.IsAggregated|PostConfig.IsActive;
			
			query=(PagedEntryQuery)Dottext.Framework.Util.Globals.BuildEntryQuery(query,Config.CurrentBlog(Context));
			//Dottext.Framework.Logger.LogManager.Log("Config",Config.CurrentBlog(Context).BlogID.ToString());
			PagedEntryCollection PostList=null;
			PostList = Entries.GetPagedEntryCollection(query);
			if(PostList!=null)
			{
				ResultsPager2.ItemCount=ResultsPager.ItemCount=PostList.MaxItems;
				ResultsPager2.PrefixText=ResultsPager.PrefixText="共"+ResultsPager.MaxPages+"页:";
				RecentPostsRepeater.DataSource = PostList;
				RecentPostsRepeater.DataBind();
			}
			CatalogTitle.Text=Config.CurrentBlog(Context).Title+"最新随笔";
				
           
		}
	
		protected string CheckLength(string content)
		{
			string NoHtmStr=Dottext.Framework.Util.Globals.RemoveHtml(content);
			content=Framework.Util.Globals.FilterScript(content);
			content=Dottext.Framework.Util.Globals.RemoveHtmlTag(content,UI.UIData.HtmlFilter);
			
			if(this.IsOnlyTitle)
			{
				return String.Empty;
			}

			if(NoHtmStr.Length>UI.UIData.PostContentLength)
			{
				return string.Format("&nbsp;&nbsp;&nbsp;&nbsp;内容篇幅较长,请点击<a href='{0}'>这里</a>阅读全文",this.fullurl);
				
			}
			else
			{
				return content;
			}

			//return "";

		}

		protected string CheckViewCount(string count)
		{
			return count==""?"0":count;
		}
		
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
					this.fullurl=sourceUrl;
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
		
		protected string GetUrl()
		{
			if(this.fullurl==null)
			{
				fullurl="";
			}
			return this.fullurl;
		}

		protected string GetBlogUrl()
		{
			return this.BlogUrl;
		}

		protected string GetTopUrl()
		{
			return Request.RawUrl+"#Top";
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
