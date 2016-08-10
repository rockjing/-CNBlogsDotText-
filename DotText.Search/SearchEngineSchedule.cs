#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// Blog:		http://ScottWater.com/blog 
// RSS:			http://scottwater.com/blog/rss.aspx
// License:		http://scottwater.com/License
// Email:		Scott@TripleASP.NET
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion
using System;
using Dottext.Framework.Logger;

namespace Dottext.Search
{
	/// <summary>
	/// Summary description for SearchEngineSchedule.
	/// </summary>
	public class SearchEngineSchedule : Dottext.Framework.ScheduledEvents.IEvent
	{
		public SearchEngineSchedule()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region IEvent Members

		public void Execute(object state)
		{
			Log log = new Log();
			log.Title = "Search Index";
			log.Message = string.Format("Daily ({0}) Build",log.StartDate.ToShortDateString());

			IndexManager.RebuildSafeIndex(30);

			log.EndDate = DateTime.Now;
			
			LogManager.Create(log);
			
		}

		#endregion
	}
}
