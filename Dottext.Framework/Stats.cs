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
using System.Collections;
using System.Collections.Specialized;
using Dottext.Framework.Components;
using Dottext.Framework.Tracking;
using Dottext.Framework.Configuration;
using Dottext.Framework.Util;
using Dottext.Framework.Providers;

namespace Dottext.Framework
{
	/// <summary>
	/// Summary description for Stats.
	/// </summary>
	public class Stats
	{
		private Stats(){}

		static EntryViewCollection queuedStatsList = null;

		static Stats()
		{
			if(Config.Settings.Tracking.QueueStats)
			{
				queuedStatsList = new EntryViewCollection();
			}
		}

		/// <summary>
		/// Clear Queue will empty the EntryViewCollection. The bool save value will determine if the results are
		/// saved to the datastore or not.
		/// </summary>
		/// <param name="save"></param>
		/// <returns></returns>
		public static bool ClearQueue(bool save)
		{
			lock(queuedStatsList.SyncRoot)
			{
				if(save)
				{
					EntryView[] eva = new EntryView[queuedStatsList.Count];
					queuedStatsList.CopyTo(eva,0);

					ClearTrackEntryQueue(new EntryViewCollection(eva));
					
				}
				queuedStatsList.Clear();	
			}
			return true;
		}

		/// <summary>
		/// Adds an EntryView to the in memory EntryViewCollection
		/// </summary>
		/// <param name="ev"></param>
		/// <returns></returns>
		public static bool AddQueuedStats(EntryView ev)
		{
			if(queuedStatsList==null)
			{
				queuedStatsList = new EntryViewCollection();
			}
			queuedStatsList.Add(ev);
			return true;
		}

		//Since we are now clearing the queue via a timer, do we even need to do this async?

		/// <summary>
		/// Internal method for asyc clearing of the EntryViewCollection. 
		/// </summary>
		/// <param name="evc"></param>
		/// <returns></returns>
		private static bool ClearTrackEntryQueue(EntryViewCollection evc)
		{
			ProcessStats ps = new ProcessStats(evc);
			ps.Enqueue();
			
			return true;
		}

		private class ProcessStats
		{
			public ProcessStats(EntryViewCollection evc)
			{
				_evc = evc;
			}
			protected EntryViewCollection _evc;

			public void Enqueue()
			{
				ManagedThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(Process));
			}

			private void Process(object state)
			{
				Stats.TrackEntry(this._evc);
			}
		}

		#region Data

		public static PagedReferrerCollection GetPagedReferrers(int pageIndex, int pageSize)
		{
			return DTOProvider.Instance().GetPagedReferrers(pageIndex, pageSize);
		}

		public static PagedReferrerCollection GetPagedReferrers(int pageIndex, int pageSize, int EntryID)
		{
			return DTOProvider.Instance().GetPagedReferrers(pageIndex, pageSize, EntryID);
		}

		#endregion
		

		/// <summary>
		/// Adds an individual EntryView to the datastore
		/// </summary>
		/// <param name="ev"></param>
		/// <returns></returns>
		public static bool TrackEntry(EntryView ev)
		{
			return DTOProvider.Instance().TrackEntry(ev);
		}

		/// <summary>
		/// Adds a collection of EntryViews to the datastore.
		/// </summary>
		/// <param name="evc"></param>
		/// <returns></returns>
		public static bool TrackEntry(EntryViewCollection evc)
		{
			return DTOProvider.Instance().TrackEntry(evc);
		}
	}
}

