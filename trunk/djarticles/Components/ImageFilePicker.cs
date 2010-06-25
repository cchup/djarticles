using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetNuke.Web.UI.WebControls;

namespace DjArticles.Components
{
    public class ImageFilePicker:DnnFilePicker
    {
        protected override void LocalizeStrings()
        {
            //return "ImageFilePicker";
        }
    }
}
