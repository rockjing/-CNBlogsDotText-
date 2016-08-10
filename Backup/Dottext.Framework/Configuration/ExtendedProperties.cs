using System;
using System.Collections.Specialized;

using Dottext.Framework.Util;

namespace Dottext.Framework.Configuration
{
	/// <summary>
	/// Summary description for ExtendedProperties.
	/// </summary>
	public class ExtendedProperties
	{
		private NameValueCollection _nvc;

		public ExtendedProperties():this(new NameValueCollection())
		{

		}

		public ExtendedProperties(NameValueCollection nvc)
		{
			_nvc = nvc;
		}

		public ExtendedProperties(byte[] bytes):this((NameValueCollection)BinarySerializer.Deserializer(bytes))
		{
			
		}

		public byte[] Bytes
		{
			get
			{
				return BinarySerializer.Serialize(_nvc);
			}
		}

		public string this[string key]
		{
			get{ return Get(key);}
			set { Set(key,value);}
		}

		public string Get(string key)
		{
			return _nvc[key];
		}

		public void Set(string key, string text)
		{
			_nvc[key] = text;
		}
	}
}
