USE [BroadWisdom]
GO
/****** 对象:  User [BroadWisdom]    脚本日期: 05/16/2010 16:27:12 ******/
CREATE USER [BroadWisdom] FOR LOGIN [BroadWisdom] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** 对象:  Table [dbo].[dj_DjArticles_Category]    脚本日期: 05/16/2010 16:27:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dj_DjArticles_Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[ParentID] [int] NOT NULL,
	[Depth] [int] NOT NULL,
	[ViewOrder] [int] NOT NULL,
	[AdminRoles] [nvarchar](255) NULL,
	[EditRoles] [nvarchar](255) NULL,
	[ViewRoles] [nvarchar](255) NULL,
	[CreatedByUserID] [nvarchar](100) NULL,
	[CreatedByUserName] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[IsActive] [bit] NULL DEFAULT ((1)),
 CONSTRAINT [PK_dj_DjArticles_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[dj_DjArticles_Article]    脚本日期: 05/16/2010 16:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dj_DjArticles_Article](
	[ArticleID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedByUserName] [nvarchar](100) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[CreatedByUserID] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CopyFrom] [nvarchar](255) NOT NULL,
	[Author] [nvarchar](255) NOT NULL,
	[KeyWords] [nvarchar](255) NOT NULL,
	[Summary] [nvarchar](2000) NOT NULL,
	[Content] [ntext] NOT NULL,
	[Hot] [bit] NOT NULL,
	[OnTop] [bit] NOT NULL,
	[Stars] [tinyint] NOT NULL,
	[Passed] [bit] NOT NULL,
	[Hits] [int] NOT NULL,
	[DefaultPicUrl] [nvarchar](255) NOT NULL,
	[AllowPrint] [bit] NULL,
	[AllowComment] [bit] NULL,
	[CommentCount] [int] NULL,
 CONSTRAINT [PK_dj_DjArticles_Article] PRIMARY KEY CLUSTERED 
(
	[ArticleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[dj_DjArticles_Comment]    脚本日期: 05/16/2010 16:27:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dj_DjArticles_Comment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[ArticleID] [int] NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Comment] [ntext] NOT NULL,
	[ReferenceCommentID] [int] NULL,
	[ParentID] [int] NULL,
	[CreatedByUserID] [nvarchar](100) NULL,
	[CreatedByUserName] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[QQ] [nvarchar](16) NOT NULL,
	[MSN] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Homepage] [nvarchar](255) NOT NULL,
	[IP] [varchar](15) NOT NULL,
 CONSTRAINT [PK_dj_DjArticles_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Category_Insert]    脚本日期: 05/16/2010 16:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------
-- Insert a single record into dj_DjArticles_Category
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Category_Insert]
	@ModuleID int,
	@Name nvarchar(510),
	@Description nvarchar(4000),
	@ParentID int,
	@Depth int,
	@ViewOrder int,
	@AdminRoles nvarchar(510) = NULL,
	@EditRoles nvarchar(510) = NULL,
	@ViewRoles nvarchar(510) = NULL,
	@CreatedByUserID nvarchar(200) = NULL,
	@CreatedByUserName nvarchar(200) = NULL,
	@CreatedDate datetime = NULL,
	@IsActive bit = NULL
AS

INSERT dj_DjArticles_Category(ModuleID, Name, Description, ParentID, Depth, ViewOrder, AdminRoles, EditRoles, ViewRoles, CreatedByUserID, CreatedByUserName, CreatedDate, IsActive)
VALUES (@ModuleID, @Name, @Description, @ParentID, @Depth, @ViewOrder, @AdminRoles, @EditRoles, @ViewRoles, @CreatedByUserID, @CreatedByUserName, @CreatedDate, COALESCE(@IsActive, (1)))

RETURN SCOPE_IDENTITY()
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Category_Update]    脚本日期: 05/16/2010 16:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------
-- Update a single record in dj_DjArticles_Category
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Category_Update]
	@CategoryID int,
	@ModuleID int,
	@Name nvarchar(510),
	@Description nvarchar(4000),
	@ParentID int,
	@Depth int,
	@ViewOrder int,
	@AdminRoles nvarchar(510) = NULL,
	@EditRoles nvarchar(510) = NULL,
	@ViewRoles nvarchar(510) = NULL,
	@CreatedByUserID nvarchar(200) = NULL,
	@CreatedByUserName nvarchar(200) = NULL,
	@CreatedDate datetime = NULL,
	@IsActive bit = NULL
AS

