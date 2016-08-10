using System;
using System.Web;
using System.Configuration;
using Dottext.Framework.Util;
using Dottext.Framework.Providers;

namespace Dottext.Framework.Configuration
{
	/// <summary>
	/// Summary description for Config.
	/// </summary>
	public class Config
	{
		public Config()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static BlogConfig CurrentBlog()
		{
			return CurrentBlog(HttpContext.Current);
		}

		
		public static BlogConfig CurrentBlog(HttpContext context)
		{
			/*if(!CheckConfig(context))
			{
				BlogConfig config=(BlogConfig)ConfigurationSettings.GetConfig("BlogConfig");
				return config;
			}*/
			return Dottext.Framework.Providers.ConfigProvider.Instance().GetConfig(context);
		}

		public static bool UpdateConfigData(BlogConfig config)
		{
			return DTOProvider.Instance().UpdateConfigData(config);
		}

		public static BlogConfigurationSettings Settings
		{
			get
			{
				return ((BlogConfigurationSettings)ConfigurationSettings.GetConfig("BlogConfigurationSettings"));
			}
		}

		public static BlogConfig GetConfig(int BlogID)
		{
			return  DTOProvider.Instance().GetConfig(BlogID);
		}
		
		public static BlogConfig[] GetConfigByRoleID(int RoleID)
		{
			return  DTOProvider.Instance().GetConfigByRoleID(RoleID);
		}

		#region SiteBlogConfig

		public static SiteBlogConfig GetSiteBlogConfig(int BlogID)
		{
			SiteBlogConfigCollection scc=GetSiteBlogConfigCollection();
			foreach(SiteBlogConfig sc in scc)
			{
				if(sc.BlogID==BlogID)
				{
					sc.LastUpdated=DateTime.Now;
					sc.FullyQualifiedUrl=Util.Globals.GetAppUrl(HttpContext.Current.Request);
					return sc;
				}
			}
			return null;
		}

		public static SiteBlogConfig GetSiteBlogConfigByCategoryID(int CategoryID)
		{
			SiteBlogConfigCollection scc=GetSiteBlogConfigCollection();
			foreach(SiteBlogConfig sc in scc)
			{
				if(sc.CategoryID==CategoryID)
				{
					return sc;
				}
			}
			return null;
		}

		public static SiteBlogConfig GetDefaultSiteBlogConfig()
		{
			SiteBlogConfigCollection scc=GetSiteBlogConfigCollection();
			foreach(SiteBlogConfig sc in scc)
			{
				if(sc.IsDefault)
				{
					return sc;
				}
			}
			return null;
		}


		public static SiteBlogConfigCollection GetSiteBlogConfigCollection()
		{
			string dataFile=System.Web.HttpContext.Current.Server.MapPath("~/SiteBlogConfig.config");
			return (SiteBlogConfigCollection)Util.SerializationHelper.Load(typeof(SiteBlogConfigCollection),dataFile);				
		}

		public static void SaveSiteBlogConfigCollection(SiteBlogConfigCollection sbcc)
		{
			string dataFile=System.Web.HttpContext.Current.Server.MapPath("~/SiteBlogConfig.config");
			Dottext.Framework.Util.SerializationHelper.Save(sbcc,dataFile);

		}

		public static void RemoveSiteBlogConfigByCategoryID(int CategoryID)
		{
			SiteBlogConfigCollection scc=GetSiteBlogConfigCollection();
			foreach(SiteBlogConfig sc in scc)
			{
				if(sc.CategoryID==CategoryID)
				{
					scc.Remove(sc);
					SaveSiteBlogConfigCollection(scc);
					return;
				}
			}
			return;
			
		}
		#endregion


		public static BlogConfig GetConfig(string UserName)
		{
			return  DTOProvider.Instance().GetConfig(UserName);
		}

		public static BlogConfig GetConfig(string UserName,HttpContext context)
		{
			BlogConfig config=GetConfig(UserName);
			return Dottext.Framework.Providers.ConfigProvider.Instance().BuildConfig(config,context);
		}

		public static BlogConfig GetConfig(string hostname, string application)
		{
			//BlogConfig result = DTOProvider.Instance().GetConfig(hostname,application);
			BlogConfig result = DTOProvider.Instance().GetConfigByApp(application);
			if(result == null)
			{
				throw new BlogDoesNotExistException(
					String.Format("A blog matching the location you requested was not found. Host = [{0}], Application = [{1}]",
					hostname, 
					application));
			}
			return result;
		}

		public static bool CheckConfig(HttpContext context)
		{
			/*string blogapp=Globals.GetBlogAppFromRequest(context.Request);
			//Logger.LogManager.Log("blogapp",blogapp);
			if(blogapp=="")
			{
				//Logger.LogManager.Log("blogapp",blogapp.Length.ToString());
				return false;
			}*/
			return true;
			//string appFromRequest = Globals.GetBlogAppFromRequest(context.Request.RawUrl.ToLower(),app);
			//string Host = Globals.GetCurrentHost(context.Request);
			//BlogConfig result = DTOProvider.Instance().GetConfig(Host,appFromRequest);
			/*if(result == null)
			{
				return false;
			}
			else
			{
				return true;
			}
			return true;*/
			
		}
	}
}
