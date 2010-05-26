using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DjArticles.Components
{
    /// <summary>
    /// 文章模块动作类型
    /// </summary>
    public class ArticleActionType
    {
       public const string CategoryManage="CategoryManageAction.Action";
       public const string NewCategoryAction = "NewCategoryAction.Action";
       public const string NewArticleAction = "NewArticleAction.Action";
    }
}
