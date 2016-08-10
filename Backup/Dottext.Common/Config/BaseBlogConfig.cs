using System;
using System.Web;
using System.Web.Caching;
using Dottext.Framework.Util;
using Dottext.Framework.Configuration;

namespace Dottext.Common.Config
{
	/// <summary>
	/// Summary description for BaseBlogConfig.
	/// </summary>
	public abstract class BaseBlogConfig : IConfig
	{
		protected const string adminPath = "/{0}/{1}";
		protected const string cacheKey = "BlogConfig-";

		public BaseBlogConfig()
		{

		}

		#region IConfig

		public abstract bool IsAggregateSite
		{
			get;
		}


		private int _blogID;
		public int BlogID
		{
			get {return this._blogID;}
			set {this._blogID = value;}
		}

		private int _cacheTime;
		public int CacheTime
		{
			get {return this._cacheTime;}
			set {this._cacheTime = value;}
		}

		private string _host;
		public string Host
		{
			get {return this._host;}
			set {this._host = value;}
		}

		private string _application;
		public string Application
		{
			get {return this._application;}
			set {this._application = value;}
		}

		private string _imageDirectory;
		public string ImageDirectory
		{
			get {return this._imageDirectory;}
			set {this._imageDirectory = value;}
		}

		#endregion


		protected string GetFomrattedHost(string host, bool useHost,string hostName)
		{
			if(useHost)
			{
				return string.Format("http://{0}.{1}", hostName,host);
				}
			else
			{
			return "http://" +  host;
			}
		}

		protected string GetCurrentHost(HttpRequest Request)
		{
			string host = Request.Url.Host;
			if(!Request.Url.IsDefaultPort)
			{
				host  += ":" + Request.Url.Port.ToString();
			}
			int firstIndex=host.IndexOf(".");
			int lastIndex=host.LastIndexOf(".");
			if(firstIndex<lastIndex)
			{
				host = host.Substring(firstIndex+1);
			}
			/*if(host.ToLower().StartsWith("www."))
			{
				host = host.Substring(4);
			}*/
			return host;
		}

		protected void CacheConfig(Cache cache, BlogConfig config, string cacheKEY)
		{
			cache.Insert(cacheKEY,config,null,DateTime.Now.AddSeconds(CacheTime),TimeSpan.Zero,CacheItemPriority.High,null);
		}

		public BlogConfig GetConfig()
		{
			return GetConfig(HttpContext.Current);
		}

		//The last part of IConfig. Must be implemented by any class deriving from BaseBlogConfig
		public abstract BlogConfig GetConfig(HttpContext context);
		public abstract BlogConfig BuildConfig(BlogConfig config,HttpContext context);
	}
}
