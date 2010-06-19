using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetNuke.Entities.Modules;
using DjArticles.Components;
using DjArticles.Common;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common.Utilities;

namespace DjArticles
{
    public partial class ArticleManage : ArticlePortalModuleBase,IActionable
    {
        private ArticlesController controller = new ArticlesController();

        #region Private Method

        /// <summary>
        /// 绑定数据源
        /// </summary>
        private void BindArticlesSource()
        {
            this.grdArticles.DataSource = controller.GetAllArticles();
            this.grdArticles.DataBind();
        }


        /// <summary>
        /// 绑定分类数据源
        /// </summary>
        private void BindCategoryDataSource()
        {
            CategoryController categoryController = new CategoryController();
            this.cboCategory.DataSource = categoryController.GetCategoriesForDropDownList();
            this.cboCategory.DataBind();
        }

        #endregion

        #region  Event Handler

        protected void Page_Load(object sender, EventArgs e)
        {
            this.grdArticles.DataSourceBind += delegate { BindArticlesSource(); };
            if (!IsPostBack)
            {
                GridView articles = this.grdArticles as GridView;
                DotNetNuke.Services.Localization.Localization.LocalizeGridView(ref articles, this.LocalResourceFile);
                BindArticlesSource();
                BindCategoryDataSource();
            }   
        }

        /// <summary>
        /// 转到新增文章页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect(EditUrl("ArticleEdit"), true);
        }

        protected void btnPass_Click(object sender, EventArgs e)
        {

        }

        protected void btnNotPass_Click(object sender, EventArgs e)
        {

        }

        protected void cmdCategoryManage_Click(object sender, EventArgs e)
        {
            Response.Redirect(EditUrl("CategoryManage"), true);
        }


        protected void grdArticles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int articleId = Null.NullInteger;
            if (e.CommandArgument != null)
            {
                int.TryParse(e.CommandArgument.ToString(), out articleId);
            }
            if (Null.IsNull(articleId))
            {
                return;
            }
            switch (e.CommandName.ToLower())
            {
                case "deletearticle":
                    controller.DeleteArticle(articleId);
                    break;
                default:
                    break;
            }
            BindArticlesSource();
            ShowMessage("删除成功！");
        }

        protected void cmdSearch_Click(object sender, EventArgs e)
        {
            int categoryId= WebControlUtils.GetObjectIntValue(this.cboCategory);
            this.grdArticles.DataSource = controller.GetArticles(categoryId);
            this.grdArticles.DataBind();
        }

        #endregion

        #region IActionable 成员

        public ModuleActionCollection ModuleActions
        {
            get {
                ModuleActionCollection actions = new ModuleActionCollection();
                actions.Add(GetNextActionID(), Localization.GetString(ArticleActionType.CategoryManage,this.LocalResourceFile), ArticleActionType.CategoryManage, "", "", EditUrl("CategoryManage"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                actions.Add(GetNextActionID(), Localization.GetString(ArticleActionType.NewCategoryAction, this.LocalResourceFile), ArticleActionType.NewCategoryAction, "", "", EditUrl("CategoryEdit"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                actions.Add(GetNextActionID(), Localization.GetString(ArticleActionType.NewArticleAction, this.LocalResourceFile), ArticleActionType.NewArticleAction, "", "", EditUrl("ArticleEdit"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                return actions;
            }
        }

        #endregion

    }
}