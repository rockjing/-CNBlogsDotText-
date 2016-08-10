using System;
using Dottext.Framework.Tracking;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// Summary description for WeblogsPingFactory.
	/// </summary>
	public class WeblogsPingHandler : IEntryFactoryHandler
	{
		public WeblogsPingHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region IEntryFactoryHandler Members

		private string BlogName;
		private string FullyQualifiedUrl;

		public void Configure()
		{
			BlogConfig config = Config.CurrentBlog();
			BlogName = config.Title;
			FullyQualifiedUrl = config.FullyQualifiedUrl;
		}

		public void Process(Dottext.Framework.Components.Entry e)
		{
			WeblogsNotificatinProxy weblogs = new WeblogsNotificatinProxy();
			weblogs.Ping(BlogName,FullyQualifiedUrl);
			weblogs.Dispose();
		}

		#endregion
	}
}
