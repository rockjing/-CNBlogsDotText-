namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using Dottext.Framework;

	/// <summary>
	///		FavoriteList ��ժҪ˵����
	/// </summary>
	public class FavoriteList : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Literal Title;
		protected System.Web.UI.WebControls.Literal Description;
		protected System.Web.UI.WebControls.Repeater Favorites;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			int cateid=Dottext.Framework.Util.WebPathStripper.GetEntryIDFromUrl(Request.PhysicalPath);
			Dottext.Framework.Components.LinkCategory category=Links.GetLinkCategory(cateid,true);
			Title.Text=category.Title;
			Description.Text=category.Description;
			Dottext.Framework.Components.LinkCollection favs=Links.GetLinksByCategoryID(cateid,true);
			Favorites.DataSource = favs;
			Favorites.DataBind();
		}

		public string GetTarget(string content)
		{
			if(content=="True")
			{
				return "_blank";
			}
			else
			{
				return "_self";
			}

			//return "_self";
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
