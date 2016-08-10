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
	///		FavoriteList 的摘要说明。
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
