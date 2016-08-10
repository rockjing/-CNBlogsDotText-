#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// 
// .Text is an open source weblog system started by Scott Watermasysk. 
// Blog: http://ScottWater.com/blog 
// RSS: http://scottwater.com/blog/rss.aspx
// Email: Dottext@ScottWater.com
//
// For updated news and information please visit http://scottwater.com/dottext and subscribe to 
// the Rss feed @ http://scottwater.com/dottext/rss.aspx
//
// On its release (on or about August 1, 2003) this application is licensed under the BSD. However, I reserve the 
// right to change or modify this at any time. The most recent and up to date license can always be fount at:
// http://ScottWater.com/License.txt
// 
// Please direct all code related questions to:
// GotDotNet Workspace: http://www.gotdotnet.com/Community/Workspaces/workspace.aspx?id=e99fccb3-1a8c-42b5-90ee-348f6b77c407
// Yahoo Group http://groups.yahoo.com/group/DotText/
// 
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Data;
using System.Web;
using System.Collections;

using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Framework.Email;
using Dottext.Framework.Util;
using Dottext.Framework.Providers;
using Dottext.Framework.Tracking;

using Dottext.Framework.EntryHandling;

namespace Dottext.Framework
{
	/// <summary>
	/// Summary description for Entries
	/// </summary>
	public class Entries
	{
		private Entries()
		{

		}

		#region Paged Posts

		public static PagedEntryCollection GetPagedEntryCollection(PagedEntryQuery query)
		{
			return DTOProvider.Instance().GetPagedEntryCollection(query);
		}


		#endregion

		#region EntryDays

		public static EntryDay GetEntryDay(EntryQuery query)
		{
			return DTOProvider.Instance().GetEntryDay(query);
		}

		public static EntryDayCollection GetEntryDayCollection(EntryQuery query)
		{
			return DTOProvider.Instance().GetEntryDayCollection(query);
		}

		#endregion

		#region EntryCollections


		public static EntryCollection GetEntryCollection(EntryQuery query)
		{
			return DTOProvider.Instance().GetEntryCollection(query);
		}	

		/// <summary>
		/// Returns a collection of Entries containing the feedback for a given post (via ParentID)
		/// </summary>
		/// <param name="ParrentID">Parent (EntryID) of the collection</param>
		/// <param name="BlogID">Current BlogID</param>
		/// <param name="UrlPattern">Format of the Url for each entry</param>
		/// <returns></returns>
		public static EntryCollection GetFeedBack(int ParrentID)
		{
			return DTOProvider.Instance().GetFeedBack(ParrentID);
		}

		public static EntryCollection GetFeedBack(Entry ParentEntry)
		{
			return DTOProvider.Instance().GetFeedBack(ParentEntry);
		}

		public static CategoryEntryCollection GetCategoryEntryCollection(EntryQuery query)
		{
			return DTOProvider.Instance().GetCategoryEntryCollection(query);
		}

		#endregion

		#region Single Entry

		public static Entry GetEntry(int EntryID)
		{
			return DTOProvider.Instance().GetEntry(EntryID);
		}

		public static Entry GetEntry(int EntryID,int BlogID)
		{
			return DTOProvider.Instance().GetEntry(EntryID,BlogID);
		}

		public static EntryStatsView GetEntryStatView(int EntryID)
		{
			return DTOProvider.Instance().GetEntryStatsView(EntryID);
		}

		public static Entry GetEntry(int EntryID, PostConfig config)
		{
			return DTOProvider.Instance().GetEntry(EntryID,null,config);
		}

		public static Entry GetEntry(string EntryName, PostConfig config)
		{
			return DTOProvider.Instance().GetEntry(0,EntryName,config);
		}


		public static CategoryEntry GetCategoryEntry(int EntryID, PostConfig config)
		{
			return DTOProvider.Instance().GetCategoryEntry(EntryID,null,config);
		}

		public static CategoryEntry GetCategoryEntry(string EntryName, PostConfig config)
		{
			return DTOProvider.Instance().GetCategoryEntry(0,EntryName,config);
		}

		#endregion

		#region Delete
	
		public static bool Delete(int EntryID)
		{
			return DTOProvider.Instance().Delete(EntryID);
		}

		#endregion

		#region Create

