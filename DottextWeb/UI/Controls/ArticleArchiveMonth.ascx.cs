namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework.Util;
	using Dottext.Framework;
	using Dottext.Framework.Components;
	using Dottext.Common.Data;

	/// <summary>
	///		ArticleArchiveMonth 的摘要说明。
	/// </summary>
	public class ArticleArchiveMonth : Dottext.Web.UI.Controls.BaseControl
	{

		protected Dottext.Web.UI.Controls.EntryList Days;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			DateTime dt = WebPathStripper.GetDateFromRequest(Request.Path,"archives");
			
			Days.EntryListItems = Cacher.GetMonth(dt,CacheTime.Short,Context,PostType.Article);
			Days.EntryListTitle = string.Format("{0} 档案", dt.ToString("MM yyyy"));//Entries
			Dottext.Web.UI.Globals.SetTitle(string.Format("{0} - {1} Entries",CurrentBlog.Title,dt.ToString("y")),Context);
			
		}
	}
}
