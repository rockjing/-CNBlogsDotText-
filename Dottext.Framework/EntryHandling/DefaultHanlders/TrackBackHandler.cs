using System;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using Dottext.Framework.Tracking;
using Dottext.Framework.Util;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;


namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// Looks for links in the body of the entry, and attempts a trackback to each.
	/// </summary>
	public class TrackBackHandler : IEntryFactoryHandler
	{
		private static Regex regexStripHTML = new Regex("<[^>]+>",RegexOptions.IgnoreCase|RegexOptions.Compiled);
		
		public TrackBackHandler(){}

		//private string BlogName;
		//private string FullyQualifiedUrl;

		#region IEntryFactoryHandler Members

		public void Process(Dottext.Framework.Components.Entry e)
		{
			//Get a list of links from the current post
			StringCollection links = TrackHelpers.GetLinks(e.Body);
			if(links != null && links.Count > 0)
			{
				//Instantiate our proxy
				TrackBackNotificationProxy proxy = new TrackBackNotificationProxy();
				
				//Walk the links
				for(int i = 0; i<links.Count; i++)
				{
					string link = links[i];
					//get the page text
					string pageText = BlogRequest.GetPageText(link,e.Link);
					if(pageText != null)
					{
						try
						{
							string desc = null;
							if(e.HasDescription)
							{
								desc = e.Description;
							}
							else
							{
								desc=string.Format("TrackBack From:{0}",e.Link);
								/*desc = regexStripHTML.Replace(e.Body,string.Empty);
								if(desc.Length > 100)
								{
									int place = 100;
									int len = desc.Length-1;
									while(!Char.IsWhiteSpace(desc[place]) && i < len)
									{
										place++;
									}
									desc = string.Format("{0}...",desc.Substring(0,place));
								}*/
							}

							//attempt a trackback.
							//proxy.TrackBackPing(pageText,link,e.Title,e.Link,e.Author,desc);
						}
						catch(Exception ex)
						{
							Logger.LogManager.CreateExceptionLog(ex,string.Format("Trackback Failure: {0}",link));
						}
					}
				}
			}
		}

		//Grab the blog title before leaving the thread
		public void Configure()
		{
			//BlogConfig config = Config.CurrentBlog();
			//BlogName = config.Title;
			//FullyQualifiedUrl = config.FullyQualifiedUrl;
		}

		#endregion
	}
}
