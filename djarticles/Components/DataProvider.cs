using System;
using DotNetNuke.Framework;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
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
        public abstract int AddArticle( int CategoryID, string Title, string CreatedByUserName, int CreatedByUserID, DateTime CreatedDate, string CopyFrom, string Author, string KeyWords, string Summary, string Content, bool Hot, bool OnTop, int Stars, bool Passed, int Hits, string DefaultPicUrl, bool AllowPrint, bool AllowComment, int CommentCount );
        public abstract int AddCategory(string Name, string Description, int ParentID, int Depth, int ViewOrder, string AdminRoles, string EditRoles, string ViewRoles, int CreatedByUserID, string CreatedByUserName, DateTime CreatedDate, bool IsActive);
        public abstract int AddComment(int ArticleID, string Title, string Comment, long ReferenceCommentID, long ParentID, int CreatedByUserID, string CreatedByUserName, DateTime CreatedDate, string QQ, string MSN, string Email, string Homepage, string IP);
        public abstract IDataReader GetArticles(int categoryId);
        public abstract IDataReader GetArticlesByPage(int categoryId, int pageSize, int currentPage, DbParameter paTotalCount);
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

        public abstract DbParameter GetParameter(string name, object value);
    }
}