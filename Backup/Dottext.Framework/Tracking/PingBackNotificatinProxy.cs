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
 // ASPNetWeblog isnot responsible for, shall have no liability for 
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
 // Originally based off of code by Simon Fell http://www.pocketsoap.com/weblog/ 
 // 
 ///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion
using System;
using CookComputing.XmlRpc;
using System.Text.RegularExpressions;

namespace Dottext.Framework.Tracking
{
	/// <summary>
	/// Summary description for WeblogsNotificatinProxy.
	/// </summary>
	
	public class PingBackNotificatinProxy : XmlRpcClientProtocol
	{
		public PingBackNotificatinProxy()
		{
			
		}

		private string errormessage = "No Error";
		public string ErrorMessage
		{
			get{return errormessage;}
		}

		public bool Ping(string pageText,string sourceURI, string targetURI)
		{
			string pingbackURL = GetPingBackURL(pageText,targetURI,sourceURI);
			if(pingbackURL != null)
			{
				this.Url = pingbackURL;
				try
				{
					Notifiy(sourceURI,targetURI);
					return true;
				}
				catch(Exception ex)
				{
					errormessage = "Error: " + ex.Message;
				}
			}
			return false;

		}

		private  string GetPingBackURL(string pageText, string url, string PostUrl)
		{
			if(!Regex.IsMatch(pageText,PostUrl,RegexOptions.IgnoreCase|RegexOptions.Singleline))
			{
				if(pageText != null)
				{
					string pat = "<link rel=\"pingback\" href=\"([^\"]+)\" ?/?>";
					Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline  ) ;
					Match m = reg.Match(pageText) ;
					if ( m.Success )
					{
						return m.Result("$1") ;
					}
				}		
			}
			return null;
		}

		[XmlRpcMethod("pingback.ping")]
		public void Notifiy(string sourceURI , string targetURI )
		{
			Invoke("Notifiy",new object[] {sourceURI,targetURI});
		}

	}
}

