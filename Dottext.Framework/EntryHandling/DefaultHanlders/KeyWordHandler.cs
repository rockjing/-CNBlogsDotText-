using System;
using Dottext.Framework.Util;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// Summary description for KeyWordFactory.
	/// </summary>
	public class KeyWordHandler : IEntryFactoryHandler
	{
		public KeyWordHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region IEntryFactoryHandler Members

		public void Configure(){}

		public void Process(Dottext.Framework.Components.Entry e)
		{
			KeyWords.Format(ref e);
		}

		#endregion
	}
}
