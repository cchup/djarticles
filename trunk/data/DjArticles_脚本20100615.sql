GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Category_Delete]    脚本日期: 06/15/2010 10:07:53 ******/
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
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Article_Update]    脚本日期: 06/15/2010 10:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------
-- Update a single record in dj_DjArticles_Article
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Article_Update]
	@ArticleID int,
	@CategoryID int,
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
	CategoryID=@CategoryID,
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
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Article_Delete]    脚本日期: 06/15/2010 10:07:49 ******/
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
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Article_Insert]    脚本日期: 06/15/2010 10:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------
-- Insert a single record into dj_DjArticles_Article
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Article_Insert]
	@CategoryID int,
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

INSERT dj_DjArticles_Article(CategoryID,CreatedByUserName, Title, CreatedByUserID, CreatedDate, CopyFrom, Author, KeyWords, Summary, Content, Hot, OnTop, Stars, Passed, Hits, DefaultPicUrl, AllowPrint, AllowComment, CommentCount)
VALUES (@CategoryID,@CreatedByUserName, @Title, @CreatedByUserID, @CreatedDate, @CopyFrom, @Author, @KeyWords, @Summary, @Content, @Hot, @OnTop, @Stars, @Passed, @Hits, @DefaultPicUrl, @AllowPrint, @AllowComment, @CommentCount)

RETURN SCOPE_IDENTITY()
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Comment_Update]    脚本日期: 06/15/2010 10:07:57 ******/
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
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Comment_Delete]    脚本日期: 06/15/2010 10:07:55 ******/
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
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Comment_Select]    脚本日期: 06/15/2010 10:07:56 ******/
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
	IP,
	Approve,
	Oppose
FROM	dj_DjArticles_Comment
WHERE 	CommentID = @CommentID
GO
/****** 对象:  Table [dbo].[dj_DjArticles_Category]    脚本日期: 06/15/2010 10:08:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dj_DjArticles_Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[ParentID] [int] NOT NULL CONSTRAINT [DF_dj_DjArticles_Category_ParentID]  DEFAULT ((-1)),
	[Depth] [int] NOT NULL,
	[ViewOrder] [int] NULL,
	[AdminRoles] [nvarchar](255) NULL,
	[EditRoles] [nvarchar](255) NULL,
	[ViewRoles] [nvarchar](255) NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedByUserName] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF__dj_DjArti__IsAct__2F4FF79D]  DEFAULT ((1)),
 CONSTRAINT [PK_dj_DjArticles_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[dj_DjArticles_Article]    脚本日期: 06/15/2010 10:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dj_DjArticles_Article](
	[ArticleID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[CreatedByUserName] [nvarchar](100) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[CreatedByUserID] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CopyFrom] [nvarchar](255) NULL,
	[Author] [nvarchar](255) NULL,
	[KeyWords] [nvarchar](255) NULL,
	[Summary] [nvarchar](2000) NOT NULL,
	[Content] [ntext] NOT NULL,
	[Hot] [bit] NULL,
	[OnTop] [bit] NULL,
	[Stars] [tinyint] NULL,
	[Passed] [bit] NULL,
	[Hits] [int] NULL,
	[DefaultPicUrl] [nvarchar](255) NULL,
	[AllowPrint] [bit] NULL,
	[AllowComment] [bit] NULL,
	[CommentCount] [int] NULL,
 CONSTRAINT [PK_dj_DjArticles_Article] PRIMARY KEY CLUSTERED 
(
	[ArticleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[dj_DjArticles_Comment]    脚本日期: 06/15/2010 10:08:10 ******/
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
	[Approve] [int] NOT NULL CONSTRAINT [DF_dj_DjArticles_Comment_Approve]  DEFAULT ((0)),
	[Oppose] [int] NOT NULL CONSTRAINT [DF_dj_DjArticles_Comment_Oppose]  DEFAULT ((0)),
 CONSTRAINT [PK_dj_DjArticles_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支持个数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dj_DjArticles_Comment', @level2type=N'COLUMN',@level2name=N'Approve'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'反对个数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dj_DjArticles_Comment', @level2type=N'COLUMN',@level2name=N'Oppose'
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjPagination]    脚本日期: 06/15/2010 10:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[dj_DjPagination]
@tblName varchar(255), -- 表名
@strGetFields varchar(1000) = '*', -- 需要返回的列 
@fldName varchar(255)='''', -- 排序的字段名
@PageSize int = 10, -- 页尺寸
@PageIndex int = 1, -- 页码
@doCount bit = 0, -- 返回记录总数, 非 0 值则返回
@OrderType bit = 0, -- 设置排序类型, 非 0 值则降序
@strWhere varchar(1500) = '''' -- 查询条件 (注意: 不要加 where)
AS
declare @strSQL varchar(5000) -- 主语句
declare @strTmp varchar(110) -- 临时变量
declare @strOrder varchar(400) -- 排序类型

