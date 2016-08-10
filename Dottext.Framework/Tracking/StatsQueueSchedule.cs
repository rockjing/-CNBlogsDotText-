using System;

namespace Dottext.Framework.Tracking
{
	/// <summary>
	/// Summary description for StatsQueueSchedule.
	/// </summary>
	public class StatsQueueSchedule : Dottext.Framework.ScheduledEvents.IEvent
	{
		public StatsQueueSchedule()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region IEvent Members

		public void Execute(object state)
		{
			Stats.ClearQueue(true);
		}

		#endregion
	}
}
