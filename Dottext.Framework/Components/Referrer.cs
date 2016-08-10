using System;

namespace Dottext.Framework.Components
{
	/// <summary>
	/// Summary description for Referrer.
	/// </summary>
	[Serializable]
	public class Referrer : IBlogIdentifier
	{

		private string _referrerURL;
		private int _entryID;
		private string _postTitle;
		private DateTime _lastreferDate;
		private int _count;

		public Referrer()
		{
		}

		public string ReferrerURL
		{
			get {
				if(!_referrerURL.StartsWith("http://"))
				{
					return "http://" + _referrerURL;
				}
				return _referrerURL; }
			set { _referrerURL = value; }
		}

		public int Count
		{
			get { return _count; }
			set { _count = value; }
		}

		public int EntryID
		{
			get { return _entryID; }
			set { _entryID = value; }
		}

		public string PostTitle
		{
			get { return _postTitle; }
			set { _postTitle = value; }
		}

		public DateTime LastReferDate
		{
			get { return _lastreferDate; }
			set { _lastreferDate = value; }
		}

		private int _blogID;
		public int BlogID
		{
			get {return this._blogID;}
			set {this._blogID = value;}
		}

	}
}
