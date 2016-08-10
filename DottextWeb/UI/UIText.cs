using System;
using System.Configuration;

namespace Dottext.Web.UI
{
	/// <summary>
	/// Summary description for UIText.
	/// </summary>
	public class UIText
	{
		private UIText()
		{
			
		}

		public static string PostCollection
		{
			get
			{
				return GetSafeConfig("PostCollection","Post Categories");
			}
		}

		public static string ArticleCollection
		{
			get
			{
				return GetSafeConfig("ArticleCollection","Article Categories");
			}
		}

		public static string FavoriteCollention
		{
			get
			{
				return GetSafeConfig("FavoriteCollention","Favorite Categories");
			}
		}

		public static string ImageCollection
		{
			get
			{
				return GetSafeConfig("ImageCollection","Image Galleries");
			}
		}


		public static string Archives
		{
			get
			{
				return GetSafeConfig("Archives","Archives");
			}
		}

		public static string SiteTitle
		{
			get
			{
				return GetSafeConfig("AggregateTitle","CNDotText");
			}
		}

		public static string SiteUrl
		{
			get
			{
				return Dottext.Framework.Configuration.Config.Settings.AggregateUrl;
				//return GetSafeConfig("AggregateUrl","localhost");
			}
		}

		public static string GetSafeConfig(string name, string defaultValue)
		{
			string text = ConfigurationSettings.AppSettings[name] as string;
			if(text == null)
			{
				return defaultValue;
			}
			return text;
		}
	}
}
