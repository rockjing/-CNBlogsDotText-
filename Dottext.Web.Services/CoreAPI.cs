using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using Dottext.Framework;
using Dottext.Framework.Components;
using Dottext.Framework.Util;
using Dottext.Framework.Configuration;

using Microsoft.Web.Services;
using Microsoft.Web.Services.Security;

using Dottext.Web.ServiceAPI.Security;

namespace Dottext.Web.ServiceAPI
{
	/// <summary>
	/// Summary description for CoreAPI.
	/// </summary>
	
	[ WebService(Name=".Text Core API",Description="Pre 1.0 version of the core .Text API. Should allow administration of most common blog functions. In order to complete any task with this service, you must include a validate UsernameToken.",Namespace="http://scottwater.com/blog/dottext/api/2004/01/16")]
	public class CoreAPI : System.Web.Services.WebService
	{
		
		public CoreAPI()
		{
		}

		private BlogConfig _currentBlog = null;
		protected BlogConfig CurrentBlog
		{
			get
			{
				if(_currentBlog == null)
				{
					_currentBlog = Config.CurrentBlog(Context);
				}
				return _currentBlog;
			}
		}


		#region internal helpers
		private  void Validate()
		{
			SoapContext requestContext = RequestSoapContext.Current;
			if(requestContext == null)
			{
				throw new ApplicationException("Non-SOAP request.");
			}
			string username = null;// UserToken.Username;
			string password = null; //UserToken.Password;
			if(requestContext.Security.Tokens.Count == 1)
			{
				foreach(SecurityToken tok in requestContext.Security.Tokens)
				{
					if(tok is UsernameToken)
					{
						UsernameToken UserToken = (UsernameToken)tok;
						if(UserToken.PasswordOption == PasswordOption.SendHashed)
						{
							
							username = UserToken.Username;
							password = UserToken.Password;
						}
					}
				}
			}
		
			if(string.Compare(username,CurrentBlog.UserName,false) == 0)
			{
				if(password == CurrentBlog.Password)
				{
					return;
				}
			}

			throw new ApplicationException("Invalid User");
		
		}

		#endregion
		
		#region Query Entries	 

		[WebMethod(MessageName="GetEntriesByQuery",Description="Returns a collection of CategoryEnties based on the supplied EntryQuery. An EntryQuery can be used to filter by PostType (flagged enum), PostConfig (flagged enum), CategoryID or CategoryTitle, and either a specific date or date range. The maximum number of entries returned will be limited to 50",EnableSession=false)]
		public CategoryEntryCollection GetEntriesByQuery(EntryQuery query)
		{
			Validate();
			if(query.ItemCount > 50 || query.ItemCount == 0)
			{
				query.ItemCount = 50;
			}
			return Entries.GetCategoryEntryCollection(query);
		}

		[WebMethod(MessageName="GetEntryByName",Description="Returns a a single entry for the given entry name.",EnableSession=false)]
		public CategoryEntry GetEntry(string EntryName)
		{
			Validate();
			return Entries.GetCategoryEntry(EntryName,PostConfig.Empty);
		}

		[WebMethod(MessageName="GetEntryByID",Description="Returns a a single entry for the given EntryID.",EnableSession=false)]
		public CategoryEntry GetEntry(int EntryID)
		{
			//Validate();
			CategoryEntry entry=new CategoryEntry();
			entry.Body="hello!";
			return entry;//Entries.GetCategoryEntry(EntryID,PostConfig.Empty);
		}

		#endregion

		#region Select Categories

		[WebMethod(MessageName="GetCategories",Description="Returns a collection of LinkCategories by the specified CategoryType.",EnableSession=false)]
		public LinkCategoryCollection GetCategories(CategoryType categoryType)
		{
			Validate();
			return Links.GetCategoriesByType(categoryType,false);
		}

		[WebMethod(MessageName="GetCategoriesWithLinks",Description="Returns all of the categories (of type CategoryType.LinkCollection) with corresponding Links.",EnableSession=false)]
		public LinkCategoryCollection GetCategoriesWithLinks()
		{	
			Validate();
			return Links.GetCategoriesWithLinks(true);
		}

		/*[WebMethod(MessageName="GetGlobalCategoriesByType",Description="Returns all of the global categories the current user has access to.",EnableSession=false)]
		public LinkCategoryCollection GetGlobalCategoriesByType(CategoryType catType)
		{
			Validate();
			return Links.GetGlobalCategoriesByType(catType,true);
		}

		[WebMethod(MessageName="GetGlobalCategoriesByEntryID",Description="Returns all of the global categories for a given entry. This request is handled on its own method call since it is an optional configuration",EnableSession=false)]
		public string[] GetGlobalCategoriesByEntryID(int EntryID)
		{
			Validate();
			return Links.GetGlobalCategoriesByEntryID(EntryID,true);
		}*/

