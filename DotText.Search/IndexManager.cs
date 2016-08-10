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
using System.Collections;
using System.IO;

using Lucene.Net.Documents;
//Need to add a method for inserting additional items into an existing index. Probably an array and single Document

namespace Dottext.Search
{
	/// <summary>
	/// IndexManager is responsbible for building the actual index. You current can only rebuild the entire index. While rebuilding, you 
	/// have two choices, "Safe" and regular. Safe builds the index to a temporary directory and then aquires a write lock on the location of the main index.
	/// In regular mode, the index is build directly to the live location. Durring the rebuild, the index will be under a write lock.
	/// </summary>
	public class IndexManager
	{
		//Can not be initialized
		private IndexManager()
		{

		}

		/// <summary>
		/// Private method for moving an index from the temp location to the live locations. While moving the files from the remote to live location a SearchLock.AquireWriter lock
		/// is requested.
		/// </summary>
		private static void MoveTempFiles()
		{
			//find the real location
			string path = SearchConfiguration.Instance().PhysicalPath;
			//temp location is one folder above the live location
			string tempIndex = System.IO.Path.Combine(path,SearchConfiguration.TempIndex);

			DirectoryInfo di = new DirectoryInfo(tempIndex);
			FileInfo[] files = di.GetFiles();
			try
			{
				foreach(FileInfo fi in files)
				{
					fi.CopyTo(Path.Combine(path,fi.Name),true);
					fi.Delete();
				}
			}
			catch(Exception e)
			{
				Dottext.Framework.Logger.LogManager.CreateExceptionLog(e,"MoveTempFiles Fail");
			}
		}

		/// <summary>
		/// Rebuilds the entire index directly to the live Search index folder. A SearchLock.AquireWriter is requested during this build, so no searches are possible
		/// durning the building of the index.
		/// </summary>
		/// <param name="lockSeconds">Number of seconds to request the Writer lock</param>
		public static void RebuildIndex(int lockSeconds)
		{
			//We need a lock for the entire build.
			SearchLock.AquireWriter(lockSeconds);
			try
			{
				Build(false);
			}
			finally
			{
				SearchLock.ReleaseWriter();
			}
		}

		/// <summary>
		/// Rebuilds the entire index directly to the live Search index folder. A SearchLock.AquireWriter is requested during this build, so no searches are possible
		/// durning the building of the index. Uses a 300 second default lock.
		/// </summary>
		public static void RebuildIndex()
		{
			RebuildIndex(300);
		}

		/// <summary>
		/// Rebuilds the entire index to a temporary location. Once the index is finished and optimized it is moved to the live location. During the move
		/// a SearchLock.AquireWriter is requested. During searches, a 30 second SearchLock.AquireReader is requested, so this should mean no downtime for searches.
		/// </summary>
		/// <param name="lockSeconds">Number of seconds to request the Writer lock</param>
		public static void RebuildSafeIndex(int lockSeconds)
		{
			try
			{
				//System.Diagnostics.Debug.WriteLine("Start");
				SearchLock.AquireWriter(lockSeconds);
				Build(false);
				//System.Diagnostics.Debug.WriteLine("Build");
			
				//System.Diagnostics.Debug.WriteLine("Lock");
				//MoveTempFiles();
				//System.Diagnostics.Debug.WriteLine("Moved");
			}
			catch(Exception e)
			{
				Dottext.Framework.Logger.LogManager.CreateExceptionLog(e,"RebuildSafeIndex Fail");
			}
			finally
			{
				SearchLock.ReleaseWriter();
			}
		}

		/// <summary>
		/// Rebuilds the entire index to a temporary location. Once the index is finished and optimized it is moved to the live location. During the move
		/// a SearchLock.AquireWriter is requested. During searches, a 30 second SearchLock.AquireReader is requested, so this should mean no downtime for searches. 
		/// A 30 second lock is the default.
		/// </summary>
		public static void RebuildSafeIndex()
		{
			RebuildSafeIndex(30);
		}

		/// <summary>
		/// Build rebuilds the entire index
		/// </summary>
		/// <param name="useTempDirectory">Indicates if the index should be built in a temporary location first.</param>
		private static void Build(bool useTempDirectory)
		{
			string path = SearchConfiguration.Instance().PhysicalPath;
			Indexer index = new Indexer(path,false,useTempDirectory);
			EntryData data = new EntryData();
			try
			{
				data.BuildItems(SearchConfiguration.Instance().Domains,index);
				
			}
			catch(Exception e)
			{
				Dottext.Framework.Logger.LogManager.CreateExceptionLog(e,"BuildItem Fail");
			}
				//ArrayList al = data.IndexDocuments(SearchConfiguration.Instance().Domains);
			
				/*Document doc = null;
				for(int i = 0;i<al.Count;i++)
				{
					doc = (Document)al[i];
					index.AddDocument(doc);
				}*/
			finally
			{
				index.Close();
			}
		}

	}
}
