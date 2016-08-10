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
using System.Configuration;
using System.Web;
using System.Xml.Serialization;

namespace Dottext.Search
{
	/// <summary>
	/// Summary description for SearchConfiguration.
	/// </summary>
	[Serializable]
	public class SearchConfiguration
	{

		//Field names for indexing. Must be the same going in and coming out, so we define them globally here. Maybe they need
		//to go to a global class?
		public static readonly string PermaLink = "permalink";
		public static readonly string Link = "link";
		//public static readonly string Description = "description";
		public static readonly string Domain = "domain";
		public static readonly string Blog = "blog";
		public static readonly string Body = "body";
		public static readonly string DateCreated = "datecreated";
		public static readonly string Title = "title";
		public static readonly string PostType = "posttype";
		public static readonly string Author = "author";
		public static readonly string RawPost = "rawpost";
		public static readonly string BoostFactor = "boostfactor";

		public static readonly string TempIndex = "tempIndex";


		/// <summary>
		/// Get an instance of the SearchConfiguration found in the web.config or app.config
		/// </summary>
		/// <returns></returns>
		public static SearchConfiguration Instance()
		{
			return (SearchConfiguration)ConfigurationSettings.GetConfig("SearchConfiguration");
		}

		public SearchConfiguration()
		{
			
			//
			// TODO: Add constructor logic here
			//
		}

		private string _urlFormat = "http://{0}/{1}/{2}/{3}.aspx";
		
		/// <summary>
		/// used to format the data found retrieved from the .Text datastore to a valid permalink
		/// </summary>
		[XmlAttribute("urlFormat")]
		public string UrlFormat
		{
			get {return this._urlFormat;}
			set {this._urlFormat = value;}
		}

		private string _domains;
		
		/// <summary>
		/// Which domains do we want to filter the index by. (multiple domains are seperated by a comma ","
		/// </summary>
		[XmlAttribute("domains")]
		public string Domains
		{
			get {return this._domains;}
			set {this._domains = value;}
		}

		private int _rebuildInterval = 60;
		
		/// <summary>
		/// Defines how often the entire index should be rebuild (does not work yet)
		/// </summary>
		[XmlAttribute("rebuildInterval")]
		public int RebuildInterval
		{
			get {return this._rebuildInterval;}
			set {this._rebuildInterval = value;}
		}

		private int _updateInterval = 30;
		
		/// <summary>
		/// Defines how often new items should be added to the index (does not work yet)
		/// </summary>
		[XmlAttribute("updateInterval")]
		public int UpdateInterval
		{
			get {return this._updateInterval;}
			set {this._updateInterval = value;}
		}

		private int _pageSize = 50;
		
		/// <summary>
		/// How many results per page
		/// </summary>
		[XmlAttribute("pageSize")]
		public int PageSize
		{
			get {return this._pageSize;}
			set {this._pageSize = value;}
		}

		private int _searchResultLimit = 100;
		/// <summary>
		/// If we enable advanced searching, what is the max results per page
		/// </summary>
		[XmlAttribute("searchResultLimit")]
		public int SearchResultLimit
		{
			get {return this._searchResultLimit;}
			set {this._searchResultLimit = value;}
		}

		private string _virtualPath;
		
		/// <summary>
		/// If the physicalpath property is not set, we will MapPath the value found at VirtualPath. This does rely on the HttpContext.
		/// </summary>
		[XmlAttribute("virtualPath")]
		public string VirtualPath
		{
			get {return this._virtualPath;}
			set {this._virtualPath = value;}
		}

		private string _physicalPath;
		
		/// <summary>
		/// Where is the index stored. If the index is not found in a valid web directory, it must be set here.
		/// </summary>
		[XmlAttribute("physicalPath")]
		public string PhysicalPath
		{
			get 
			{
				if(this._physicalPath == null)
				{
					//If not physical path exists, try the virtual path. This will throw an exception if it can not found.
					if(VirtualPath != null)
					{
						this._physicalPath = HttpContext.Current.Server.MapPath(VirtualPath);
					}
					else
					{
						throw new ApplicationException("Physical location of the search index could not be found. Either the physical or virtual location must be specified in your configuration file");
					}
				}
				return this._physicalPath;
			}
			set {this._physicalPath = value;}
		}
	}
}
