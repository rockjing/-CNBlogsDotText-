using System;

namespace Dottext.Framework.Components
{
	/// <summary>
	/// Summary description for EntryStatsView.
	/// </summary>
	public class EntryStatsView : Entry
	{
		public EntryStatsView()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		

		private DateTime _webLastUpdated;
		public DateTime WebLastUpdated
		{
			get {return this._webLastUpdated;}
			set {this._webLastUpdated = value;}
		}

		private DateTime _aggLastUpdated;
		public DateTime AggLastUpdated
		{
			get {return this._aggLastUpdated;}
			set {this._aggLastUpdated = value;}
		}


	}
}
