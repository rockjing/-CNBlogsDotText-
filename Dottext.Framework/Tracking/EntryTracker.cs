using System;
using System.Web;
using System.Text.RegularExpressions;

using Dottext.Framework.Configuration;
using Dottext.Framework.Util;
using Dottext.Framework.Components;

namespace Dottext.Framework.Tracking
{
	/// <summary>
	/// Summary description for TrackEntry.
	/// </summary>
	public class EntryTracker
	{
		private EntryTracker()
		{

		}

		static EntryTracker()
		{
			Dottext.Framework.Configuration.Tracking tracking = Config.Settings.Tracking;
			WebTrack = tracking.EnableWebStats;
			AggTrack = tracking.EnableAggBugs;
			QueueStats = tracking.QueueStats;
		}
		


		private static bool WebTrack = false;
		private static bool AggTrack = false;
		private static bool QueueStats = false;
		

		public static bool Track(int EntryID, int BlogID)
		{
			if(AggTrack)
			{
				EntryView ev = new EntryView();
				ev.EntryID = EntryID;
				ev.BlogID = BlogID;
				ev.PageViewType = PageViewType.AggView;
				return Stats.TrackEntry(ev);
			}
			return false;
		}

		public static bool Track(EntryView ev)
		{
			if(QueueStats)
			{
				return Stats.AddQueuedStats(ev);
			}
			else
			{
				return Stats.TrackEntry(ev);
			}
		}

		public static bool Track(HttpContext context, int EntryID, int BlogID)
		{
			if(WebTrack)
			{
				if(FilerUserAgent(context.Request.UserAgent))
				{
					if(context.Request.HttpMethod != "POST")
					{
						if(IsOkay(context,EntryID))
						{
							string refUrl = GetReferral(context.Request);
							EntryView ev = new EntryView();
							ev.EntryID = EntryID;
							ev.BlogID = BlogID;
							ev.ReferralUrl = refUrl;
							ev.PageViewType = PageViewType.WebView;
							return Track(ev);
							
						}
				
					}
				}
			}
			return false;
		}

		private static string GetReferral(HttpRequest Request)
		{
			string url = Globals.GetUriReferrerSafe(Request);
			if(url != null)
			{
				url = url.ToLower().Replace("www.",string.Empty);
				string fqu = Config.CurrentBlog().FullyQualifiedUrl.ToLower().Replace("www.",string.Empty);
				if(Regex.IsMatch(url,fqu,RegexOptions.IgnoreCase))
				{
					return null;
				}
			}
			return url;
		}

		private static bool FilerUserAgent(string agent)
		{
			return (agent != null && agent.Length > 0 && Regex.IsMatch(agent,"msie|mozilla|opera",RegexOptions.IgnoreCase));
		}

		private static bool IsOkay(HttpContext context,int entryID)
		{
			string key=Util.Globals.GetClientGUID(context)+entryID.ToString();
			
			if(context.Cache[key]==null)
			{
				context.Cache.Insert(key,"ok",null,DateTime.Now.AddHours(1),TimeSpan.Zero);
				return true;
			}
			return false;
		}
	}
}
