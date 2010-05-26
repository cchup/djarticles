using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetNuke.Services.Exceptions;

namespace DjArticles.Common
{
    /// <summary>
    /// DjArticles 文章处理异常
    /// </summary>
    public class ArticlesException : BasePortalException
    {
        public ArticlesException(string message)
            : base(message)
        {
        }
    }
}
