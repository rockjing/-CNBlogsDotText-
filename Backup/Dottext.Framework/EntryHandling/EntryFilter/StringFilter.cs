using System;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// StringFilter 的摘要说明。
	/// </summary>
	public class StringFilter:Attribute
	{
		public StringFilter(FilterType filterType)
		{
			this._filterType=filterType;
		}

		protected FilterType _filterType;

		public FilterType FilterType
		{
			get
			{
				return _filterType;
			}
		}


	}
}
