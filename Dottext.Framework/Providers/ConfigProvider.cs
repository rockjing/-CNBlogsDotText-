using System;
using Dottext.Framework.Configuration;

namespace Dottext.Framework.Providers
{
	/// <summary>
	/// ConfigProvider loads the Singleton Instance of IConfig
	/// </summary>
	public class ConfigProvider
	{
		private ConfigProvider(){}

		static ConfigProvider()
		{
			ConfigProviderConfiguration cpc = Config.Settings.BlogProviders.ConfigProvider;
			
			config = (IConfig)cpc.Instance();
			//config.GetConfig();
			config.Application = cpc.Application;
			config.CacheTime = cpc.CacheTime;
			config.Host = cpc.Host;
			config.ImageDirectory = cpc.ImageDirectory;
			config.BlogID = cpc.BlogID;
			
		}

		private static IConfig config = null;
		public static IConfig Instance()
		{
			return config;
		}
	}
}
