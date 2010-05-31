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
using DotNetNuke.Services.Exceptions;

namespace DjArticles
{
    public partial class ArticlesList : ArticlePortalModuleBase
    {
        #region Private Members
        private ArticlesListBase articlesList;
        #endregion

        #region Private Methods
        /// <summary>
        /// 加载显示控件
        /// </summary>
        private void LoadArticlesListControl()
        {
            try
            {
                string templateSetting = this.GetSettingString("Template");
                if (string.IsNullOrEmpty(templateSetting))
                {
                    templateSetting = "Standard";
                }
                string controlPath = this.ControlPath + "ArticlesList_" + templateSetting+".ascx";
                articlesList = (ArticlesListBase)LoadControl(controlPath);
                if (articlesList != null)
                {
                    articlesList.ModuleConfiguration = this.ModuleConfiguration;
                    this.objPlaceholder.Controls.Add(articlesList);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Events Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadArticlesListControl();
            }
        }
        #endregion

    }
}