using System;

namespace Dottext.Framework.Components
{
	/// <summary>
	/// Summary description for PagedEntryQuery.
	/// </summary>
	public class PagedEntryQuery : EntryQuery
	{
		public PagedEntryQuery()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private int _pageIndex;
		/// <summary>
		/// Property PageIndex (int)
		/// </summary>
		public int PageIndex
		{
			get {return this._pageIndex;}
			set {this._pageIndex = value;}
		}

		private int _pageSize;
		
		/// <summary>
		/// Property PageSize (int)
		/// </summary>
		public int PageSize
		{
			get {return this._pageSize;}
			set {this._pageSize = value;}
		}

		




	}
}
