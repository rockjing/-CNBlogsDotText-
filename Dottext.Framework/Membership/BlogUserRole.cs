using System;

namespace Dottext.Framework.Membership
{
	/// <summary>
	/// Summary description for BlogUserRole.
	/// </summary>
	public class BlogUserRole
	{
		public BlogUserRole()
		{

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

		private string _userName;
		
		/// <summary>
		/// Property UserName (string)
		/// </summary>
		public string UserName
		{
			get {return this._userName;}
			set {this._userName = value;}
		}

		private int _userID;
		
		/// <summary>
		/// Property UserID (int)
		/// </summary>
		public int UserID
		{
			get {return this._userID;}
			set {this._userID = value;}
		}

		private BlogRole _blogRole;
		
		/// <summary>
		/// Property BlogRole (BlogRole)
		/// </summary>
		public BlogRole BlogRole
		{
			get {return this._blogRole;}
			set {this._blogRole = value;}
		}
	}
}
