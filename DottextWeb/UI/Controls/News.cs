#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// 
// .Text is an open source weblog system started by Scott Watermasysk. 
// Blog: http://ScottWater.com/blog 
// RSS: http://scottwater.com/blog/rss.aspx
// Email: Dottext@ScottWater.com
//
// For updated news and information please visit http://scottwater.com/dottext and subscribe to 
// the Rss feed @ http://scottwater.com/dottext/rss.aspx
//
// On its release (on or about August 1, 2003) this application is licensed under the BSD. However, I reserve the 
// right to change or modify this at any time. The most recent and up to date license can always be fount at:
// http://ScottWater.com/License.txt
// 
// Please direct all code related questions to:
// GotDotNet Workspace: http://www.gotdotnet.com/Community/Workspaces/workspace.aspx?id=e99fccb3-1a8c-42b5-90ee-348f6b77c407
// Yahoo Group http://groups.yahoo.com/group/DotText/
// 
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion

namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework;
	using Dottext.Framework.Util;
	using Dottext.Framework.Configuration;
	

	/// <summary>
	///		Summary description for Header.
	/// </summary>
	public class News : BaseControl
	{
		protected System.Web.UI.WebControls.Literal NewsItem;

		protected override void OnLoad(EventArgs e)
		{
			this.Visible=Dottext.Web.UI.Globals.CheckContorVisible("news");
			base.OnLoad (e);
			if(Context != null)
			{
				if(CurrentBlog.HasNews)
				{
					NewsItem.Text = Dottext.Framework.Util.Globals.RemoveHtmlTag(CurrentBlog.News,"form");;
				}
				else
				{
					//this.Controls.Clear();
					this.Visible = false;
				}
			}
		}


	}
}

