using System;
using Dottext.Framework.Configuration;

namespace Dottext.Common.Syndication
{
	/// <summary>
	/// SiteCatalogOpmlWriter 的摘要说明。
	/// </summary>
	public class SiteCatalogOpmlWriter : Dottext.Framework.Syndication.BaseOpmlWriter
	{
		public SiteCatalogOpmlWriter()
		{
			
		}

		public SiteCatalogOpmlWriter(System.IO.Stream stream):base(stream)
		{
			
		}
		
		protected override void Build()
		{
			try
			{
				this.StartBuild();
				this.StartOutline(this.SiteTilte,"","");
				string fullurl=Dottext.Framework.Util.Globals.GetAppUrl(System.Web.HttpContext.Current.Request);
				foreach(SiteBlogConfig sbc in this.SiteConfigCollection)
				{
					if(sbc.InOpml)
					{
						string htmlUrl=string.Format("{0}default.aspx?id={1}",fullurl,sbc.BlogID.ToString());
						string xmlUrl=string.Format("{0}rss.aspx?id={1}",fullurl,sbc.BlogID.ToString());
						this.StartOutline(sbc.Title,htmlUrl,xmlUrl);
						this.EndOutline();
					}
				}
				this.EndOutline();
				this.EndBuild();
			}
			finally
			{
				this.Flush();
				this.Close();
			}
		}

		public void Output()
		{
			this.Build();
		}

		private string _siteTitle;
		public string SiteTilte
		{
			get
			{
				return this._siteTitle;
			}
			set
			{
				this._siteTitle=value;
			}
		}

		private SiteBlogConfigCollection _siteConfigCollection;
		public SiteBlogConfigCollection SiteConfigCollection
		{
			get
			{
				return this._siteConfigCollection;
			}
			set
			{
				this._siteConfigCollection=value;
			}
		}


	}
}
