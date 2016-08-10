#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// 
// .Text is an open source weblog system started by Scott Watermasysk. 
// Blog: http://ScottWater.com/blog 
// RSS: http://scottwater.com/blog/rss.aspx
// Email: Dottext@ScottWater.com
//
// For updated news and information please visit http://scottwater.com/dottext and subscribe to 
// the Rss feed @ http://scottwater.com/dottext/rss.aspx
//
// On its release (on or about August 1, 2003) this application is licensed under the BSD. However, I reserve the 
// right to change or modify this at any time. The most recent and up to date license can always be fount at:
// http://ScottWater.com/License.txt
// 
// Please direct all code related questions to:
// GotDotNet Workspace: http://www.gotdotnet.com/Community/Workspaces/workspace.aspx?id=e99fccb3-1a8c-42b5-90ee-348f6b77c407
// Yahoo Group http://groups.yahoo.com/group/DotText/
// 
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Xml.Serialization;

// TODO: tweak xml serialization for size/utility
namespace Dottext.Framework.Membership
{
	[Serializable]
	public class BlogUser
	{
		#region Members
		private int userID;
		private string userName;
		private string password;
		private UserPasswordFormat userPasswordFormat = UserPasswordFormat.MD5Hash;
		private string salt;
		private string passwordQuestion;
		private string passwordAnswer;
		private string email;
		private UserConfig userConfig;		
		private DateTime dateCreated;
		private DateTime dateLastLogin;
		private DateTime dateLastActive;
		private string lastAction;
		private UserAccountStatus userAccountStatus = UserAccountStatus.Approved;
		private bool isAnonymous=true;
		private bool forceLogin;		
		private string about;
		private string url;
		private string displayLocation;
		private string displayName;
		private string displayEmail;
		private string[] roles;
		
		#endregion
			
		public BlogUser()
		{
			//
		}
		
		#region Accessors
		[XmlAttribute("userID")]
		public int UserID
		{
			get {return this.userID;}
			set {this.userID = value;}
		}
		
		[XmlAttribute("userName")]
		public string UserName
		{
			get{return userName;}
			set{userName = value;}
		}
		
		[XmlIgnore]
		public string Password
		{
			get{return password;}
			set{password = value;}
		}
		
		[XmlIgnore]
		public string Salt
		{
			get {return this.salt;}
			set {this.salt = value;}
		}
		
		[XmlIgnore]
		public string PasswordQuestion
		{
			get {return this.passwordQuestion;}
			set {this.passwordQuestion = value;}
		}
		
		[XmlIgnore]
		public string PasswordAnswer
		{
			get {return this.passwordAnswer;}
			set {this.passwordAnswer = value;}
		}
		
		[XmlAttribute("email")]
		public string Email
		{
			get {return this.email;}
			set {this.email = value;}
		}
		
		[System.Obsolete("Deprecated in favor of DisplayEmail", false)]
		[XmlAttribute("publicEmail")]
		public string PublicEmail
		{
			get {return this.displayEmail;}
			set {this.displayEmail = value;}
		}

		[XmlAttribute("userConfig")]
		public UserConfig UserConfig
		{
			get {return this.userConfig;}
			set {this.userConfig = value;}
		}
		
		public UserAccountStatus UserAccountStatus
		{
			get {return this.userAccountStatus;}
			set {this.userAccountStatus = value;}
		}
		
		public UserPasswordFormat UserPasswordFormat
		{
			get {return this.userPasswordFormat;}
			set {this.userPasswordFormat = value;}
		}

		[XmlIgnore]
		public string LastAction
		{
			get {return this.lastAction;}
			set {this.lastAction = value;}
		}
		
		[XmlIgnore]
		public DateTime DateCreated
		{
			get {return this.dateCreated;}
			set {this.dateCreated = value;}
		}
		
		[XmlIgnore]
		public DateTime DateLastLogin
		{
			get {return this.dateLastLogin;}
			set {this.dateLastLogin = value;}
		}
		
		[XmlIgnore]
		public DateTime DateLastActive
		{
			get {return this.dateLastActive;}
			set {this.dateLastActive = value;}
		}
		
		[XmlIgnore]
		public bool IsAnonymous
		{
			get {return this.isAnonymous;}
			set {this.isAnonymous = value;}
		}
		
		[XmlIgnore]
		public bool ForceLogin
		{
			get {return this.forceLogin;}
			set {this.forceLogin = value;}
		}
		
		[XmlAttribute("displayEmail")]
		public string DisplayEmail
		{
			get
			{
				return displayEmail;
			}
			set
			{
				displayEmail = value;
			}
		}

		[XmlAttribute("displayName")]
		public string DisplayName
		{
			get
			{
				return displayName;
			}
			set
			{
				displayName = value;
			}
		}

		[XmlAttribute("displayLocation")]
		public string DisplayLocation
		{
			get
			{
				return displayLocation;
			}
			set
			{
				displayLocation = value;
			}
		}
		
		[XmlAttribute("url")]
		public string Url
		{
			get
			{
				return url;
			}
			set
			{
				url = value;
			}
		}

		[XmlAttribute("about")]
		public string About
		{
			get
			{
				return about;
			}
			set
			{
				about = value;
			}
		}
		
		public string[] Roles
		{
			get {return this.roles;}
			set {this.roles = value;}
		}

		#endregion
	}
}