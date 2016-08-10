using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

using Dottext.Framework.Components;
using Dottext.Framework.Providers;
using Dottext.Framework.Util;

namespace Dottext.Framework.Membership
{
	/// <summary>
	/// Summary description for Users.
	/// </summary>
	public class Users
	{
		private Users()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static readonly string CurrentUserContextKey = "CurrentUserContextKey";

        public static UserAccountStatus ValidateUser(string username, string password)
        {
            return DTOProvider.Instance().ValidateUser(username,password);
        }

		public static BlogUser GetUser(string username)
		{
			return DTOProvider.Instance().GetUser(username);
		}

    	public static BlogUser GetUserByEmail(string email)
		{
			return DTOProvider.Instance().GetUserByEmail(email);
		}

		public static BlogUserRole[] BlogUserRolesByBlog()
		{
			return DTOProvider.Instance().BlogUserRolesByBlog();
		}

		public static bool UpdateRole(int UserID, int BlogID, BlogRole role)
		{
			return DTOProvider.Instance().UpdateRole(UserID,BlogID,role);
		}
		
		public static bool CreateUser(BlogUser bu)
		{
			return DTOProvider.Instance().CreateUser(bu);
		}

		public static bool UpdateUser(BlogUser bu)
		{
			return DTOProvider.Instance().UpdateUser(bu);
		}

		public static bool RemoveUserFromBlog(string userName)
		{
			return DTOProvider.Instance().RemoveUserFromBlog(userName);
		}

	
		public static BlogUser CurrentUser(HttpContext context)
		{
			BlogUser bu = context.Items[CurrentUserContextKey] as BlogUser;
			if(bu == null)
			{				
				bu =  SetUserIdentity(context);
			}
			return bu;
		}

		public static BlogUser CurrentUser()
		{
			return CurrentUser(HttpContext.Current);
		}

		public static BlogUser SetUserIdentity(HttpContext context)
		{
			
			BlogUser bu = null;
			if(context.Request.IsAuthenticated)
			{
				HttpCookie authcookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
				if(authcookie != null)
				{
					string cookiedata = authcookie.Value;
					FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookiedata);
					string userdata = ticket.UserData;
					bu = (BlogUser)SerializationHelper.ConvertFromString(typeof(BlogUser),userdata);
				}
				else
				{
					bu = Users.GetUser(context.User.Identity.Name);
					CreateTicket(context,bu,false);
				}

				if(bu != null)
				{
					context.Items.Add(CurrentUserContextKey,bu);
					//Note, look into creating custom Principal so that we do not have to add each role
					//for a BlogRole, ie, if Owner then Memeber and Private should be assumed
					context.User = new GenericPrincipal(context.User.Identity,bu.Roles);
				}
			}
			return bu;
		}

		public static void CreateTicket(HttpContext context, BlogUser bu, bool persist)
		{
				if(bu != null)
				{
					string userData = SerializationHelper.ConvertToString(bu);

					FormsAuthenticationTicket ticket = 
						new FormsAuthenticationTicket(1,context.User.Identity.Name,DateTime.Now,DateTime.Now.AddHours(1),false,userData);

					string cookieValue = FormsAuthentication.Encrypt(ticket);
					HttpCookie rolesCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
					rolesCookie.Value = cookieValue;
					if(persist)
					{
						rolesCookie.Expires = DateTime.Now.AddYears(1);
					}
					context.Response.Cookies.Add(rolesCookie);
				}
		}


	}
}
