using System;

namespace Dottext.Framework.Logger
{
	/// <summary>
	/// Summary description for Log.
	/// </summary>
	public class Log
	{
		public Log()
		{
			this.StartDate = DateTime.Now;
			this.ServerName = Environment.MachineName;
			this.BlogID = -1;
			this.LogID = -1;
		}

		private int _logID;
		
		/// <summary>
		/// Property LogID (int)
		/// </summary>
		public int LogID
		{
			get {return this._logID;}
			set {this._logID = value;}
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

		private string _message;
		
		/// <summary>
		/// Property Message (string)
		/// </summary>
		public string Message
		{
			get {return this._message;}
			set {this._message = value;}
		}

		private string _userName;
		
		/// <summary>
		/// Property UserName (string)
		/// </summary>
		public string UserName
		{
			get {return this._userName;}
			set {this._userName = value;}
		}

		private string _serverName;
		
		/// <summary>
		/// Property ServerName (string)
		/// </summary>
		public string ServerName
		{
			get {return this._serverName;}
			set {this._serverName = value;}
		}

		private string _url;
		
		/// <summary>
		/// Property Url (string)
		/// </summary>
		public string Url
		{
			get {return this._url;}
			set {this._url = value;}
		}

		private int _blogID;
		
		/// <summary>
		/// Property BlogID (int)
		/// </summary>
		public int BlogID
		{
			get {return this._blogID;}
			set {this._blogID = value;}
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
			get 
			{
				if(setEndDate)
				{
					return this._endDate;
				}
				else
				{
					return StartDate;
				}
			}
			set 
			{
				setEndDate = true;
				this._endDate = value;
			}
		}

		private bool setEndDate = false;
	}
}
