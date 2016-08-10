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
using System.Collections.Specialized;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Dottext.Framework.Components;
using Dottext.Framework.Format;
using Dottext.Framework.Util;
using Dottext.Framework.Providers;
using System.Reflection;
using System.Web.Caching;

namespace Dottext.Framework.Configuration
{
	/// <summary>
	/// Summary description for Configuration.
	/// </summary>
	[Serializable]
	public class BlogConfig : IBlogIdentifier
	{
		private object urlLock = new object();

		public BlogConfig()
		{
		}

		private UrlFormats _UrlFormats = null;
		[XmlIgnore]
		public UrlFormats UrlFormats
		{
			get
			{
				if(_UrlFormats == null)
				{
					lock(urlLock)
					{
						if(_UrlFormats == null)
						{
							_UrlFormats = UrlFormatProvider.Instance(this.FullyQualifiedUrl);
						}
					}
				}
				return _UrlFormats;
			}
		}

		private string _imageDirectory;
		[XmlIgnore]
		public string ImageDirectory
		{
			get{return _imageDirectory;}
			set{_imageDirectory = value;}
		}

		private string _imagePath;
		[XmlIgnore]
		public string ImagePath
		{
			get{return _imagePath;}
			set{_imagePath = value;}
		}
		

		private DateTime _lastupdated;
		[XmlIgnore]
		public DateTime LastUpdated
		{
			get{return _lastupdated;}
			set{_lastupdated = value;}
		}

		private int _blogID = -1;
		
		public int BlogID
		{
			get{return _blogID;}
			set{_blogID = value;}
		}

		private int _timeZone = 0;
		[XmlIgnore]
		public int TimeZone
		{
			get{return _timeZone;}
			set{_timeZone = value;}
		}

		private int _itemCount = 15;
		public int ItemCount
		{
			get{return _itemCount;}
			set{_itemCount = value;}
		}

		private string _language = "en-US";
		[XmlIgnore]
		public string Language
		{
			get{return _language;}
			set{_language = value;}
		}

		private string _email;
		[XmlIgnore]
		public string Email
		{
			get{return _email;}
			set{_email = value;}
		}

		private string _host;
		[XmlIgnore]
		public string Host
		{
			get{return _host;}
			set{_host = value.Replace("www.",string.Empty);}
		}

		//not sure if this should be a persisted value or not
		private bool _isVirtual;
		[XmlIgnore]
		public bool IsVirtual
		{
			get{return _isVirtual;}
			set{_isVirtual = value;}
		}

		[XmlIgnore]
		public bool AllowServiceAccess
		{
			get{return FlagPropertyCheck(ConfigurationFlag.EnableServiceAccess);}
			set{FlagSetter(ConfigurationFlag.EnableServiceAccess,value);}
		}

		[XmlIgnore]
		public bool IsPasswordHashed
		{
			get{return FlagPropertyCheck(ConfigurationFlag.IsPasswordHashed);}
			set{FlagSetter(ConfigurationFlag.IsPasswordHashed,value);}
		}

		public bool IsAggregated
		{
			get{return FlagPropertyCheck(ConfigurationFlag.IsAggregated);}
			set{FlagSetter(ConfigurationFlag.IsAggregated,value);}
		}

		[XmlIgnore]
		public bool EnableComments
		{
			get{return FlagPropertyCheck(ConfigurationFlag.EnableComments);}
			set{FlagSetter(ConfigurationFlag.EnableComments,value);}
		}

		public bool IsActive
		{
			get{return FlagPropertyCheck(ConfigurationFlag.IsActive);}
			set{FlagSetter(ConfigurationFlag.IsActive,value);}
		}

		private string _application;
		[XmlIgnore]
		public string Application
		{
			get{return _application;}
			set
			{
				_application = value;
				if(!_application.StartsWith("/"))
				{
					_application = "/" + _application;
				}
				if(!_application.EndsWith("/"))
				{
					_application = _application + "/";
				}
			}

		}

