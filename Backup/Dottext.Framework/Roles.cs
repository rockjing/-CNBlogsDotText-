using System;
using Dottext.Framework.Data;
using Dottext.Framework.Providers;
using Dottext.Framework.Components;

namespace Dottext.Framework
{
	/// <summary>
	/// Roles 的摘要说明。
	/// </summary>
	public class Roles
	{
		public Roles()
		{
			
		}

		public static Role[] GetRoles(int BlogID)
		{
			return DTOProvider.Instance().GetRoles(BlogID);
		}
		
		public static bool AddUserToRole(int BlogID,int RoleID)
		{
			return DTOProvider.Instance().AddUserToRole(BlogID,RoleID);
		}

		public static bool RemoveUserFromRole(int BlogID,int RoleID)
		{
			return DTOProvider.Instance().RemoveUserFromRole(BlogID,RoleID);
		}

	}
}
