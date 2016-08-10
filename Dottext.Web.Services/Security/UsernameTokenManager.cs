using Microsoft.Web.Services.Security;
using System;
using System.Security.Permissions;
using Dottext.Framework.Configuration;

using Dottext.Framework;

//Borrowed from ASP.NET Forums V2

namespace Dottext.Web.ServiceAPI.Security
{
	/// <summary>
	/// Summary description for UsernameTokenManager.
	/// </summary>
	[SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.UnmanagedCode)]
	public class UsernameTokenManager : Microsoft.Web.Services.Security.Tokens.UsernameTokenManager
	{
		protected override string AuthenticateToken(UsernameToken usernameToken)
		{
			if (usernameToken == null) throw new SecurityFault("The security token could not be authenticated or authorized", SecurityFault.FailedAuthenticationCode);

			BlogConfig CurrentBlog = Config.CurrentBlog();
			if(usernameToken.Username == CurrentBlog.UserName)
			{
				return CurrentBlog.Password;
			}
			else throw new SecurityFault("The security token could not be authenticated or authorized", SecurityFault.FailedAuthenticationCode);
		}

		

	}
}
