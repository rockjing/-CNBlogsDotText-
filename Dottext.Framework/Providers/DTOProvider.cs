using System;
using System.Xml.Serialization;
using Dottext.Framework.Data;

using Dottext.Framework.Configuration;

namespace Dottext.Framework.Providers
{
	/// <summary>
	/// Summary description for DTOProvider.
	/// </summary>

	public class DTOProvider
	{
		private DTOProvider(){}

		static DTOProvider()
		{
			DTOProviderConfiguration dtoPC = Config.Settings.BlogProviders.DTOProvider;
			idto = (IDTOProvider)dtoPC.Instance();
		}

		private static IDTOProvider idto = null;
		public static IDTOProvider Instance()
		{
			return idto;
		}
	}
}
