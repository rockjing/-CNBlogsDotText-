#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// Blog:		http://ScottWater.com/blog 
// RSS:			http://scottwater.com/blog/rss.aspx
// License:		http://scottwater.com/License
// Email:		Scott@TripleASP.NET
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Data;

using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Framework.Logger;

namespace Dottext.Framework.Data
{
	/// <summary>
	/// Summary description for IBlogDataProvider.
	/// </summary>
	public interface IDbProvider
	{

		string ConnectionString
		{
			get;
			set;
		}

		#region Get Blog Data

		IDataReader GetEntriesReader(EntryQuery query);
		IDataReader GetPagedEntriesReader(PagedEntryQuery query);
		IDataReader GetEntry(int EntryID, string EntryName, PostConfig config, bool IncludeCategories);
		IDataReader GetEntry(int EntryID);
		IDataReader GetEntry(int EntryID,int BlogID);
		IDataReader GetEntryStatsView(int EntryID);
		
		DataSet GetEntriesDataSet(EntryQuery query);
		DataSet GetCategoryEntriesDataSet(EntryQuery query);
		DataSet GetPagedEntriesDataSet(PagedEntryQuery query);

		//Need to handle this method better. It would end up doubling the logic of the core sp's. 
		IDataReader GetFeedBack(int PostID);


		#endregion

		#region Update Blog Data
		
		//Should have one create method for Entry, CategoryEntry and Trackback entries 
		
		bool DeleteEntry(int EntryID);

		//Should just be Entry and check is CategoryEntry?
		int InsertCategoryEntry(CategoryEntry ce);
		bool UpdateCategoryEntry(CategoryEntry ce);

		int InsertEntry(Entry entry); //change to create?
		bool UpdateEntry(Entry entry);

		int InsertPingTrackEntry(Entry entry); //Create and add check for PostType. 
		#endregion

		#region Links

		IDataReader GetLinkCollectionByPostID(int PostID);
		IDataReader GetLinkCollectionByPostID(int BlogID,int PostID);

		//use charlist_to_table
		bool AddEntryToCategories(int PostID, LinkCollection lc);

		bool SetEntryCategoryList(int PostID, int[] Categories);

		bool DeleteLink(int LinkID);

		IDataReader GetSingleLink(int linkID);

		int InsertLink(Link link); //Create?

		bool UpdateLink(Link link); 

		DataSet GetCategoriesWithLinks(bool IsActive);

		IDataReader GetLinksByCategoryID(int catID, bool ActiveOnly); //Add another method for by name



		#endregion

		#region Categories

		bool DeleteCategory(int CatID);
		bool DeleteCategory(int CatID,int BlogID);
		IDataReader GetLinkCategory(int catID, string categoryName, bool IsActive);
		IDataReader GetLinkCategory(int catID, string categoryName, bool IsActive,int BlogID);
		IDataReader GetCategoriesByType(CategoryType catType, bool ActiveOnly);
		IDataReader GetCategoriesByType(int BlogID,CategoryType catType, bool ActiveOnly);
		IDataReader GetCategoriesByParentID(CategoryType catType,int ParentID,bool IsActive);

		bool UpdateCategory(LinkCategory lc);

		int InsertCategory(LinkCategory lc);

		#endregion

		#region Config

		IDataReader GetConfig(string host, string application);
		IDataReader GetConfig(int BlogID);
		IDataReader GetConfigByRoleID(int RoleID);
		IDataReader GetConfig(string UserName);
		IDataReader GetConfigByApp(string app);
		IDataReader GetSkinControlCollection(int BlogID);
		IDataReader GetBlogGroup(int BlogID);
		bool UpateSkinControl(SkinControl sc);
		bool UpdateSingleSkinControl(int ControlID,bool visible,int BlogID);

		bool UpdateConfigData(BlogConfig config);

		#endregion

		#region KeyWord
		IDataReader GetKeyWord(int KeyWordID);
		IDataReader GetPagedKeyWords(int pageIndex, int pageSize,bool sortDescending);

		bool DeleteKeyWord(int KeyWordID);

		int InsertKeyWord(KeyWord kw);

		bool UpdateKeyWord(KeyWord kw);

		IDataReader GetKeyWords();

		#endregion

		#region Statistics

		bool TrackEntry(EntryView ev);
		bool TrackEntry(EntryViewCollection evc);

//		bool TrackPages(Referrer[] _feferrers);
//		bool TrackPage(PageType PageType, int PostID, string Referral);

		#endregion

		#region Images

		IDataReader GetImagesByCategoryID(int catID, bool ActiveOnly);
		IDataReader GetSingleImage(int imageID, bool ActiveOnly);

		int InsertImage(Image _image);
		bool UpdateImage(Image _image);
		bool DeleteImage(int imageID);

		#endregion

		#region Admin

		IDataReader GetPagedLinks(int CategoryID, int pageIndex, int pageSize, bool sortDescending);
		IDataReader GetPagedReferrers(int pageIndex, int pageSize);
		IDataReader GetPagedReferrers(int pageIndex, int pageSize, int EntryID);

		#endregion

		#region Archives

		IDataReader GetPostsByMonthArchive(PostType postType);
		IDataReader GetPostsByYearArchive(PostType postType);

		#endregion

		#region ScheduledEvents
		DateTime GetLastExecuteScheduledEventDateTime(string key, string serverName);
		void SetLastExecuteScheduledEventDateTime(string key, string serverName, DateTime dt);
		#endregion

		#region Logger
		int CreateLog(Log blogLog);
		#endregion

		#region Rate
		int InsertRate(EntryRate er);
		IDataReader GetRatePeople(int entryID,int score);
		#endregion

		#region EntryCount
		IDataReader GetEntryCount(EntryQuery query);
		#endregion

		#region Security
		IDataReader GetRoles(int BlogID);
		bool AddUserToRole(int BlogID,int RoleID);
		bool RemoveUserFromRole(int BlogID,int RoleID);
		#endregion

		#region MailNotify

		IDataReader GetNotifyMailList(int EntryID);
		bool InsertNotifySubscibe(int EntryID,int BlogID,int SendToBlogID,string EMail);
		bool DeleteMailNotify(int EntryID,int SendToBlogID);

		#endregion

	}
}
