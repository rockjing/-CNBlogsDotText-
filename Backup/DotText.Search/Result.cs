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
using Dottext.Framework.Components;

namespace Dottext.Search
{
	/// <summary>
	/// Represents an individual search result
	/// </summary>
	public class Result
	{
		public Result()
		{

		}

		private string _permaLink;
		
		/// <summary>
		/// Property Link (string)
		/// </summary>
		public string PermaLink
		{
			get {return this._permaLink;}
			set {this._permaLink = value;}
		}

		private string _title;
		
		/// <summary>
		/// Property Title (string)
		/// </summary>
		public string Title
		{
			get {return this._title;}
			set {this._title = value;}
		}

		private string _body;
		
		/// <summary>
		/// Property Body (string)
		/// </summary>
		public string Body
		{
			get {return this._body;}
			set {this._body = value;}
		}

		private string _description;
		
		/// <summary>
		/// Property Description (string)
		/// </summary>
		public string Description
		{
			get {return this._description;}
			set {this._description = value;}
		}

		private PostType _postType;
		
		/// <summary>
		/// Property PostType (PostType)
		/// </summary>
		public PostType PostType
		{
			get {return this._postType;}
			set {this._postType = value;}
		}

		private string _dateCreated;
		
		/// <summary>
		/// Property DateCreated (DateTime)
		/// </summary>
		public string DateCreatedString
		{
			get {return this._dateCreated;}
			set {this._dateCreated = value;}
		}

		private float _score;
		
		/// <summary>
		/// Property Score (float)
		/// </summary>
		public float Score
		{
			get {return this._score;}
			set {this._score = value;}
		}

		private string _author;
		
		/// <summary>
		/// Property Author (string)
		/// </summary>
		public string Author
		{
			get {return this._author;}
			set {this._author = value;}
		}

		private string _rawPost;
		
		/// <summary>
		/// Property RawPost (string)
		/// </summary>
		public string RawPost
		{
			get {return this._rawPost;}
			set {this._rawPost = value;}
		}

		private int _boostFactor;
		
		/// <summary>
		/// Property BoostFactor (float)
		/// </summary>
		public int BoostFactor
		{
			get {return this._boostFactor;}
			set {this._boostFactor = value;}
		}
	}
}