		private string _password;
		[XmlIgnore]
		public string Password
		{
			get
			{
				/*if(_password == null)
				{
					ConfigException("Invalid Password Setting");
				}*/
				return _password;
			}
			set{_password = value;}
		}

		private string _username;
		[XmlIgnore]
		public string UserName
		{
			get
			{
				if(_username == null)
				{
					//ConfigException("Invalid UserName Setting");
				}
				return _username;
			}
			set{_username = value;}
		}

		private string _title;
		public virtual string Title
		{
			get{return _title;}
			set{_title = value;}
		}

		private string _subtitle;
		public virtual string SubTitle
		{
			get{return _subtitle;}
			set{_subtitle = value;}
		}

		private SkinConfig _skin;
		public SkinConfig Skin
		{
			get{return _skin;}
			set{_skin = value;}
		}

		[XmlIgnore]
		public bool HasNews
		{
			get{ return News != null && News.Trim().Length > 0;}
		}

		private string news;
		[XmlIgnore]
		public string News
		{
			get{return news;}
			set{news = value;}
		}

		private string _author = ".Text WebLog";
		public string Author
		{
			get{
				return _author;
			}
			set{_author = value;}
		}
		

	
		private string fullyQualifiedUrl;
		[XmlIgnore]
		public string FullyQualifiedUrl
		{
			get{return fullyQualifiedUrl;}
			set
			{
				if(value != null && value.StartsWith("http://"))
				{
					fullyQualifiedUrl = value;
				}
				else
				{
					fullyQualifiedUrl = "http://" + value;
				}
				if(!fullyQualifiedUrl.EndsWith("/"))
				{
					fullyQualifiedUrl += "/";
				}
			}
		}

		private ConfigurationFlag _flag = ConfigurationFlag.Empty;
		[XmlIgnore]
		public ConfigurationFlag Flag
		{
			get{return _flag;}
			set{_flag = value;}
		}
		
		[XmlIgnore]
		public string CleanApplication
		{
			get {return this.Application.Replace("/",string.Empty).Trim();}
			
		}

		private bool _isMailNotify=true;
		[XmlIgnore]
		public bool IsMailNotify
		{
			get{return _isMailNotify;}
			set{_isMailNotify = value;}
		}

		private string _notifyMail=null;
		[XmlIgnore]
		public string NotifyMail
		{
			get{
				if(_notifyMail==null||_notifyMail=="")
				{
					_notifyMail=Email;
				}
				return _notifyMail;
			}
			set{_notifyMail = value;}
		}

		private bool _isOnlyListTitle=false;
		public bool IsOnlyListTitle
		{
			get{return _isOnlyListTitle;}
			set{_isOnlyListTitle = value;}
		}

		#region Counts 

		//These might need to go somewhere else.

		private int _postCount;
		[XmlIgnore]
		public int PostCount
		{
			get {return this._postCount;}
			set {this._postCount = value;}
		}

		private int _commentCount;
		[XmlIgnore]
		public int CommentCount
		{
			get {return this._commentCount;}
			set {this._commentCount = value;}
		}

		private int _storyCount;
		[XmlIgnore]
		public int StoryCount
		{
			get {return this._storyCount;}
			set {this._storyCount = value;}
		}

		private int _pingTrackCount;
		[XmlIgnore]
		public int PingTrackCount
		{
			get {return this._pingTrackCount;}
			set {this._pingTrackCount = value;}
		}

		#endregion

		#region Helper

		protected void FlagSetter(ConfigurationFlag cf, bool select)
		{
			if(select)
			{
				this.Flag = Flag | cf;
			}
			else
			{
				this.Flag = Flag & ~cf;
			}
		}


		protected bool FlagPropertyCheck(ConfigurationFlag cf)
		{
			return (this.Flag & cf) == cf;
		}

		private void ConfigException(string message)
		{
			throw new Exception(message);
		}
		#endregion
	}
}

