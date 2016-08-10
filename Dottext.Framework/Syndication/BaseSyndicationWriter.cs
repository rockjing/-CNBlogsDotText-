using System;
using System.IO;
using System.Text;
using System.Xml;

using Dottext.Framework;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Framework.Format;
using Dottext.Framework.Tracking;

namespace Dottext.Framework.Syndication
{
	/// <summary>
	/// Summary description for BaseSyndicationWriter.
	/// </summary>
	public abstract class BaseSyndicationWriter : XmlTextWriter
	{

		private StringWriter _sw  = null;
		protected BlogConfig config;

		public BaseSyndicationWriter():this(new StringWriter())
		{
			
		}

		public BaseSyndicationWriter(System.IO.Stream stream,Encoding encoding):base(stream,encoding)
		{
			
		}

		public BaseSyndicationWriter(StringWriter sw):base(sw)
		{
		_sw = sw;
		config = Config.CurrentBlog();
		}

				

		public StringWriter StringWriter
		{
			get
			{
				Build();
				return _sw;
			}
		}

		public string GetXml
		{
			get{return this.StringWriter.ToString();}
		}

		public override string ToString()
		{
			return GetXml;
		}

		private bool _useAggBugs = false;
		public bool UseAggBugs
		{
			get {return this._useAggBugs;}
			set {this._useAggBugs = value;}
		}

		private bool _allowComments = true;
		public bool AllowComments
		{
			get {return this._allowComments;}
			set {this._allowComments = value;}
		}

		private EntryCollection _entries;
		public EntryCollection Entries
		{
			get {return this._entries;}
			set {this._entries = value;}
		}

		protected abstract void Build();
	}
}
