using System;

namespace Dottext.Framework.Membership
{
	/// <summary>
	/// Summary description for UserConfig.
	/// </summary>
	[Flags()]
	public enum UserConfig
	{
		//Has this user been authenticated
		Authenticated = 1,
		
		//Does this user have a hashed password
		HashedPassword = 2
	}
}
