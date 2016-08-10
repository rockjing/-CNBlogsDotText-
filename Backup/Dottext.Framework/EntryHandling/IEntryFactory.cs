using System;
using Dottext.Framework.Components;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// Summary description for IEntryFactoryHandler.
	/// </summary>
	public interface IEntryFactoryHandler
	{
		void Process(Entry e);
		void Configure();
	}
}
