namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using Dottext.Framework.Configuration;
	using Dottext.Framework.Components;
	using Dottext.Framework;

	/// <summary>
	///		SiteMoreCategory ��ժҪ˵����
	/// </summary>
	public class SiteCategory : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Repeater CategoryLevel1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			CategoryLevel1.DataSource=Config.GetSiteBlogConfigCollection();//GetGlobalCategory(-1);
			CategoryLevel1.DataBind();
		}

		protected LinkCategoryCollection GetGlobalCategory(int ParentID)
		{
			return Links.GetCategoriesByParentID(CategoryType.Global,ParentID,true);
		}

		protected string GetUrl(string CategoryID)
		{
			string url= string.Format("~/posts.{0}?cateid={1}",Config.Settings.UrlFormat,CategoryID);
			return url;
		}

	
		protected string GetRssUrl(string CategoryID)
		{
			string url= string.Format("~/rss.{0}?cateid={1}",Config.Settings.UrlFormat,CategoryID);
			return url;
		}

		private int GetRowsCount(bool IsToday,BlogConfig config)
		{
			EntryQuery query = new	EntryQuery();
			query.PostType = PostType.BlogPost;
			query.PostConfig = PostConfig.IsActive|PostConfig.IsAggregated;
			if(IsToday)
			{
				DateTime now=DateTime.Now;
				DateTime StartDate=new DateTime(now.Year,now.Month,now.Day,0,0,0,0);
				query.StartDate=StartDate;
			}
			
			query=(EntryQuery)Dottext.Framework.Util.Globals.BuildEntryQuery(query,config);
			return Entries.GetEntryCount(query);
			
		}

		protected string CheckTitle(string title,string CategoryID)
		{
			if(Config.Settings.CategoryDepth==2)
			{
				return title;
			}
			SiteBlogConfig config=Config.GetSiteBlogConfigByCategoryID(int.Parse(CategoryID));
			if(config!=null)
			{
				title+=string.Format("({0}/{1})",GetRowsCount(true,config).ToString(),GetRowsCount(false,config).ToString());
			}
			return title;
						
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