UPDATE	dj_DjArticles_Category
SET	ModuleID = @ModuleID,
	Name = @Name,
	Description = @Description,
	ParentID = @ParentID,
	Depth = @Depth,
	ViewOrder = @ViewOrder,
	AdminRoles = @AdminRoles,
	EditRoles = @EditRoles,
	ViewRoles = @ViewRoles,
	CreatedByUserID = @CreatedByUserID,
	CreatedByUserName = @CreatedByUserName,
	CreatedDate = @CreatedDate,
	IsActive = COALESCE(@IsActive, (1))
WHERE 	CategoryID = @CategoryID
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Category_Delete]    脚本日期: 05/16/2010 16:26:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
----------------------------------------------------------------------------
-- Delete a single record from dj_DjArticles_Category
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Category_Delete]
	@CategoryID int
AS

DELETE	dj_DjArticles_Category
WHERE 	CategoryID = @CategoryID
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Category_Select]    脚本日期: 05/16/2010 16:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
----------------------------------------------------------------------------
-- Select a single record from dj_DjArticles_Category
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Category_Select]
	@CategoryID int
AS

SELECT	CategoryID,
	ModuleID,
	Name,
	Description,
	ParentID,
	Depth,
	ViewOrder,
	AdminRoles,
	EditRoles,
	ViewRoles,
	CreatedByUserID,
	CreatedByUserName,
	CreatedDate,
	IsActive
FROM	dj_DjArticles_Category
WHERE 	CategoryID = @CategoryID
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Category_GetAllCategorys]    脚本日期: 05/16/2010 16:26:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[dj_DjArticles_Category_GetAllCategorys]
	@ModuleId int
AS
SELECT dj_DjArticles_Category.*
FROM         dj_DjArticles_Category where moduleid= @ModuleId order by ParentId
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Article_Update]    脚本日期: 05/16/2010 16:26:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------
-- Update a single record in dj_DjArticles_Article
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Article_Update]
	@ArticleID int,
	@CreatedByUserName nvarchar(200),
	@Title nvarchar(510),
	@CreatedByUserID nvarchar(200),
	@CreatedDate datetime,
	@CopyFrom nvarchar(510),
	@Author nvarchar(510),
	@KeyWords nvarchar(510),
	@Summary nvarchar(4000),
	@Content ntext,
	@Hot bit,
	@OnTop bit,
	@Stars tinyint,
	@Passed bit,
	@Hits int,
	@DefaultPicUrl nvarchar(510),
	@AllowPrint bit = NULL,
	@AllowComment bit = NULL,
	@CommentCount int = NULL
AS

UPDATE	dj_DjArticles_Article
SET	CreatedByUserName = @CreatedByUserName,
	Title = @Title,
	CreatedByUserID = @CreatedByUserID,
	CreatedDate = @CreatedDate,
	CopyFrom = @CopyFrom,
	Author = @Author,
	KeyWords = @KeyWords,
	Summary = @Summary,
	Content = @Content,
	Hot = @Hot,
	OnTop = @OnTop,
	Stars = @Stars,
	Passed = @Passed,
	Hits = @Hits,
	DefaultPicUrl = @DefaultPicUrl,
	AllowPrint = @AllowPrint,
	AllowComment = @AllowComment,
	CommentCount = @CommentCount
WHERE 	ArticleID = @ArticleID
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Article_Select]    脚本日期: 05/16/2010 16:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
----------------------------------------------------------------------------
-- Select a single record from dj_DjArticles_Article
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Article_Select]
	@ArticleID int
AS

SELECT	ArticleID,
	CreatedByUserName,
	Title,
	CreatedByUserID,
	CreatedDate,
	CopyFrom,
	Author,
	KeyWords,
	Summary,
	Content,
	Hot,
	OnTop,
	Stars,
	Passed,
	Hits,
	DefaultPicUrl,
	AllowPrint,
	AllowComment,
	CommentCount
FROM	dj_DjArticles_Article
WHERE 	ArticleID = @ArticleID
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Article_Delete]    脚本日期: 05/16/2010 16:26:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
----------------------------------------------------------------------------
-- Delete a single record from dj_DjArticles_Article
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Article_Delete]
	@ArticleID int
AS

