using System;
using System.Xml.Serialization;
using Dottext.Framework.Util;

namespace Dottext.Framework.Providers
{
	/// <summary>
	/// Summary description for IBlogProvider.
	/// </summary>
	public interface IBlogProvider
	{

		[XmlAttribute("type")]
		string Type
		{
			get;
			set;
		}

		void Initialize();

		
	}
}
