using System;
using System.Text.RegularExpressions;
using System.Security.Principal;

namespace Dottext.Framework.Membership
{
	/// <summary>
	/// Summary description for BlogPrincipal.
	/// </summary>
	public class BlogPrincipal : IPrincipal
	{
		static readonly string OwnerRole = "@{0}.1@|@{0}.2,|@{0}.4@";
		static readonly string MemberRole = "@{0}.2@|@{0}.4@";
		static readonly string PrivateRole = "@{0}.4@";
		
		public BlogPrincipal(IIdentity identity, string roles)
		{
			this._identity = identity;
			this._roles = roles;
		}

		protected IIdentity _identity = null;
		protected string _roles = null;

		public IIdentity Identity
		{
			get
			{				
				return _identity;
			}
		}

		public bool IsInRole(string role)
		{
			string[] parts = role.Split('.');
			string lookup = null;
			switch(parts[1])
			{
				case "1":
					lookup = string.Format(OwnerRole,parts[0]);
					break;
				case "2":
					lookup = string.Format(MemberRole,parts[0]);
					break;
				case "4":
					lookup = string.Format(PrivateRole,parts[0]);
					break;
			}
			return Regex.IsMatch(string.Format("@{0}@",role),lookup);
			//return false;
		}
	}
}