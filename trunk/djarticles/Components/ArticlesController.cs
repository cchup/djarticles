using System;
using System.Configuration;
using System.Data;
using System.Xml;
using System.Web;
using System.Collections.Generic;

using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Search;
using DotNetNuke.Entities.Modules;
using DjArticles.Common;
using System.Data.Common;

namespace DjArticles.Components
{

    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// The Controller class for Articles 
    /// </summary> 
    /// <remarks> 
    /// </remarks> 
    /// <history> 
    /// </history> 
    /// ----------------------------------------------------------------------------- 
    public class ArticlesController : ISearchable, IPortable
    {

        #region "Public Methods"

        /// <summary>
        /// 查询所有的文章
        /// </summary>
        /// <returns></returns>
        public List<ArticleInfo> GetArticles()
        {
            return CBO.FillCollection<ArticleInfo>(DataProvider.Instance().GetAllArticles());
        }

        /// <summary>
        /// 查询文章列表
        /// </summary>
        /// <param name="filterByCategory">是否按分类进行查询</param>
        /// <param name="filterCategoryID">要查询的分类</param>
        /// <param name="willPage">是否分页</param>
        /// <param name="articlesPerPage">分页大小</param>
        /// <returns></returns>
        public List<ArticleInfo> GetArticlesList(bool filterByCategory, int filterCategoryID, bool willPage,int pageSize,int currentPage,out int totalCount)
        {
            if (filterByCategory && (filterCategoryID == Null.NullInteger || filterCategoryID == 0))
            {
                throw new ArticlesException("按分类查询时，分类标识ID必须指定！");
            }
            if (willPage && (pageSize == Null.NullInteger || pageSize == 0))
            {
                throw new ArticlesException("分页大小必须指定！");
            }
            // 下面的代码注释掉：如果不按模块分类，可能系统接受模块ID参数也可以查询指定模块
            //if (!filterByCategory)
            //{
            //    filterCategoryID = Null.NullInteger;
            //}
            if (willPage)
            {
                DbParameter paTotalCount = DataProvider.Instance().GetParameter("totalCount", Null.NullInteger);
                List<ArticleInfo> articles = CBO.FillCollection<ArticleInfo>(DataProvider.Instance().GetArticlesByPage(filterCategoryID, pageSize, currentPage, paTotalCount));
                if (paTotalCount.Value!=null)
                {
                    totalCount = (int)paTotalCount.Value;
                }
                else
                {
                    totalCount = 0;
                }
                return articles;
            }
            else
            {
                List<ArticleInfo> articles = this.GetArticles(filterCategoryID);
                totalCount = articles.Count;
                return articles;
            }
        }

        /// <summary>
        /// 查获分类文章，如果没有置顶分类查询所有的文章
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<ArticleInfo> GetArticles(int categoryId)
        {
            if (categoryId == Null.NullInteger)
            {
                return this.GetArticles();
            }
            else
            {
                return CBO.FillCollection<ArticleInfo>(DataProvider.Instance().GetArticles(categoryId));
            }
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="objArticles"></param>
        public void AddArticle(ArticleInfo article)
        {
            if (article == null)
            {
                return;
            }
            DataProvider.Instance().AddArticle(article.CategoryID, article.Title, article.CreatedByUserName,article.CreatedByUserID,
                article.CreatedDate,article.CopyFrom,article.Author,article.KeyWords,
                article.Summary,article.Content,article.Hot,article.OnTop,
                article.Stars,article.Passed,article.Hits,article.DefaultPicUrl,
                article.AllowPrint,article.AllowComment,article.CommentCount);
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="objArticles"></param>
        public void UpdateArticle(ArticleInfo article)
        {
            if (article == null)
            {
                return;
            }
            DataProvider.Instance().UpdateArticle(article.ArticleID,article.CategoryID, article.Title, article.CreatedByUserName, article.CreatedByUserID,
                 article.CreatedDate, article.CopyFrom, article.Author, article.KeyWords,
                 article.Summary, article.Content, article.Hot, article.OnTop,
                 article.Stars, article.Passed, article.Hits, article.DefaultPicUrl,
                 article.AllowPrint, article.AllowComment, article.CommentCount);
        }

        /// <summary>
        /// 获取文章
        /// </summary>
        /// <param name="articleId">文章Id</param>
        /// <returns>文章对象</returns>
        public ArticleInfo GetArticle(int articleId)
        {
            if (articleId == Null.NullInteger)
            {
                return null;
            }
            return CBO.FillObject<ArticleInfo>(DataProvider.Instance().GetArticle(articleId));
        }

        /// <summary>
        /// 保存文章，如果存在则更新否则新增
        /// </summary>
        /// <param name="article"></param>
        public void SaveArticle(ArticleInfo article)
        {
            if (article == null)
            {
                return;
            }
            article.CreatedDate = DateTime.Now;
            if (article.ArticleID == Null.NullInteger)
            {
                AddArticle(article);
            }
            else
            {
                UpdateArticle(article);
            }
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="articleId"></param>
        public void DeleteArticle(int articleId)
        {
            if (Null.IsNull(articleId))
            {
                return;
            }
            DataProvider.Instance().DeleteArticle(articleId);
        }

        #endregion

        #region "Optional Interfaces"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// GetSearchItems implements the ISearchable Interface 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
        {

            SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

            //List<ArticleInfo> colArticless = GetArticless(ModInfo.ModuleID);
            //foreach (ArticleInfo objArticles in colArticless)
            //{
            //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objArticles.Content, objArticles.CreatedByUserID, objArticles.CreatedDate, ModInfo.ModuleID, objArticles.ArticleID.ToString(), objArticles.Content, "ItemId=" + objArticles.ArticleID.ToString());
            //    SearchItemCollection.Add(SearchItem);
            //}

            return SearchItemCollection;

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// ExportModule implements the IPortable ExportModule Interface 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleID">The Id of the module to be exported</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public string ExportModule(int ModuleID)
        {

            string strXML = "";

            List<ArticleInfo> colArticless = GetArticles(ModuleID);
            if (colArticless.Count != 0)
            {
                strXML += "<Articless>";
                foreach (ArticleInfo objArticles in colArticless)
                {
                    strXML += "<Articles>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objArticles.Content) + "</content>";
                    strXML += "</Articles>";
                }
                strXML += "</Articless>";
            }

            return strXML;

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// ImportModule implements the IPortable ImportModule Interface 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleID">The Id of the module to be imported</param> 
        /// <param name="Content">The content to be imported</param> 
        /// <param name="Version">The version of the module to be imported</param> 
        /// <param name="UserId">The Id of the user performing the import</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
        {

            XmlNode xmlArticless = Globals.GetContent(Content, "Articless");
            foreach (XmlNode xmlArticles in xmlArticless.SelectNodes("Articles"))
            {
                ArticleInfo objArticles = new ArticleInfo();
                objArticles.Content = xmlArticles.SelectSingleNode("content").InnerText;
                objArticles.CreatedByUserID = UserId;
                AddArticle(objArticles);
            }

        }

        #endregion

    }
}