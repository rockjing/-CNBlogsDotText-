using System;
using Dottext.Framework.Components;

namespace Dottext.Framework.Data
{
	/// <summary>
	/// Summary description for IProccessEntry.
	/// </summary>
	public interface IProccessEntry
	{
		int Create(Entry entry);
		bool Update(Entry entry);
	}
}
