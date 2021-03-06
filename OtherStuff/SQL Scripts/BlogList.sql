if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedBloggerList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedBloggerList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedBloggerListByRegisterTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedBloggerListByRegisterTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedPagedBloggerList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedPagedBloggerList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[blog_GetAggregatedPagedBloggerListByRegisterTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[blog_GetAggregatedPagedBloggerListByRegisterTime]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Proc  blog_GetAggregatedBloggerList
as
Select  BlogID
From blog_Config  with(nolock)
where  PostCount> 0 and blog_Config.Flag & 2 = 2  and blog_Config.IsActive=1
order by LastUpdated desc
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

