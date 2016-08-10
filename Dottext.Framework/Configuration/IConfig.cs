using System;
using System.Web;

namespace Dottext.Framework.Configuration
{
	/// <summary>
	/// Summary description for IBlogConfig.
	/// </summary>
	public interface IConfig
	{
		BlogConfig GetConfig();
		BlogConfig GetConfig(HttpContext context);
		BlogConfig BuildConfig(BlogConfig config,HttpContext context);


		int BlogID
		{
			get;
			set;
		}

		int CacheTime
		{
			get;
			set;
		}

		string Host
		{
			get;
			set;
		}
		string Application
		{
			get;
			set;
		}

		string ImageDirectory
		{
			get;
			set;
		}

		bool IsAggregateSite
		{
			get;
		}
	}
}
