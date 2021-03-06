IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'DotTextData')
	DROP DATABASE [DotTextData]
GO

CREATE DATABASE [DotTextData]  ON (NAME = N'DotTextData_Data', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL\data\DotTextData_Data.MDF' , SIZE = 3, FILEGROWTH = 10%) LOG ON (NAME = N'DotTextData_Log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL\data\DotTextData_Log.LDF' , SIZE = 1, FILEGROWTH = 10%)
 COLLATE Chinese_PRC_CI_AS
GO

exec sp_dboption N'DotTextData', N'autoclose', N'true'
GO

exec sp_dboption N'DotTextData', N'bulkcopy', N'false'
GO

exec sp_dboption N'DotTextData', N'trunc. log', N'true'
GO

exec sp_dboption N'DotTextData', N'torn page detection', N'true'
GO

exec sp_dboption N'DotTextData', N'read only', N'false'
GO

exec sp_dboption N'DotTextData', N'dbo use', N'false'
GO

exec sp_dboption N'DotTextData', N'single', N'false'
GO

exec sp_dboption N'DotTextData', N'autoshrink', N'true'
GO

exec sp_dboption N'DotTextData', N'ANSI null default', N'false'
GO

exec sp_dboption N'DotTextData', N'recursive triggers', N'false'
GO

exec sp_dboption N'DotTextData', N'ANSI nulls', N'false'
GO

exec sp_dboption N'DotTextData', N'concat null yields null', N'false'
GO

exec sp_dboption N'DotTextData', N'cursor close on commit', N'false'
GO

exec sp_dboption N'DotTextData', N'default to local cursor', N'false'
GO

exec sp_dboption N'DotTextData', N'quoted identifier', N'false'
GO

exec sp_dboption N'DotTextData', N'ANSI warnings', N'false'
GO

exec sp_dboption N'DotTextData', N'auto create statistics', N'true'
GO

exec sp_dboption N'DotTextData', N'auto update statistics', N'true'
GO

if( ( (@@microsoftversion / power(2, 24) = 8) and (@@microsoftversion & 0xffff >= 724) ) or ( (@@microsoftversion / power(2, 24) = 7) and (@@microsoftversion & 0xffff >= 1082) ) )
	exec sp_dboption N'DotTextData', N'db chaining', N'false'
GO

use [DotTextData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Content_Trigger]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[blog_Content_Trigger]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iter_charlist_to_table]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[iter_charlist_to_table]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Blog_GetRecentCommentPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Blog_GetRecentCommentPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Blog_GetTopCommentPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Blog_GetTopCommentPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Blog_GetTopCommentPostsByDay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Blog_GetTopCommentPostsByDay]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Blog_GetTopCommentPostsByMonth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Blog_GetTopCommentPostsByMonth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Blog_GetTopPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Blog_GetTopPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Blog_GetTopPostsByDay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Blog_GetTopPostsByDay]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Blog_GetTopPostsByMonth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Blog_GetTopPostsByMonth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Blog_SearchPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Blog_SearchPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_CategoriesWithLinks]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_CategoriesWithLinks]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_DeleteBlogger]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_DeleteBlogger]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_DeleteCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_DeleteCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_DeleteImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_DeleteImage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_DeleteKeyWord]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_DeleteKeyWord]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_DeleteLink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_DeleteLink]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_DeleteLinksByPostID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_DeleteLinksByPostID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_DeletePost]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_DeletePost]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Export]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_Export]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GenericGetEntriesCount_10]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GenericGetEntriesCount_10]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GenericGetEntriesWithCategories_10]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GenericGetEntriesWithCategories_10]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GenericGetEntries_10]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GenericGetEntries_10]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GenericGetEntryIDs_10]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GenericGetEntryIDs_10]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GenericGetPagedEntries_10]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GenericGetPagedEntries_10]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedBloggerListByRegisterTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedBloggerListByRegisterTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedBloggers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedBloggers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedBloggersByMonth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedBloggersByMonth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedBookPost]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedBookPost]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedBookPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedBookPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedCommentAuthors]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedCommentAuthors]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedFAQPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedFAQPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedJobPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedJobPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedNoTechPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedNoTechPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedPagedBloggerList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedPagedBloggerList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedPagedBloggerListByRegisterTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedPagedBloggerListByRegisterTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedPickedPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedPickedPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedPostsByCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedPostsByCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedPostsID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedPostsID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedProjectPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedProjectPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedQuotePosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedQuotePosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedStats]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedStats]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedTechPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedTechPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedVIPBloggers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedVIPBloggers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedVIPPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedVIPPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAllPostsByMonth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAllPostsByMonth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetBlogGroupByBlogID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetBlogGroupByBlogID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetCategoriesByType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetCategoriesByType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetConfig]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetConfig]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetConfigByApp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetConfigByApp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetConfigByBlogID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetConfigByBlogID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetConfigByRoleID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetConfigByRoleID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetConfigByUserName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetConfigByUserName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetEntryByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetEntryByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetEntryStatViewByEntryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetEntryStatViewByEntryID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetEntry_10]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetEntry_10]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetFeedBack]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetFeedBack]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetImageCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetImageCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetKeyWord]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetKeyWord]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetKeyWords]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetKeyWords]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetLastExecuteScheduledEventDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetLastExecuteScheduledEventDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetLinkCollectionByPostID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetLinkCollectionByPostID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetLinksByCategoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetLinksByCategoryID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetLinksCountByCategoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetLinksCountByCategoryID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetPageableKeyWords]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetPageableKeyWords]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetPageableLinks]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetPageableLinks]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetPageableReferrers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetPageableReferrers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetPageableReferrersByEntryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetPageableReferrersByEntryID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetPagedPosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetPagedPosts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetPostCountByType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetPostCountByType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetPostsByMonthArchive]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetPostsByMonthArchive]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetPostsByYearArchive]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetPostsByYearArchive]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetRatePeople]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetRatePeople]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetSingleImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetSingleImage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetSingleLink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetSingleLink]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetSkinControlByBlogID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetSkinControlByBlogID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetTopFeedbackPostsByBlogID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetTopFeedbackPostsByBlogID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetTopPostsByBlogID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetTopPostsByBlogID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetUrlID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetUrlID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertBlogProfile]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertBlogProfile]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertEntry]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertEntryViewCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertEntryViewCount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertFavorite]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertFavorite]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertImage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertKeyWord]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertKeyWord]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertLink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertLink]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertLinkCategoryList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertLinkCategoryList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertPingTrackEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertPingTrackEntry]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertPostCategoryByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertPostCategoryByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertRate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertRate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_InsertReferral]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_InsertReferral]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_MailNotify_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_MailNotify_Delete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_MailNotify_GetMailList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_MailNotify_GetMailList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_MailNotify_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_MailNotify_Insert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Role_AddUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_Role_AddUser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Role_RemoveUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_Role_RemoveUser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Roles_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_Roles_Get]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_SetLastExecuteScheduledEventDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_SetLastExecuteScheduledEventDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_StatsSummary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_StatsSummary]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_TrackEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_TrackEntry]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_UTILITY_AddBlog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_UTILITY_AddBlog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_UpdateCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_UpdateCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_UpdateConfig]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_UpdateConfig]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_UpdateConfigUpdateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_UpdateConfigUpdateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_UpdateEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_UpdateEntry]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_UpdateImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_UpdateImage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_UpdateKeyWord]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_UpdateKeyWord]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_UpdateLink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_UpdateLink]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_UpdatePostConfig]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_UpdatePostConfig]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_UpdateSkinControl]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_UpdateSkinControl]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Utility_GetUnHashedPasswords]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_Utility_GetUnHashedPasswords]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Utility_UpdateToHashedPassword]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_Utility_UpdateToHashedPassword]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_aggregate_Search]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_aggregate_Search]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_aggregate_Search_BU]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_aggregate_Search_BU]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Log_View]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[Log_View]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SiteCatalog]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[SiteCatalog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VIEW_ScheduleEvents]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[VIEW_ScheduleEvents]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Content_View]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[blog_Content_View]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Comment_Audit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Comment_Audit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Config]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Config]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Content]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Content]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Content_Audit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Content_Audit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_EntryRate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_EntryRate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_EntryViewCount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_EntryViewCount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Images]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Images]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_KeyWords]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_KeyWords]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_LinkCategories]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_LinkCategories]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Links]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Links]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Log]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Log]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_MailNotify]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_MailNotify]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Profile]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Profile]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Referrals]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Referrals]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_Roles]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_Roles]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_ScheduledEvents]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_ScheduledEvents]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_SkinControl]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_SkinControl]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_SkinControl_Config]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_SkinControl_Config]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_URLs]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_URLs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_UsersInRoles]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[blog_UsersInRoles]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




