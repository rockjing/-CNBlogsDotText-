using System;

namespace Dottext.Framework.Membership
{
	/// <summary>
	/// Summary description for LoginUserStatus.
	/// </summary>
	public enum LoginUserStatus
	{
		/// <summary>
		/// Username and password didn't match.
		/// </summary>
		InvalidCredentials = 0, 

		/// <summary>
		/// The user name and password are ok.
		/// </summary>
		Success = 1, 

		AccountPending = 2,

		AccountBanned = 3,

		/// <summary>
		/// Unknown situation possibly generated by un-syncronization beteen 
		/// data layer and business layer.
		/// </summary>
		UnknownError = 100
	}
}
