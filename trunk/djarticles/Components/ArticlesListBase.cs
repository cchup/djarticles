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

namespace DjArticles.Components
{
    public class ArticlesListBase : ArticlePortalModuleBase
    {
        #region Controls
        /// <summary>
        /// 
        /// </summary>
        protected global::System.Web.UI.WebControls.HyperLink lnkReadMore;
        /// <summary>
        /// 
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
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
