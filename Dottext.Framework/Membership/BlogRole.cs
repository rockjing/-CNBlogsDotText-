using System;

namespace Dottext.Framework.Membership
{

	//Please note, this is an experiment. I would not recommend implementing this kind of authentication else where.
	
	[Flags()]
	public enum BlogRole
	{
		Any = 0,
		Owner = 1,
		Member = 2,
		Private = 4
	};
}
