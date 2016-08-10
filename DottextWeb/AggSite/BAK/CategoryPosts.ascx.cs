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
	///		CategoryPosts ��ժҪ˵����
	/// </summary>
	public class CategoryPosts : System.Web.UI.UserControl
	{

		private int _categoryID = -1;
		public int CategoryID
		{
			get
			{
				return _categoryID;
			}
			set
			{
				_categoryID = value;
			}
		}


		private string BlogUrl="";
		protected System.Web.UI.WebControls.HyperLink Title;
		protected System.Web.UI.WebControls.Repeater RecentPostsRepeater;
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

		private void Page_Load(object sender, System.EventArgs e)
		{
			string cateid=Request.QueryString["cateid"];
			if(cateid!=null && cateid!="")
			{
				CategoryID=Convert.ToInt32(cateid);
			}
			
			EntryQuery query = new	EntryQuery();
			query.PostType = PostType.BlogPost;
			SiteBlogConfig config=Config.GetSiteBlogConfigByCategoryID(CategoryID);
			if(config==null)
			{
				return;
			}
			query.PostConfig = PostConfig.IsActive|PostConfig.IsAggregated;
			query=(EntryQuery)Dottext.Framework.Util.Globals.BuildEntryQuery(query,config);
			
			EntryCollection PostList=null;
			try
			{
				PostList = Entries.GetEntryCollection(query);
				if(PostList==null)
				{
					return;
				}
				if(PostList.Count==0)
				{
					//this.Visible=false;
				}
				RecentPostsRepeater.DataSource = PostList;
				RecentPostsRepeater.DataBind();
			}
			finally
			{
				PostList.Clear();
				PostList=null;
			}
			Title.Text=config.Title;
			//Title.NavigateUrl="~/default.aspx?id="+BlogID;
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