if @doCount != 0
begin
if @strWhere !=''''
set @strSQL = 'select count(*) as Total from [' + @tblName + '] where '+@strWhere
else
set @strSQL = 'select count(*) as Total from [' + @tblName + ']'
end
--以上代码的意思是如果@doCount传递过来的不是0，就执行总数统计。以下的所有代码都是@doCount为0的情况：
else
begin
if @OrderType != 0
begin
set @strTmp = '<(select min'
set @strOrder = ' order by [' + @fldName +'] desc'
--如果@OrderType不是0，就执行降序，这句很重要！
end
else
begin
set @strTmp = '>(select max'
set @strOrder = ' order by [' + @fldName +'] asc'
end

if @PageIndex = 1
begin
if @strWhere != '''' 

set @strSQL = 'select top ' + str(@PageSize) +' '+@strGetFields+ '
　　　　　　　　from [' + @tblName + '] where ' + @strWhere + ' ' + @strOrder
else

set @strSQL = 'select top ' + str(@PageSize) +' '+@strGetFields+ ' 
　　　　　　　　from ['+ @tblName + '] '+ @strOrder
--如果是第一页就执行以上代码，这样会加快执行速度
end
else
begin --以下代码赋予了@strSQL以真正执行的SQL代码
set @strSQL = 'select top ' + str(@PageSize) +' '+@strGetFields+ ' from ['
+ @tblName + '] where [' + @fldName + ']' + @strTmp + '(['+ @fldName + ']) 
　　　　　　from (select top ' + str((@PageIndex-1)*@PageSize) + ' ['+ @fldName + '] 
　　　　　　from [' + @tblName + ']' + @strOrder + ') as tblTmp)'+ @strOrder

