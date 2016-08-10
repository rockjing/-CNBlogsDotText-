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
using System.Threading;

namespace Dottext.Search
{
	/// <summary>
	/// No reads can take place while the index is being written. Search lock simply defines a common read/write aquire location
	/// </summary>
	public class SearchLock
	{
		//Can not be initalized
		private SearchLock(){}

		static SearchLock()
		{
			//initialize a singleton ReaderWriter lock.
			rwl = new ReaderWriterLock();
		}

		private static ReaderWriterLock rwl = null;

		/// <summary>
		/// Number of seconds to wait for a read.
		/// </summary>
		/// <param name="timeout"></param>
		public static void AquireReader(int timeout)
		{
			rwl.AcquireReaderLock(timeout*1000);
		}


		/// <summary>
		/// Release the reader lock
		/// </summary>
		public static void ReleaseReader()
		{
			rwl.ReleaseReaderLock();
		}

		/// <summary>
		/// Release the writer lock
		/// </summary>
		public static void ReleaseWriter()
		{
			rwl.ReleaseWriterLock();
		}

		/// <summary>
		///  Number of seconds to a aquire a writer lock
		/// </summary>
		/// <param name="timeout"></param>
		public static void AquireWriter(int timeout)
		{
			rwl.AcquireWriterLock(timeout*1000);
		}




	}
}
