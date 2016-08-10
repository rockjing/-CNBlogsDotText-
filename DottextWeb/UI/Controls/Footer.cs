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
	using Dottext.Framework.Configuration;
	

	/// <summary>
	///		Summary description for Header.
	/// </summary>
	public  class Footer : BaseControl
	{
		protected System.Web.UI.WebControls.Literal FooterText;
		protected System.Web.UI.WebControls.HyperLink Hyperlink3;

		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			FooterText.Text = CurrentBlog.Author;
			if(Hyperlink3!=null)
			{
				Hyperlink3.ImageUrl = "~/images/CNBlogs.gif";
				Hyperlink3.Text = "²©¿ÍÔ°";
				Hyperlink3.NavigateUrl = "http://www.cnblogs.com";
				Hyperlink3.Font.Size = new FontUnit("12px");
				Hyperlink3.Font.Name = "Verdana";
			}
			
		}
	}
}

