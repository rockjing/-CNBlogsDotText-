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
using System.Web.UI;

namespace Dottext.Web.UI.Pages 
{
	/// <summary>
	/// Summary description for BaseBlogPageHandlerFactory.
	/// </summary>
	public abstract class BaseBlogPageHandlerFactory :  IHttpHandlerFactory
	{
		public BaseBlogPageHandlerFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public abstract Type PageType
		{
			get;
		}
		

		public virtual IHttpHandler GetHandler(HttpContext context, string requestType, string url, string path)
		{
			return (IHttpHandler)Activator.CreateInstance(PageType);//, 564, null, args, null);
		}

		public virtual void ReleaseHandler(IHttpHandler handler) 
		{
			
		}
	}
}

