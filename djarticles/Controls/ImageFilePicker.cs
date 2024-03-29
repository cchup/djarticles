﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DjArticles.Controls
{
    public class ImageFilePicker:DotNetNuke.Web.UI.WebControls.DnnFilePicker
    {
        public new string FilePath
        {
            get
            {
                string filePath = base.FilePath;
                if (filePath.Contains("//"))
                {
                    filePath = filePath.Replace("//", "/");
                }
                return filePath;
            }
            set
            {
                base.FilePath = value;
            }
        }
    }
}
