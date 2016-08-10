using System;
using System.Diagnostics;
using System.Web;
using System.Threading;
using Dottext.Framework.Util;


using Dottext.Framework.Configuration;

namespace Dottext.Framework.ScheduledEvents
{
	/// <summary>
	/// EventManager is called from the EventHttpModule (or another means of scheduling a Timer). Its sole purpose
	/// is to iterate over an array of Events and deterimine of the Event's IEvent should be processed. All events are
	/// added to the managed threadpool. 
	/// </summary>
	public class EventManager
	{
		private EventManager()
		{
		}

		public static readonly int TimerMinutesInterval = 5;


		public static void Execute()
		{
			Event[] items = Config.Settings.ScheduledItems;
            Event item = null;
			
			if(items != null)
			{
				
				for(int i = 0; i<items.Length; i++)
				{
					item = items[i];
					if(item.ShouldExecute)
					{
						item.UpdateTime();
						IEvent e = item.IEventInstance;
						ManagedThreadPool.QueueUserWorkItem(new WaitCallback(e.Execute));
					}
				}
			}
		}
	}
}
