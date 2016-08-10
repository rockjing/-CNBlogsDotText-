using System;
using System.Reflection;
using Dottext.Framework.Configuration;
using Dottext.Framework.Format;


namespace Dottext.Framework.Providers
{
	/// <summary>
	/// Summary description for UrlFormatProvider.
	/// </summary>
	public class UrlFormatProvider
	{
		private UrlFormatProvider()
		{
		}

		static UrlFormatProvider()
		{
			UrlFormatProviderConfiguration urlFPC = Config.Settings.BlogProviders.UrlFormatProvider;
			Type[] types = {typeof(string)};
			Type t = Type.GetType(urlFPC.ProviderType);
			formatConstructor = t.GetConstructor(types);
		}

		private static ConstructorInfo formatConstructor = null;

		public static UrlFormats Instance(string fullyQualifiedUrl)
		{
			return (UrlFormats)formatConstructor.Invoke(new object[]{fullyQualifiedUrl});
		}
	}
}
