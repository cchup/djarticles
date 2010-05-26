using System;
using DotNetNuke.Framework;
using System.Data;
namespace DjArticles.Components
{
    /// 数据访问抽象实现类
    public abstract class DataProvider
    {
        private static DataProvider objProvider = null;

        static DataProvider()
        {
            CreateProvider();
        }
        private static void CreateProvider()
        {
            objProvider = (DataProvider)Reflection.CreateObject("djArticles");
        }
        public static DataProvider Instance()
        {
            return objProvider;
        }
        /**
        #region category info data access

        public abstract CategoryInfo GetCategoryByID();

        public abstract Array GetAllCategorys();

        public abstract int AddCategory(CategoryInfo categoryInfo);

        public abstract int DeleteCategoryByID(int categoryId);

        public abstract int UpdateCategory(CategoryInfo categoryInfo);

        #endregion

        #region article info data access
 
        public abstract ArticleInfo GetArticleByID(int articleId);

        public abstract Array GetArticlesByCategoryID_(int categoryId, int size);

        public abstract Array GetArticlesByCategoryID(int categoryId);

        public abstract int AddArticle(ArticleInfo articleInfo);

        public abstract int DeleteArticleByID(int articleId);

        public abstract int UpdateArticle(ArticleInfo articleInfo);

        public abstract int UpdateArticlePassState(int articleId, int isPass);

        public abstract int UpdateArticleStars(int articleId, int stars);

        public abstract int UpdateArticleHits(int articleId);

        public abstract int UpdateArticleOnTop(int articleId);

        #endregion

        #region comment info data access

        public abstract Array GetCommentsByIArticleID(int articleId);

        public abstract int AddComment(CommentInfo commentInfo);

        public abstract int DeleteComment(int commentId);

        public abstract int UpdateComment(int commentInfo);

        #endregion
        **/

        public abstract int AddArticle( int CategoryID, string Title, string CreatedByUserName, int CreatedByUserID, DateTime CreatedDate, string CopyFrom, string Author, string KeyWords, string Summary, string Content, bool Hot, bool OnTop, int Stars, bool Passed, int Hits, string DefaultPicUrl, bool AllowPrint, bool AllowComment, int CommentCount );
        public abstract int AddCategory(string Name, string Description, int ParentID, int Depth, int ViewOrder, string AdminRoles, string EditRoles, string ViewRoles, int CreatedByUserID, string CreatedByUserName, DateTime CreatedDate, bool IsActive);
        public abstract int AddComment(int ArticleID, string Title, string Comment, long ReferenceCommentID, long ParentID, int CreatedByUserID, string CreatedByUserName, DateTime CreatedDate, string QQ, string MSN, string Email, string Homepage, string IP);
        public abstract IDataReader GetArticles(int categoryId);
        public abstract IDataReader GetAllArticles();
        public abstract IDataReader GetArticle(int articleId);

        public abstract void DeleteArticle(int ArticleID);
        public abstract void DeleteCategory(int CategoryID);
        public abstract void DeleteComment(int CommentID);
        public abstract void DeleteSpecial(int specialID);
        public abstract void DeleteSpecialArticle(int specialID, int articleID);
        public abstract int GetArticleCountByCategoryID(int CategoryID);
        public abstract IDataReader GetArticleManagerModules(int PortalId);

        public abstract IDataReader GetCategories(int Depth, int ParentID);
        public abstract IDataReader GetCategory(int CategoryID);
        public abstract IDataReader GetAllCategorys();
        public abstract IDataReader GetComment(int CommentID);
        public abstract IDataReader GetCommentsByArticleID(int ArticleID);

        public abstract void UpdateArticle(int ArticleID, int CategoryID, string Title, string CreatedByUserName, int CreatedByUserID, DateTime CreatedDate, string CopyFrom, string Author, string KeyWords, string Summary, string Content, bool Hot, bool OnTop, int Stars, bool Passed, int Hits, string DefaultPicUrl, bool AllowPrint, bool AllowComment, int CommentCount);
        public abstract void UpdateArticleHits(int ArticleID);
        public abstract void UpdateCategory(int CategoryID,string Name, string Description, int ParentID, int Depth, int ViewOrder, string AdminRoles, string EditRoles, string ViewRoles, string CreatedByUserName, int createByUserId, DateTime CreatedDate, bool IsActive);
        public abstract void UpdateComment(int CommentID, string Title, string Comment, string QQ, string MSN, string Email, string Homepage, string IP, int Score);
    }
}