		#endregion

		#region edit entries

		private void Check(CategoryEntry entry)
		{
			if(entry.PostType == PostType.Undeclared)
			{
				throw new ApplicationException("You must set a valid PostType");
			}

			if(entry.PostType == PostType.Comment || entry.PostType == PostType.PingTrack)
			{
				if(entry.ParentID <= 0)
				{
					throw new ApplicationException("ParentID must be set for a Comment or PingTrack PostType");
				}
			}

			entry.BlogID = CurrentBlog.BlogID;
			if(entry.Author == null)
			{
				entry.Author = CurrentBlog.Author;
			}
			if(entry.Email == null)
			{
				entry.Email = CurrentBlog.Email;
			}
			
			
		}

		[WebMethod(MessageName="CreateEntry",Description="Inserts a new entry into the data store",EnableSession=false)]
		public int CreateEntry(CategoryEntry entry)
		{
			Validate();

			Check(entry);
			entry.DateUpdated = entry.DateCreated;

			return Entries.Create(entry);
		}

		/*[WebMethod(MessageName="CreateEntryWithGlobalCategories",Description="Inserts a new entry into the data store In addition, the global categories for the entry are either created.",EnableSession=false)]
		public int CreateEntry(CategoryEntry entry, string[] GlobalCategories)
		{
			Validate();

			Check(entry);
			entry.DateUpdated = entry.DateCreated;

			return Entries.Create(entry,null,GlobalCategories);
		}*/

		[WebMethod(MessageName="UpdateEntry",Description="Updates an existing entry",EnableSession=false)]
		public bool UpdateEntry(CategoryEntry entry)
		{
			Validate();
			Check(entry);
			return Entries.Update(entry);
		}

		/*[WebMethod(MessageName="UpdateEntryWithGlobalCategories",Description="Updates an existing entry. In addition, the global categories for the entry are either created or updated.",EnableSession=false)]
		public bool UpdateEntry(CategoryEntry entry, string[] GlobalCategories)
		{
			Validate();
			Check(entry);
			return Entries.Update(entry,null,GlobalCategories);
		}*/

		[WebMethod(MessageName="DeleteEntry",Description="Delete an entry",EnableSession=false)]
		public bool DeleteEntry(int entryID)
		{
			Validate();
			return Entries.Delete(entryID);
		}

		#endregion

		#region Edit Links

		[WebMethod(MessageName="CreateLink",Description="Create a new Link",EnableSession=false)]
		public int CreateLink(Link link)
		{
			Validate();
			return Links.CreateLink(link);
		}

		[WebMethod(MessageName="UpdateLink",Description="Update an existing Link",EnableSession=false)]
		public bool UpdateLink(Link link)
		{
			Validate();
			return Links.UpdateLink(link);
		}

		[WebMethod(MessageName="DeleteLink",Description="Delete an existing Link",EnableSession=false)]
		public bool DeleteLink(int LinkID)
		{
			Validate();
			return Links.DeleteLink(LinkID);
		}

		#endregion

		#region Edit LinkCategories

		[WebMethod(MessageName="CreateLinkCategory",Description="Create a new LinkCategory",EnableSession=false)]
		public int CreateLinkCategory(LinkCategory lc)
		{
			Validate();
			return Links.CreateLinkCategory(lc);
		}

		[WebMethod(MessageName="UpdateLinkCategory",Description="Update an existing LinkCategory",EnableSession=false)]
		public bool UpdateLinkCategory(LinkCategory lc)
		{
			Validate();
			return Links.UpdateLinkCategory(lc);
		}

		[WebMethod(MessageName="DeleteLinkCategory",Description="Delete an existing LinkCategory",EnableSession=false)]
		public bool DeleteLinkCategory(int CategoryID)
		{
			Validate();
			return Links.DeleteLinkCategory(CategoryID);
		}

		[WebMethod(MessageName="test",Description="Delete an existing LinkCategory",EnableSession=false)]
		public string test()
		{
			
			return "Hello World";
		}

		#endregion

		#region
		//-1 --用户不存在
		//-2 --密码错误
		public int Login(string username,string password)
		{
			BlogConfig config=Config.GetConfig(username);
			if(config==null)
			{
				return -2;
			}
			if(!Dottext.Framework.Security.Authenticate(username,password))
			{
				return -1;
			}
			return 1;
		}

		public BlogConfig GetBlogConfig(string username)
		{
			
			if(true)//||HttpContext.Current.Request.IsAuthenticated)
			{
				BlogConfig config=Config.GetConfig(username);
				//Dottext.Framework.Logger.LogManager.Log("BlogID",config.BlogID.ToString());
				return config;
			}
			else
			{
				throw new ApplicationException("你还没有登录,请先登录");
			}
			return null;
		}
		#endregion




	}
}
