namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework;
	using Dottext.Framework.Components;
	using Dottext.Framework.Configuration;

	/// <summary>
	///		RecentComments 的摘要说明。
	/// </summary>
	public class RecentComments : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Repeater CommentList;
		protected System.Web.UI.WebControls.HyperLink RSSHyperlink1;
		public int index=1;

		private void InitializeComponent()
		{
		
		}

		
		protected override void OnLoad(EventArgs e)
		{
			this.Visible=Dottext.Web.UI.Globals.CheckContorVisible("RecentComments");

			string url=Config.CurrentBlog().FullyQualifiedUrl;
			RSSHyperlink1.NavigateUrl=url+"RecentCommentsRSS.aspx";
			BindList();
			
		}

		private void BindList()
		{
			
			EntryQuery query = new	EntryQuery();
			query.PostType = PostType.Comment|PostType.PingTrack;
			query.ItemCount=Config.CurrentBlog().ItemCount;
			//query.PageIndex = 1;
			//uery.PageSize = ResultsPager.PageSize;
			
			EntryCollection EntryList = Entries.GetEntryCollection(query);

			if (EntryList.Count > 0)
			{
				//Response.Write(EntryList.Count.ToString());
				CommentList.DataSource = EntryList;
				CommentList.DataBind();
			}
			
		}

		protected string CheckLength(string content)
		{	
			content=Dottext.Framework.Util.Globals.RemoveHtmlTag(content,"img");
			if(content.Length>400)
			{
				return "";
			}
			else
			{
				return content;
			}

		}

		
	}
}
