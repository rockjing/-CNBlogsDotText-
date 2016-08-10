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
using System.Text;
using System.Web;
using System.Web.Caching;
using Dottext.Framework;
using Dottext.Framework.Util;
using Dottext.Framework.Components;

namespace Dottext.Web.UI
{
	public class ErrorHandler : IHttpHandler
	{
		public ErrorHandler()
		{
			//
		}

		public void ProcessRequest(HttpContext context)
		{
			context.Items["PendingException"] = new Exception("Error processing that file request.");
			context.Server.Transfer("Error.aspx", false);
		}
	
		public bool IsReusable
		{
			get { return true; }
		}
	}
}

