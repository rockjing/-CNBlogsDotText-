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
using System.Collections;
using Dottext.Framework.Components;
using Dottext.Framework.Logger;
using Dottext.Framework.Configuration;

namespace Dottext.Framework.Data
{
	/// <summary>
	/// Summary description for IDTOProvider.
	/// </summary>
	public interface IDTOProvider
	{

		#region Entries

		#region EntryCollections

		EntryCollection GetEntryCollection(EntryQuery query);
		CategoryEntryCollection GetCategoryEntryCollection(EntryQuery query);
		EntryDayCollection GetEntryDayCollection(EntryQuery query);
		PagedEntryCollection GetPagedEntryCollection(PagedEntryQuery query);
		EntryDay GetEntryDay(EntryQuery query);

		EntryCollection GetFeedBack(int ParrentID);
		EntryCollection GetFeedBack(Entry ParentEntry);

		#endregion

		#region Single Entry
		Entry GetEntry(int EntryID);
		Entry GetEntry(int EntryID,int BlogID);
		EntryStatsView GetEntryStatsView(int EntryID);
		Entry GetEntry(int EntryID, string EntryName, PostConfig config);
		CategoryEntry GetCategoryEntry(int EntryID, string EntryName, PostConfig config);
		
		#endregion

		#region Delete
	
		bool Delete(int PostID);

		#endregion

		#region Create

		int Create(Entry entry);
		int Create(Entry entry, int[] CategoryIDs);

		#endregion

		#region Update

		bool Update(Entry entry);
		bool Update(Entry entry, int[] CategoryIDs);

		#endregion

		#region Entry Category List

		bool SetEntryCategoryList(int EntryID, int[] Categories);

		#endregion

		#endregion

		#region Links/Categories

		#region Paged Links

		PagedLinkCollection GetPagedLinks(int categoryTypeID, int pageIndex, int pageSize, bool sortDescending);

		#endregion

		#region LinkCollection

		LinkCollection GetLinkCollectionByPostID(int PostID);
		LinkCollection GetLinkCollectionByPostID(int BlogID,int PostID);
		LinkCollection GetLinksByCategoryID(int catID, bool ActiveOnly);
		
		#endregion

		#region Single Link

		Link GetSingleLink(int linkID);
		
		#endregion

		#region LinkCategoryCollection

		LinkCategoryCollection GetCategoriesByType(CategoryType catType, bool ActiveOnly);
		LinkCategoryCollection GetCategoriesByParentID(CategoryType catType,int ParentID,bool ActiveOnly);
		LinkCategoryCollection GetCategoriesByType(int BlogID,CategoryType catType, bool ActiveOnly);
		LinkCategoryCollection GetCategoriesWithLinks(bool IsActive);

		#endregion

		#region LinkCategory

		LinkCategory GetLinkCategory(int CategoryID, bool IsActive);
		LinkCategory GetLinkCategory(int CategoryID, bool IsActive,int BlogID);
		LinkCategory GetLinkCategory(string categoryName, bool IsActive);

		#endregion

		#region Edit Links/Categories

		bool UpdateLink(Link link);
		int CreateLink(Link link);
		bool UpdateLinkCategory(LinkCategory lc);
		int CreateLinkCategory(LinkCategory lc);
		bool DeleteLinkCategory(int CategoryID);
		bool DeleteLink(int LinkID);
		bool DeleteLinkCategory(int LinkID,int BlogID);

		#endregion

		#endregion

		#region Stats

		PagedReferrerCollection GetPagedReferrers(int pageIndex, int pageSize);
		PagedReferrerCollection GetPagedReferrers(int pageIndex, int pageSize, int EntryID);

		bool TrackEntry(EntryView ev);
		bool TrackEntry(EntryViewCollection evc);

		#endregion

		#region  Configuration

		bool UpdateConfigData(BlogConfig config);
		BlogConfig GetConfig(string hostname, string application);
		BlogConfig GetConfig(int BlogID);
		BlogConfig[] GetConfigByRoleID(int RoleID);
		string[] GetBlogGroup(int BlogID);
		BlogConfig GetConfig(string UserName);
		BlogConfig GetConfigByApp(string application);
		SkinControlCollection GetSkinControlCollection(int BlogID);
		bool UpateSkinControl(SkinControl sc);
		bool UpdateSingleSkinControl(int ControlID,bool visible,int BlogID);

		#endregion

		#region KeyWords

		KeyWord GetKeyWord(int KeyWordID);
		KeyWordCollection GetKeyWords();
		PagedKeyWordCollection GetPagedKeyWords(int pageIndex, int pageSize,bool sortDescending);
		bool UpdateKeyWord(KeyWord kw);
		int InsertKeyWord(KeyWord kw);
		bool DeleteKeyWord(int KeyWordID);

		#endregion

		#region Images

		ImageCollection GetImagesByCategoryID(int catID, bool ActiveOnly);
		Image GetSingleImage(int imageID, bool ActiveOnly);
		int InsertImage(Dottext.Framework.Components.Image _image);
		bool UpdateImage(Dottext.Framework.Components.Image _image);
		bool DeleteImage(int ImageID);

		#endregion

		#region Archives
		ArchiveCountCollection GetPostsByYearArchive(PostType postType);
		ArchiveCountCollection GetPostsByMonthArchive(PostType postType);
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
		int GetRatePeople(int entryID,int score);
		#endregion

		#region EntryCount
		int GetEntryCount(EntryQuery query);
		#endregion

		#region Security
		Role[] GetRoles(int BlogID);
		bool AddUserToRole(int BlogID,int RoleID);
		bool RemoveUserFromRole(int BlogID,int RoleID);
		#endregion

		#region MailNotify

		ArrayList GetNotifyMailList(int EntryID);
		bool InsertNotifySubscibe(int EntryID,int BlogID,int SendToBlogID,string EMail);
		bool DeleteMailNotify(int EntryID,int SendToBlogID);

		#endregion

	}
}
