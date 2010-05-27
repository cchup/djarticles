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

namespace DjArticles
{
    public partial class ArticlesList : ArticlesListBase
    {
        private ArticlesController controller = new ArticlesController();

        /// <summary>
        /// 绑定数据源
        /// </summary>
        private void BindArticlesSource()
        {
            this.lstArticles.DataSource = controller.GetArticles();
            this.lstArticles.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArticlesSource();
            }   
        }
    }
}