--Found at: http://www.algonet.se/~sommar/arrays-in-sql.html
  CREATE FUNCTION iter_charlist_to_table
                    (@list      ntext,
                     @delimiter nchar(1) = N',')
         RETURNS @tbl TABLE (listpos int IDENTITY(1, 1) NOT NULL,
                             str     varchar(4000),
                             nstr    nvarchar(2000)) AS

   BEGIN
      DECLARE @pos      int,
              @textpos  int,
              @chunklen smallint,
              @tmpstr   nvarchar(4000),
              @leftover nvarchar(4000),
              @tmpval   nvarchar(4000)

      SET @textpos = 1
      SET @leftover = ''
      WHILE @textpos <= datalength(@list) / 2
      BEGIN
         SET @chunklen = 4000 - datalength(@leftover) / 2
         SET @tmpstr = @leftover + substring(@list, @textpos, @chunklen)
         SET @textpos = @textpos + @chunklen

         SET @pos = charindex(@delimiter, @tmpstr)

         WHILE @pos > 0
         BEGIN
            SET @tmpval = ltrim(rtrim(left(@tmpstr, @pos - 1)))
            INSERT @tbl (str, nstr) VALUES(@tmpval, @tmpval)
            SET @tmpstr = substring(@tmpstr, @pos + 1, len(@tmpstr))
            SET @pos = charindex(@delimiter, @tmpstr)
         END

         SET @leftover = @tmpstr
      END

      INSERT @tbl(str, nstr) VALUES (ltrim(rtrim(@leftover)), ltrim(rtrim(@leftover)))
   RETURN
   END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE TABLE [dbo].[blog_Comment_Audit] (
	[EntryID] [int] NOT NULL ,
	[BlogID] [int] NOT NULL ,
	[OwnerBlogID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_Config] (
	[BlogID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Password] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Email] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Title] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[SubTitle] [nvarchar] (250) COLLATE Chinese_PRC_CI_AS NULL ,
	[Skin] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Application] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Host] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Author] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[TimeZone] [int] NULL ,
	[IsActive] [bit] NULL ,
	[Language] [nvarchar] (10) COLLATE Chinese_PRC_CI_AS NULL ,
	[ItemCount] [int] NULL ,
	[LastUpdated] [datetime] NULL ,
	[News] [ntext] COLLATE Chinese_PRC_CI_AS NULL ,
	[SecondaryCss] [ntext] COLLATE Chinese_PRC_CI_AS NULL ,
	[PostCount] [int] NULL ,
	[StoryCount] [int] NULL ,
	[PingTrackCount] [int] NULL ,
	[CommentCount] [int] NULL ,
	[IsAggregated] [bit] NULL ,
	[Flag] [int] NULL ,
	[SkinCssFile] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[BlogGroup] [int] NULL ,
	[RegisterTime] [datetime] NULL ,
	[IsMailNotify] [bit] NULL ,
	[NotifyMail] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[IsOnlyListTitle] [bit] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_Content] (
	[ID] [int] IDENTITY (145, 1) NOT NULL ,
	[Title] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[DateAdded] [smalldatetime] NOT NULL ,
	[SourceUrl] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PostType] [int] NOT NULL ,
	[Author] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Email] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[SourceName] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[BlogID] [int] NULL ,
	[Description] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NULL ,
	[DateUpdated] [smalldatetime] NULL ,
	[TitleUrl] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Text] [ntext] COLLATE Chinese_PRC_CI_AS NULL ,
	[ParentID] [int] NULL ,
	[FeedBackCount] [int] NULL ,
	[PostConfig] [int] NULL ,
	[EntryName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[IsOriginal] [bit] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_Content_Audit] (
	[AuditID] [int] IDENTITY (1, 1) NOT NULL ,
	[ID] [int] NOT NULL ,
	[Title] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[DateAdded] [smalldatetime] NOT NULL ,
	[SourceUrl] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[PostType] [int] NOT NULL ,
	[Author] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Email] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[SourceName] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[BlogID] [int] NULL ,
	[Description] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NULL ,
	[DateUpdated] [smalldatetime] NULL ,
	[TitleUrl] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Text] [ntext] COLLATE Chinese_PRC_CI_AS NULL ,
	[ParentID] [int] NOT NULL ,
	[FeedBackCount] [int] NOT NULL ,
	[PostConfig] [int] NULL ,
	[EntryName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[IsOriginal] [bit] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_EntryRate] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[EntryID] [int] NOT NULL ,
	[BlogID] [int] NOT NULL ,
	[ClientID] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Score] [tinyint] NOT NULL ,
	[UpdateTime] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_EntryViewCount] (
	[EntryID] [int] NOT NULL ,
	[BlogID] [int] NOT NULL ,
	[WebCount] [int] NOT NULL ,
	[AggCount] [int] NOT NULL ,
	[WebLastUpdated] [datetime] NULL ,
	[AggLastUpdated] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_Images] (
	[ImageID] [int] IDENTITY (1, 1) NOT NULL ,
	[Title] [nvarchar] (250) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[CategoryID] [int] NOT NULL ,
	[Width] [int] NOT NULL ,
	[Height] [int] NOT NULL ,
	[File] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Active] [bit] NOT NULL ,
	[BlogID] [int] NOT NULL ,
	[UploadTime] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_KeyWords] (
	[KeyWordID] [int] IDENTITY (1, 1) NOT NULL ,
	[Word] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Text] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[ReplaceFirstTimeOnly] [bit] NOT NULL ,
	[OpenInNewWindow] [bit] NOT NULL ,
	[Url] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Title] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[BlogID] [int] NOT NULL ,
	[CaseSensitive] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_LinkCategories] (
	[CategoryID] [int] IDENTITY (1, 1) NOT NULL ,
	[Title] [nvarchar] (150) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Active] [bit] NOT NULL ,
	[BlogID] [int] NOT NULL ,
	[CategoryType] [tinyint] NULL ,
	[Description] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ParentID] [int] NULL ,
	[UpdateTime] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_Links] (
	[LinkID] [int] IDENTITY (1, 1) NOT NULL ,
	[Title] [nvarchar] (150) COLLATE Chinese_PRC_CI_AS NULL ,
	[Url] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Rss] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Active] [bit] NOT NULL ,
	[CategoryID] [int] NULL ,
	[BlogID] [int] NOT NULL ,
	[PostID] [int] NULL ,
	[NewWindow] [bit] NULL ,
	[UpdateTime] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_Log] (
	[LogID] [int] IDENTITY (1, 1) NOT NULL ,
	[Title] [nvarchar] (250) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Message] [nvarchar] (250) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[UserName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[Url] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL ,
	[ServerName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[BlogID] [int] NOT NULL ,
	[StartDate] [datetime] NOT NULL ,
	[EndDate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_MailNotify] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[EntryID] [int] NOT NULL ,
	[BlogID] [int] NOT NULL ,
	[SendToBlogID] [int] NOT NULL ,
	[EMail] [nvarchar] (150) COLLATE Chinese_PRC_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_Profile] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[BlogID] [int] NOT NULL ,
	[City] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_Referrals] (
	[EntryID] [int] NOT NULL ,
	[BlogID] [int] NOT NULL ,
	[UrlID] [int] NOT NULL ,
	[Count] [int] NOT NULL ,
	[LastUpdated] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_Roles] (
	[RoleID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [nvarchar] (256) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Description] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_ScheduledEvents] (
	[ScheduleID] [int] IDENTITY (1, 1) NOT NULL ,
	[Key] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[LastExecuted] [datetime] NOT NULL ,
	[ServerName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_SkinControl] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[ControlName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Control] [nvarchar] (150) COLLATE Chinese_PRC_CI_AS NULL ,
	[DefaultVisible] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_SkinControl_Config] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[ControlID] [int] NOT NULL ,
	[BlogID] [int] NOT NULL ,
	[Visible] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_URLs] (
	[UrlID] [int] IDENTITY (1, 1) NOT NULL ,
	[URL] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[blog_UsersInRoles] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserID] [int] NOT NULL ,
	[RoleID] [int] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[blog_Config] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_Config] PRIMARY KEY  CLUSTERED 
	(
		[BlogID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_Content] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_Content] PRIMARY KEY  CLUSTERED 
	(
		[ID] DESC 
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_Content_Audit] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_Content_Audit] PRIMARY KEY  CLUSTERED 
	(
		[AuditID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_EntryViewCount] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_EntryViewCount] PRIMARY KEY  CLUSTERED 
	(
		[EntryID],
		[BlogID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_Images] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_Images] PRIMARY KEY  CLUSTERED 
	(
		[ImageID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_KeyWords] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_KeyWords] PRIMARY KEY  CLUSTERED 
	(
		[KeyWordID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_LinkCategories] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_LinkCategories] PRIMARY KEY  CLUSTERED 
	(
		[CategoryID] DESC 
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_Links] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_Links] PRIMARY KEY  CLUSTERED 
	(
		[LinkID] DESC 
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_Log] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_Log] PRIMARY KEY  CLUSTERED 
	(
		[LogID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_MailNotify] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_MailNotify] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_Referrals] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_Referrals] PRIMARY KEY  CLUSTERED 
	(
		[EntryID],
		[BlogID],
		[UrlID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_ScheduledEvents] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_ScheduledEvents] PRIMARY KEY  CLUSTERED 
	(
		[ScheduleID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[blog_URLs] WITH NOCHECK ADD 
	CONSTRAINT [PK_blog_URLs] PRIMARY KEY  CLUSTERED 
	(
		[UrlID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

 CREATE  UNIQUE  CLUSTERED  INDEX [PK_blog_SkinControl_Config] ON [dbo].[blog_SkinControl_Config]([id]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

ALTER TABLE [dbo].[blog_Config] ADD 
	CONSTRAINT [DF_blog_Config_TimeZone] DEFAULT (0) FOR [TimeZone],
	CONSTRAINT [DF__blog_Conf__IsAct__047AA831] DEFAULT (1) FOR [IsActive],
	CONSTRAINT [DF_Blog_Config_Language] DEFAULT ('en-US') FOR [Language],
	CONSTRAINT [DF__blog_Conf__ItemC__0662F0A3] DEFAULT (15) FOR [ItemCount],
	CONSTRAINT [DF__blog_Conf__PostC__5D60DB10] DEFAULT (0) FOR [PostCount],
	CONSTRAINT [DF__blog_Conf__Story__5E54FF49] DEFAULT (0) FOR [StoryCount],
	CONSTRAINT [DF__blog_Conf__PingT__5F492382] DEFAULT (0) FOR [PingTrackCount],
	CONSTRAINT [DF__blog_Conf__Comme__603D47BB] DEFAULT (0) FOR [CommentCount],
	CONSTRAINT [DF__blog_Conf__IsAgg__61316BF4] DEFAULT (1) FOR [IsAggregated],
	CONSTRAINT [DF_blog_Config_BlogGroup] DEFAULT (1) FOR [BlogGroup],
	CONSTRAINT [DF_blog_Config_IsMailNotify] DEFAULT (1) FOR [IsMailNotify],
	CONSTRAINT [DF_blog_Config_IsOnlyListTitle] DEFAULT (0) FOR [IsOnlyListTitle],
	CONSTRAINT [IX_blog_Config] UNIQUE  NONCLUSTERED 
	(
		[Application],
		[Host]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

 CREATE  UNIQUE  INDEX [IX_blog_Config_HostApplication] ON [dbo].[blog_Config]([BlogID], [Host], [Application]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_Config_IsAggregated] ON [dbo].[blog_Config]([IsAggregated]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

ALTER TABLE [dbo].[blog_Content] ADD 
	CONSTRAINT [DF__blog_Cont__DateU__075714DC] DEFAULT (getdate()) FOR [DateUpdated],
	CONSTRAINT [DF__blog_Cont__Paren__0ABD916C] DEFAULT ((-1)) FOR [ParentID],
	CONSTRAINT [DF__blog_Cont__FeedB__0BB1B5A5] DEFAULT (0) FOR [FeedBackCount],
	CONSTRAINT [DF__blog_Cont__PostC__24B26D99] DEFAULT (0) FOR [PostConfig],
	CONSTRAINT [DF_blog_Content_IsOriginal] DEFAULT (1) FOR [IsOriginal]
GO

 CREATE  INDEX [IX_blog_Content_EntryName] ON [dbo].[blog_Content]([EntryName]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_Content_PostType] ON [dbo].[blog_Content]([PostType]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_Content_BlogID] ON [dbo].[blog_Content]([BlogID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_Content_ParentID] ON [dbo].[blog_Content]([ParentID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_Content_DateUpdated] ON [dbo].[blog_Content]([DateUpdated] DESC ) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_Content_PostConfig] ON [dbo].[blog_Content]([PostConfig]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [LX_blog_Content_DateAdded] ON [dbo].[blog_Content]([DateAdded]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [blog_Content9] ON [dbo].[blog_Content]([ID], [PostType], [BlogID], [PostConfig]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

ALTER TABLE [dbo].[blog_EntryViewCount] ADD 
	CONSTRAINT [DF_blog_EntryViewCount_WebCount] DEFAULT (0) FOR [WebCount],
	CONSTRAINT [DF_blog_EntryViewCount_AggCount] DEFAULT (0) FOR [AggCount]
GO

 CREATE  INDEX [blog_EntryViewCount11] ON [dbo].[blog_EntryViewCount]([BlogID], [WebCount], [AggCount]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_EntryViewCount_EntryID] ON [dbo].[blog_EntryViewCount]([EntryID] DESC ) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_EntryViewCount_ViewCount] ON [dbo].[blog_EntryViewCount]([WebCount], [AggCount]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

ALTER TABLE [dbo].[blog_Images] ADD 
	CONSTRAINT [DF_blog_Images_Active] DEFAULT (1) FOR [Active]
GO

 CREATE  INDEX [IX_blog_Images_CategoryID] ON [dbo].[blog_Images]([CategoryID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_Images_BlogID] ON [dbo].[blog_Images]([BlogID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

ALTER TABLE [dbo].[blog_LinkCategories] ADD 
	CONSTRAINT [DF_blog_LinkCategories_CategoryType] DEFAULT (0) FOR [CategoryType]
GO

 CREATE  INDEX [IX_blog_LinkCategories_BlogID] ON [dbo].[blog_LinkCategories]([BlogID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_LinkCategories_CategoryType] ON [dbo].[blog_LinkCategories]([CategoryType]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

ALTER TABLE [dbo].[blog_Links] ADD 
	CONSTRAINT [DF_blog_Links_PostID] DEFAULT ((-1)) FOR [PostID],
	CONSTRAINT [DF__blog_Link__NewWi__084B3915] DEFAULT (0) FOR [NewWindow]
GO

 CREATE  INDEX [IX_blog_Links_CategoryID] ON [dbo].[blog_Links]([CategoryID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_Links_BlogID] ON [dbo].[blog_Links]([BlogID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [blog_Links27] ON [dbo].[blog_Links]([PostID], [CategoryID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_SkinControl_Config_ContorlID] ON [dbo].[blog_SkinControl_Config]([ControlID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

 CREATE  INDEX [IX_blog_SkinControl_Config_BlogID] ON [dbo].[blog_SkinControl_Config]([BlogID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

ALTER TABLE [dbo].[blog_URLs] ADD 
	CONSTRAINT [IX_blog_URLs] UNIQUE  NONCLUSTERED 
	(
		[URL]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.Log_View
AS
SELECT TOP 100 PERCENT *
FROM dbo.blog_Log
ORDER BY LogID DESC



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.SiteCatalog
AS
SELECT *
FROM dbo.blog_LinkCategories
WHERE (CategoryType = 6)



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.VIEW_ScheduleEvents
AS
SELECT TOP 100 PERCENT *
FROM dbo.blog_ScheduledEvents
ORDER BY ScheduleID DESC



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.blog_Content_View
AS
SELECT TOP 100 *
FROM dbo.blog_Content
ORDER BY ID DESC



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO






CREATE Proc Blog_GetRecentCommentPosts  -- 'localhost', 1
(
	@Author nvarchar(100)=null
)
as
if (@Author is null )
begin
SELECT Top 50 Host, Application,ID,blog_Content.Title, blog_Content.DateAdded as DateCreated, 
blog_Content.SourceUrl, blog_Content.TitleUrl,blog_Content.PostType, blog_Content.Author, blog_Content.[Text] as Body 

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID

where PostType=8 and parentid in (select ID from blog_Content where  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and  blog_Config.IsActive = 1)
order by DateAdded desc
end
else
begin
SELECT Top 50 Host, Application,ID,blog_Content.Title, blog_Content.DateAdded as DateCreated, 
blog_Content.SourceUrl, blog_Content.TitleUrl,blog_Content.PostType, blog_Content.Author, blog_Content.[Text] as Body 

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID

where PostType=8 and blog_Content.Author =@Author and parentid in (select ID from blog_Content where  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and  blog_Config.IsActive = 1) 
order by DateAdded desc
end




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE Proc Blog_GetTopCommentPosts  -- 'localhost', 1
as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, (vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content with(nolock)
inner join blog_Config with(nolock)on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc with(nolock) ON (blog_Content.[ID] = vc.EntryID)
where blog_Content.PostConfig & 64 = 64 and  blog_Config.IsAggregated = 1
order by FeedBackCount desc





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE Proc Blog_GetTopCommentPostsByDay  -- 'localhost', 1
as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
,(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content with(nolock)
inner join blog_Config with(nolock) on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc with(nolock) ON (blog_Content.[ID] = vc.EntryID)
Where Year(DateAdded)=Year(GetDate()) and Month(DateAdded)=Month(GetDate()) and Day(DateAdded)=Day(GetDate()) and blog_Content.PostType = 1 and blog_Content.PostConfig & 64 = 64 and  blog_Config.IsAggregated = 1
order by FeedBackCount desc



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE Proc Blog_GetTopCommentPostsByMonth  -- 'localhost', 1
as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
,(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content with(nolock)
inner join blog_Config with(nolock) on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc with(nolock) ON (blog_Content.[ID] = vc.EntryID)
Where Year(DateAdded)=Year(GetDate()) and Month(DateAdded)=Month(GetDate()) and blog_Content.PostConfig & 64 = 64 and blog_Config.IsAggregated = 1
order by FeedBackCount desc





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE Proc Blog_GetTopPosts  -- 'localhost', 1
as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, 
blog_Content.DateAdded, blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
,(vc.WebCount+vc.AggCount) as ViewCount
FROM blog_Content with(nolock)
inner join blog_Config with(nolock) on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc with(nolock) ON (blog_Content.[ID] = vc.EntryID)
where blog_Content.PostConfig & 64 = 64 and  blog_Config.IsAggregated = 1
order by ViewCount desc





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE Proc Blog_GetTopPostsByDay  -- 'localhost', 1
as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
,(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content with(nolock)
inner join blog_Config with(nolock) on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc with(nolock) ON (blog_Content.[ID] = vc.EntryID)
Where Year(DateAdded)=Year(GetDate()) and Month(DateAdded)=Month(GetDate()) and Day(DateAdded)=Day(GetDate())
and blog_Content.PostConfig & 64 = 64 and  blog_Config.IsAggregated = 1 and blog_Content.PostType = 1
order by ViewCount desc





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE Proc Blog_GetTopPostsByMonth  -- 'localhost', 1
as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
,(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content with(nolock)
inner join blog_Config with(nolock) on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  with(nolock) ON (blog_Content.[ID] = vc.EntryID)
Where Year(DateAdded)=Year(GetDate()) and Month(DateAdded)=Month(GetDate())
and blog_Content.PostConfig & 64 = 64 and blog_Config.IsAggregated = 1
order by ViewCount desc





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE    Proc Blog_SearchPosts  -- 'localhost', 1
	@SearchKey nvarchar(200)

as
SELECT  Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, 
blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 
1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [
Description]
FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
WHERE blog_Content.Title like "%"+@SearchKey+"%" or blog_Content.Text like "%"+@SearchKey+"%"
order by [ID] desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO













CREATE   Proc blog_CategoriesWithLinks
(
	@blogID int,
	@IsActive bit
)
as
SELECT 
	blc.CategoryID, blc.Title, blc.Active, blc.CategoryType, blc.[Description]
FROM 
	blog_LinkCategories blc
WHERE 
	blc.Active <> Case @IsActive When 1 then 0 Else -1 End and blc.BLOGID = @BlogID 
	and blc.CategoryType = 0
ORDER BY 
	blc.Title

SELECT 
	bl.LinkID, bl.Title, bl.Url, bl.Rss, bl.Active, bl.NewWindow, bl.CategoryID,  bl.PostID ,bl.UpdateTime 
FROM 
	blog_Links bl 
	INNER JOIN blog_LinkCategories blc ON bl.CategoryID = blc.CategoryID
WHERE 
	bl.Active <> Case @IsActive When 1 then 0 Else -1 End AND 
	blc.Active <> Case @IsActive When 1 then 0 Else -1 End
	and blc.BLOGID = @BlogID and  bl.BLOGID = @BlogID and blc.CategoryType = 0
ORDER BY 
	bl.Title


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Proc blog_DeleteBlogger
(
	@BlogID int
)
as
Begin

	Delete From blog_Content Where BlogID = @BlogID
	Delete From blog_Links where BlogID = @BlogID
	Delete blog_LinkCategories From blog_LinkCategories where BlogID = @BlogID
	Delete From blog_EntryViewCount where BlogID = @BlogID
	Delete From blog_Referrals where BlogID = @BlogID
	Delete From blog_Images where BlogID = @BlogID
	Delete From blog_KeyWords where BlogID = @BlogID
	Delete From blog_Config where BlogID=@BlogID
	Delete From blog_Profile where BlogID=@BlogID
	Delete From blog_Comment_Audit where BlogID=@BlogID
	Delete From blog_EntryRate where BlogID=@BlogID
	Delete From blog_SkinControl_Config where BlogID=@BlogID 
	Delete From blog_UsersInRoles where UserID=@BlogID 
	
End





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO







CREATE   Proc blog_DeleteCategory
(
	@CategoryID int,
	@BlogID int
)
as
Delete blog_Links From blog_Links Where blog_Links.CategoryID = @CategoryID and blog_Links.BlogID = @BlogID
Delete blog_Images From blog_Images Where blog_Images.CategoryID = @CategoryID and blog_Images.BlogID = @BlogID
Delete blog_LinkCategories From blog_LinkCategories Where blog_LinkCategories.CategoryID = @CategoryID and blog_LinkCategories.BlogID = @BlogID


SET QUOTED_IDENTIFIER OFF 






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












Create Proc blog_DeleteImage
(
	@BlogID int,
	@ImageID int
)
as
Delete blog_Images From blog_Images 
Where ImageID = @ImageID and BlogID = @BlogID












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO








Create Proc blog_DeleteKeyWord
(
	@KeyWordID int,
	@BlogID int
)

as

Delete From blog_KeyWords where BLOGID = @BlogID and KeyWordID = @KeyWordID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












CREATE Proc blog_DeleteLink
(
	@LinkID int,
	@BlogID int
)
as
Delete blog_Links From blog_Links Where blog_Links.[LinkID] = @LinkID




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












Create Proc blog_DeleteLinksByPostID
(
	@PostID int,
	@BlogID int
)
as
Set NoCount On
Delete blog_Links From blog_Links where PostID = @PostID and BlogID = @BlogID












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO














CREATE Proc blog_DeletePost
(
	@ID int,
	@BlogID int
)
as

Declare @ParentID int, @PostType int

Insert blog_Content_Audit ([ID], [Title], [DateAdded], [SourceUrl], [PostType], [Author], [Email], [SourceName], [BlogID], [Description], [DateUpdated], [TitleUrl], [Text], [ParentID], [FeedBackCount], [PostConfig], [EntryName], [IsOriginal])
Select [ID], [Title], [DateAdded], [SourceUrl], [PostType], [Author], [Email], [SourceName], [BlogID], [Description], [DateUpdated], [TitleUrl], [Text], [ParentID], [FeedBackCount], [PostConfig], [EntryName], [IsOriginal] FROM blog_Content
Where [ID] = @ID

Select @ParentID = ParentID, @PostType = PostType From blog_Content where [ID] = @ID


if(@PostType = 8 or @PostType = 4)
Begin
	Update blog_Content
	Set FeedBackCount = FeedBackCount - 1
	where [ID] = @ParentID
	
	Delete From blog_Comment_Audit where EntryID = @ID

End
Else
Begin

	Delete from blog_MailNotify where EntryID=@ID 
	Delete From blog_Comment_Audit where EntryID in (Select [ID] From blog_Content Where ParentID = @ID)
	Delete From blog_Content Where ParentID = @ID
	Delete From blog_Links where PostID = @ID
	Delete From blog_EntryViewCount where EntryID = @ID
	Delete From blog_Referrals where EntryID = @ID
End

Delete From blog_Content Where blog_Content.[ID] = @ID and blog_Content.BlogID = @BlogID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE Proc blog_Export
(
	@BlogID nvarchar(50)
)
as

Select * from blog_Config Where BlogID = @BlogID FOR XML AUTO, XMLDATA,ELEMENTS


Select * from blog_Content where BlogID = @BlogID FOR XML AUTO, XMLDATA,ELEMENTS


Select * from blog_EntryViewCount where EntryID in (Select ID from blog_Content where BlogID=@BlogID) FOR XML AUTO, XMLDATA,ELEMENTS


Select * from blog_Images where BlogID = @BlogID FOR XML AUTO, XMLDATA,ELEMENTS


Select * from blog_KeyWords where BlogID = @BlogID FOR XML AUTO, XMLDATA,ELEMENTS


Select * from blog_LinkCategories where BlogID = @BlogID FOR XML AUTO, XMLDATA,ELEMENTS


Select * from blog_Links where CategoryID in (Select CategoryID from blog_LinkCategories where BlogID = @BlogID) FOR XML AUTO, XMLDATA,ELEMENTS


Select * from blog_Referrals where BlogID = @BlogID FOR XML AUTO, XMLDATA,ELEMENTS


Select * from blog_URLs where UrlID in (Select UrlID from blog_Referrals where BlogID = @BlogID) FOR XML AUTO, XMLDATA,ELEMENTS


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROC blog_GenericGetEntriesCount_10
(
	@ItemCount int, 
	@PostType int,
	@PostConfig int,
	@BlogID int,
	@CategoryID int = null,
	@CategoryName nvarchar(100) = null,
	@StartDate datetime = null,
	@StopDate datetime = null,
	@CategoryType int = null,
	@BlogGroupID int=null,
	@Author nvarchar(100) = null
)
as

/*
	Generic Entry Collection Proc With Categories

	All possible combinations will be filter by PostTye, PostConfig, and BlogID

	# of records will be controlled rowcount

	Order of precidence:
		CategoryID
		CategoryName
		StartDate
		Default
*/

set rowcount @ItemCount
--用户组
if(@BlogGroupID is not null)
Begin
	if(@StartDate is not null and @StopDate is null)
		begin
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			count(bc.[ID]) as Count
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock)  on bc.ID = bl.PostID
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bc.BlogID in (Select UserID from blog_UsersInRoles where RoleID=@BlogGroupID)
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
			and bl.CategoryID =808
		
		end
	else
		begin
	SELECT 
			count(bc.[ID]) as Count
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bc.BlogID in (Select UserID from blog_UsersInRoles where RoleID=@BlogGroupID)
			and bl.CategoryID =808
		
		end
		return
End
--精华区
if(@CategoryType is not null)
Begin
	if(@StartDate is not null and @StopDate is null)
		begin
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			count(bc.[ID]) as Count
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID and bl.UpdateTime >= @StartDate and bl.UpdateTime <= @StopDate
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID
		WHERE 
			bc.PostType | @PostType = @PostType
			and bl.CategoryID in(Select CategoryID from blog_LinkCategories where CategoryType=@CategoryType )
			--and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		
		end
	else
		begin 
	SELECT 
			count(bc.[ID]) as Count
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
		WHERE 
			bc.PostType | @PostType = @PostType
			and bl.CategoryID in(Select CategoryID from blog_LinkCategories where CategoryType=@CategoryType)
		
		end
		
		return
End


if(@BlogID is not null)
Begin
--Do we have a CategoryID?
if(@CategoryID is not null)
Begin
	--we will filter by categoryID. Should we also filter by date?
	if(@StartDate is null)
	Begin
		-- No Date Filter
		SELECT 
			count(bc.[ID]) as Count
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
		WHERE 
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
		
	End
	Else
	Begin
		--Filter by CategoryID and Date. 

		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		-- No Date Filter
		SELECT 
			count(bc.[ID]) as Count
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
		WHERE 
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		
	End
End
-- Do we have a CategoryName? (CategoryID will override this value)
else if(@CategoryName is not null)
Begin
	--We will filter by categryName (Title)
	--Should we also filter by Date?
	if(@StartDate is null)
	Begin
		-- Filter by CategoryName and not Date
		SELECT 
			count(bc.[ID]) as Count 
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID

		WHERE 
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
		
	End
	Else
	Begin
		--Filter by CategoryName (Title) and Date

		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			count(bc.[ID]) as Count
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID
		WHERE 
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		
	End
End
else if(@StartDate is not null)
Begin
	--No categoryID or Category was found. We will ONLY filter by dates

	--If we only have a start date and no stop date, add 24 hours to to stopdate
	if(@StartDate is not null and @StopDate is null)
	Set @StopDate = DateAdd(day,1,@StartDate)

	SELECT 
		count(bc.[ID]) as Count
	FROM 
		blog_Content bc with(nolock)
	WHERE 
		bc.BlogID = @BlogID
		and bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
		and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
	

End
Else
Begin
	--All else has failed :)
	--We will just select the last x number of items
	SELECT 
		count(bc.[ID]) as Count
	FROM 
		blog_Content bc with(nolock)
	WHERE 
		bc.BlogID = @BlogID
		and bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType

End
End
Else
--BlogID is Null
Begin
--Do we have a CategoryID?
if(@CategoryID is not null)
Begin
	--we will filter by categoryID. Should we also filter by date?
	if(@StartDate is null)
	Begin
		-- No Date Filter
		SELECT 
			count(bc.[ID]) as Count
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
		
	End
	Else
	Begin
		--Filter by CategoryID and Date. 

		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		-- No Date Filter
		SELECT 
			count(bc.[ID]) as Count
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		
	End
End
-- Do we have a CategoryName? (CategoryID will override this value)
else if(@CategoryName is not null)
Begin
	--We will filter by categryName (Title)
	--Should we also filter by Date?
	if(@StartDate is null)
	Begin
		-- Filter by CategoryName and not Date
		SELECT 
			count(bc.[ID]) as Count 
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID
			INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
		
	End
	Else
	Begin
		--Filter by CategoryName (Title) and Date

		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			count(bc.[ID]) as Count
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID
			INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		
	End
End
else if(@StartDate is not null)
Begin
	--No categoryID or Category was found. We will ONLY filter by dates

	--If we only have a start date and no stop date, add 24 hours to to stopdate
	if(@StartDate is not null and @StopDate is null)
	Set @StopDate = DateAdd(day,1,@StartDate)
	IF (@PostType = 8)
	Begin
	SELECT 
		count(bc.[ID]) as Count
	FROM 
		blog_Content bc with(nolock)
		INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
		and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		and bc.ParentID in (Select blog_Content.ID from blog_Content where blog_Content.ID=bc.ParentID and blog_Content.PostConfig=93)
	End
	Else
	Begin
	SELECT 
		count(bc.[ID]) as Count
	FROM 
		blog_Content bc with(nolock)
		INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
		and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
	End
		
	

End
Else
Begin
	--All else has failed :)
	--We will just select the last x number of items
	IF (@PostType = 8)
	Begin
	SELECT 
		count(bc.[ID]) as Count
	FROM 
		blog_Content bc with(nolock)
		INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType 
		and bc.ParentID in (Select blog_Content.ID from blog_Content where blog_Content.ID=bc.ParentID and blog_Content.PostConfig=93)
		--and blog_Content.[ID] not in(select blog_Links.PostID from blog_Links  where blog_Links.PostID=bc.ParentID and blog_Links.CategoryID=807))
	
	End
	Else
	Begin 
	SELECT 
		count(bc.[ID]) as Count
	FROM 
		blog_Content bc with(nolock)
		INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
	
	End
End
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO







CREATE PROC blog_GenericGetEntriesWithCategories_10
(
	@ItemCount int, 
	@PostType int,
	@PostConfig int,
	@BlogID int,
	@CategoryID int = null,
	@CategoryName nvarchar(100) = null,
	@StartDate datetime = null,
	@StopDate datetime = null,
	@CategoryType int = null,
	@BlogGroupID int=null,
	@Author nvarchar(100) = null
)
as

/*
	Generic Entry Collection Proc With Categories

	All possible combinations will be filter by PostTye, PostConfig, and BlogID

	# of records will be controlled rowcount

	Order of precidence:
		CategoryID
		CategoryName
		StartDate
		Default
*/

SET NOCOUNT ON
set rowcount @ItemCount

Create Table #IDs
(
	TempID int IDENTITY (0, 1) NOT NULL,
	EntryID int not null
)

Insert #IDs (EntryID)
exec blog_GenericGetEntryIDs_10 @ItemCount, @PostType, @PostConfig, @BlogID, @CategoryID, @CategoryName, @StartDate, @StopDate

SELECT 
	bc.BlogID, bc.[ID], bc.Title, 
	bc.DateAdded, bc.[Text], bc.[Description],
	bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
	bc.SourceName, bc.DateUpdated, bc.TitleUrl,
	bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
	bc.EntryName 
FROM 
	blog_Content bc with(nolock)
	inner join #IDs on bc.[ID] = #IDs.EntryID
Order by TempID 

Set rowcount 0
Select c.Title, l.PostID From blog_Links l
inner join #IDs on l.[PostID] = #IDs.[EntryID]
inner join blog_LinkCategories c on l.CategoryID = c.CategoryID

DROP Table #IDs


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROC blog_GenericGetEntries_10
(
	@ItemCount int, 
	@PostType int,
	@PostConfig int,
	@BlogID int=null,
	@CategoryID int = null,
	@CategoryName nvarchar(100) = null,
	@StartDate datetime = null,
	@StopDate datetime = null,
	@CategoryType int = null,
	@BlogGroupID int=null,
	@Author nvarchar(100) = null
)
as

/*
	Generic Entry Collection Proc

	All possible combinations will be filter by PostTye, PostConfig, and BlogID

	# of records will be controlled rowcount

	Order of precidence:
		CategoryID
		CategoryName
		StartDate
		Default
*/
SET NOCOUNT ON
set rowcount @ItemCount

--按作者名查询
if(@Author is not null)
begin
	SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,bcc.Application,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc with(nolock)
			inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
			bc.PostType | @PostType = @PostType
			and bc.Author=@Author
		ORDER BY 
			bc.[dateadded] desc
	return
end

if(@BlogGroupID is not null)
Begin
	if(@StartDate is not null and @StopDate is null)
		begin
		Set @StopDate = DateAdd(day,1,@StartDate)
		SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,bcc.Application,vc.WebCount,vc.AggCount
		FROM 
			blog_Content bc  with(nolock) 
			inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
			and bc.BlogID in (Select BlogID from blog_UsersInGroups where GroupID=@BlogGroupID)
			and bl.CategoryID =808
		ORDER BY 
			bc.[dateadded] desc
	
		end
	else
		begin
			SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,bcc.Application,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc  with(nolock)
			inner join blog_Config bcc  with(nolock) on bc.BlogID = bcc.BlogID
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bc.BlogID in (Select BlogID from blog_UsersInGroups where GroupID=@BlogGroupID)
			and bl.CategoryID =808
		ORDER BY 
			bc.[dateadded] desc
		end
return 
End

if(@CategoryType is not null)
Begin
	if(@StartDate is not null and @StopDate is null)
		begin
		Set @StopDate = DateAdd(day,1,@StartDate)
		SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,bcc.Application,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc with(nolock) 
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
			bc.PostType | @PostType = @PostType
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
			and bl.CategoryID in(Select CategoryID from blog_LinkCategories where CategoryType=@CategoryType)
		ORDER BY 
			bc.[dateadded] desc
		end
	else
		begin
		SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,bcc.Application,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc with(nolock) 
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
			bc.PostType | @PostType = @PostType
			and bl.CategoryID in(Select CategoryID from blog_LinkCategories where CategoryType=@CategoryType)
		ORDER BY 
			bc.[dateadded] desc
		end	
		return
End

if(@BlogID is not null)
Begin
--Do we have a CategoryID?
if(@CategoryID is not null)
Begin
	--we will filter by categoryID. Should we also filter by date?
	if(@StartDate is null)
	Begin
		-- No Date Filter
		SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		
		WHERE 
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
		ORDER BY 
			bc.[dateadded] desc
	End
	Else
	Begin
		--Filter by CategoryID and Date. 

		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc  with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		ORDER BY 
			bc.[dateadded] desc
	End
End
-- Do we have a CategoryName? (CategoryID will override this value)
else if(@CategoryName is not null)
Begin
	--We will filter by categryName (Title)
	--Should we also filter by Date?
	if(@StartDate is null)
	Begin
		-- Filter by CategoryName and not Date
		SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc with(nolock) 
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock)  on bl.CategoryID = bcat.CategoryID
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
		ORDER BY 
			bc.[dateadded] desc
	End
	Else
	Begin
		--Filter by CategoryName (Title) and Date

		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock)  on bl.CategoryID = bcat.CategoryID
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
		
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		ORDER BY 
			bc.[dateadded] desc
	End
End

else if(@StartDate is not null)
Begin
	--No categoryID or Category was found. We will ONLY filter by dates

	--If we only have a start date and no stop date, add 24 hours to to stopdate
	if(@StartDate is not null and @StopDate is null)
	Set @StopDate = DateAdd(day,1,@StartDate)

	SELECT 
		bc.BlogID, bc.[ID], bc.Title, 
		bc.DateAdded, bc.[Text], bc.[Description],
		bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
		bc.SourceName, bc.DateUpdated, bc.TitleUrl,
		bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
		bc.EntryName,vc.WebCount,vc.AggCount 
	FROM 
		blog_Content bc with(nolock)
		Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
	WHERE
		bc.BlogID = @BlogID 
		and bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
		and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate		
	ORDER BY 
		bc.[dateadded] desc

End
Else
Begin
	--All else has failed :)
	--We will just select the last x number of items
	SELECT 
		bc.BlogID, bc.[ID], bc.Title, 
		bc.DateAdded, bc.[Text], bc.[Description],
		bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
		bc.SourceName, bc.DateUpdated, bc.TitleUrl,
		bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
		bc.EntryName,vc.WebCount,vc.AggCount
	FROM 
		blog_Content bc with(nolock)
		Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
	WHERE 
		bc.BlogID = @BlogID
		and bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
	ORDER BY 
		bc.[dateadded] desc
End
End
--BlogID is null
Else
Begin
	if(@CategoryID is not null)
	Begin
	--we will filter by categoryID. Should we also filter by date?
	if(@StartDate is null)
	Begin
		-- No Date Filter
		SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,bcc.Application,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc  with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
		ORDER BY 
			bc.[dateadded] desc
	End
	Else
	Begin
		--Filter by CategoryID and Date. 

		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,bcc.Application,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		ORDER BY 
			bc.[dateadded] desc
	End
End
-- Do we have a CategoryName? (CategoryID will override this value)
else if(@CategoryName is not null)
Begin
	--We will filter by categryName (Title)
	--Should we also filter by Date?
	if(@StartDate is null)
	Begin
		-- Filter by CategoryName and not Date
		SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,bcc.Application,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID
			inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
		ORDER BY 
			bc.[dateadded] desc
	End
	Else
	Begin
		--Filter by CategoryName (Title) and Date


		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			bc.BlogID, bc.[ID], bc.Title, 
			bc.DateAdded, bc.[Text], bc.[Description],
			bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
			bc.SourceName, bc.DateUpdated, bc.TitleUrl,
			bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
			bc.EntryName,bcc.Application,vc.WebCount,vc.AggCount 
		FROM 
			blog_Content bc  
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID
			inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1
			Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
		WHERE 
		
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		ORDER BY 
			bc.[dateadded] desc
	End
End
else if(@StartDate is not null)
Begin
	--No categoryID or Category was found. We will ONLY filter by dates

	--If we only have a start date and no stop date, add 24 hours to to stopdate
	if(@StartDate is not null and @StopDate is null)
	Set @StopDate = DateAdd(day,1,@StartDate)

	SELECT 
		bc.BlogID, bc.[ID], bc.Title, 
		bc.DateAdded, bc.[Text], bc.[Description],
		bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
		bc.SourceName, bc.DateUpdated, bc.TitleUrl,
		bc.FeedBackCount, bc.ParentID, bc.PostConfig, 
		bc.EntryName ,bcc.Application,vc.WebCount,vc.AggCount
	FROM 
		blog_Content bc with(nolock)
		inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1
		Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
		and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
	ORDER BY 
		bc.[dateadded] desc

End
Else
Begin
	--All else has failed :)
	--We will just select the last x number of items
	IF (@PostType = 8)
	Begin
	SELECT 
		bc.BlogID, bc.[ID], bc.Title, 
		bc.DateAdded, bc.[Text], bc.[Description],
		bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
		bc.SourceName, bc.DateUpdated, bc.TitleUrl,
		bc.FeedBackCount, bc.ParentID, bc.PostConfig,bcc.Application, 
		bc.EntryName,vc.WebCount,vc.AggCount 
	FROM 
		blog_Content bc with(nolock)
		inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1
		Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
		and bc.ParentID in (Select blog_Content.ID from blog_Content where blog_Content.ID=bc.ParentID and blog_Content.PostConfig=93)
		--and blog_Content.[ID] not in(select blog_Links.PostID from blog_Links  where blog_Links.PostID=bc.ParentID and blog_Links.CategoryID=807))
	ORDER BY 
		bc.[dateadded] desc
	End
	Else
	Begin 
	SELECT 
		bc.BlogID, bc.[ID], bc.Title, 
		bc.DateAdded, bc.[Text], bc.[Description],
		bc.SourceUrl, bc.PostType, bc.Author, bc.Email, 
		bc.SourceName, bc.DateUpdated, bc.TitleUrl,
		bc.FeedBackCount, bc.ParentID, bc.PostConfig,bcc.Application, 
		bc.EntryName,vc.WebCount,vc.AggCount 
	FROM 
		blog_Content bc with(nolock)
		inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1
		Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
	ORDER BY 
		bc.[dateadded] desc
	End
End
	
	End


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROC blog_GenericGetEntryIDs_10
(
	@ItemCount int, 
	@PostType int,
	@PostConfig int,
	@BlogID int,
	@CategoryID int = null,
	@CategoryName nvarchar(100) = null,
	@StartDate datetime = null,
	@StopDate datetime = null,
	@CategoryType int = null,
	@BlogGroupID int=null,
	@Author nvarchar(100) = null
)
as

/*
	Generic Entry Collection Proc With Categories

	All possible combinations will be filter by PostTye, PostConfig, and BlogID

	# of records will be controlled rowcount

	Order of precidence:
		CategoryID
		CategoryName
		StartDate
		Default
*/
SET NOCOUNT ON
set rowcount @ItemCount
--按作者名查询
if(@Author is not null)
begin
	SELECT 
			bc.[ID]
		FROM 
			blog_Content bc with(nolock)
		WHERE 
			bc.PostType | @PostType = @PostType
			and bc.Author = @Author
		ORDER BY 
			bc.[dateadded] desc
	return
end
--用户组
if(@BlogGroupID is not null)
Begin
if(@BlogGroupID = 1000)
Begin
	SELECT 
		bc.[ID]
	FROM 
		blog_Content bc with(nolock)
	INNER Join blog_Comment_Audit bca on bc.ID=bca.EntryID 
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
		and bca.OwnerBlogID=@BlogID
	ORDER BY 
		bc.[dateadded] desc
	return
End
else if(@BlogGroupID = 2000)--查询订阅的文章
Begin
	SELECT 
		bc.[ID]
	FROM 
		blog_Content bc
	INNER Join blog_MailNotify bmn on bc.ID=bmn.EntryID and bc.BlogID=bmn.BlogID
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
		and bmn.SendToBlogID=@BlogID
	ORDER BY 
		bc.[dateadded] desc
	return
End
else
Begin
	if(@StartDate is not null and @StopDate is null)
		begin
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			bc.[ID]
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
		WHERE 
			bc.PostType | @PostType = @PostType
			and bc.BlogID in (Select BlogID from blog_UsersInGroups where GroupID=@BlogGroupID)
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
			and bl.CategoryID =808
		ORDER BY 
			bc.[dateadded] desc
		end
	else
		begin
	SELECT 
			bc.[ID]
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bc.BlogID in (Select BlogID from blog_UsersInGroups where GroupID=@BlogGroupID)
			and bl.CategoryID =808
		ORDER BY 
			bc.[dateadded] desc
		end
		return
End
End
--精华区
if(@CategoryType is not null)
Begin
	if(@StartDate is not null and @StopDate is null)
		begin
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			bc.[ID]
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID
		WHERE 
			bc.PostType | @PostType = @PostType
			and bl.CategoryID in(Select CategoryID from blog_LinkCategories where CategoryType=@CategoryType)
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		ORDER BY 
			bc.[dateadded] desc
		end
	else
		begin 
	SELECT 
			bc.[ID]
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
		WHERE 
			bc.PostType | @PostType = @PostType
			and bl.CategoryID in(Select CategoryID from blog_LinkCategories where CategoryType=@CategoryType)
		ORDER BY 
			bc.[dateadded] desc
		end
		
		return
End


if(@BlogID is not null)
Begin
--Do we have a CategoryID?
if(@CategoryID is not null)
Begin
	--we will filter by categoryID. Should we also filter by date?
	if(@StartDate is null)
	Begin
		-- No Date Filter
		SELECT 
			bc.[ID]
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
		WHERE 
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
		ORDER BY 
			bc.[dateadded] desc
	End
	Else
	Begin
		--Filter by CategoryID and Date. 

		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		-- No Date Filter
		SELECT 
			bc.[ID]
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
		WHERE 
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		ORDER BY 
			bc.[dateadded] desc
	End
End
-- Do we have a CategoryName? (CategoryID will override this value)
else if(@CategoryName is not null)
Begin
	--We will filter by categryName (Title)
	--Should we also filter by Date?
	if(@StartDate is null)
	Begin
		-- Filter by CategoryName and not Date
		SELECT 
			bc.[ID] 
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID

		WHERE 
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
		ORDER BY 
			bc.[dateadded] desc
	End
	Else
	Begin
		--Filter by CategoryName (Title) and Date

		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			bc.[ID]
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID
		WHERE 
			bc.BlogID = @BlogID
			and bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		ORDER BY 
			bc.[dateadded] desc
	End
End
else if(@StartDate is not null)
Begin
	--No categoryID or Category was found. We will ONLY filter by dates

	--If we only have a start date and no stop date, add 24 hours to to stopdate
	if(@StartDate is not null and @StopDate is null)
	Set @StopDate = DateAdd(day,1,@StartDate)

	SELECT 
		bc.[ID]
	FROM 
		blog_Content bc with(nolock)
	WHERE 
		bc.BlogID = @BlogID
		and bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
		and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
	ORDER BY 
		bc.[dateadded] desc

End
Else
Begin
	--All else has failed :)
	--We will just select the last x number of items
	SELECT 
		bc.[ID]
	FROM 
		blog_Content bc with(nolock)
	WHERE 
		bc.BlogID = @BlogID
		and bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
	ORDER BY 
		bc.[dateadded] desc
End
End
Else
--BlogID is Null
Begin
--Do we have a CategoryID?
if(@CategoryID is not null)
Begin
	--we will filter by categoryID. Should we also filter by date?
	if(@StartDate is null)
	Begin
		-- No Date Filter
		SELECT 
			bc.[ID]
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
		ORDER BY 
			bc.[dateadded] desc
	End
	Else
	Begin
		--Filter by CategoryID and Date. 

		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		-- No Date Filter
		SELECT 
			bc.[ID]
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bl.CategoryID = @CategoryID
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		ORDER BY 
			bc.[dateadded] desc
	End
End
-- Do we have a CategoryName? (CategoryID will override this value)
else if(@CategoryName is not null)
Begin
	--We will filter by categryName (Title)
	--Should we also filter by Date?
	if(@StartDate is null)
	Begin
		-- Filter by CategoryName and not Date
		SELECT 
			bc.[ID] 
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID
			INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
		ORDER BY 
			bc.[dateadded] desc
	End
	Else
	Begin
		--Filter by CategoryName (Title) and Date

		--If we only have a start date and no stop date, add 24 hours to to stopdate
		if(@StartDate is not null and @StopDate is null)
		Set @StopDate = DateAdd(day,1,@StartDate)
		
		SELECT 
			bc.[ID]
		FROM 
			blog_Content bc with(nolock)
			INNER JOIN blog_Links bl with(nolock) on bc.ID = bl.PostID
			INNER JOIN blog_LinkCategories bcat with(nolock) on bl.CategoryID = bcat.CategoryID
			INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
		WHERE 
			bc.PostConfig & @PostConfig = @PostConfig 
			and bc.PostType | @PostType = @PostType
			and bcat.Title = @CategoryName
			and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		ORDER BY 
			bc.[dateadded] desc
	End
End
else if(@StartDate is not null)
Begin
	--No categoryID or Category was found. We will ONLY filter by dates

	--If we only have a start date and no stop date, add 24 hours to to stopdate
	if(@StartDate is not null and @StopDate is null)
	Set @StopDate = DateAdd(day,1,@StartDate)

	SELECT 
		bc.[ID]
	FROM 
		blog_Content bc with(nolock)
		INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
		and bc.DateAdded >= @StartDate and bc.DateAdded <= @StopDate
		
	ORDER BY 
		bc.[dateadded] desc

End
Else
Begin
	--All else has failed :)
	--We will just select the last x number of items
	IF (@PostType = 8)
	Begin
	SELECT 
		bc.[ID]
	FROM 
		blog_Content bc with(nolock)
		INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType 
		and bc.ParentID in (Select blog_Content.ID from blog_Content where blog_Content.ID=bc.ParentID and blog_Content.PostConfig=93)
		--and blog_Content.[ID] not in(select blog_Links.PostID from blog_Links  where blog_Links.PostID=bc.ParentID and blog_Links.CategoryID=807))
	ORDER BY 
		bc.[dateadded] desc
	End
	Else
	Begin 
	SELECT 
		bc.[ID]
	FROM 
		blog_Content bc with(nolock)
		INNER JOIN blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID and bcc.IsAggregated = 1 
	WHERE 
		bc.PostConfig & @PostConfig = @PostConfig 
		and bc.PostType | @PostType = @PostType
	ORDER BY 
		bc.[dateadded] desc
	End
End
End

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO








CREATE PROC blog_GenericGetPagedEntries_10
(
	@ItemCount int,
	@PostType int,
	@PostConfig int,
	@BlogID int,
	@PageIndex int,
	@PageSize int,
	@CategoryID int = null,
	@CategoryName nvarchar(100) = null,
	@StartDate datetime = null,
	@StopDate datetime = null,
	@CategoryType int = null,
	@BlogGroupID int = null,
	@Author nvarchar(100) = null
)
as

/*
	Generic Entry Collection Proc With Categories

	All possible combinations will be filter by PostTye, PostConfig, and BlogID

	# of records will be controlled rowcount

	Order of precidence:
		CategoryID
		CategoryName
		StartDate
		Default
*/

DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
SET NOCOUNT ON
SET @PageLowerBound = @PageSize * @PageIndex - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

Create Table #IDs
(
	TempID int IDENTITY (1, 1) NOT NULL,
	EntryID int not null
)

Insert #IDs (EntryID)
exec blog_GenericGetEntryIDs_10 @ItemCount, @PostType, @PostConfig, @BlogID, @CategoryID, @CategoryName, @StartDate, @StopDate,@CategoryType,@BlogGroupID,@Author
if(@BlogID is  null)
Begin
SELECT	
	bc.BlogID, bc.[ID], bc.Title, bc.DateAdded, 
	bc.[Text], bc.[Description],bc.SourceUrl, bc.PostType, 
	bc.Author, bc.Email, bc.SourceName, bc.DateUpdated, 
	bc.TitleUrl, bc.FeedbackCount,	bc.ParentID,
	bc.PostConfig,	bc.EntryName,	vc.WebCount,
	vc.AggCount,	vc.WebLastUpdated,vc.AggLastUpdated,bcc.Application
		
FROM  	blog_content bc with(nolock)
    	INNER JOIN #IDS tmp ON (bc.[ID] = tmp.EntryID)
    	inner join blog_Config bcc with(nolock) on bc.BlogID = bcc.BlogID
    	Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
WHERE 	tmp.TempID > @PageLowerBound 
		AND tmp.TempID < @PageUpperBound
ORDER BY tmp.TempID
End
else
Begin
SELECT	
	bc.BlogID, bc.[ID], bc.Title, bc.DateAdded, 
	bc.[Text], bc.[Description],bc.SourceUrl, bc.PostType, 
	bc.Author, bc.Email, bc.SourceName, bc.DateUpdated, 
	bc.TitleUrl, bc.FeedbackCount,	bc.ParentID,
	bc.PostConfig,	bc.EntryName,	vc.WebCount,
	vc.AggCount, vc.WebLastUpdated,vc.AggLastUpdated
		
FROM  	blog_content bc with(nolock)
    	INNER JOIN #IDS tmp ON (bc.[ID] = tmp.EntryID)
  		Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID and vc.BlogID = @BlogID)
WHERE 	bc.BlogID = @BlogID 
		AND tmp.TempID > @PageLowerBound 
		AND tmp.TempID < @PageUpperBound
ORDER BY tmp.TempID
End 



SELECT COUNT(*) as TotalRecords
FROM 	#IDS 


DROP TABLE #IDS


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE Proc  blog_GetAggregatedBloggerListByRegisterTime
as
Select  BlogID
From blog_Config  with(nolock)
where   blog_Config.IsActive=1
order by RegisterTime desc
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE Proc  blog_GetAggregatedBloggers
(
	@ItemCount int=100,
	@GroupID int=-1
)
as
set rowcount @ItemCount
if(@GroupID > 0)
begin
select   bc.Author,bc.Application,bc.Host,bc.Title,PostCount, CommentCount, StoryCount, PingTrackCount, LastUpdated
from blog_Config bc 
where  bc.IsActive=1 and bc.BlogID in (select BlogID from blog_UsersInGroups where GroupID=@GroupID) 
order by PostCount DESC
end
else
begin
select  bc.Author,bc.Application,bc.Host,bc.Title,PostCount, CommentCount, StoryCount, PingTrackCount, LastUpdated
from blog_Config bc 
where  bc.IsActive=1
order by PostCount DESC
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO






CREATE Proc  blog_GetAggregatedBloggersByMonth
(
	@Host nvarchar(100)=null,
	@GroupID int=1
)
as
select sum(WebCount+AggCount+CommentCount*10) as ViewCount,bc.Author,bc.Application,bc.Host,bc.Title,PostCount, CommentCount, StoryCount, PingTrackCount, LastUpdated
from blog_EntryViewCount bev 
inner join blog_Config bc on bc.BlogID=bev.BlogID
where PostCount>1 and bc.IsActive=1 and (select DateAdded from blog_Content where blog_Content.ID=bev.EntryID)>DATEADD([Month], - 1, GETDATE())
group by bev.BlogID, bc.Author,bc.Application,bc.Host,bc.Title,PostCount, CommentCount, StoryCount, PingTrackCount, LastUpdated
order by ViewCount DESC




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE Proc blog_GetAggregatedBookPost  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int

as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	 and blog_Content.ID  in (Select PostID from blog_Links where CategoryID=5079)  and  blog_Config.IsActive = 1
order by blog_Content.DateAdded desc



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO





CREATE Proc blog_GetAggregatedBookPosts  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int

as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	 and blog_Content.ID  in (Select PostID from blog_Links where CategoryID=5079)  and  blog_Config.IsActive = 1
order by blog_Content.DateAdded desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO






CREATE Proc  blog_GetAggregatedCommentAuthors
as
Select top 200  Author, count(Author) as PostCount,max(DateAdded) as LastUpdated
From blog_Content
Where PostType=8
Group by Author
order by PostCount desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE Proc blog_GetAggregatedFAQPosts  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int

as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	and BlogGroup & @GroupID = @GroupID and blog_Content.ID  in (Select PostID from blog_Links where CategoryID=3969)  and  blog_Config.IsActive = 1
order by blog_Content.DateAdded desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE Proc blog_GetAggregatedJobPosts  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int

as
SELECT Top 80 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	 and blog_Content.ID  in (Select PostID from blog_Links where CategoryID=6151)  and  blog_Config.IsActive = 1
order by blog_Content.DateAdded desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE Proc blog_GetAggregatedNoTechPosts  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int

as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	 and blog_Content.ID  in (Select PostID from blog_Links where CategoryID=807)  and  blog_Config.IsActive = 1
order by blog_Content.DateAdded desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROC blog_GetAggregatedPagedBloggerList
(
	@PageIndex int,
	@PageSize int
)
as
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
SET NOCOUNT ON
SET @PageLowerBound = @PageSize * @PageIndex - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

Create Table #IDs
(
	TempID int IDENTITY (1, 1) NOT NULL,
	BlogID int not null
)

Insert #IDs (BlogID)
exec blog_GetAggregatedBloggerList

SELECT	
	 bc.Author, bc.Application, bc.Title,bc.SubTitle,bc.PostCount,bc.CommentCount,bc.StoryCount, bc.PingTrackCount, bc.LastUpdated
	
FROM  	
		blog_Config bc with(nolock)
    	INNER JOIN #IDS tmp ON (bc.[BlogID] = tmp.BlogID)
    	
WHERE 	tmp.TempID > @PageLowerBound 
		AND tmp.TempID < @PageUpperBound
ORDER BY tmp.TempID


SELECT COUNT(*) as TotalRecords
FROM 	#IDS 

DROP TABLE #IDS
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROC blog_GetAggregatedPagedBloggerListByRegisterTime
(
	@PageIndex int,
	@PageSize int
)
as
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
SET NOCOUNT ON
SET @PageLowerBound = @PageSize * @PageIndex - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

Create Table #IDs
(
	TempID int IDENTITY (1, 1) NOT NULL,
	BlogID int not null
)

Insert #IDs (BlogID)
exec blog_GetAggregatedBloggerListByRegisterTime

SELECT	
	 bc.Author, bc.Application, bc.Title,bc.SubTitle,bc.PostCount,bc.CommentCount,bc.StoryCount, bc.PingTrackCount, RegisterTime as LastUpdated
	
FROM  	
		blog_Config bc with(nolock)
    	INNER JOIN #IDS tmp ON (bc.[BlogID] = tmp.BlogID)
    	
WHERE 	tmp.TempID > @PageLowerBound 
		AND tmp.TempID < @PageUpperBound
ORDER BY tmp.TempID


SELECT COUNT(*) as TotalRecords
FROM 	#IDS 

DROP TABLE #IDS
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO






CREATE Proc blog_GetAggregatedPickedPosts  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int,
	@CategoryID int=null

as
if(@CategoryID is  null)
begin
SELECT Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	  and  blog_Config.IsActive = 1 and blog_Content.ID in (Select PostID from blog_Links where CategoryID in(Select CategoryID from blog_LinkCategories where CategoryType=7)) 
order by blog_Content.DateAdded desc
end
else
begin 
SELECT Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	 and  blog_Config.IsActive = 1 and blog_Content.ID in (Select PostID from blog_Links where CategoryID = @CategoryID) 
order by blog_Content.DateAdded desc
end




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Proc blog_GetAggregatedPosts  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int

as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount,(Select Title from blog_LinkCategories where CategoryID in(Select CategoryID from Blog_Links where Blog_Links.PostID=blog_Content.ID) and CategoryType=6) as CategoryTitle

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID 
Left outer JOIN  blog_EntryViewCount vc   ON (blog_Content.[ID] = vc.EntryID)  
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	  and  blog_Config.IsActive = 1
order by blog_Content.DateAdded desc
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE Proc blog_GetAggregatedPostsByCategory  -- 'localhost', 1
	@Host nvarchar(100)=null,
	@GroupID int=null,
	@ServerTimeZone int=null,
	@CategoryID int=null

as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	and BlogGroup & @GroupID = @GroupID and blog_Content.ID  in (Select PostID from blog_Links where CategoryID=@CategoryID)  and  blog_Config.IsActive = 1
order by blog_Content.DateAdded desc



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE      Proc blog_GetAggregatedPostsID  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int

as
SELECT blog_Content.[ID]
FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	and BlogGroup & @GroupID = @GroupID
order by DateAdd(hh,@ServerTimeZone - blog_Config.TimeZone,blog_Content.DateAdded) desc



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO





CREATE Proc blog_GetAggregatedProjectPosts  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int

as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	 and (blog_Content.ID  in (Select PostID from blog_Links where CategoryID=5719)  or blog_Config.username='ourgame')and  blog_Config.IsActive = 1
order by blog_Content.DateAdded desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE Proc blog_GetAggregatedQuotePosts  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int

as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	 and blog_Content.ID  in (Select PostID from blog_Links where CategoryID=4347)  and  blog_Config.IsActive = 1
order by blog_Content.DateAdded desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO










CREATE   Proc blog_GetAggregatedStats

as
Select Count(BlogID) as [BlogCount], Sum(PostCount) as PostCount,Sum(StoryCount) as StoryCount, Sum(PingTrackCount) as PingTrackCount,(Select Count(ID)  from blog_Content where PostType=8 )as CommentCount 
From blog_Config where blog_Config.Flag & 2 = 2 


SET QUOTED_IDENTIFIER ON
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE Proc blog_GetAggregatedTechPosts  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int

as
SELECT Top 35 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host
	 and blog_Content.ID  in (Select PostID from blog_Links where CategoryID=808)  and  blog_Config.IsActive = 1
order by blog_Content.DateAdded desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE        Proc  blog_GetAggregatedVIPBloggers
(
	@Host nvarchar(100),
	@GroupID int
)
as
select sum(WebCount+AggCount+CommentCount*10) as ViewCount,bc.Author,bc.Application,bc.Host,bc.Title,PostCount, CommentCount, StoryCount, PingTrackCount, LastUpdated
from blog_EntryViewCount bev 
inner join blog_Config bc on bc.BlogID=bev.BlogID
where PostCount>1 and bc.IsActive=1 and BlogGroup=2
group by bev.BlogID, bc.Author,bc.Application,bc.Host,bc.Title,PostCount, CommentCount, StoryCount, PingTrackCount, LastUpdated
order by ViewCount DESC




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE Proc blog_GetAggregatedVIPPosts  -- 'localhost', 1
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int

as
SELECT Top 40 Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [Description],
(vc.WebCount+vc.AggCount) as ViewCount

FROM blog_Content
inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE  blog_Content.PostType = 1 and blog_Config.Flag & 2 = 2 and blog_Config.Host = @Host and  blog_Content.PostConfig & 1 = 1
	and  blog_Config.BlogGroup=2 and  blog_Content.ID  in (Select PostID from blog_Links where CategoryID=808) and blog_Config.IsActive = 1
order by blog_Content.DateAdded desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO






CREATE            Proc blog_GetAllPostsByMonth -- 2,2003,0
(
	@Month int,
	@Year int
)
as
SELECT blog_Content.BlogID, blog_Content.[ID], blog_Content.Title, blog_Content.DateAdded, blog_Content.[Text], blog_Content.[Description],
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.SourceName, blog_Content.DateUpdated, blog_Content.TitleUrl,
blog_Content.FeedBackCount, blog_Content.ParentID, blog_Content.PostConfig,
blog_Content.EntryName FROM blog_Content
WHERE blog_Content.PostType=1  and blog_Content.PostConfig & 1 = 1 
	and Month(blog_Content.DateAdded)  = @Month and Year(blog_Content.DateAdded)  = @Year
ORDER BY blog_Content.DateAdded desc



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE PROCEDURE blog_GetBlogGroupByBlogID
(
	@BlogID int
)
AS
select GroupName from blog_Groups where GroupID in(select GroupID from Blog_UsersInGroups where BlogID=@BlogID)
	RETURN




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO















CREATE Proc blog_GetCategoriesByType
(
	@BlogID int=null,
	@IsActive bit=null,
	@CategoryType tinyint,
	@ParentID int=null
)
As
if(@ParentID is not null)
Begin 
SELECT blog_LinkCategories.CategoryID, blog_LinkCategories.Title, blog_LinkCategories.Active, 
blog_LinkCategories.CategoryType, blog_LinkCategories.[Description],ParentID
FROM blog_LinkCategories
where blog_LinkCategories.ParentID=@ParentID and blog_LinkCategories.CategoryType = @CategoryType 
and blog_LinkCategories.Active <> Case @IsActive When 1 then 0 Else -1 End 
ORDER BY blog_LinkCategories.UpdateTime desc;
End
Else
Begin
SELECT blog_LinkCategories.CategoryID, blog_LinkCategories.Title, blog_LinkCategories.Active, 
blog_LinkCategories.CategoryType, blog_LinkCategories.[Description],ParentID
FROM blog_LinkCategories
where blog_LinkCategories.BlogID = @BlogID and blog_LinkCategories.CategoryType = @CategoryType 
and blog_LinkCategories.Active <> Case @IsActive When 1 then 0 Else -1 End
ORDER BY blog_LinkCategories.UpdateTime desc
End

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO















CREATE       Proc blog_GetCategory
(
	@CategoryID int,
	@CategoryName nvarchar(150),
	@IsActive bit,
	@BlogID int
)
as

if(@CategoryID is not null and @CategoryID > 0)
Begin
	SELECT blog_LinkCategories.CategoryID, blog_LinkCategories.Title, blog_LinkCategories.Active, 
	blog_LinkCategories.CategoryType, blog_LinkCategories.[Description],blog_LinkCategories.ParentID
	FROM blog_LinkCategories
	WHERE blog_LinkCategories.CategoryID=@CategoryID  and blog_LinkCategories.Active <> case @IsActive when 0 then -1 else 0 end
End
Else
Begin
	SELECT blog_LinkCategories.CategoryID, blog_LinkCategories.Title, blog_LinkCategories.Active, 
	blog_LinkCategories.CategoryType, blog_LinkCategories.[Description],blog_LinkCategories.ParentID
	FROM blog_LinkCategories
	WHERE blog_LinkCategories.Title=@CategoryName and blog_LinkCategories.BlogID = @BlogID and blog_LinkCategories.Active <> case @IsActive when 0 then -1 else 0 end
End

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO









CREATE             Proc blog_GetConfig
(
	@Host nvarchar(100),
	@Application nvarchar(50)
)
as
Select 	blog_Config.BlogID, UserName, [Password], Email, Title, SubTitle, Skin, Application, Host, 
	Author, TimeZone, ItemCount, [Language], News, SecondaryCss, 
	LastUpdated, PostCount, StoryCount, PingTrackCount, CommentCount, Flag, SkinCssFile,IsMailNotify,NotifyMail,IsOnlyListTitle
 From blog_Config

Where Host = @Host and Application = @Application and Flag & 1 > 0



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE             Proc blog_GetConfigByApp
(
	@Application nvarchar(50)
)
as
Select 	blog_Config.BlogID, UserName, [Password], Email, Title, SubTitle, Skin, Application, Host, 
	Author, TimeZone, ItemCount, [Language], News, SecondaryCss, 
	LastUpdated, PostCount, StoryCount, PingTrackCount, CommentCount, Flag, SkinCssFile,IsMailNotify,NotifyMail,IsOnlyListTitle
 From blog_Config

Where  Application = @Application and Flag & 1 > 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO






CREATE Proc blog_GetConfigByBlogID
(
	@BlogID int
)
as
Select 	blog_Config.BlogID, UserName, [Password], Email, Title, SubTitle, Skin, Application, Host, 
	Author, TimeZone, ItemCount, [Language], News, SecondaryCss, 
	LastUpdated, PostCount, StoryCount, PingTrackCount, CommentCount, Flag, SkinCssFile,IsMailNotify,NotifyMail,IsOnlyListTitle
  From blog_Config

Where BlogID= @BlogID and Flag & 1 > 0



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE Proc blog_GetConfigByRoleID
(
	@RoleID int
)
as
Select 	blog_Config.BlogID, UserName, [Password], Email, Title, SubTitle, Skin, Application, Host, 
	Author, TimeZone, ItemCount, [Language], News, SecondaryCss, 
	LastUpdated, PostCount, StoryCount, PingTrackCount, CommentCount, Flag, SkinCssFile,IsMailNotify,NotifyMail,IsOnlyListTitle
  From blog_Config
  inner join blog_UsersInRoles on (RoleID=@RoleID)
 Where blog_Config.BlogID= blog_UsersInRoles.UserID and Flag & 1 > 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO






CREATE Proc blog_GetConfigByUserName
(
	@UserName nvarchar(50)
)
as
Select 	blog_Config.BlogID, UserName, [Password], Email, Title, SubTitle, Skin, Application, Host, 
	Author, TimeZone, ItemCount, [Language], News, SecondaryCss, 
	LastUpdated, PostCount, StoryCount, PingTrackCount, CommentCount, Flag, SkinCssFile,IsMailNotify,NotifyMail,IsOnlyListTitle
From blog_Config

Where UserName= @UserName and Flag & 1 > 0



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE Proc blog_GetEntryByID
(
	@EntryID int,
	@BlogID int
)
as

SELECT 
		bc.BlogID, bc.[ID], bc.Title, bc.DateAdded, bc.[Text], bc.[Description],
		bc.SourceUrl, bc.PostType, bc.Author, bc.Email, bc.SourceName, bc.DateUpdated, bc.TitleUrl, bc.ParentID,
		bc.FeedBackCount, bc.PostConfig, bc.EntryName,vc.WebCount,vc.AggCount 
	FROM 
		blog_Content bc
		Left JOIN  blog_EntryViewCount vc ON (bc.[ID] = vc.EntryID )
	WHERE 
		bc.ID=@EntryID and bc.BlogID=@BlogID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE  blog_GetEntryStatViewByEntryID 
(
	@EntryID int
)
AS
Select WebCount,AggCount,WebLastUpdated,AggLastUpdated
from blog_EntryViewCount with(nolock)
where EntryID=@EntryID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Proc blog_GetEntry_10
(
	@EntryID int,
	@EntryName nvarchar(150),
	@PostConfig int,
	@IncludeCategories bit,
	@BlogID int
)
as

if(@EntryID is null)
Begin
	SELECT 
		bc.BlogID, bc.[ID], bc.Title, bc.DateAdded, bc.[Text], bc.[Description],
		bc.SourceUrl, bc.PostType, bc.Author, bc.Email, bc.SourceName, bc.DateUpdated, bc.TitleUrl, bc.ParentID,
		bc.FeedBackCount, bc.PostConfig, bc.EntryName,vc.WebCount,vc.AggCount  
	FROM 
		blog_Content bc
		Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
	WHERE 
		bc.EntryName = @EntryName and  bc.BlogID = @BlogID and 
		bc.PostConfig & @PostConfig = @PostCOnfig
End
Else
Begin
	SELECT 
		bc.BlogID, bc.[ID], bc.Title, bc.DateAdded, bc.[Text], bc.[Description],
		bc.SourceUrl, bc.PostType, bc.Author, bc.Email, bc.SourceName, bc.DateUpdated, bc.TitleUrl, bc.ParentID,
		bc.FeedBackCount, bc.PostConfig, bc.EntryName,bcc.Application,vc.WebCount,vc.AggCount 
	FROM 
		blog_Content bc
		inner join blog_Config bcc on bc.BlogID = bcc.BlogID
		Left JOIN  blog_EntryViewCount vc with(nolock) ON (bc.[ID] = vc.EntryID )
	WHERE 
		bc.[ID] = @EntryID and  bc.BlogID=@BlogID and
		bc.PostConfig & @PostConfig = @PostConfig
End

if(@IncludeCategories = 1)
Begin
	if(@EntryID is null)
	Begin
		Select c.Title, l.PostID From blog_Links l
		inner join blog_LinkCategories c on l.CategoryID = c.CategoryID
		inner join blog_Content bc on l.PostID = bc.[ID]
		where bc.EntryName = @EntryName
	End
	Else
	Begin
		Select c.Title, l.PostID From blog_Links l
		inner join blog_LinkCategories c on l.CategoryID = c.CategoryID
		inner join blog_Content bc on l.PostID = bc.[ID]
		where bc.[ID] = @EntryID
	End
End

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE           Proc blog_GetFeedBack 
(
	@ParentID int,
	@BlogID int=null
)
as

SELECT blog_Content.BlogID, blog_Content.[ID], blog_Content.Title, blog_Content.DateAdded, blog_Content.[Text], blog_Content.[Description],
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.SourceName, blog_Content.DateUpdated, blog_Content.TitleUrl,
blog_Content.FeedBackCount, blog_Content.ParentID, blog_Content.PostConfig, blog_Content.EntryName,0 as WebCount,0 as AggCount FROM blog_Content
WHERE blog_Content.PostConfig & 1 = 1 and blog_Content.ParentID = @ParentID
ORDER BY [ID]


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO














CREATE   Proc blog_GetImageCategory
(
	@CategoryID int,
	@IsActive bit,
	@BlogID int
)
as
exec blog_GetCategory @CategoryID, null, @IsActive, @BlogID
Select Title, CategoryID, Height, Width, [File], Active, ImageID From blog_Images  
where CategoryID = @CategoryID and BlogID = @BlogID and Active <> Case @IsActive When 1 then 0 Else -1 End
order by Title














GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO









CREATE  Proc blog_GetKeyWord
(
	@KeyWordID int,
	@BlogID int
)
as

Select 
	KeyWordID, Word,[Text],ReplaceFirstTimeOnly,OpenInNewWindow, CaseSensitive,Url,Title,BlogID
From
	blog_keywords
Where 
	KeyWordID = @KeyWordID and BlogID = @BlogID









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO










CREATE Proc blog_GetKeyWords
(
	@BlogID int
)
as

Select 
	KeyWordID, Word,[Text],ReplaceFirstTimeOnly,OpenInNewWindow, CaseSensitive,Url,Title,BlogID
From
	blog_keywords
Where 
	BlogID = @BlogID










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE Proc blog_GetLastExecuteScheduledEventDateTime
(
	@Key varchar(100),
	@ServerName varchar(100),
	@LastExecuted datetime output
)
as
--Check to see when the last time the item was executed
Select @LastExecuted = max(LastExecuted) From blog_ScheduledEvents where [Key] = @Key 

if(@LastExecuted is null) -- if this item was never executed, set the date for now -1 year
Begin
	Set @LastExecuted = DateAdd(year,-1,getdate())
End


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO











CREATE     Proc blog_GetLinkCollectionByPostID
(
	@PostID int,
	@BlogID int
)
as
SELECT blog_Links.LinkID, blog_Links.Title, blog_Links.Url, blog_Links.Rss, blog_Links.Active, blog_Links.CategoryID,  blog_Links.PostID, blog_Links.NewWindow,blog_Links.UpdateTime 
FROM blog_Links
WHERE blog_Links.PostID=@PostID and blog_Links.BlogID = @BlogID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE      Proc blog_GetLinksByCategoryID
(
	@CategoryID int,
	@IsActive bit,
	@BlogID int
)
as
SELECT blog_Links.LinkID, blog_Links.Title, blog_Links.Url, blog_Links.Rss, blog_Links.Active, blog_Links.NewWindow, blog_Links.CategoryID,  blog_Links.PostID,blog_Links.UpdateTime
FROM blog_Links
WHERE 
	blog_Links.Active  <> Case @IsActive When 1 then 0 Else -1 End and
	blog_Links.CategoryID=@CategoryID and blog_Links.BlogID = @BlogID
ORDER BY blog_Links.UpdateTime DESC


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE Proc blog_GetLinksCountByCategoryID
(
	@CategoryID int,
	@StartDate datetime = null,
	@StopDate datetime = null
)
as
Set @StopDate = DateAdd(day,1,@StartDate)
SELECT count([ID]) as PostCount				
FROM blog_Content bc
INNER JOIN blog_Links bl on bc.ID=bl.PostID
WHERE 
bc.PostConfig & 64 = 64
			
			and bl.CategoryID = @CategoryID
			 






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO














CREATE    PROC blog_GetPageableKeyWords -- 0,1,2,1
(
	@BlogID int,
	@PageIndex int,
	@PageSize int,
	@SortDesc bit
--	@TotalRecords int output
)
AS

DECLARE @PageLowerBound int
DECLARE @PageUpperBound int

SET @PageLowerBound = @PageSize * @PageIndex - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1


CREATE TABLE #TempPagedKeyWordIDs 
(
	TempID int IDENTITY (1, 1) NOT NULL,
	KeywordID int NOT NULL
)	

if(@SortDesc = 1)
BEGIN
	INSERT INTO #TempPagedKeyWordIDs (KeyWordID)
	SELECT	KeyWordID
	FROM 	blog_KeyWords 
	WHERE 	blogID = @BlogID 
	ORDER BY Word
END
Else
BEGIN
	INSERT INTO #TempPagedKeyWordIDs (KeyWordID)
	SELECT	KeyWordID
	FROM 	blog_KeyWords 
	WHERE 	blogID = @BlogID 
	ORDER BY Word desc
END

SELECT 	words.KeyWordID, 
	words.Word,
	words.[Text],
	words.ReplaceFirstTimeOnly,
	words.OpenInNewWindow,
	words.CaseSensitive,
	words.Url,
	words.Title,
	words.BlogID
FROM 	
	blog_KeyWords words
	INNER JOIN #TempPagedKeyWordIDs tmp ON (words.KeyWordID = tmp.KeyWordID)
WHERE 	
	words.blogID = @BlogID 
	AND tmp.TempID > @PageLowerBound
	AND tmp.TempID < @PageUpperBound
ORDER BY
	tmp.TempID
 
DROP TABLE #TempPagedKeyWordIDs

SELECT 	COUNT([KeywordID]) as 'TotalRecords'
FROM 	blog_KeyWords 
WHERE 	blogID = @BlogID









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE    PROC blog_GetPageableLinks 
(
	@BlogID int,
	@CategoryID int,
	@PageIndex int,
	@PageSize int,
	@SortDesc bit
)
AS

DECLARE @PageLowerBound int
DECLARE @PageUpperBound int

SET @PageLowerBound = @PageSize * @PageIndex - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1



CREATE TABLE #TempPagedLinkIDs 
(
	TempID int IDENTITY (1, 1) NOT NULL,
	LinkID int NOT NULL
)	

IF NOT (@SortDesc = 1)
	BEGIN
		INSERT INTO #TempPagedLinkIDs (LinkID)
		SELECT	LinkID
		FROM 	blog_Links 
		WHERE 	blogID = @BlogID 
			AND CategoryID = @CategoryID
		ORDER BY UpdateTime
	END
ELSE
	BEGIN
		INSERT INTO #TempPagedLinkIDs (LinkID)
		SELECT	LinkID
		FROM 	blog_Links
		WHERE 	blogID = @BlogID 
			AND CategoryID = @CategoryID
		ORDER BY UpdateTime DESC
	END


SELECT 	links.LinkID, 
	links.Title, 
	links.Url,
	links.Rss, 
	links.Active, 
	links.NewWindow, 
	links.CategoryID,  
	links.PostID,
	links.UpdateTime
FROM 	
	blog_Links links
	INNER JOIN #TempPagedLinkIDs tmp ON (links.LinkID = tmp.LinkID)
WHERE 	
	links.blogID = @BlogID 
	--AND links.CategoryID = @CategoryID
	AND tmp.TempID > @PageLowerBound
	AND tmp.TempID < @PageUpperBound
ORDER BY
	tmp.TempID
 

SELECT  COUNT(*) as TotalRecords
FROM 	#TempPagedLinkIDs 
--WHERE 	blogID = @BlogID AND CategoryID = @CategoryID 	AND PostID = -1

DROP TABLE #TempPagedLinkIDs


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO









--Select Top 5 * FROM blog_Referrals order by LastUpdated desc

CREATE Proc blog_GetPageableReferrers
-- 0, 1, 20
(
	@BlogID INT,
	@PageIndex INT,
	@PageSize INT
)
AS


DECLARE @PageLowerBound int
DECLARE @PageUpperBound int

SET @PageLowerBound = @PageSize * @PageIndex - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

CREATE TABLE #tempblog_Referrals 
(
	TempID INT IDENTITY(1, 1) NOT NULL,
	[EntryID] [int] NOT NULL ,
	[UrlID] [int] NOT NULL ,
	[Count] [int] NOT NULL ,
	[LastUpdated] [datetime] NOT NULL
) 




INSERT INTO #tempblog_Referrals (EntryID,UrlID, [Count], LastUpdated)
  SELECT EntryID, UrlID, [Count], LastUpdated
  FROM blog_Referrals
  WHERE blog_Referrals.BlogID = @BlogID and blog_Referrals.UrlID not in (select UrlID from blog_URLs where URL like '%google.%')
  Order by LastUpdated desc
   


SELECT	u.URL,
	c.Title,
	r.EntryID,
	c.EntryName,
	LastUpdated,
	[Count]
FROM 	blog_Content c,
	#tempblog_Referrals r,
	blog_URLs u
WHERE r.EntryID = c.ID and
      c.BlogID = @BlogID
  AND r.UrlID = u.UrlID
  AND r.TempID > @PageLowerBound
  AND r.TempID < @PageUpperBound

Order by TempID



SELECT COUNT(*) as 'TotalRecords' FROM #tempblog_Referrals




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO










--blog_GetPageableReferrersByEntryID 0, 7043, 1, 10

CREATE     Proc blog_GetPageableReferrersByEntryID 
(
	@BlogID INT,
	@EntryID int,
	@PageIndex INT,
	@PageSize INT
)
AS


DECLARE @PageLowerBound int
DECLARE @PageUpperBound int

SET @PageLowerBound = @PageSize * @PageIndex - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

CREATE TABLE #tempblog_Referrals 
(
	TempID INT IDENTITY(1, 1) NOT NULL,
	[UrlID] [int] NOT NULL ,
	[Count] [int] NOT NULL ,
	[LastUpdated] [datetime] NOT NULL
) 




INSERT INTO #tempblog_Referrals (UrlID, [Count], LastUpdated)
  SELECT UrlID, [Count], LastUpdated
  FROM blog_Referrals
  WHERE blog_Referrals.BlogID = @BlogID and blog_Referrals.EntryID = @EntryID
  Order by LastUpdated desc
   


SELECT	u.URL,
	c.Title,
	c.EntryName,
	@EntryID as 'EntryID',
	LastUpdated,
	[Count]
FROM 	blog_Content c,
	#tempblog_Referrals r,
	blog_URLs u
WHERE c.ID = @EntryID and 
      c.BlogID = @BlogID
  AND r.UrlID = u.UrlID
  AND r.TempID > @PageLowerBound
  AND r.TempID < @PageUpperBound
  Order by TempID



SELECT COUNT(*) as 'TotalRecords' FROM #tempblog_Referrals
















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE PROC blog_GetPagedPosts
(
	@PageIndex int,
	@PageSize int,
	@Host nvarchar(100),
	@GroupID int,
	@ServerTimeZone int
)
as


DECLARE @PageLowerBound int
DECLARE @PageUpperBound int

SET @PageLowerBound = @PageSize * @PageIndex - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

Create Table #IDs
(
	TempID int IDENTITY (1, 1) NOT NULL,
	EntryID int not null
)

Insert #IDs (EntryID)
exec blog_GetAggregatedPostsID @Host, @GroupID, @ServerTimeZone
SELECT 	
	Host, Application, 
IsNull(blog_Content.EntryName,blog_Content.[ID]) as [EntryName], blog_Content.[ID],  blog_Content.Title, 
blog_Content.DateAdded, 
blog_Content.SourceUrl, blog_Content.PostType, blog_Content.Author, blog_Content.Email, blog_Content.
FeedBackCount,
blog_Content.SourceName, blog_Content.EntryName, Convert(bit,case when blog_Content.PostConfig & 2 = 2 then 
1 else 0 end) as 'IsXHTML', blog_Config.Title as [BlogTitle],  blog_Content.PostCOnfig, blog_Config.TimeZone
, IsNull(case when PostConfig & 32 = 32 then blog_Content.[Description] else blog_Content.[Text] end,'') as [
Description],
(vc.WebCount+vc.AggCount) as ViewCount

		
FROM  	blog_content 
	inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
    	INNER JOIN #IDS tmp ON (blog_content .[ID] = tmp.EntryID)
	Left outer JOIN  blog_EntryViewCount vc  ON (blog_Content.[ID] = vc.EntryID)
WHERE 	tmp.TempID > @PageLowerBound 
	AND tmp.TempID < @PageUpperBound
ORDER BY tmp.TempID

SELECT COUNT(*) as TotalRecords
FROM 	#IDS 


DROP TABLE #IDS



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE Proc blog_GetPostCountByType
(
	@PostType int,
	@StartDate datetime = null,
	@StopDate datetime = null
)
as
begin
	Set @StopDate = DateAdd(day,1,@StartDate)
	SELECT count([ID]) as PostsCount,(SELECT count([ID])  FROM blog_Content WHERE blog_Content.PostType=@PostType) as AllPostsCount
	FROM blog_Content
	inner join blog_Config on blog_Content.BlogID = blog_Config.BlogID
	where PostType=8 and parentid in (select ID from blog_Content where  blog_Content.PostType = 1 and  blog_Content.PostConfig & 1 = 1 
	and blog_Content.PostConfig & 64 = 64 and blog_Config.Flag & 2 = 2 and  blog_Config.IsActive = 1)
	and  DateAdded>=@StartDate and  DateAdded<=@StopDate
			 
end



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO









CREATE   Proc blog_GetPostsByMonthArchive 
(
	@BlogID int,
	@PostType int
)
as
Select Month(DateAdded) as [Month], Year(DateAdded) as [Year], 1 as Day, Count(*) as [Count] From blog_Content 
where PostType = @PostType and PostConfig & 1 = 1 and BlogID = @BlogID 
Group by Year(DateAdded), Month(DateAdded) order by [Year] desc, [Month] desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO










CREATE   Proc blog_GetPostsByYearArchive 
(
	@BlogID int,
	@PostType int
)
as
Select 1 as [Month], Year(DateAdded) as [Year], 1 as Day, Count(*) as [Count] From blog_Content 
where PostType =@PostType and PostConfig & 1 = 1 and BlogID = @BlogID 
Group by Year(DateAdded) order by [Year] desc




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE PROCEDURE blog_GetRatePeople
(
	@EntryID int,
	@Score int
)
as

Select count(ID) as peoples from blog_EntryRate where EntryID=@EntryID and Score=@Score




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












Create Proc blog_GetSingleImage
(
	@ImageID int,
	@IsActive bit, 
	@BlogID int
)
as
Select Title, CategoryID, Height, Width, [File], Active, ImageID From blog_Images  
where ImageID = @ImageID and BlogID = @BlogID and  Active <> Case @IsActive When 1 then 0 Else -1 End












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












CREATE    Proc blog_GetSingleLink
(
	@LinkID int,
	@BlogID int
)
as
SELECT blog_Links.LinkID, blog_Links.Title, blog_Links.Url, blog_Links.Rss, blog_Links.Active, blog_Links.NewWindow, blog_Links.CategoryID,  blog_Links.PostID,blog_Links.UpdateTime 
FROM blog_Links
WHERE blog_Links.LinkID=@LinkID and blog_Links.BlogID = @BlogID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE             Proc blog_GetSkinControlByBlogID
(
	@BlogID int
)
as
Select 	sc.ID,sc.ControlName,sc.Control,isnull(scc.Visible,sc.DefaultVisible) as Visible
From blog_SkinControl sc
Left outer JOIN blog_SkinControl_Config scc on scc.ControlId = sc.ID and scc.BlogID= @BlogID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE Proc blog_GetTopFeedbackPostsByBlogID
(
	@BlogID int,
	@ItemCount int
)
as
set rowcount @ItemCount

SELECT blog_Content.[ID],  blog_Content.Title,blog_Content.DateAdded,blog_Content.FeedBackCount
FROM blog_Content with(nolock)
where blog_Content.PostType=1 and blog_Content.BlogID=@BlogID and PostConfig&1=1
order by FeedBackCount desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE Proc blog_GetTopPostsByBlogID
(
	@BlogID int,
	@ItemCount int
)
as
set rowcount @ItemCount

SELECT blog_Content.[ID],  blog_Content.Title,blog_Content.DateAdded,blog_Content.FeedBackCount,(vc.WebCount+vc.AggCount) as ViewCount
FROM blog_Content with(nolock)
Left outer JOIN  blog_EntryViewCount vc with(nolock) ON (blog_Content.[ID] = vc.EntryID)
where blog_Content.PostType=1 and blog_Content.BlogID=@BlogID and PostConfig&1=1
order by ViewCount desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












Create Proc blog_GetUrlID
(
	@Url nvarchar(255),
	@UrlID int output
)
as
if exists(Select UrlID From blog_Urls where Url = @Url)
Begin
	Select @UrlID = UrlID From blog_Urls where Url = @Url
End
Else
Begin
	Insert blog_Urls Values (@Url)
	Select @UrlID = @@Identity
End












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE Proc blog_InsertBlogProfile
(
	@BlogID int,
	@City nvarchar(150)
)

as

 Insert blog_Profile ( BlogID,City)
 values (@BlogID, @City)





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO













CREATE    Proc blog_InsertCategory
(
	@Title nvarchar(150),
	@Active bit,
	@BlogID int,
	@CategoryType tinyint,
	@Description nvarchar(1000),
	@ParentID int=null,
	@CategoryID int output
)
as
Set NoCount On
INSERT INTO blog_LinkCategories ( Title, Active, CategoryType, [Description], BlogID,ParentID,UpdateTime )
VALUES (@Title,@Active, @CategoryType, @Description, @BlogID,@ParentID,getdate())
Select @CategoryID = @@Identity

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO














CREATE   Proc blog_InsertEntry
(
	@Title nvarchar(255),
	@TitleUrl nvarchar(255),	
	@Text ntext,
	@SourceUrl nvarchar(200),
	@PostType int,
	@Author nvarchar(50),
	@Email nvarchar(50),
	@SourceName nvarchar(200),
	@Description nvarchar(500),
	@BlogID int,
	@DateAdded datetime,
	@ParentID int,
	@PostConfig int,
	@EntryName nvarchar(150),
	@ID int output)
as

if(@EntryName is not null)
Begin
	if exists(Select EntryName From blog_Content where BlogID = @BlogID and EntryName = @EntryName)
	Begin
		RAISERROR('The EntryName you entry is already in use with in this Blog. Please pick a unique EntryName.',11,1) 
		RETURN 1
	End
End
if(Ltrim(Rtrim(@Description)) = '')
set @Description = null
INSERT INTO blog_Content 
(Title, TitleUrl, [Text], SourceUrl, PostType, Author, Email, DateAdded,DateUpdated, SourceName, [Description], PostConfig, ParentID, BlogID, EntryName )
VALUES 
(@Title, @TitleUrl, @Text, @SourceUrl, @PostType, @Author, @Email, @DateAdded, @DateAdded, @SourceName, @Description, @PostConfig, @ParentID, @BlogID, @EntryName)
Select @ID = @@Identity

if(@PostType = 1 or @PostType = 2)
Begin
	exec blog_UpdateConfigUpdateTime @blogID, @DateAdded
End
Else if(@PostType = 8)
Begin
	Update blog_Content
	Set FeedBackCount = FeedBackCount + 1 where [ID] = @ParentID
End




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO







CREATE Proc blog_InsertEntryViewCount-- 1, 0, 1
(
	@EntryID int,
	@BlogID int,
	@IsWeb bit
)

as

Begin
	--Do we have an existing entry in the blog_InsertEntryViewCount table?
	if exists(Select EntryID From blog_EntryViewCount where EntryID = @EntryID and BlogID = @BlogID)
	begin
		if(@IsWeb = 1) -- Is this a web view?
		begin
			Update blog_EntryViewCount
			Set [WebCount] = [WebCount] + 1, WebLastUpdated = getdate()
			where EntryID = @EntryID and BlogID = @BlogID
		end
		else
		begin
			Update blog_EntryViewCount
			Set [AggCount] = [AggCount] + 1, AggLastUpdated = getdate()
			where EntryID = @EntryID and BlogID = @BlogID
		end
	end
	else
	begin
		if(@IsWeb = 1) -- Is this a web view
		begin
			Insert blog_EntryViewCount (EntryID, BlogID, WebCount, AggCount, WebLastUpdated, AggLastUpdated)
		       values (@EntryID, @BlogID, 1, 0, getdate(), null)
		end
		else
		begin
			Insert blog_EntryViewCount (EntryID, BlogID, WebCount, AggCount, WebLastUpdated, AggLastUpdated)
		       values (@EntryID, @BlogID, 0, 1, null, getdate())
		end
	end


End








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO




CREATE  Proc blog_InsertFavorite
(
	@EntryID int,
	@BlogID int,
	@IsPublished tinyint
)
as
	Insert blog_Favorite (EntryID,BlogID,IsPublished,UpdateTime)
	Values (@EntryID, @BlogID, @IsPublished,getdate())



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO











CREATE Proc blog_InsertImage
(
	@Title nvarchar(250),
	@CategoryID int,
	@Width int,
	@Height int,
	@File nvarchar(50),
	@Active bit,
	@BlogID int,
	@ImageID int output
)
as
Insert blog_Images
(
	Title, CategoryID, Width, Height, [File], Active, BlogID,UploadTime
)
Values
(
	@Title, @CategoryID, @Width, @Height, @File, @Active, @BlogID,getdate()
)
Set @ImageID = @@Identity


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO









CREATE  Proc blog_InsertKeyWord
(
	@Word nvarchar(100),
	@Text nvarchar(100),
	@ReplaceFirstTimeOnly bit,
	@OpenInNewWindow bit,
	@CaseSensitive bit,
	@Url nvarchar(255),
	@Title nvarchar(100),
	@BlogID int,
	@KeyWordID int output
)

as

Insert blog_keywords 
	(Word,[Text],ReplaceFirstTimeOnly,OpenInNewWindow, CaseSensitive,Url,Title,BlogID)
Values
	(@Word,@Text,@ReplaceFirstTimeOnly,@OpenInNewWindow, @CaseSensitive,@Url,@Title,@BlogID)

Select @KeyWordID = @@Identity










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












CREATE    Proc blog_InsertLink
(
	@Title nvarchar(150)=null,
	@Url nvarchar(255)=null,
	@Rss nvarchar(255),
	@Active bit,
	@NewWindow bit,
	@CategoryID int,
	@PostID int,
	@BlogID int,
	@LinkID int output
)
as
INSERT INTO blog_Links 
( Title, Url, Rss, Active, NewWindow, PostID, CategoryID, BlogID ,UpdateTime)
VALUES 
(@Title, @Url, @Rss, @Active, @NewWindow, @PostID, @CategoryID, @BlogID,getdate());
Select @LinkID = @@Identity




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO








CREATE     Proc blog_InsertLinkCategoryList
(
	@CategoryList nvarchar(4000),
	@PostID int,
	@BlogID int
)
as

if(@CategoryList is not null and LEN(LTRIM(RTRIM(@CategoryList))) > 0)
Begin

--Delete categories that have been removed
Delete blog_Links From blog_Links
where 
	CategoryID not in (Select str From iter_charlist_to_table(@CategoryList,','))
And 
	BlogID = @BlogID and PostID = @PostID

--Add updated/new categories
INSERT INTO blog_Links ( Title, Url, Rss, Active, NewWindow, PostID, CategoryID, BlogID,UpdateTime )
Select null, null, null, 1, 0, @PostID, Convert(int, [str]), @BlogID,getdate()
From iter_charlist_to_table(@CategoryList,',')
where 
	Convert(int, [str]) not in (Select CategoryID From blog_Links where PostID = @PostID and BlogID = @BlogID)
End
Else
Begin
	Delete blog_Links From blog_Links where BlogID = @BlogID and PostID = @POSTID
End




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE Proc blog_InsertLog
(
	@Title varchar(100),
	@Message varchar(800),
	@UserName varchar(100),
	@Url varchar(500),
	@ServerName varchar(100),
	@BlogID int,
	@StartDate datetime,
	@EndDate datetime,
	@LogID int output
)

as

Insert blog_Log (Title, Message, UserName, Url, ServerName, BlogID, StartDate, EndDate)
Values (@Title, @Message, @UserName, @Url, @ServerName, @BlogID, @StartDate, @EndDate)

Select @LogID = @@Identity






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


















CREATE     Proc blog_InsertPingTrackEntry
(
	@Title nvarchar(255),
	@TitleUrl nvarchar(255),	
	@Text ntext,
	@SourceUrl nvarchar(200),
	@PostType int,
	@Author nvarchar(50),
	@Email nvarchar(50),
	@SourceName nvarchar(200),
	@Description nvarchar(500),
	@BlogID int,
	@DateAdded datetime,
	@ParentID int,
	@PostConfig int,
	@EntryName nvarchar(150),
	@ID int output)
as

--Do not insert EntryNames. No needed for comments and tracks. To messy anyway

Set @ID = -1

if not exists (Select [ID] From blog_Content where TitleUrl = @TitleUrl and ParentID = @ParentID)
Begin

if(Ltrim(Rtrim(@Description)) = '')
set @Description = null
INSERT INTO blog_Content 
( PostConfig, Title, TitleUrl, [Text], SourceUrl, PostType, Author, Email, DateAdded,DateUpdated, SourceName, [Description], ParentID, BlogID)
VALUES 
(@PostConfig, @Title, @TitleUrl, @Text, @SourceUrl, @PostType, @Author, @Email, @DateAdded, @DateAdded, @SourceName, @Description, @ParentID, @BlogID)

Select @ID = @@Identity

Update blog_Content
Set FeedBackCount = FeedBackCount + 1 
where [ID] = @ParentID

End


















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO











CREATE   Proc blog_InsertPostCategoryByName
(
	@Title nvarchar(150),
	@PostID int,
	@BlogID int
)
as
Declare @CategoryID int
Select @CategoryID = CategoryID From blog_LinkCategories where Title = @Title and BlogID = @BlogID and CategoryType = 1

if(@CategoryID is null)
Begin

exec blog_InsertCategory @Title, 1, @BlogID, 1, null, @CategoryID = @CategoryID output

End

Declare @LinkID int
exec blog_InsertLink null, null, null, 1, 0, @CategoryID, @PostID, @BlogID, @LinkID output














GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO





CREATE  Proc blog_InsertRate
(
	@EntryID int,
	@BlogID int,
	@ClientID nvarchar(50),
	@Score tinyint,
	@ID int output
)
as
if exists(Select ID From blog_EntryRate where EntryID = @EntryID and ClientID= @ClientID)
	Begin
		Set @ID=0
		RETURN 1
	End

	Insert blog_EntryRate(EntryID,BlogID,ClientID,Score,UpdateTime)
	Values (@EntryID, @BlogID,@ClientID, @Score,getdate())
Set @ID = @@Identity
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO







Create Proc blog_InsertReferral
(
	@EntryID int,
	@BlogID int,
	@Url nvarchar(255)
)

as

Declare @UrlID int

if(@Url is not null)
Begin
	exec blog_GetUrlID @Url, @UrlID = @UrlID output
End

if(@UrlID is not null)
Begin

	if exists(Select EntryID From blog_Referrals where EntryID = @EntryID and BlogID = @BlogID and UrlID = @UrlID)
	begin
		Update blog_Referrals
		Set [Count] = [Count] + 1, LastUpdated = getdate()
		where EntryID = @EntryID and BlogID = @BlogID and UrlID = @UrlID
	end
	else
	begin
		Insert blog_Referrals (EntryID, BlogID, UrlID, [Count], LastUpdated)
		       values (@EntryID, @BlogID, @UrlID, 1, getdate())
	end


End







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.blog_MailNotify_Delete
	(
		@EntryID int,
		@SendToBlogID int
	)

AS
	delete from blog_MailNotify where EntryID=@EntryID and SendToBlogID=@SendToBlogID
	
	RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.blog_MailNotify_GetMailList
	(
		@EntryID int
	)

AS
	select EMail from blog_MailNotify where EntryID = @EntryID
	RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.blog_MailNotify_Insert
(
		@EntryID int,
		@BlogID int,
		@SendToBlogID int,
		@EMail nvarchar(150)
)

AS
	IF NOT EXISTS (SELECT EntryID FROM blog_MailNotify  WHERE EntryID = @EntryID AND SendToBlogID = @SendToBlogID )
	insert into blog_MailNotify(EntryID,BlogID,SendToBlogID,EMail)values(@EntryID,@BlogID,@SendToBlogID,@EMail)
	



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE procedure blog_Role_AddUser
(
   @UserID int,
   @RoleID int
)
AS
IF NOT EXISTS (SELECT UserID FROM blog_UsersInRoles WHERE UserID = @UserID AND RoleID = @RoleID)
INSERT INTO	blog_UsersInRoles(UserID,RoleID) VALUES (@UserID, @RoleID)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE procedure blog_Role_RemoveUser
(
   @UserID	int,
   @RoleID	int
)
AS
IF EXISTS (SELECT UserID FROM blog_UsersInRoles WHERE UserID = @UserID AND @RoleID = @RoleID)
DELETE FROM
    blog_UsersInRoles
WHERE
    	UserID	= @UserID
	AND RoleID = @RoleID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO










CREATE   procedure blog_Roles_Get
(
@UserID int = -1
)
AS
BEGIN

	IF (@UserID = -1)
		SELECT
			*
		FROM
			blog_Roles
	ELSE
		SELECT DISTINCT
			R.RoleID,R.Name,R.Description 
		FROM 
			blog_UsersInRoles U,
			blog_Roles R
		WHERE
			U.RoleID = R.RoleID AND
			UserID = @UserID
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE Proc blog_SetLastExecuteScheduledEventDateTime
(
	@Key varchar(100),
	@ServerName varchar(100),
	@LastExecuted datetime
)
as
delete from blog_ScheduledEvents where ([Key]=@Key) and (LastExecuted < DATEADD([day], - 7, GETDATE()))

Insert blog_ScheduledEvents ([Key], ServerName, LastExecuted) Values (@Key, @ServerName, @LastExecuted)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO







Create Proc blog_StatsSummary
(
	@BlogID int
)
as
Declare @ReferralCount int
Declare @WebCount int
Declare @AggCount int

Select @ReferralCount = Sum([Count]) From blog_Referrals where BlogID = @BlogID

Select @WebCount = Sum(WebCount), @AggCount = Sum(AggCount) From blog_EntryViewCount where BlogID = @BlogID

Select @ReferralCount as 'ReferralCount', @WebCount as 'WebCount', @AggCount as 'AggCount'








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO








CREATE  Proc blog_TrackEntry
(
	@EntryID int,
	@BlogID int,
	@Url nvarchar(255),
	@IsWeb bit
)

as

if(@Url is not null and @IsWeb = 1)
begin
	exec blog_InsertReferral @EntryID, @BlogID, @Url
end

exec blog_InsertEntryViewCount @EntryID, @BlogID, @IsWeb








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE Proc blog_UTILITY_AddBlog
(
	@UserName nvarchar(50),
	@Password nvarchar(50),
	@Email nvarchar(50),
	@Host nvarchar(50),
	@Application nvarchar(50),
	@Author nvarchar(50),
	@Title nvarchar(100),
	@SubTitle nvarchar(250),
	@IsHashed bit,
	@Skin nvarchar(50)='AnotherEon001',
	@City nvarchar(50)
)

as

Declare @Flag int
Set @Flag = 55
if(@IsHashed = 1)
Set @Flag = 63

Insert blog_Config  (LastUpdated, UserName, Password, Email,     Title,       SubTitle,                     Skin, SkinCssFile,Application, Host, Author, TimeZone, Language, ItemCount, Flag,RegisterTime)
Values              (getdate(),@UserName, @Password, @Email, @Title,@SubTitle, @Skin,null,@Application, @Host,@Author,8,'zh-CHS',10,@Flag,getdate())

exec blog_InsertBlogProfile @@Identity,@City

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO













CREATE     Proc blog_UpdateCategory
(
	@CategoryID int,
	@Title nvarchar(150),
	@Active bit,
	@CategoryType tinyint,
	@Description nvarchar(1000),
	@BlogID int
)
as
UPDATE blog_LinkCategories 
SET 
	blog_LinkCategories.Title = @Title, 
	blog_LinkCategories.Active = @Active,
	blog_LinkCategories.CategoryType = @CategoryType,
	blog_LinkCategories.[Description] = @Description
WHERE   
	blog_LinkCategories.CategoryID=@CategoryID and blog_LinkCategories.BlogID = @BlogID













GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO














CREATE Proc blog_UpdateConfig
(
	@UserName nvarchar(50),
	@Password nvarchar(50),
	@Email nvarchar(50),
	@Title nvarchar(100),
	@SubTitle nvarchar(250),
	@Skin nvarchar(50),
	@Application nvarchar(50),
	@Host nvarchar(100),
	@Author nvarchar(100),
	@Language nvarchar(10),
	@TimeZone int,
	@ItemCount int,
	@News nText,
	@LastUpdated datetime,
	@SecondaryCss nText,
	@SkinCssFile varchar(100),
	@Flag int,
	@BlogID int,
	@IsMailNotify bit,
	@NotifyMail nvarchar(50),
	@IsOnlyListTitle bit
)
as
Update blog_Config
Set
UserName  =    @UserName,     
[Password]  =  @Password ,    
Email	   =   @Email,        
Title	   =   @Title ,       
SubTitle   =   @SubTitle  ,   
Skin	  =    @Skin   ,      
Application =  @Application , 
Host	  =    @Host  ,       
Author	   =   @Author,
Language = @Language,
TimeZone   = @TimeZone,
ItemCount = @ItemCount,
News      = @News,
LastUpdated = @LastUpdated,
Flag = @Flag,
SecondaryCss = @SecondaryCss,
SkinCssFile = @SkinCssFile,
IsMailNotify=@IsMailNotify,
NotifyMail=@NotifyMail,
IsOnlyListTitle=@IsOnlyListTitle
Where BlogID = @BlogID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












Create Proc blog_UpdateConfigUpdateTime
(
	@BlogID int,
	@LastUpdated datetime
)
as
Update blog_Config
Set LastUpdated = @LastUpdated
where blogid = @blogid












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE             Proc blog_UpdateEntry
(
	@ID int,
	@Title nvarchar(255),
	@TitleUrl nvarchar(255),
	@Text ntext,
	@SourceUrl nvarchar(200),
	@PostType int,
	@Author nvarchar(50),
	@Email nvarchar(50),
	@Description nvarchar(500),
	@SourceName nvarchar(200),
	@DateUpdated datetime,
	@PostConfig int,
	@ParentID int,
	@EntryName nvarchar(150),
	@BlogID int
)
as

if(@EntryName is not null)
Begin
	if exists(Select EntryName From blog_Content where BlogID = @BlogID and EntryName = @EntryName and [ID] <> @ID)
	Begin
		RAISERROR('The EntryName you entry is already in use with in this Blog. Please pick a unique EntryName.',11,1) 
		RETURN 1
	End
End

--Insert blog_Content_Audit ([ID], [Title], [DateAdded], [SourceUrl], [PostType], [Author], [Email], [SourceName], [BlogID], [Description], [DateUpdated], [TitleUrl], [Text], [ParentID], [FeedBackCount], [PostConfig], [EntryName], [IsOriginal])
--Select [ID], [Title], [DateAdded], [SourceUrl], [PostType], [Author], [Email], [SourceName], [BlogID], [Description], [DateUpdated], [TitleUrl], [Text], [ParentID], [FeedBackCount], [PostConfig], [EntryName], [IsOriginal] FROM blog_Content
--Where [ID] = @ID


if(Ltrim(Rtrim(@Description)) = '')
set @Description = null
UPDATE blog_Content 
SET 
	blog_Content.Title = @Title, 
	blog_Content.TitleUrl = @TitleUrl, 
	blog_Content.[Text] = @Text, 
	blog_Content.SourceUrl = @SourceUrl, 
	blog_Content.PostType = @PostType,
	blog_Content.Author = @Author, 
	blog_Content.Email = @Email, 
	blog_Content.[Description] = @Description,
	blog_Content.DateUpdated = @DateUpdated,
	blog_Content.PostConfig = @PostConfig,
	blog_Content.ParentID = @ParentID,
	blog_Content.SourceName = @SourceName,
	blog_Content.EntryName = @EntryName,
	blog_Content.IsOriginal = 0
WHERE 	
	blog_Content.[ID]=@ID and blog_Content.BlogID = @BlogID
exec blog_UpdateConfigUpdateTime @blogID, @DateUpdated

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












CREATE  Proc blog_UpdateImage
(
	@Title nvarchar(250),
	@CategoryID int,
	@Width int,
	@Height int,
	@File nvarchar(50),
	@Active bit,
	@BlogID int,
	@ImageID int
)
as
Update blog_Images
Set
	Title = @Title,
	CategoryID = @CategoryID,
	Width = @Width,
	Height = @Height,
	[File] = @File,
	Active = @Active
	
Where
	ImageID = @ImageID and BlogID = @BlogID












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO









CREATE  Proc blog_UpdateKeyWord
(
	@KeyWordID int,
	@Word nvarchar(100),
	@Text nvarchar(100),
	@ReplaceFirstTimeOnly bit,
	@OpenInNewWindow bit,
	@CaseSensitive bit,
	@Url nvarchar(255),
	@Title nvarchar(100),
	@BlogID int
)

as

Update blog_keywords 
	Set
		Word = @Word,
		[Text] = @Text,
		ReplaceFirstTimeOnly = @ReplaceFirstTimeOnly,
		OpenInNewWindow = @OpenInNewWindow,
		CaseSensitive = @CaseSensitive,
		Url = @Url,
		Title = @Title
	Where
		BlogID = @BlogID and KeyWordID = @KeyWordID










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












CREATE   Proc blog_UpdateLink
(
	@LinkID int,
	@Title nvarchar(150)=null,
	@Url nvarchar(255)=null,
	@Rss nvarchar(255),
	@Active bit,
	@NewWindow bit,
	@CategoryID int,
	@BlogID int
	
)
as
UPDATE blog_Links 
SET 
	blog_Links.Title = @Title, 
	blog_Links.Url = @Url, 
	blog_Links.Rss = @Rss, 
	blog_Links.Active = @Active,
	blog_Links.NewWindow = @NewWindow, 
	blog_Links.CategoryID = @CategoryID,
	blog_LInks.UpdateTime = getdate()
WHERE  
	blog_Links.LinkID=@LinkID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE PROCEDURE blog_UpdatePostConfig

	(
		@EntryID int,
		@PostConfig int
	)

AS
	update blog_Content set PostConfig=@PostConfig where ID=@EntryID




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE    Proc blog_UpdateSkinControl
(
	@ControlID int,
	@Visible bit,
	@BlogID int
)
as

if exists(select ID from blog_SkinControl_Config where ControlID=@ControlID and BlogID=@BlogID)
	begin
		Update blog_SkinControl_Config
		Set Visible=@Visible
		Where ControlID = @ControlID and BlogID=@BlogID
	end
else
	begin
		insert blog_SkinControl_Config(ControlID,BlogID,Visible)values(@ControlID,@BlogID,@Visible)
	end





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






Create Proc blog_Utility_GetUnHashedPasswords
as

Select BlogID, Password FROM blog_COnfig where Flag & 8 = 0






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






Create Proc blog_Utility_UpdateToHashedPassword
(
	@Password nvarchar(100),
	@BlogID int
)

as

Update blog_Config
Set 
	Password = @Password,
	Flag = Flag | 8 
where blogid = @blogid





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO





CREATE Proc blog_aggregate_Search  --'localhost'
(
	@StartDate datetime = null
)

as

Select 
	bc.Application, bc.Host,  c.[Text], IsNull(c.SourceUrl,'') as 'SourceUrl',c.DateAdded, c.PostType,
	isnull(c.EntryName,c.[ID]) as 'EntryID', c.Title, c.Author, c.FeedbackCount,
	IsNull((Select e.WebCount From blog_EntryViewCount e Where  e.BlogID = c.BlogID and e.EntryID = c.[ID]),0) as 'WebViewCount'
From 
	blog_Content c, blog_Config bc
Where 
	c.BlogID = bc.BlogID  and bc.Flag & 1 = 1 and c.PostConfig & 1 = 1 and bc.IsActive = 1 and  DateUpdated >@StartDate

ORDER BY c.DateAdded DESC




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE Proc blog_aggregate_Search_BU
(
	@Hosts varchar(400)
)

as

Select 
	bc.Application, bc.Host, c.[Text], IsNull(c.[Description],'') as 'Description', c.DateAdded, c.PostType,
	isnull(c.EntryName,c.[ID]) as 'EntryID', c.Title, c.Author
From 
	blog_Content c, blog_Config bc
Where 
	c.BlogID = bc.BlogID  and bc.Flag & 1 = 1 and c.PostConfig & 1 = 1 and bc.IsActive = 1

ORDER BY c.DateAdded DESC




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE    TRIGGER blog_Content_Trigger
On dbo.blog_Content
AFTER INSERT, UPDATE, Delete
as

Declare @BlogID int

--Get the current blogid
Select @BlogID = BlogID From INSERTED

--much more likely to be an insert than delete
--need to run on updates as well, incase an item is marked as inactive
if(@BlogID is null)
Begin
	Select @BlogID = BlogID From DELETED	
End

Update blog_Config
Set 
PostCount = (Select Count(*) From blog_Content Where blog_Content.BlogID = blog_Config.BlogID and PostType = 1 and PostConfig & 1 = 1),
CommentCount =  (Select Count(*) From blog_Content Where blog_Content.BlogID = blog_Config.BlogID and PostType =8 and PostConfig & 1 = 1),
StoryCount =  (Select Count(*) From blog_Content Where blog_Content.BlogID = blog_Config.BlogID and PostType = 2 and PostConfig & 1 = 1),
PingTrackCount =  (Select Count(*) From blog_Content Where blog_Content.BlogID = blog_Config.BlogID and PostType = 4 and PostConfig & 1 = 1)
Where BlogID = @BlogID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

