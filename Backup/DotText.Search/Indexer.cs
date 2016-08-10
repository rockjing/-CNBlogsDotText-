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
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;


namespace Dottext.Search
{
	/// <summary>
	/// Indexer is a wrapper for generating an index.
	/// </summary>
	public class Indexer : IDisposable
	{
		protected Directory dir = null;
		protected IndexWriter writer = null;
		
		/// <summary>
		/// Instantiates an Indexer
		/// </summary>
		/// <param name="physicalPath">Path where the index to be located or created</param>
		/// <param name="create">Do we want to create a new index</param>
		/// <param name="useTempDirectory">Are we writing the index to a temporary location</param>
		public Indexer(string physicalPath, bool create, bool useTempDirectory)
		{
			//if temp, change the physicalpath to a temp location.
			if(useTempDirectory)
			{
				physicalPath = System.IO.Path.Combine(physicalPath,SearchConfiguration.TempIndex);
			}
			if(!System.IO.File.Exists(physicalPath+"\\segments"))
			{
				create=true;
			}
			dir = FSDirectory.GetDirectory(physicalPath,create);
			//dir.Close();

			//The WRITER AND READER analyzer must be the SAME.
			
			
			writer = new IndexWriter(dir,ConfigAnalyzer.GetAnalyzer(),create);
			//writer.SetUseCompoundFile(true);
			writer.mergeFactor = 15;
			
		}

		/// <summary>
		/// Add a document to the Index.
		/// </summary>
		/// <param name="doc">A Lucene Docment to Index</param>
		public void AddDocument(Document doc)
		{
			writer.AddDocument(doc);
		}

		/// <summary>
		/// Closes and optimizes the index.
		/// </summary>
		public void Close()
		{
			if(!disposed)
			{
				dir.Close();
				writer.Optimize();
				writer.Close();
				disposed = true;
			}
		}

		private bool disposed = false;

		/// <summary>
		/// Closes and optimizes the index.
		/// </summary>
		public void Dispose()
		{
			Close();
		}

	}
}