DELETE	dj_DjArticles_Article
WHERE 	ArticleID = @ArticleID
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Article_Insert]    脚本日期: 05/16/2010 16:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------
-- Insert a single record into dj_DjArticles_Article
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Article_Insert]
	@CreatedByUserName nvarchar(200),
	@Title nvarchar(510),
	@CreatedByUserID nvarchar(200),
	@CreatedDate datetime,
	@CopyFrom nvarchar(510),
	@Author nvarchar(510),
	@KeyWords nvarchar(510),
	@Summary nvarchar(4000),
	@Content ntext,
	@Hot bit,
	@OnTop bit,
	@Stars tinyint,
	@Passed bit,
	@Hits int,
	@DefaultPicUrl nvarchar(510),
	@AllowPrint bit = NULL,
	@AllowComment bit = NULL,
	@CommentCount int = NULL
AS

INSERT dj_DjArticles_Article(CreatedByUserName, Title, CreatedByUserID, CreatedDate, CopyFrom, Author, KeyWords, Summary, Content, Hot, OnTop, Stars, Passed, Hits, DefaultPicUrl, AllowPrint, AllowComment, CommentCount)
VALUES (@CreatedByUserName, @Title, @CreatedByUserID, @CreatedDate, @CopyFrom, @Author, @KeyWords, @Summary, @Content, @Hot, @OnTop, @Stars, @Passed, @Hits, @DefaultPicUrl, @AllowPrint, @AllowComment, @CommentCount)

RETURN SCOPE_IDENTITY()
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Comment_Insert]    脚本日期: 05/16/2010 16:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------
-- Insert a single record into dj_DjArticles_Comment
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Comment_Insert]
	@ArticleID int = NULL,
	@Title nvarchar(510),
	@Comment ntext,
	@ReferenceCommentID int = NULL,
	@ParentID int = NULL,
	@CreatedByUserID nvarchar(200) = NULL,
	@CreatedByUserName nvarchar(200),
	@CreatedDate datetime,
	@QQ nvarchar(32),
	@MSN nvarchar(510),
	@Email nvarchar(510),
	@Homepage nvarchar(510),
	@IP varchar(15)
AS

INSERT dj_DjArticles_Comment(ArticleID, Title, Comment, ReferenceCommentID, ParentID, CreatedByUserID, CreatedByUserName, CreatedDate, QQ, MSN, Email, Homepage, IP)
VALUES (@ArticleID, @Title, @Comment, @ReferenceCommentID, @ParentID, @CreatedByUserID, @CreatedByUserName, @CreatedDate, @QQ, @MSN, @Email, @Homepage, @IP)

RETURN SCOPE_IDENTITY()
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Comment_Update]    脚本日期: 05/16/2010 16:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------
-- Update a single record in dj_DjArticles_Comment
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Comment_Update]
	@CommentID int,
	@ArticleID int = NULL,
	@Title nvarchar(510),
	@Comment ntext,
	@ReferenceCommentID int = NULL,
	@ParentID int = NULL,
	@CreatedByUserID nvarchar(200) = NULL,
	@CreatedByUserName nvarchar(200),
	@CreatedDate datetime,
	@QQ nvarchar(32),
	@MSN nvarchar(510),
	@Email nvarchar(510),
	@Homepage nvarchar(510),
	@IP varchar(15)
AS

UPDATE	dj_DjArticles_Comment
SET	ArticleID = @ArticleID,
	Title = @Title,
	Comment = @Comment,
	ReferenceCommentID = @ReferenceCommentID,
	ParentID = @ParentID,
	CreatedByUserID = @CreatedByUserID,
	CreatedByUserName = @CreatedByUserName,
	CreatedDate = @CreatedDate,
	QQ = @QQ,
	MSN = @MSN,
	Email = @Email,
	Homepage = @Homepage,
	IP = @IP
WHERE 	CommentID = @CommentID
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Comment_Delete]    脚本日期: 05/16/2010 16:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
----------------------------------------------------------------------------
-- Delete a single record from dj_DjArticles_Comment
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Comment_Delete]
	@CommentID int
AS

DELETE	dj_DjArticles_Comment
WHERE 	CommentID = @CommentID
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Comment_Select]    脚本日期: 05/16/2010 16:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
----------------------------------------------------------------------------
-- Select a single record from dj_DjArticles_Comment
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Comment_Select]
	@CommentID int
AS

SELECT	CommentID,
	ArticleID,
	Title,
	Comment,
	ReferenceCommentID,
	ParentID,
	CreatedByUserID,
	CreatedByUserName,
	CreatedDate,
	QQ,
	MSN,
	Email,
	Homepage,
	IP
FROM	dj_DjArticles_Comment
WHERE 	CommentID = @CommentID
GO
