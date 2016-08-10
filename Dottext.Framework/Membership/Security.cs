using System;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;

namespace Dottext.Framework.Membership
{
	/// <summary>
	/// Handles blog logins/passwords/tickets
	/// </summary>
	public class Security
	{
		//Can not instantiate this object
		private Security(){}

		public static readonly string RoleFormat = "{0}.{1}";

		public static bool IsInRole(BlogRole role, HttpContext context)
		{
			
			int BlogID = Config.CurrentBlog(context).BlogID;
			return IsInRole(role,context.User,BlogID);
		}

		public static bool IsInRole(BlogRole role, IPrincipal principal, int BlogID)
		{
			string[] roles = role.ToString().Split(',');
			foreach(string roleName in roles)
			{
				if(principal.IsInRole(string.Format(RoleFormat,BlogID,roleName)))
				{
					return true;
				}
			}
			return false;
		}

		

		/// <summary>
		/// Check to see if the supplied credentials are valid for the current blog. If so, Set the user's FormsAuthentication Ticket
		/// This method will handle passwords for both hashed and non-hashed configurations
		/// </summary>
		/// <param name="username">Supplied UserName</param>
		/// <param name="password">Supplied Password</param>
		/// <returns>bool indicating successful login</returns>
		public static bool Authenticate(string username, string password)
		{
			return Authenticate(username,password,false);
		}

		/// <summary>
		/// Check to see if the supplied credentials are valid for the current blog. If so, Set the user's FormsAuthentication Ticket
		/// This method will handle passwords for both hashed and non-hashed configurations
		/// </summary>
		/// <param name="username">Supplied UserName</param>
		/// <param name="password">Supplied Password</param>
		/// <param name="persist">If valid, should we persist the login</param>
		/// <returns>bool indicating successful login</returns>
		public static bool Authenticate(string username, string password,bool persist)
		{
			if(Config.Settings.UseHashedPasswords)
			{
				password = Encrypt(password);
			}
			return Verify(username,password,persist);

		}

		/// <summary>
		/// Verify works in the same manor as Authenticate, with the exception the password is left as is. There is no
		/// check for Hashing and the password will not be hashed if the blog is currently hashing passwords
		/// </summary>
		public static bool Verify(string username, string password)
		{
			return Verify(username,password,false);
		}

		/// <summary>
		/// Verify works in the same manor as Authenticate, with the exception the password is left as is. There is no
		/// check for Hashing and the password will not be hashed if the blog is currently hashing passwords
		/// </summary>
		public static bool Verify(string username, string password, bool persist)
		{
            UserAccountStatus status = Users.ValidateUser(username,password);
            if(status == UserAccountStatus.Approved)
            {
                BlogUser bu =  Users.GetUser(username);
                if(bu != null)
                {
                    Users.CreateTicket(HttpContext.Current,bu,persist);
                }
                return bu != null;
            }
			return false;
		}

		/// <summary>
		/// Get hashed/encrypted representation of the password. This is a one-way hash.
		/// </summary>
		/// <param name="password">Supplied Password</param>
		/// <returns>Encrypted (Hashed) value</returns>
		public static string Encrypt(string password) 
		{
			// Force the string to lower case
			//
			password = password.ToLower();

			Byte[] clearBytes = new UnicodeEncoding().GetBytes(password);
			Byte[] hashedBytes = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);

			return BitConverter.ToString(hashedBytes);
		}

		/// <summary>
		/// Returns the password in the correct system format
		/// </summary>
		/// <param name="format"></param>
		/// <param name="cleanString"></param>
		/// <returns></returns>
		public static string Encrypt(UserPasswordFormat format, string cleanString) 
		{
			Byte[] clearBytes;
			Byte[] hashedBytes;

			switch (format) 
			{

				case UserPasswordFormat.ClearText:
					return cleanString;

				case UserPasswordFormat.Sha1Hash:
					// Force the string to lower case
					//
					cleanString = cleanString.ToLower();

					clearBytes = new UnicodeEncoding().GetBytes(cleanString);
					hashedBytes = ((HashAlgorithm) CryptoConfig.CreateFromName("SHA1")).ComputeHash(clearBytes);

					return BitConverter.ToString(hashedBytes);

				default: // default to MD5 hash
					// Force the string to lower case
					//
					cleanString = cleanString.ToLower();

					clearBytes = new UnicodeEncoding().GetBytes(cleanString);
					hashedBytes = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);

					return BitConverter.ToString(hashedBytes);

			}

		}


		/// <summary>
		/// When we Encrypt/Hash the password, we can not un-Encrypt/Hash the password. If user's need to retrieve this value, all we can
		/// do is reset the passowrd to a new value and send it.
		/// </summary>
		/// <returns>A New Password</returns>
		public static string ResetPassword(string email)
		{
			string password = null; 

			BlogUser bu = Users.GetUserByEmail(email);

			if(bu != null)
			{

				if(Config.Settings.UseHashedPasswords)
				{
					//Create a new password
					password = RandomPassword();
					bu.Password = Encrypt(password);
				}
				else
				{
					//Unhashed passwords. We will just send the existing password
					password = bu.Password;
				}
			
				if(Users.UpdateUser(bu))
				{
					return password;
				}
			}

			return null;
		}

		/// <summary>
		/// Updates the current users password to the supplied value. Handles hashing (or not hashing of the password)
		/// </summary>
		/// <param name="password">Supplied Password</param>
		public static bool UpdatePassword(HttpContext context, string oldPassword, string newPassword)
		{
			if(context.Request.IsAuthenticated)
			{
				//Do not use the user from the Context. It will not have a password
				BlogUser bu = Users.GetUser(context.User.Identity.Name);

				//using hashed passwords
				if(Config.Settings.UseHashedPasswords)
				{
					oldPassword = Encrypt(oldPassword);
				}

				//compare old against the supplied
				if(string.Compare(bu.Password,oldPassword,true) == 0)
				{
					//if match, should we hash the new password
					if(Config.Settings.UseHashedPasswords)
					{
						newPassword = Encrypt(newPassword);
					}
					//Update User
					//bu.Password = password;
					//Users.UpdateUser(bu);
					//Users.CreateTicket(context,bu);
					return true;
				}
			}
			return false;
			
		}

		/// <summary>
		/// Generates a "Random Enough" password. :)
		/// </summary>
		/// <returns></returns>
		public static string RandomPassword()
		{
			return Guid.NewGuid().ToString().Substring(0,8);
		}

		public static bool IsAdmin
		{
			get
			{
				return IsInRole(BlogRole.Member|BlogRole.Owner,HttpContext.Current);
				//return string.Compare(GetCurrentUserName,Config.CurrentBlog().UserName,true) == 0;
			}
		}

		public static string GetCurrentUserName
		{
			get
			{
				if(HttpContext.Current.Request.IsAuthenticated)
				{
					try
					{
						return HttpContext.Current.User.Identity.Name;
					}
					catch{}
				}
				return null;
			}
		}

	}
}
