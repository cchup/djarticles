using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using DotNetNuke.Common;

namespace DjArticles.Components
{
    public class SideMenuSource :IEnumerable 
    {
        private ArrayList categoryList = new ArrayList();
        private ArrayList sideMenuList = new ArrayList();

        public SideMenuSource(ArrayList categoryList)
        {
            this.categoryList = categoryList;
            this.BuildMenuListHtml();
        }

        /// <summary>
        /// 构建树形菜单HTML元素信息
        /// </summary>
        private void BuildMenuListHtml()
        {
            if (categoryList == null || categoryList.Count == 0)
            {
                return;
            }
            foreach (CategoryInfo category in categoryList)
            {
                SideMenu sideMenu = new SideMenu();
                sideMenu.MenuHtml = GetCategoryHtml(category);
                sideMenuList.Add(sideMenu);
            }
        }

        /// <summary>
        /// 生成单个菜单的HTML原始
        /// </summary>
        /// <param name="categoryInfo"></param>
        /// <returns></returns>
        private string GetCategoryHtml(CategoryInfo categoryInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<li>");
            sb.Append("<a href=\"" + GetNavigatUrl(categoryInfo) + "\">");
            sb.Append(categoryInfo.Name);
            sb.Append("</a>");
            //生成子菜单
            if (categoryInfo.ChildCategorys != null && categoryInfo.ChildCategorys.Count > 0)
            {
                sb.Append("<div><ul>");
                foreach (CategoryInfo childCategory in categoryInfo.ChildCategorys)
                {
                   sb.Append(GetCategoryHtml(childCategory));
                }
                sb.Append("</ul></div>");
            }
            sb.Append("</li>");
            return sb.ToString();
        }

        /// <summary>
        /// 获取导航地址
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private string GetNavigatUrl(CategoryInfo categoryInfo){
            return Globals.NavigateURL("", "CategoryId=" + categoryInfo.CategoryID);
        }

        #region IEnumerable 成员

        public IEnumerator GetEnumerator()
        {
            return sideMenuList.GetEnumerator();
        }

        #endregion
    }


    public class SideMenu
    {
        private string menuHtml;

        public string MenuHtml
        {
            get { return menuHtml; }
            set { menuHtml = value; }
        }
    }
}
