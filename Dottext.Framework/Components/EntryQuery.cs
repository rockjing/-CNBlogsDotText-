using System;
using Dottext.Framework.Components;

namespace Dottext.Framework.Components
{
	
	/// <summary>
	/// Summary description for EntryQuery.
	/// </summary>
	public class EntryQuery
	{
		private static readonly DateTime defaultDate = new DateTime(1999,1,1,new System.Globalization.GregorianCalendar());
		public EntryQuery()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public EntryQuery(PostConfig config, PostType postType)
		{
			this.PostConfig = config;
			this.PostType = postType;
		}

		public EntryQuery(PostConfig config, PostType postType, int itemCount)
		{
			this.PostConfig = config;
			this.PostType = postType;
			this.ItemCount = itemCount;
		}

		#region Properties
		private int _itemCount;
		
		/// <summary>
		/// Property ItemCount (int)
		/// </summary>
		public int ItemCount
		{
			get {return this._itemCount;}
			set {this._itemCount = value;}
		}

		private int _categoryID;
		/// <summary>
		/// Property CategoryID (int)
		/// </summary>
		public int CategoryID
		{
			get {return this._categoryID;}
			set {this._categoryID = value;}
		}

		private string _categoryTitle;
		/// <summary>
		/// Property CategoryTitle (string)
		/// </summary>
		public string CategoryTitle
		{
			get {return this._categoryTitle;}
			set {this._categoryTitle = value;}
		}

		private PostConfig _postConfig= PostConfig.Empty;
		/// <summary>
		/// Property PostConfig (PostConfig)
		/// </summary>
		public PostConfig PostConfig
		{
			get {return this._postConfig;}
			set {this._postConfig = value;}
		}

		private PostType _postType = PostType.Undeclared;
		
		/// <summary>
		/// Property PostType (PostType)
		/// </summary>
		public PostType PostType
		{
			get {return this._postType;}
			set {this._postType = value;}
		}

		private DateTime _startDate;
		
		/// <summary>
		/// Property StartDate (DateTime)
		/// </summary>
		public DateTime StartDate
		{
			get {return this._startDate;}
			set {this._startDate = value;}
		}

		private DateTime _endDate;
		
		/// <summary>
		/// Property EndDate (DateTime)
		/// </summary>
		public DateTime EndDate
		{
			get {return this._endDate;}
			set {this._endDate = value;}
		}
		#endregion

		public bool HasCategoryID
		{
			get
			{
				return this.CategoryID > 0;
			}
		}

		public bool HasCategoryTitle
		{
			get
			{
				return this.CategoryTitle != null && this.CategoryTitle.Trim().Length > 0;
			}
		}

		public bool HasCategory
		{
			get	{return this.HasCategoryID || this.HasCategoryTitle;}
		}


		public bool HasStartDate
		{
			get{ return this.StartDate.Year > 1999;}
		}

		public bool HasEndDate
		{
			get{ return HasStartDate && this.EndDate.Year > 1999;}
		}

		public void Reset()
		{
			this.CategoryTitle = null;
			this.CategoryID = 0;
			ClearDates();

		}

		public void ClearDates()
		{
			this.StartDate = defaultDate;
			this.EndDate = defaultDate;
		}

		private CategoryType _cateType=CategoryType.Undeclared;
		public CategoryType CateType
		{
			get {return this._cateType;}
			set {this._cateType = value;}
		}
			
		public bool HasCateType
		{
			get
			{
				return _cateType != CategoryType.Undeclared;
			}
		}

		private int _blogGroupID;
		public int BlogGroupID
		{
			get {return this._blogGroupID;}
			set {this._blogGroupID = value;}
		}
			
		public bool HasBlogGroupID
		{
			get
			{
				return _blogGroupID > 0;
			}
		}

		private string _author;
		public string Author
		{
			get {return this._author;}
			set {this._author = value;}
		}
			
		public bool HasAuthor
		{
			get
			{
				return this.Author != null && this.Author.Trim().Length > 0;
			}
			
		}


	}
}
