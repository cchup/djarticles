using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetNuke.Framework.Providers;
using DjArticles.Components;
using Microsoft.ApplicationBlocks.Data;
using Microsoft.VisualBasic.CompilerServices;
using System.Data.SqlClient;

namespace DjArticles.Providers.Data_Providers
{
    public class SqlDataProvider : DataProvider
    {
        private string _connectionString;
        private string _databaseOwner;
        private string _objectQualifier;
        private string _providerPath;
        private string _moduleDataPrefix = "DjArticles_";
        private const string ProviderType = "data";

        // 构造函数
        public SqlDataProvider()
        {
            ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType);
            Provider provider = (Provider)_providerConfiguration.Providers[_providerConfiguration.DefaultProvider];
            if ((provider.Attributes["connectionStringName"] != "") && (ConfigurationManager.AppSettings[provider.Attributes["connectionStringName"]] != ""))
            {
                this._connectionString = ConfigurationManager.AppSettings[provider.Attributes["connectionStringName"]];
            }
            else
            {
                this._connectionString = provider.Attributes["connectionString"];
            }
            this._providerPath = provider.Attributes["providerPath"];
            this._objectQualifier = provider.Attributes["objectQualifier"];
            if (!String.IsNullOrEmpty(this._objectQualifier) && !this._objectQualifier.EndsWith("_"))
            {
                this._objectQualifier = this._objectQualifier + "_";
            }
            this._databaseOwner = provider.Attributes["databaseOwner"];
            if (!String.IsNullOrEmpty(this._databaseOwner) && !this._databaseOwner.EndsWith("."))
            {
                this._databaseOwner = this._databaseOwner + ".";
            }
        }

        /// <summary>
        /// 获取要执行命令的名称
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="operationName"></param>
        /// <returns></returns>
        private string getCommandName(string tableName, string operationName)
        {
            string commandName= this._databaseOwner + this._objectQualifier + this._moduleDataPrefix + tableName;
            if (!String.IsNullOrEmpty(operationName))
            {
                commandName += "_" + operationName;
            }
            return commandName;
        }

        #region Article
        /// <summary>
        /// 插入一篇文章
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <param name="Title"></param>
        /// <param name="CreatedByUser"></param>
        /// <param name="CreatedDate"></param>
        /// <param name="CopyFrom"></param>
        /// <param name="Author"></param>
        /// <param name="KeyWords"></param>
        /// <param name="Hot"></param>
        /// <param name="OnTop"></param>
        /// <param name="Elite"></param>
        /// <param name="Stars"></param>
        /// <param name="Passed"></param>
        /// <param name="Summary"></param>
        /// <param name="Content"></param>
        /// <param name="IncludePic"></param>
        /// <param name="DefaultPicUrl"></param>
        /// <param name="PaginationType"></param>
        /// <param name="MaxCharPerPage"></param>
        /// <returns></returns>
        public override int AddArticle( int CategoryID, string Title, string CreatedByUserName, int CreatedByUserID, DateTime CreatedDate, string CopyFrom, string Author, string KeyWords, string Summary, string Content, bool Hot, bool OnTop, int Stars, bool Passed, int Hits, string DefaultPicUrl,bool AllowPrint,bool AllowComment,int CommentCount)
        {
            string commandName = getCommandName("Article", "Insert");
            return Conversions.ToInteger(SqlHelper.ExecuteScalar(this._connectionString, commandName, 
                CategoryID, CreatedByUserName, Title,
                CreatedByUserID, CreatedDate, CopyFrom, Author,
                KeyWords, Summary, Content, Hot,
                OnTop, Stars, Passed, Hits,
                DefaultPicUrl, AllowPrint, AllowComment, CommentCount));
        }

        /// <summary>
        /// 获取某一分类的文章
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public override IDataReader GetArticles( int categoryId )
        {
            string commandName = getCommandName("Article", "SelectCategoryAll");
            return SqlHelper.ExecuteReader(this._connectionString, commandName, categoryId);
        }

        /// <summary>
        /// 查询所有文章，默认按照创建时间排序
        /// </summary>
        /// <returns></returns>
        public override IDataReader GetAllArticles()
        {
            string commandName = getCommandName("Article", "SelectAll");
            return SqlHelper.ExecuteReader(this._connectionString, commandName);
        }

