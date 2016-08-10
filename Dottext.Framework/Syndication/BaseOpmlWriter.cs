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
	/// BaseOpmlWriter 的摘要说明。
	/// </summary>
	public class BaseOpmlWriter : BaseSyndicationWriter
	{
		public BaseOpmlWriter()
		{
			
		}

		public BaseOpmlWriter(System.IO.Stream stream):base(stream,Encoding.UTF8)
		{
			
		}


		protected override void Build()
		{
			
		}
		
				
		protected  void StartBuild()
		{
			this.Formatting = Formatting.Indented;
			StartDocument();
			StartOpml();
			StartBody();
		}

		protected void EndBuild()
		{
			EndBody();
			EndOpml();
			//EndDocument();
		}

		protected virtual void StartDocument()
		{
			this.WriteStartDocument();
			
			
		}

		protected void EndDocument()
		{
			this.WriteEndElement();
		}

		protected void StartOpml()
		{
			this.WriteStartElement("opml");
		}
		protected void EndOpml()
		{
			this.WriteEndElement();
		}

		protected void StartBody()
		{
			this.WriteStartElement("body");
		}
		protected void EndBody()
		{
			this.WriteEndElement();
		}

		protected void StartOutline(string title,string htmlUrl, string xmlUrl)
		{
			this.WriteStartElement("outline");
			this.WriteAttributeString("title",title);
			if(htmlUrl!="")
			{
				this.WriteAttributeString("htmlUrl",htmlUrl);
			}
			if(xmlUrl!="")
			{
				this.WriteAttributeString("xmlUrl",xmlUrl);
			}
		}
		
		protected void EndOutline()
		{
			this.WriteEndElement();
		}

		
	}
}
