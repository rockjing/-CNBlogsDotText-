using System;
using System.Xml.Serialization;
using Dottext.Framework.Data;

namespace Dottext.Framework.Providers
{
	/// <summary>
	/// Summary description for DbProvider.
	/// </summary>
	[XmlRoot("DbProvider")]
	public class DbProviderConfiguration : BaseProvider 
	{
		public DbProviderConfiguration()
		{
		}

		private string _connectionString;
		[XmlAttribute("connectionString")]
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}

	}
}
