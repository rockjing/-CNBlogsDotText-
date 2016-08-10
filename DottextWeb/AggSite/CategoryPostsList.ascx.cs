namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework.Configuration;


	/// <summary>
	///		��ʾ��������������б�
	/// </summary>
	public class CategoryPostsList : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Panel PostsPanel;

		private void Page_Load(object sender, System.EventArgs e)
		{
			//Control con=null;
			SiteBlogConfigCollection sbcc=Config.GetSiteBlogConfigCollection();
			for(int i=0;i<sbcc.Count;i++)
			{
				Control con=LoadControl("CategoryPosts.ascx");
				CategoryPosts posts=new CategoryPosts();
				posts.ID="CategoryPosts"+sbcc[i].CategoryID;
				posts.CategoryID=sbcc[i].CategoryID;
				PostsPanel.Controls.Add(posts);
				Response.Write(sbcc.Count.ToString());
			}
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
