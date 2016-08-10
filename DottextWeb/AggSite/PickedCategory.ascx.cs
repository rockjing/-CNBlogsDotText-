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
	///		PickedCategory ��ժҪ˵����
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
