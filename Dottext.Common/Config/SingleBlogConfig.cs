using System;
using System.Web;
using System.Web.Caching;
using Dottext.Framework.Configuration;
using Dottext.Framework.Util;

namespace Dottext.Common.Config
{
	/// <summary>
	/// A sample implementation of IConfig. This class will return the BlogConfig found at the current host/application, or the one found
	/// by configuring the Providers Host and Application values.
	/// </summary>
	public class SingleBlogConfig : BaseBlogConfig
	{
		private  static readonly object ConfigLock = new object();

		public SingleBlogConfig(){}

		//Part of IConfig
		public override bool IsAggregateSite
		{
			get	{return false;}
		}

		//Part of IConfig
		public override BlogConfig GetConfig(HttpContext context)
		{
			BlogConfig config = (BlogConfig)context.Cache[cacheKey];
			if(config == null)
			{
				lock(ConfigLock)
				{
					config = (BlogConfig)context.Cache[cacheKey];
					if(config == null)
					{

						config = this.LoadSingleConfig(context);

						this.CacheConfig(context.Cache,config,cacheKey);
					}
				}
			}
			return config;
		}

		#region LoadSingleConfig
		private BlogConfig LoadSingleConfig(HttpContext context)
		{
			if(Host == null)
			{
				Host = GetCurrentHost(context.Request);
			}

			if(Application == null)
			{
				string appPath = context.Request.ApplicationPath;
				if(appPath.StartsWith("/"))
				{
					appPath = appPath.Remove(0,1);
				}
				if(appPath.EndsWith("/"))
				{
					appPath = appPath.Remove(appPath.Length-1,1);
				}
				Application = appPath;
			}

			BlogConfig config = Dottext.Framework.Configuration.Config.GetConfig(Host,Application);

			BlogConfigurationSettings settings = Dottext.Framework.Configuration.Config.Settings;

			if(settings.UseHost)
			{
				config.FullyQualifiedUrl = "http://."+settings.HostName + config.Host + config.Application;
			}
			else
			{
				config.FullyQualifiedUrl = "http://" + config.Host + config.Application;
			}

			config.ImageDirectory = context.Server.MapPath("~/images");
			config.ImagePath = string.Format("{0}images/",config.FullyQualifiedUrl);

			return config;
		}
		#endregion

		public override BlogConfig BuildConfig(BlogConfig config,HttpContext context)
		{
			
			BlogConfigurationSettings settings = Dottext.Framework.Configuration.Config.Settings;

			string app = context.Request.ApplicationPath;

			//string appPath = Globals.FormatApplicationPath(string.Format("{0}/{1}",app,config.Application));

			string formattedHost = GetFomrattedHost(config.Host,settings.UseHost,settings.HostName);

			config.FullyQualifiedUrl = Globals.GetAppUrl(context.Request)+config.Application.Remove(0,1);//formattedHost + appPath;


			if(!app.EndsWith("/"))
			{
				app += "/";
			}

			string virtualPath = string.Format("images/{0}{1}",context.Request.Url.Host,config.Application);

			config.ImagePath = string.Format("{0}{1}{2}",formattedHost,app,virtualPath);
			config.ImageDirectory = context.Server.MapPath("~/" + virtualPath);

			return config;
		}

	}
}
