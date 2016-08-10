using System;
using Microsoft.Web.Services.Security;

//Borrowed from ASP.NET Forums V2

namespace Dottext.Web.ServiceAPI.Security
{
	/// <summary>
	/// Summary description for Utilities.
	/// </summary>
	public class Utility
	{
		protected Utility()
		{
		}

		public static bool UsernameTokenExists(Microsoft.Web.Services.Security.Security securityHeader)
		{
			bool usernameTokenExists = false;
			if (securityHeader.Tokens.Count > 0)
			{
				foreach (SecurityToken securityToken in securityHeader.Tokens)
				{
					UsernameToken usernameToken = securityToken as UsernameToken;
					if (usernameToken != null ) usernameTokenExists = (usernameToken.Username == null || usernameToken.Username == string.Empty) ? false : true;
				}
			}
			return usernameTokenExists;
		}

		public static UsernameToken GetUsernameToken(Microsoft.Web.Services.Security.Security securityHeader)
		{
			if (!UsernameTokenExists(securityHeader)) return null;

			foreach (SecurityToken securityToken in securityHeader.Tokens)
			{
				UsernameToken usernameToken = securityToken as UsernameToken;
				if (usernameToken != null ) return usernameToken;
			}

			return null;
		}
	
	}
}
