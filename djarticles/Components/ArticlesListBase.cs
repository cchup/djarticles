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

namespace DjArticles.Components
{
    /// <summary>
    /// 文章列表的基类，用户可以根据此基础定制不同的现实效果
    /// </summary>
    public class ArticlesListBase : ArticlePortalModuleBase,IActionable
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
        protected global::System.Web.UI.WebControls.DataList lstArticles;
        /// <summary>
        /// 文章列表分页控件
        /// </summary>
        protected global::DotNetNuke.UI.WebControls.PagingControl ctlPagingControl;
        #endregion

        #region Private Members

        ArticlesController articleController = new ArticlesController();
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
        #endregion

        #region Member Methods

        /// <summary>
        /// 获取绑定数据源
        /// </summary>
        /// <returns></returns>
        private List<ArticleInfo> GetDataPage()
        {
            filterByCategory = GetSettingBool("FilterByCategory", false);
            filterCategoryID = GetSettingInt("FilterCategoryID", Null.NullInteger);
            willPage = GetSettingBool("WillPage", true);
            articlesPerPage = GetSettingInt("ArticlesPerPage", 10);
            return articleController.GetArticles();
        }

        #endregion

        #region Event Handler

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.LocalResourceFile = Localization.GetResourceFile(this, "ArticlesList.ascx").Replace("/Templates", "");
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
