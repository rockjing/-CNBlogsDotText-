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

using System;
using System.Web;
using System.Web.Caching;
using Dottext.Framework;
using Dottext.Framework.Util;
using Dottext.Framework.Components;
using System.IO;
using System.Xml;
using System.Text;
using Dottext.Framework.Configuration;

namespace Dottext.Web.UI
{
	/// <summary>
	/// Summary description for RssHandler.
	/// </summary>
	public class PrintHandler : IHttpHandler
	{
		public PrintHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void ProcessRequest(HttpContext context)
		{

			int PostID = Dottext.Framework.Util.Globals.GetPostIDFromUrl(context.Request.Path);
			if(PostID > -1)
			{
				Entry entry = Entries.GetEntry(PostID,true);
				if(entry != null)
				{
					StringBuilder sb = new StringBuilder();
					sb.Append("<html><head><title>" + entry.Title + "</title>");
					sb.Append("<link rel=\"stylesheet\" href=\"" + Config.CurrentBlog(context).FullyQualifiedUrl + "Skins/" + Globals.Skin(context) + "/style.css\" type=\"text/css\" /></head><body>");
					sb.Append("<h1>" + entry.Title + "</h1>");
					sb.Append("by: " + entry.Author + "<br />");
					sb.Append("posted on: " + entry.DateCreated.ToString("f") + "<br />");
					if(entry.IsUpdated)
					{
						sb.Append("updated on: " + entry.DateUpdated.ToString("f") + "<br />");
					}
					sb.Append(entry.Body);
					sb.Append("<hr>originally published at: " + entry.Link);
					sb.Append("</body></html>");
					context.Response.Write(sb.ToString());
				}
				else
				{
					context.Response.Write("<H1>Could not find the story</H1>");
				}
				
			}
			else
			{
				context.Response.Write("<H1>Could not find the story</H1>");
			}
		}
	
	

		public bool IsReusable
		{
			get { return true; }
		}
	}
}

