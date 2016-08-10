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
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Remoting.Proxies;
using Dottext.Framework.EntryHandling;

namespace Dottext.Framework.Components
{
	/// <summary>
	/// Summary description for Entry.
	/// </summary>
	[Serializable]
	public class Entry : IBlogIdentifier
	{
		public Entry()
		{
			
		}

		public Entry(PostType ptype)
		{
			this.PostType = ptype;
		
		}

		/*public static Entry CreateInstance()
		{
			IBlogIdentifier entry=new Entry();
			RealProxy realProxy = new FilterRealProxy(entry);
			object transparentProxy = realProxy.GetTransparentProxy();
			//IBlogIdentifier proxyEntry=(IBlogIdentifier)FilterRealProxy.Wrap(entry);//transparentProxy;
			return (Entry)transparentProxy;
			
		}*/

		private int _blogID=-2;
		public int BlogID
		{
			get {return this._blogID;}
			set {this._blogID = value;}
		}

		private int _entryid;
		[XmlAttribute]
		public   int EntryID
		{
			get{return _entryid;}
			set{_entryid = value;}
		}

		private int _parentID = -1;		
		public int ParentID
		{
			get
			{
				return this._parentID;
			}
			set
			{
				this._parentID = value;
			}
		}

		public bool IsUpdated
		{
			get
			{
				return DateCreated != DateUpdated;
			}
		}

		public bool HasDescription
		{
			get
			{
				return ((Description != null) && (Description.Trim().Length > 0));
			}
		}

		public bool HasTitleUrl
		{
			get
			{
				return ((TitleUrl != null) && (TitleUrl != Link));
			}
		}

		private PostType _postType = PostType.Undeclared;
		public virtual PostType PostType
		{
			get
			{
				return _postType;
			}
			set
			{
				_postType = value;
			}
		}

		private string _description;
		public string Description
		{
			get{return _description;}
			set{_description = value;}
		}

		private string _entryName;
		public string EntryName
		{
			get{return _entryName;}
			set{_entryName = value;}
		}

		public bool HasEntryName
		{
			get
			{
				return this.EntryName != null && this.EntryName.Trim().Length >0;
			}
		}

		private string _title;
		public string Title
		{
			//[StringFilter(FilterType.Script)]
			get{return _title;}
			set{_title = value;}
		}

		private string _titleurl;
		public string TitleUrl
		{
			get{
				if(_titleurl == null)
				{
					_titleurl = this.Link;
				}
				return _titleurl;
			}
			set{_titleurl = value;}
		}

		private string _body;
		
		public virtual string Body
		{
			get{return _body;}
			set{_body = value;}
		}

		private string _sourceurl="";
		public string SourceUrl
		{
			get{return _sourceurl;}
			set{_sourceurl= value;}
		}

		private string _sourcename="";
		public string SourceName
		{
			get{return _sourcename;}
			set{_sourcename= value;}
		}

		private string _author;
		public string Author
		{
			get{return _author;}
			set{_author = value;}
		}

		private string _email;
		public string Email
		{
			get{return _email;}
			set{_email = value;}
		}

		private DateTime _datecreated;
		public DateTime DateCreated
		{
			get
			{
				return _datecreated;
			}
			set{_datecreated = value;}
		}

		private DateTime _dateupated;
		public DateTime DateUpdated
		{
			get
			{
				return _dateupated;
			}
			set{_dateupated = value;}
		}

		public bool IsActive
		{
			get{return EntryPropertyCheck(PostConfig.IsActive);}
			set{PostConfigSetter(PostConfig.IsActive,value);}
		}

		public bool IsXHMTL
		{
			get{return EntryPropertyCheck(PostConfig.IsXHTML);}
			set{PostConfigSetter(PostConfig.IsXHTML,value);}
		}

		public bool AllowComments
		{
			get{return EntryPropertyCheck(PostConfig.AllowComments);}
			set{PostConfigSetter(PostConfig.AllowComments,value);}
		}

		public bool DisplayOnHomePage
		{
			get{return EntryPropertyCheck(PostConfig.DisplayOnHomePage);}
			set{PostConfigSetter(PostConfig.DisplayOnHomePage,value);}
		}

		public bool SyndicateDescriptionOnly
		{
			get{return EntryPropertyCheck(PostConfig.SyndicateDescriptionOnly);}
			set{PostConfigSetter(PostConfig.SyndicateDescriptionOnly,value);}
		}

		public bool IncludeInMainSyndication
		{
			get{return EntryPropertyCheck(PostConfig.IncludeInMainSyndication);}
			set{PostConfigSetter(PostConfig.IncludeInMainSyndication,value);}
		}

		public bool IsAggregated
		{
			get{return EntryPropertyCheck(PostConfig.IsAggregated);}
			set{PostConfigSetter(PostConfig.IsAggregated,value);}
		}

		private string _link="";
		public virtual string Link
		{
			get{ return _link;}
			set{ _link = value;}
		}

		private int _feedBackCount = 0;
		public int FeedBackCount
		{
			get{return _feedBackCount;}
			set{_feedBackCount = value;}
		}

		private PostConfig _PostConfig = PostConfig.Empty;
		
		public PostConfig PostConfig
		{
			get {return this._PostConfig;}
			set {this._PostConfig = value;}
		}

		protected bool EntryPropertyCheck(PostConfig ep)
		{
			return (this.PostConfig & ep) == ep;
		}

		protected void PostConfigSetter(PostConfig ep, bool select)
		{
			if(select)
			{
				this.PostConfig = PostConfig | ep;
			}
			else
			{
				this.PostConfig = PostConfig & ~ep;
			}
		}

		private int _webCount;
		public int WebCount
		{
			get {return this._webCount;}
			set {this._webCount = value;}
		}

		private int _aggCount;
		public int AggCount
		{
			get {return this._aggCount;}
			set {this._aggCount = value;}
		}

		public int ViewCount
		{
			get {return WebCount+AggCount;}
			
		}
	}
}