		/// <summary>
		/// Add a new .Text Entry to the datastore. ProcessEntry.PreCommit is fired before an attempted save. Proccess.PostCommit is fired after the item is saved
		/// </summary>
		/// <param name="entry"></param>
		/// <returns></returns>
		public static int Create(Entry entry)
		{
			return Create(entry,null);
		}

		/// <summary>
		/// Add a new .Text Entry to the datastore. ProcessEntry.PreCommit is fired before an attempted save. Proccess.PostCommit is fired after the item is saved
		/// </summary>
		/// <param name="entry"></param>
		/// <param name="CategoryIDs"></param>
		/// <returns></returns>
		public static int Create(Entry entry, int[] CategoryIDs)
		{
			HandlerManager.PreCommit(entry,ProcessAction.Insert);
			
			int result = DTOProvider.Instance().Create(entry,CategoryIDs);
			
			if(result > 0)
			{
				HandlerManager.PostCommit(entry,ProcessAction.Insert);
				
			}

			return result;
		}

		#endregion

		#region Update

		public static bool Update(Entry entry)
		{
			return Update(entry,null);
		}

		public static bool Update(Entry entry, int[] CategoryIDs)
		{
			HandlerManager.PreCommit(entry,ProcessAction.Update);

			bool result = DTOProvider.Instance().Update(entry,CategoryIDs);
			
			if(result)
			{
				HandlerManager.PostCommit(entry,ProcessAction.Update);
			}

			return result;
		}

		#endregion

		#region Entry Category List

		public static bool SetEntryCategoryList(int EntryID, int[] Categories)
		{
			return DTOProvider.Instance().SetEntryCategoryList(EntryID,Categories);
		}

		#endregion

		#region Comments

		[Obsolete]
		public static void InsertComment(Entry entry)
		{
			entry.Author = Globals.SafeFormat(entry.Author);
			entry.TitleUrl =  Globals.SafeFormat(entry.TitleUrl);
			entry.Body = Globals.SafeFormatWithUrl(entry.Body);
			entry.Title = Globals.SafeFormat(entry.Title);
			//entry.SourceUrl = Globals.PostsUrl(entry.ParentID);
			entry.IsXHMTL = false;
			entry.IsActive = true;
			entry.DateCreated = entry.DateUpdated = BlogTime.CurrentBloggerTime;
			
			

			if (null == entry.SourceName || String.Empty == entry.SourceName)
				entry.SourceName = "N/A";


			// insert comment into backend, save the returned entryid for permalink anchor below
			int entryID = Entries.Create(entry);

			// if it's not the administrator commenting
			if(!Security.IsAdmin)
			{
				try
				{
					
					string blogTitle = Config.CurrentBlog().Title;

					// create and format an email to the site admin with comment details
					IMailProvider im = EmailProvider.Instance();

					string To = Config.CurrentBlog().Email;
					string From = Config.Settings.BlogProviders.EmailProvider.AdminEmail;
					string Subject = String.Format("Comment: {0} (via {1})", entry.Title, blogTitle);
					string Body = String.Format("Comments from {0}:\r\n\r\nSender: {1}\r\nUrl: {2}\r\nIP Address: {3}\r\n=====================================\r\n\r\n{4}\r\n\r\n{5}\r\n\r\nSource: {6}#{7}", 
						blogTitle,
						entry.Author,
						entry.TitleUrl,
						entry.SourceName,
						entry.Title,					
						// we're sending plain text email by default, but body includes <br>s for crlf
						entry.Body.Replace("<br>", "\n"), 
						entry.SourceUrl,
						entryID);			
					
					im.Send(To,From,Subject,Body);
				}
				catch{}
			}
		}
		
		#endregion

		#region EntryCount
		public static int GetEntryCount(EntryQuery query)
		{
			return DTOProvider.Instance().GetEntryCount(query);
		}
		#endregion

		#region MailNotify

		public static ArrayList GetNotifyMailList(int EntryID)
		{
			return DTOProvider.Instance().GetNotifyMailList(EntryID);
		}

		public static bool InsertNotifySubscibe(int EntryID,int BlogID,int SendToBlogID,string EMail)
		{
			return DTOProvider.Instance().InsertNotifySubscibe(EntryID,BlogID,SendToBlogID,EMail);
		}

		public static bool DeleteMailNotify(int EntryID,int SendToBlogID)
		{
			return DTOProvider.Instance().DeleteMailNotify(EntryID,SendToBlogID);
		}

		#endregion

	}
}

