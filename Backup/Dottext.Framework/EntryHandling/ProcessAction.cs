using System;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// Summary description for ProcessAction.
	/// </summary>
	[Flags()]
	public enum ProcessAction
	{
		None = 0,
		Insert = 1,
		Update = 2
	};
}