        /// <summary>
        /// 获取文章
        /// </summary>
        /// <param name="categoryId">指定分类</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="totalCount">输出总数</param>
        /// <returns></returns>
        public override IDataReader GetArticlesByPage(int categoryId, int pageSize, int currentPage, SqlParameter paTotalCount)
        {
            string commandName = getCommandName("Article", "SelectArticlesByPage");
           
            SqlParameter paCategoryId=new SqlParameter("CategoryID",categoryId);
            SqlParameter paPageSize=new SqlParameter("pageSize",pageSize);
            SqlParameter paCurrentPage=new SqlParameter("currentPage",currentPage);
            if (paTotalCount != null)
            {
                paTotalCount.Direction = ParameterDirection.Output;
            }
            SqlHelper.ExecuteReader(this._connectionString, CommandType.StoredProcedure, commandName, paCategoryId, paPageSize, paCurrentPage, paTotalCount);
        }

        /// <summary>
        /// 查询当前文章
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public override IDataReader GetArticle(int articleId )
        {
            string commandName = getCommandName("Article", "Select");
            return SqlHelper.ExecuteReader(this._connectionString, commandName, articleId);
        }

        /// <summary>
        /// 删除当前文章
        /// </summary>
        /// <param name="articleID"></param>
        public override void DeleteArticle(int articleID)
        {
            string commandName = getCommandName("Article", "Delete");
            SqlHelper.ExecuteNonQuery(this._connectionString, commandName, articleID);
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="ArticleID"></param>
        /// <param name="CategoryID"></param>
        /// <param name="Title"></param>
        /// <param name="CreatedByUser"></param>
        /// <param name="CreatedDate"></param>
        /// <param name="CopyFrom"></param>
        /// <param name="Author"></param>
        /// <param name="KeyWords"></param>
        /// <param name="Hot"></param>
        /// <param name="OnTop"></param>
        /// <param name="Elite"></param>
        /// <param name="Stars"></param>
        /// <param name="Passed"></param>
        /// <param name="Summary"></param>
        /// <param name="Content"></param>
        /// <param name="IncludePic"></param>
        /// <param name="DefaultPicUrl"></param>
        /// <param name="PaginationType"></param>
        /// <param name="MaxCharPerPage"></param>
        /// <param name="IsUpdateCreatedInfo"></param>
        public override void UpdateArticle(int ArticleID, int CategoryID, string Title, string CreatedByUserName, int CreatedByUserID, DateTime CreatedDate, string CopyFrom, string Author, string KeyWords, string Summary, string Content, bool Hot, bool OnTop, int Stars, bool Passed, int Hits, string DefaultPicUrl, bool AllowPrint, bool AllowComment, int CommentCount)
        {
            string commandName = getCommandName("Article", "Update");
            SqlHelper.ExecuteNonQuery(this._connectionString, commandName,
                ArticleID, CategoryID, CreatedByUserName, Title,
                CreatedByUserID, CreatedDate, CopyFrom, Author,
                KeyWords, Summary, Content, Hot,
                OnTop, Stars, Passed, Hits,
                DefaultPicUrl, AllowPrint, AllowComment, CommentCount);
        }

        public override void UpdateArticleHits(int ArticleID)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Category
        
        /// <summary>
        /// 插入Category分类信息
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="ParentID"></param>
        /// <param name="ViewOrder"></param>
        /// <param name="AdminRoles"></param>
        /// <param name="EditRoles"></param>
        /// <param name="ViewRoles"></param>
        /// <param name="CreatedByUser"></param>
        /// <param name="CreatedDate"></param>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        public override int AddCategory( string Name, string Description, int ParentID,int Depth, int ViewOrder, string AdminRoles, string EditRoles, string ViewRoles, int CreatedByUserID, string CreatedByUserName, DateTime CreatedDate, bool IsActive)
        {
            string commandName = getCommandName("Category", "Insert");
            return Conversions.ToInteger(SqlHelper.ExecuteScalar(this._connectionString, commandName, Name, Description, ParentID,Depth, ViewOrder, AdminRoles, EditRoles, ViewRoles, CreatedByUserID, CreatedByUserName, CreatedDate, IsActive));

        }

        /// <summary>
        /// 删除一个分类信息
        /// </summary>
        /// <param name="CategoryID"></param>
        public override void DeleteCategory( int CategoryID )
        {
            string commandName = getCommandName("Category", "Delete");
            SqlHelper.ExecuteNonQuery(this._connectionString, commandName, CategoryID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Depth"></param>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public override IDataReader GetCategories(  int Depth, int ParentID )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有的分类信息
        /// </summary>
        /// <returns></returns>
        public override IDataReader GetAllCategorys( )
        {
            string commandName = getCommandName("Category", "GetAllCategorys");
            return SqlHelper.ExecuteReader(this._connectionString, commandName);
        }

        /// <summary>
        /// 查询一个分类信息
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public override IDataReader GetCategory( int CategoryID)
        {
            string commandName = getCommandName("Category", "Select");
            return SqlHelper.ExecuteReader(this._connectionString, commandName, CategoryID);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="ViewOrder"></param>
        /// <param name="AdminRoles"></param>
        /// <param name="EditRoles"></param>
        /// <param name="ViewRoles"></param>
        /// <param name="CreatedByUserName"></param>
        /// <param name="createByUserId"></param>
        /// <param name="CreatedDate"></param>
        /// <param name="IsActive"></param>
        public override void UpdateCategory(int CategoryID, string Name, string Description,int ParentID, int Depth, int ViewOrder, string AdminRoles, string EditRoles, string ViewRoles, string CreatedByUserName, int createByUserId, DateTime CreatedDate, bool IsActive)
        {
            string commandName = getCommandName("Category", "Update");
            SqlHelper.ExecuteNonQuery(this._connectionString, commandName, CategoryID, Name, Description, ParentID, 
                Depth, ViewOrder, AdminRoles, EditRoles, ViewRoles, CreatedByUserName, createByUserId, CreatedDate, IsActive);
        }

        #endregion

        #region Comment

        /// <summary>
        /// 插入评论信息
        /// </summary>
        /// <param name="ArticleID"></param>
        /// <param name="Title"></param>
        /// <param name="Comment"></param>
        /// <param name="CreatedByUser"></param>
        /// <param name="CreatedDate"></param>
        /// <param name="QQ"></param>
        /// <param name="MSN"></param>
        /// <param name="Email"></param>
        /// <param name="Homepage"></param>
        /// <param name="IP"></param>
        /// <param name="Score"></param>
        /// <returns></returns>
        public override int AddComment(int ArticleID, string Title, string Comment, long ReferenceCommentID, long ParentID, int CreatedByUserID, string CreatedByUserName, DateTime CreatedDate, string QQ, string MSN, string Email, string Homepage, string IP)
        {
            string commandName = getCommandName("Comment", "Insert");
            return Conversions.ToInteger(SqlHelper.ExecuteScalar(this._connectionString, commandName, ArticleID, Title, Comment, ReferenceCommentID, ParentID, CreatedByUserID, CreatedByUserName, CreatedDate, QQ, MSN, Email, Homepage, IP));
        }

        public override void DeleteComment(int CommentID)
        {
            throw new NotImplementedException();
        }

        public override IDataReader GetComment(int CommentID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询所有的评论信息
        /// </summary>
        /// <param name="ArticleID"></param>
        /// <returns></returns>
        public override IDataReader GetCommentsByArticleID(int ArticleID)
        {
            string commandName = getCommandName("Comment", "SelectByArticle");
            return SqlHelper.ExecuteReader(_connectionString, commandName, ArticleID);
        }

        public override void UpdateComment(int CommentID, string Title, string Comment, string QQ, string MSN, string Email, string Homepage, string IP, int Score)
        {
            throw new NotImplementedException();
        }

        #endregion


        public override void DeleteSpecial(int specialID)
        {
            throw new NotImplementedException();
        }

        public override void DeleteSpecialArticle(int specialID, int articleID)
        {
            throw new NotImplementedException();
        }

        public override int GetArticleCountByCategoryID(int CategoryID)
        {
            throw new NotImplementedException();
        }

        public override IDataReader GetArticleManagerModules(int PortalId)
        {
            throw new NotImplementedException();
        }


    }
}
