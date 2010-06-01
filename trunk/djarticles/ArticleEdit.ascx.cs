using System;
using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DjArticles.Components;
using DjArticles.Common;

namespace DjArticles
{

    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// </summary> 
    /// <remarks> 
    /// </remarks> 
    /// <history> 
    /// </history> 
    /// ----------------------------------------------------------------------------- 
    partial class ArticleEdit : ArticlePortalModuleBase
    {

        #region "Private Members"

        private ArticlesController controller = new ArticlesController();
        private int articleId = Null.NullInteger;

        #endregion

        #region Helper Method

        /// <summary>
        /// 绑定分类数据源
        /// </summary>
        private void BindCategoryDataSource()
        {
            CategoryController categoryController = new CategoryController();
            this.cboCategory.DataSource = categoryController.GetCategoriesForDropDownList();
            this.cboCategory.DataBind();
        }

        /// <summary>
        /// 根据ArticleId信息获取完整的Article信息
        /// </summary>
        /// <param name="articleId"></param>
        private void SetArticleInfo(int articleId)
        {
            if (articleId == Null.NullInteger)
            {
                return;
            }
            ArticleInfo article= controller.GetArticle(articleId);
            if (article != null)
            {
                this.hfArticleId.Value = articleId.ToString();
                this.cboCategory.SelectedValue = article.CategoryID.ToString() ;
                this.txtTitle.Text = article.Title;
                this.txtKeyWords.Text = article.KeyWords;
                this.txtSummary.Text = article.Summary;
                WebControlUtils.SetTextEditorValue(this.txtContent, article.Content);
                this.cbAllowComment.Checked = article.AllowComment;
                this.cbAllowPrint.Checked = article.AllowPrint;
                this.cbOnTop.Checked = article.OnTop;
                this.cbPassed.Checked = article.Passed;
            }
        }

        /// <summary>
        /// 获取ArticleInfo对象
        /// </summary>
        /// <param name="articleId"></param>
        private ArticleInfo GetArticleInfo()
        {
            ArticleInfo article = new ArticleInfo();
            article.ArticleID = WebControlUtils.GetObjectIntValue(this.hfArticleId);
            article.CategoryID = WebControlUtils.GetObjectIntValue(this.cboCategory);
            article.Title = this.txtTitle.Text;
            article.KeyWords = this.txtKeyWords.Text;
            article.Summary = this.txtSummary.Text;
            article.CreatedByUserID = this.UserId;
            article.CreatedByUserName = this.GetUserName();
            article.Content = WebControlUtils.GetTextEditorValue(this.txtContent);
            article.AllowComment = this.cbAllowComment.Checked;
            article.AllowPrint = this.cbAllowPrint.Checked;
            article.OnTop = this.cbOnTop.Checked;
            article.Passed = this.cbPassed.Checked;
            return article;
        }

        #endregion

        #region "Event Handlers"

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Null.IsNull(this.UserId))
            {
                throw new ArticlesException("您还没有登陆不能执行该操作，请先登录！");
            }
            string _articleId = Request.Params.Get("ArticleId");
            if (_articleId != null)
            {
                if (!int.TryParse(_articleId, out articleId))
                {
                    articleId = Null.NullInteger;
                }
            }
            if (!IsPostBack)
            {
                this.BindCategoryDataSource();
                if (articleId != Null.NullInteger)
                {
                    SetArticleInfo(articleId);
                }
            }
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(Globals.NavigateURL(), true);
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ArticleInfo articleInfo= GetArticleInfo();
                controller.SaveArticle(articleInfo);
                Response.Redirect(Globals.NavigateURL(), true);
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


        protected void cmdDelete_Click(object sender, EventArgs e)
        {

        }

        protected void cmdCategoryManage_Click(object sender, EventArgs e)
        {
            Response.Redirect(EditUrl("CategoryManage"), true);
        }

        #endregion
    }
}
