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

namespace Dottext.Search
{
	/// <summary>
	/// Defines the results of a search query. 
	/// </summary>
	public class ResultSet
	{
		public ResultSet()
		{

		}


		private int _count;
		
		/// <summary>
		/// The total number of items found during the search. This is not necessarily the same number of items returned via ResultSet.Results[]
		/// </summary>
		public int Count
		{
			get {return this._count;}
			set {this._count = value;}
		}

		private long _executionTime;
		
		/// <summary>
		/// How long did the search take?
		/// </summary>
		public long ExecutionTime
		{
			get {return this._executionTime;}
			set {this._executionTime = value;}
		}

		private Result[] _results;
		
		/// <summary>
		/// Property Results (Result[])
		/// </summary>
		public Result[] Results
		{
			get {return this._results;}
			set {this._results = value;}
		}

		private int _pageIndex;
		
		/// <summary>
		/// CurrentPage of the index
		/// </summary>
		public int PageIndex
		{
			get {return this._pageIndex;}
			set {this._pageIndex = value;}
		}
	}
}
