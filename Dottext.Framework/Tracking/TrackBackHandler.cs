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

#region Notes
 ///////////////////////////////////////////////////////////////////////////////////////////////////
 // The code in this file is freely distributable.
 // 
 // ASPNetWeblog is not responsible for, shall have no liability for 
 // and disclaims all warranties whatsoever, expressed or implied, related to this code,
 // including without limitation any warranties related to performance, security, stability,
 // or non-infringement of title of the control.
 // 
 // If you have any questions, comments or concerns, please contact
 // Scott Watermasysk, Scott@TripleASP.Net.
 // 
 // For more information on this control, updates, and other tools to integrate blogging 
 // into your existing applications, please visit, http://aspnetweblog.com
 // 
 // Based off of code by Simon Fell http://www.pocketsoap.com/weblog/ 
 // 
 ///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Web;
using System.Xml;
using Dottext.Framework;
using Dottext.Framework.Components;
using Dottext.Framework.Util;
using Dottext.Framework.Configuration;

namespace Dottext.Framework.Tracking
{
	/// <summary>
	/// Summary description for TrackBackHandler.
	/// </summary>
	public class TrackBackHandler : IHttpHandler
	{
		public TrackBackHandler() 
		{
		}
	
		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType="text/xml" ;

//			if ( context.Request.QueryString["postid"] == null )
//			{
//				trackbackResponse (context, 1, "PostID missing" ) ;
//			}
			
			

			int postId = 0 ;
			try 
			{
				postId = WebPathStripper.GetEntryIDFromUrl(context.Request.Path);//int.Parse(context.Request.QueryString["postid"]) ;
			}
			catch 
			{
				trackbackResponse (context, 1, "EntryID is invalid or missing" ) ;
				Logger.LogManager.Log("TrackBackFail","EntryID is invalid or missing");
			}


			if ( context.Request.HttpMethod == "POST" )
			{
				string title     = safeParam(context,"title") ;
				string excerpt   = safeParam(context,"excerpt") ;
				string url       = safeParam(context,"url");
				string blog_name = safeParam(context,"blog_name") ;

				// is the url valid ?
				if ( url == "" )
				{
					Logger.LogManager.Log("TrackBackFail","no url parameter found, please try harder!");
					trackbackResponse (context, 1, "no url parameter found, please try harder!") ;
				}
	
				string pageTitle = null;
				Entry trackedEntry = Entries.GetEntry(postId,PostConfig.IsActive);
				if (trackedEntry != null &&  ! Verifier.SourceContainsTarget(url, trackedEntry.Link, out pageTitle))
				{
					Logger.LogManager.Log("TrackBackFail","Sorry couldn't find a relevant link in " + url);
					trackbackResponse (context, 2, "Sorry couldn't find a relevant link in " + url ) ;
				}
				
				try
				{
					Entry entry = new Entry(PostType.PingTrack);
					entry.ParentID = postId;
					entry.Title = title;
					entry.TitleUrl = url;
					entry.Author = blog_name;
					entry.Body = excerpt;
					entry.IsActive = true;
				
					entry.DateCreated = entry.DateUpdated = DateTime.Now;
					Entries.Create(entry);
				}
				catch(Exception e)
				{
					Logger.LogManager.CreateExceptionLog(e,"TrackBackFail");
				}
				Logger.LogManager.Log("Receive TrackBack Successful",string.Format("From:{0} To:{1} ",url,trackedEntry.Link));
			}
			else
			{
				Entry entry = Entries.GetEntry(postId,PostConfig.IsActive);

				XmlTextWriter w = new XmlTextWriter(context.Response.Output) ;
				w.Formatting = Formatting.Indented;


				w.WriteStartDocument() ;
				w.WriteStartElement("response") ;
				w.WriteElementString("error", "0") ;
				w.WriteStartElement("rss") ;
				w.WriteAttributeString("version", "0.91") ;
				w.WriteStartElement("channel") ;
				w.WriteElementString("title", entry.Title ) ;
				w.WriteElementString("link", Config.CurrentBlog(context).UrlFormats.TrackBackUrl(postId));
				w.WriteElementString("description", "" ) ;
				w.WriteElementString("language", "en-us" ) ;

				w.WriteEndElement() ; // channel
				w.WriteEndElement() ; // rss 
				w.WriteEndElement() ; // response
				w.WriteEndDocument() ;
		
			}

		}

		public bool IsReusable
		{
			get { return true; }
		}

		private void trackbackResponse(HttpContext context, int errNum, string errText)
		{
			XmlDocument d = new XmlDocument() ;
			XmlElement root = d.CreateElement("response") ;
			d.AppendChild(root) ;
			XmlElement er = d.CreateElement("error") ;
			root.AppendChild(er) ;
			er.AppendChild(d.CreateTextNode(errNum.ToString())) ;
			if ( errText != "" )
			{
				XmlElement msg = d.CreateElement("message") ;
				root.AppendChild(msg) ;
				msg.AppendChild(d.CreateTextNode(errText)) ;
			}
			d.Save ( context.Response.Output ) ;
			context.Response.End() ;
		}

		private string safeParam(HttpContext context,string pName)
		{
			if ( context.Request.Form[pName] != null )
				return Globals.SafeFormat(context.Request.Form[pName]);
			return  string.Empty;
		}
	}
}

