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
using DotNetNuke.Framework;
using DotNetNuke.Common.Utilities;
using DjArticles.Common;
using DotNetNuke.Common;

namespace DjArticles
{
    public partial class CategoryManage : ArticlePortalModuleBase
    {
        private CategoryController controller = new CategoryController();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.grdCategories.DataSourceBind += delegate { BindCategorySource(); };
            if (!IsPostBack)
            {
                GridView category=this.grdCategories as GridView;
                DotNetNuke.Services.Localization.Localization.LocalizeGridView(ref category, this.LocalResourceFile);
                BindCategorySource();
            }
        }

        /// <summary>
        /// 绑定显示数据源
        /// </summary>
        private void BindCategorySource()
        {
            this.grdCategories.DataSource = controller.GetCategories();
            this.grdCategories.DataBind();
        }

        /// <summary>
        /// 转到新增页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            //重转向
            this.Response.Redirect(EditUrl("CategoryEdit"), true);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Null.IsNull(this.UserId))
            {
                throw new ArticlesException("您还没有登陆不能执行该操作，请先登录！");
            }

            //controller.DeleteCategory(
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //重转向
            this.Response.Redirect(Globals.NavigateURL(), true);
        }
    }
}