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

namespace Dottext.Common.Syndication
{
	// To Do: Should we validate the supplied XML? 
	// Not much that can be done if it is not correct.

	/// <summary>
	/// Implementation of http://wellformedweb.org/story/9
	/// Accepts a posted XML document via HttpPost.
	/// </summary>
	public class CommentHandler : IHttpHandler
	{
		public CommentHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void ProcessRequest(HttpContext context)
		{
			HttpRequest Request = context.Request;
			if(Request.RequestType == "POST" && Request.ContentType == "text/xml")
			{

				XmlDocument doc = new XmlDocument();
				doc.Load(Request.InputStream);
				Entry entry = new Entry(PostType.Comment);

				string name = doc.SelectSingleNode("//item/author").InnerText;
				if(name.IndexOf("<") != -1)
				{
					name = name.Substring(0,name.IndexOf("<"));
				}
                entry.Author = name.Trim();

				entry.Body = doc.SelectSingleNode("//item/description").InnerText;
			
				entry.Title = doc.SelectSingleNode("//item/title").InnerText;
				entry.TitleUrl = Globals.CheckForUrl(doc.SelectSingleNode("//item/link").InnerText);

				entry.ParentID = Globals.GetPostIDFromUrl(Request.Path);

				Entries.Create(entry);
			}
			

		}
	
	

		public bool IsReusable
		{
			get { return true; }
		}
	}
}

