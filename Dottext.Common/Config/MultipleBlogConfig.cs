using System;
using System.Web;
using System.Web.Caching;
using System.Text.RegularExpressions;
using Dottext.Framework.Util;
using Dottext.Framework.Configuration;

namespace Dottext.Common.Config
{
	/// <summary>
	/// A sample implemtation of a class that implements IConfig for a multiple blog system
	/// </summary>
	public class MultipleBlogConfig : BaseBlogConfig
	{
		public MultipleBlogConfig(){}

		//part of IConfig
		public override bool IsAggregateSite
		{
			get	{return true;}
		}


		/// <summary>
		/// Override abstract GetConfig() (also part of IConfig). Returns a BlogConfig instance for the current blog. 
		/// The object first checks the context for an existing object. It will next check the cache.
		/// </summary>
		/// <returns></returns>
		public override BlogConfig GetConfig(HttpContext context)
		{
			//First check the context for an existing BlogConfig. This saves us the trouble of having to figure out which blog we are at.
			
			BlogConfig config = (BlogConfig)context.Items[cacheKey];
		
			if(config == null)
			{
				string app,appFromRequest="";
				//appFromRequest=HttpContext.Current.User.Identity.Name;
				if(appFromRequest=="")
				{
					app= context.Request.ApplicationPath.ToLower();
					appFromRequest = Globals.GetBlogAppFromRequest(context.Request.RawUrl.ToLower(),app);
				
				}
				
				
				//BlogConfig was not found in the context. It could be in the current cache.
				string mCacheKey = cacheKey +  appFromRequest;

				if(Globals.GetBlogAppFromRequest(context.Request)==""||Globals.GetBlogAppFromRequest(context.Request).ToLower()=="comments")
				{
					if(context.Request.QueryString["id"]!=null) 
					{
						mCacheKey+="id:"+context.Request.QueryString["id"];
					}
				}

				//check the cache.
				config = (BlogConfig)context.Cache[mCacheKey];
				//System.IO.File.Create("f:\\"+mCacheKey);
				if(config == null)
				{
					//Not found in the cache

					//if(Host == null)
					//{
						Host = GetCurrentHost(context.Request);
						
					//}
					
					config = BuildConfig(Host,appFromRequest,context);
					if(config==null)
					{
						return null;
					}
					
					CacheConfig(context.Cache,config,mCacheKey);
					context.Items.Add(cacheKey,config);
					
				}
				else
				{
					context.Items.Add(cacheKey,config);
					
				}
			}
			//Dottext.Framework.Logger.LogManager.Log(context.Request.RawUrl,config.BlogID.ToString());
			return config;
		}

		/*public override BlogConfig GetConfigByApp(HttpContext context,string app)
		{
			Host = GetCurrentHost(context.Request);
			config = BuildConfig(Host,app,context);
			return config;
		}*/

		protected virtual BlogConfig BuildConfig(string host, string application, HttpContext context)
		{
			string blogapp=Globals.GetBlogAppFromRequest(context.Request);
			if(blogapp==""||blogapp.ToLower()=="comments")
			{
				/*string regstr=@"^((/default\.aspx)|(/))$";
				string path=Dottext.Framework.Util.Globals.RemoveAppFromPath(context.Request.Path,context.Request.ApplicationPath);
				if(Regex.IsMatch(path,regstr,System.Text.RegularExpressions.RegexOptions.IgnoreCase))
				{
					return Dottext.Framework.Configuration.Config.GetDefaultSiteBlogConfig();
				}
				int cateid=WebPathStripper.GetEntryIDFromUrl(context.Request.Path);*/
				string cateid=context.Request.QueryString["cateid"];
				if(cateid=="" || cateid==null)
				{
					return Dottext.Framework.Configuration.Config.GetDefaultSiteBlogConfig();
				}
				return Dottext.Framework.Configuration.Config.GetSiteBlogConfigByCategoryID(int.Parse(cateid));
			}
			BlogConfig config = Dottext.Framework.Configuration.Config.GetConfig(host,application);
					
			BlogConfigurationSettings settings = Dottext.Framework.Configuration.Config.Settings;

			string app = context.Request.ApplicationPath;

			//string appPath = Globals.FormatApplicationPath(string.Format("{0}/{1}",app, application));

			string formattedHost = Dottext.Framework.Configuration.Config.Settings.AggregateUrl;//GetFomrattedHost(host,settings.UseHost,settings.HostName);

			config.FullyQualifiedUrl = formattedHost + application;


			if(!app.EndsWith("/"))
			{
				app += "/";
			}

			string virtualPath = string.Format("images/{0}/{1}/",Regex.Replace(host,@"\:|\.","_"),application);
			config.ImagePath = string.Format("{0}{1}{2}",formattedHost,app,virtualPath);
			config.ImageDirectory = context.Server.MapPath("~/" + virtualPath);

			return config;
		}

		public override BlogConfig BuildConfig(BlogConfig config,HttpContext context)
		{
			
			BlogConfigurationSettings settings = Dottext.Framework.Configuration.Config.Settings;

			string app = context.Request.ApplicationPath;

			//string appPath = Globals.FormatApplicationPath(string.Format("{0}/{1}",app,config.Application));

			string formattedHost = Dottext.Framework.Configuration.Config.Settings.AggregateUrl;//GetFomrattedHost(config.Host,settings.UseHost,settings.HostName);

			config.FullyQualifiedUrl = formattedHost + config.Application;//Globals.GetAppUrl(context.Request)+config.Application.Remove(0,1);//formattedHost + appPath;


			if(!app.EndsWith("/"))
			{
				app += "/";
			}

			string virtualPath = string.Format("images/{0}{1}",context.Request.Url.Host,config.Application);

			config.ImagePath = string.Format("{0}{1}",formattedHost,virtualPath);
			config.ImageDirectory = context.Server.MapPath("~/" + virtualPath);

			return config;
		}
	}
}
