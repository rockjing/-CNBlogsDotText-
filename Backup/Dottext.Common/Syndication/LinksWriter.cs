using System;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Framework.Format;

namespace Dottext.Common.Syndication
{
	/// <summary>
	/// LinksWriter 的摘要说明。
	/// </summary>
	public class LinksWriter : Dottext.Framework.Syndication.BaseRssWriter
	{
		private LinkCollection lc;

		public LinksWriter(LinkCollection links) 
		{
			this.lc=links;
		}

		protected override void WalkEntries()
		{
			foreach(Link lnk in lc)
			{
				this.WriteStartElement("item");
				EntryXml(lnk);
				this.WriteEndElement();
			}
			lc.Clear();
		}

		protected  void EntryXml(Link link)
		{
			this.WriteElementString("dc:creator",config.Author);
			//core
			this.WriteElementString("title",link.Title);
			//core
			this.WriteElementString("link",link.Url);
			this.WriteElementString("pubDate",link.UpdateTime.ToUniversalTime().ToString("r"));
			//core Should we set the 
			this.WriteElementString("guid",link.Url);

			this.WriteElementString("description", string.Format("<a href='{0}'>{0}</a>", link.Url));
		}


	}
}
