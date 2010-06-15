using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetNuke.Common;
using System.Collections.Generic;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules.Actions;
using DjArticles.Components;

namespace DjArticles
{
    /// <summary>
    /// 文章列表的基类，用户可以根据此基础定制不同的现实效果
    /// </summary>
    public partial class ArticlesListBase : ArticlePortalModuleBase, IActionable
    {
        #region Controls
        /// <summary>
        /// 更多按钮
        /// </summary>
        protected global::System.Web.UI.WebControls.HyperLink lnkReadMore;
        /// <summary>
        /// 消息提示框
        /// </summary>
        protected global::System.Web.UI.WebControls.Label lblMessage;
        /// <summary>
        /// 文章列表控件
        /// </summary>
        protected global::System.Web.UI.WebControls.Repeater lstArticles;
        /// <summary>
        /// 文章列表分页控件
        /// </summary>
        protected global::DotNetNuke.UI.WebControls.PagingControl ctlPagingControl;
        #endregion

        #region Private Members

        ArticlesController articleController = new ArticlesController();
        ModuleController moduleController = new ModuleController();
        /// <summary>
        /// 是否按类别查询
        /// </summary>
        private bool filterByCategory = false;
        /// <summary>
        /// 分类类别
        /// </summary>
        private int filterCategoryID = Null.NullInteger;
        /// <summary>
        /// 是否分页
        /// </summary>
        private bool willPage = true;
        /// <summary>
        /// 每页大小
        /// </summary>
        private int articlesPerPage = 10;
        /// <summary>
        /// 文章详细模块名称
        /// </summary>
        private readonly string DetailModuleName = "DjArticles-Detail";
        private readonly string DetailModuleControlName = "ArticleDetail";
        #endregion

        #region Member Methods

        /// <summary>
        /// 获取绑定数据源
        /// </summary>
        /// <returns></returns>
        private void GetDataPage()
        {
            filterByCategory = GetSettingBool("FilterByCategory", false);
            bool AcceptParameter = GetSettingBool("AcceptParameter", false);
            if (filterByCategory)
            {
                //如果设置指定按模块分类查询，则必须指定分类模块ID
                filterCategoryID = GetSettingInt("FilterCategoryID", Null.NullInteger);
            }
            else if (AcceptParameter)
            {
                // 如果未设置按模块分类查询， 但指定可以接受模块ID参数时也可以查询指定的模块
                filterCategoryID = GetIntParameter("CategoryId");
            }
            willPage = GetSettingBool("WillPage", false);
            articlesPerPage = GetSettingInt("ArticlesPerPage", 10);
            int currentPage= GetIntParameter("CurrentPage");
            int totalCount=0;
            List<ArticleInfo> articles= articleController.GetArticlesList(filterByCategory, filterCategoryID, willPage, articlesPerPage, currentPage, out totalCount);
            this.lstArticles.DataSource = articles;
            this.lstArticles.DataBind();
            if (willPage)
            {
                this.ctlPagingControl.Visible = true;
                this.ctlPagingControl.CurrentPage = currentPage;
                this.ctlPagingControl.PageSize = articlesPerPage;
                this.ctlPagingControl.TotalRecords = totalCount;
            }
            else
            {
                this.ctlPagingControl.Visible = false;
            }
        }

        /// <summary>
        /// 显示文章内容
        /// </summary>
        /// <param name="e"></param>
        private void ShowArticles(RepeaterItemEventArgs e)
        {
            HyperLink lnkReadMore = e.Item.FindControl("lnkReadMore") as HyperLink;
            if (lnkReadMore == null)
            {
                lnkReadMore = new HyperLink();
            }
            Image articleImage = e.Item.FindControl("imgArticleImage") as Image;
            if (articleImage == null)
            {
                articleImage = new Image();
            }
            object _objPicUrl =DataBinder.Eval(e.Item.DataItem, "DefaultPicUrl");
            if (_objPicUrl != null)
            {
                articleImage.ImageUrl = _objPicUrl.ToString();
            }
            if (string.IsNullOrEmpty(articleImage.ImageUrl))
            {
                articleImage.Visible = false;
            }
        }

        /// <summary>
        /// 找到文章详细信息的Url
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        protected string GetArticleDetailUrl(object articleId)
        {
            int _articleId = Null.NullInteger;
            if (articleId != null)
            {
                
                if(!int.TryParse(articleId.ToString(),out _articleId)){
                    _articleId=Null.NullInteger;
                }
            }
            if (Null.IsNull(_articleId))
            {
                return Globals.NavigateURL();
            }
            int detailTablId=Null.NullInteger;
            ModuleInfo module = moduleController.GetModuleByDefinition(this.PortalId, DetailModuleName);
            if (module != null)
            {
                detailTablId = module.TabID;
            }
            if (!Null.IsNull(detailTablId))
            {
                return Globals.NavigateURL(detailTablId, "", "ArticleID=" + _articleId);
            }
            else
            {
                return this.EditUrl("ArticleID", _articleId.ToString(), "ArticleView");
            }
        }

        /// <summary>
        /// 获取更多链接Url
        /// </summary>
        /// <returns></returns>
        protected string GetMoreArticleDetialUrl()
        {
            int filterCategoryID = GetSettingInt("FilterCategoryID", Null.NullInteger);
            int moreTabId = GetSettingInt("MoreArticlesPage");
            if (!Null.IsNull(moreTabId))
            {
                return Globals.NavigateURL(moreTabId, "", "CategoryId=" + filterCategoryID);
            }
            else
            {
                return Globals.NavigateURL();
            }
        }

        /// <summary>
        /// 显示评论内容
        /// </summary>
        /// <param name="e"></param>
        private void ShowComments(RepeaterItemEventArgs e)
        {
        }
        #endregion

        #region Event Handler

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetDataPage();
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.LocalResourceFile = Localization.GetResourceFile(this, "ArticlesList.ascx").Replace("/Templates", "");
        }


        protected void Item_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                ShowArticles(e);
            }
        }

        #endregion

        #region IActionable 成员

        public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection actions = new ModuleActionCollection();
                //actions.Add(GetNextActionID(), Localization.GetString(ArticleActionType.ArticlesListSettings,this.LocalResourceFile), ArticleActionType.ArticlesListSettings, "", "", EditUrl("ArticlesListSettings"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                return actions;
            }
        }

        #endregion
    }
}
