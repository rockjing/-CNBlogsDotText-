namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework;
	using Dottext.Framework.Components;

	/// <summary>
	///		PickedCategory 的摘要说明。
	/// </summary>
	public class PickedCategory : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Literal Title;
		protected System.Web.UI.WebControls.Repeater LinkList;

		private void Page_Load(object sender, System.EventArgs e)
		{
			LinkCategoryCollection lcc=Links.GetCategoriesByType(-1,CategoryType.Picked,false);
			LinkList.DataSource=lcc;
			LinkList.DataBind();
		}

		protected string GetTitle(string title,string cateid)
		{
			if(cateid!=null&&cateid!="")
			{
				return title+"("+GetRowsCount(int.Parse(cateid))+")";
			}
			return title;
		}

		private int GetRowsCount(int cateid)
		{
			EntryQuery query = new	EntryQuery();
			query.PostType = PostType.BlogPost|PostType.Article;
			query.PostConfig = PostConfig.IsActive;
			query.CategoryID=cateid;
			return Entries.GetEntryCount(query);
			
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
	}
}
