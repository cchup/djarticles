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
using DjArticles.Components;
using DotNetNuke.Common;

namespace DjArticles
{
    public partial class CategoryList : ArticlePortalModuleBase
    {
        private CategoryController controller = new CategoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategorySource();
            }
        }

        /// <summary>
        /// 绑定显示数据源
        /// </summary>
        private void BindCategorySource()
        {
            this.lstCategory.DataSource = controller.GetCategorysForSideMenu();
            this.lstCategory.DataBind();
        }
    }
}