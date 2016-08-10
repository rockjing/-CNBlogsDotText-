using System;
using System.Web;
using System.Threading;
using System.Diagnostics;

using Dottext.Framework.Logger;

namespace Dottext.Framework.ScheduledEvents
{
	/// <summary>
	/// Summary description for EventModule.
	/// </summary>
	public class EventHttpModule : System.Web.IHttpModule
	{
		static Timer eventTimer;

		public EventHttpModule()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region IHttpModule Members

		public void Init(System.Web.HttpApplication application)
		{
			if (eventTimer == null)
			{
				//eventTimer = new Timer(new TimerCallback(ScheduledEventWorkCallback), application.Context, 60000, 60000);
				eventTimer = new Timer(new TimerCallback(ScheduledEventWorkCallback), application.Context, 60000, EventManager.TimerMinutesInterval * 60000);
			}
		}

		private void ScheduledEventWorkCallback(object sender)
		{
			try
			{
				EventManager.Execute();
			}
			catch(Exception ex)
			{
				LogManager.CreateExceptionLog(ex,"Failed ScheduledEventCallBack");
			}

		}

		public void Dispose()
		{
			eventTimer = null;
		}

		#endregion
	}
}