if @strWhere != ''''
set @strSQL = 'select top ' + str(@PageSize) +' '+@strGetFields+ ' from ['
+ @tblName + '] where [' + @fldName + ']' + @strTmp + '(['
+ @fldName + ']) from (select top ' + str((@PageIndex-1)*@PageSize) + ' ['
+ @fldName + '] from [' + @tblName + '] where ' + @strWhere + ' '
+ @strOrder + ') as tblTmp) and ' + @strWhere + ' ' + @strOrder
end 

end 

exec (@strSQL)
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Article_SelectArticlesByPage]    脚本日期: 06/15/2010 10:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
----------------------------------------------------------------------------
-- 递归查询所有子分类的文章
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Article_SelectArticlesByPage]
	@CategoryID int,
	@pagesize int,
	@cureentpage int,
	@tatalCount int out
as
-- 递归所有的子分类
WITH stb 
AS(
	SELECT CategoryID,ParentID,[Name]
	FROM dj_DjArticles_Category 
	where dj_DjArticles_Category.CategoryID=@CategoryID
	UNION ALL 
	SELECT B.CategoryID,B.ParentID ,B.[Name]
	FROM stb A,[dj_DjArticles_Category] B 
	WHERE A.CategoryID=B.ParentID
)
--查询所有的总数
select @tatalCount=count(1) from dj_DjArticles_Article a inner join stb d on a.CategoryID=d.CategoryID
--关联获取所有的文章
select m.* from 
	(select top(@pagesize) * from
		(SELECT top(@pagesize*@cureentpage)	a.ArticleID,
				a.CategoryID,
				d.[Name] CategoryName,
				a.CreatedByUserName,
				a.Title,
				a.CreatedByUserID,
				a.CreatedDate,
				a.CopyFrom,
				a.Author,
				a.KeyWords,
				a.Summary,
				a.[Content],
				a.Hot,
				a.OnTop,
				a.Stars,
				a.Passed,
				a.Hits,
				a.DefaultPicUrl,
				a.AllowPrint,
				a.AllowComment,
				a.CommentCount
			FROM dj_DjArticles_Article a inner join stb d 
			on a.CategoryID=d.CategoryID
			order by a.CreatedDate desc )as t
		order by t.CreatedDate asc )as m
	order by m.CreatedDate desc
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Article_SelectCategoryAll]    脚本日期: 06/15/2010 10:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
----------------------------------------------------------------------------
-- 递归查询所有子分类的文章
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Article_SelectCategoryAll]
	@CategoryID int
AS
-- 递归所有的子分类
WITH stb 
AS( 
	SELECT CategoryID,ParentID,[Name]
	FROM dj_DjArticles_Category 
	where dj_DjArticles_Category.CategoryID=@CategoryID
	UNION ALL 
	SELECT B.CategoryID,B.ParentID ,B.[Name]
	FROM stb A,[dj_DjArticles_Category] B 
	WHERE A.CategoryID=B.ParentID
)
--关联获取所有的文章
SELECT	ArticleID,
	a.CategoryID,
	d.[Name] CategoryName,
	a.CreatedByUserName,
	a.Title,
	a.CreatedByUserID,
	a.CreatedDate,
	a.CopyFrom,
	a.Author,
	a.KeyWords,
	a.Summary,
	a.[Content],
	a.Hot,
	a.OnTop,
	a.Stars,
	a.Passed,
	a.Hits,
	a.DefaultPicUrl,
	a.AllowPrint,
	a.AllowComment,
	a.CommentCount
FROM	dj_DjArticles_Article a inner join stb d 
on a.CategoryID=d.CategoryID
order by a.CreatedDate
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Article_SelectAll]    脚本日期: 06/15/2010 10:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
----------------------------------------------------------------------------
-- Select a single record from dj_DjArticles_Article
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Article_SelectAll]
AS

SELECT	ArticleID,
	a.CategoryID,
	d.[Name] CategoryName,
	a.CreatedByUserName,
	a.Title,
	a.CreatedByUserID,
	a.CreatedDate,
	a.CopyFrom,
	a.Author,
	a.KeyWords,
	a.Summary,
	a.[Content],
	a.Hot,
	a.OnTop,
	a.Stars,
	a.Passed,
	a.Hits,
	a.DefaultPicUrl,
	a.AllowPrint,
	a.AllowComment,
	a.CommentCount
FROM	dj_DjArticles_Article a inner join dj_DjArticles_Category d 
on a.CategoryID=d.CategoryID
order by a.CreatedDate
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Category_Select]    脚本日期: 06/15/2010 10:07:54 ******/
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
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Category_GetAllCategorys]    脚本日期: 06/15/2010 10:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[dj_DjArticles_Category_GetAllCategorys]
AS
SELECT dj_DjArticles_Category.*
FROM         dj_DjArticles_Category order by ParentId,Name
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Category_Insert]    脚本日期: 06/15/2010 10:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------
-- Insert a single record into dj_DjArticles_Category
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Category_Insert]
	@Name nvarchar(510),
	@Description nvarchar(4000),
	@ParentID int,
	@Depth int,
	@ViewOrder int,
	@AdminRoles nvarchar(510) = NULL,
	@EditRoles nvarchar(510) = NULL,
	@ViewRoles nvarchar(510) = NULL,
	@CreatedByUserID int,
	@CreatedByUserName nvarchar(200) = NULL,
	@CreatedDate datetime = NULL,
	@IsActive bit = NULL
AS

INSERT dj_DjArticles_Category(Name, Description, ParentID, Depth, ViewOrder, AdminRoles, EditRoles, ViewRoles, CreatedByUserID, CreatedByUserName, CreatedDate, IsActive)
VALUES (@Name, @Description, @ParentID, @Depth, @ViewOrder, @AdminRoles, @EditRoles, @ViewRoles, @CreatedByUserID, @CreatedByUserName, @CreatedDate, COALESCE(@IsActive, (1)))

RETURN SCOPE_IDENTITY()
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Category_Update]    脚本日期: 06/15/2010 10:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------
-- Update a single record in dj_DjArticles_Category
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Category_Update]
	@CategoryID int,
	@Name nvarchar(510),
	@Description nvarchar(4000),
	@ParentID int,
	@Depth int,
	@ViewOrder int,
	@AdminRoles nvarchar(510) = NULL,
	@EditRoles nvarchar(510) = NULL,
	@ViewRoles nvarchar(510) = NULL,
	@CreatedByUserID int,
	@CreatedByUserName nvarchar(200) = NULL,
	@CreatedDate datetime = NULL,
	@IsActive bit = NULL
AS

UPDATE	dj_DjArticles_Category
SET	Name = @Name,
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
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Comment_Insert]    脚本日期: 06/15/2010 10:07:56 ******/
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
--更新评论数
update dj_DjArticles_Article set CommentCount=CommentCount+1 
where ArticleID=@ArticleID
RETURN SCOPE_IDENTITY()
GO
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Article_Select]    脚本日期: 06/15/2010 10:07:51 ******/
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
	CategoryID,
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
/****** 对象:  StoredProcedure [dbo].[dj_DjArticles_Comment_SelectByArticle]    脚本日期: 06/15/2010 10:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
----------------------------------------------------------------------------
-- Select a single record from dj_DjArticles_Comment
----------------------------------------------------------------------------
CREATE PROC [dbo].[dj_DjArticles_Comment_SelectByArticle]
	@ArticleID int
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
	IP,
	Approve,
	Oppose
FROM	dj_DjArticles_Comment
WHERE 	ArticleID = @ArticleID
Order by CreatedDate Desc
GO
