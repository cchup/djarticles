using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetNuke.Security;
using DotNetNuke.Security.Roles;
using System.Collections;
using DotNetNuke.Common.Utilities;
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using DotNetNuke.Entities.Users;
using DjArticles.Common;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;

namespace DjArticles.Components
{
    public class CategoryController
    {
        // Methods
        public void AddCategory(CategoryInfo objCategoryInfo)
        {
            DataProvider.Instance().AddCategory( objCategoryInfo.Name,objCategoryInfo.Description,objCategoryInfo.ParentID,objCategoryInfo.Depth,objCategoryInfo.ViewOrder,objCategoryInfo.AdminRoles,objCategoryInfo.EditRoles,objCategoryInfo.ViewRoles,objCategoryInfo.CreatedByUserID,objCategoryInfo.CreatedByUserName,objCategoryInfo.CreatedDate,objCategoryInfo.IsActive);
        }

        public bool CanEdit(CategoryInfo objCategoryInfo)
        {
            return (((PortalSecurity.IsInRoles(objCategoryInfo.AdminRoles) | PortalSecurity.IsInRoles(objCategoryInfo.EditRoles)) | (objCategoryInfo.EditRoles.Length == 0)) | PortalSecurity.IsInRoles("Administrators"));
        }

        public bool CanView(CategoryInfo objCategoryInfo)
        {
            return ((((PortalSecurity.IsInRoles(objCategoryInfo.AdminRoles) | PortalSecurity.IsInRoles(objCategoryInfo.EditRoles)) | PortalSecurity.IsInRoles(objCategoryInfo.ViewRoles)) | (objCategoryInfo.ViewRoles.Length == 0)) | PortalSecurity.IsInRoles("Administrators"));
        }

        public void DeleteCategory(int CategoryID)
        {
            DataProvider.Instance().DeleteCategory(CategoryID);
        }

        /// <summary>
        /// 获取Tree显示前面的格式字符串
        /// </summary>
        /// <param name="Depth"></param>
        /// <returns></returns>
        public string FormatTreeSpace(int Depth)
        {
            if (Depth == 1)
            {
                return "";
            }
            string strTemp = "";
            for (int i = 1; i < Depth; i++)
            {
                strTemp += "|　";
            }
            strTemp += "|—";

            return strTemp;
        }

        public int GetArticleCountByCategoryID(int CategoryID)
        {
            return DataProvider.Instance().GetArticleCountByCategoryID(CategoryID);
        }

        public ArrayList GetCategories(int Depth, int ParentID)
        {
            return CBO.FillCollection(DataProvider.Instance().GetCategories(Depth, ParentID), typeof(CategoryInfo));
        }

        /// <summary>
        /// 获取所有的分类信息
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCategories( )
        {
            return CBO.FillCollection(DataProvider.Instance().GetAllCategorys(), typeof(CategoryInfo));
        }

        /// <summary>
        ///  获取绑定DropDownList的数据集
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCategoriesForDropDownList()
        {
            ArrayList categorys = this.GetCategories();

            #region 构建一个颗树形结构的对象集
            Dictionary<int, ArrayList> allDepthCategory = new Dictionary<int, ArrayList>();
            //将所有分类按深度分类
            foreach (CategoryInfo category in categorys)
            {
                int depth = category.Depth;
                ArrayList depthCategorys = null;
                if (allDepthCategory.ContainsKey(depth))
                {
                    depthCategorys = allDepthCategory[depth];
                }
                else
                {
                    depthCategorys = new ArrayList();
                    allDepthCategory[depth] = depthCategorys;
                }
                depthCategorys.Add(category);
            }
            int cudepth = ArticleConstants.TopDepth;
            Dictionary<int, CategoryInfo> currentDepthList = new Dictionary<int, CategoryInfo>();
            Dictionary<int, CategoryInfo> parentDepthList = new Dictionary<int, CategoryInfo>();
            while (true)
            {
                if (!allDepthCategory.ContainsKey(cudepth))
                {
                    break;
                }
                currentDepthList = new Dictionary<int, CategoryInfo>();
                ArrayList depthCategorys = allDepthCategory[cudepth];
                foreach (CategoryInfo category in depthCategorys)
                {
                    currentDepthList.Add(category.CategoryID, category);
                    //存在上级分类，添加为其子分类
                    if (parentDepthList.ContainsKey(category.ParentID))
                    {
                        parentDepthList[category.ParentID].AddChildCategory(category);
                    }
                }
                //重新设置上级分类为当前级别的分类，以供下级分类使用
                parentDepthList = new Dictionary<int, CategoryInfo>(currentDepthList);
                cudepth++;
            }

            #endregion
           
            ArrayList allCategorys = new ArrayList();
            if (allDepthCategory.ContainsKey(ArticleConstants.TopDepth))
            {
                ArrayList topCategorys = allDepthCategory[ArticleConstants.TopDepth];
                GetCurrentDepthCategorys(allCategorys, topCategorys);
            }
            // 添加默认项
            CategoryInfo defaultCategory = new CategoryInfo();
            defaultCategory.Name = "--无--";
            defaultCategory.CategoryID = Null.NullInteger;
            allCategorys.Insert(0, defaultCategory);
            return allCategorys;
        }

        /// <summary>
        /// 递归获取所有的分类
        /// </summary>
        /// <param name="allCategorys"></param>
        /// <param name="currentCategorys"></param>
        private void GetCurrentDepthCategorys(ArrayList allCategorys, IList currentCategorys)
        {
            if(currentCategorys==null)
            {
                return;
            }
            foreach (CategoryInfo category in currentCategorys)
            {
                int depth = category.Depth;
                category.Name = FormatTreeSpace(depth) + category.Name;
                allCategorys.Add(category);
                GetCurrentDepthCategorys(allCategorys,category.ChildCategorys);
            }
        }

        /// <summary>
        /// 获取某一分类详细信息
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public CategoryInfo GetCategory(int CategoryID)
        {
            return (CategoryInfo)CBO.FillObject(DataProvider.Instance().GetCategory(CategoryID), typeof(CategoryInfo));
        }

        public CategoryInfo GetParentCategory(int ParentID)
        {
            CategoryController controller = new CategoryController();
            return controller.GetCategory(ParentID);
        }

        public string GetParentCategoryRoles(int ParentID, RoleType eRoleType)
        {
            string adminRoles = string.Empty;
         
            return adminRoles;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="objCategoryInfo"></param>
        public void UpdateCategory(CategoryInfo objCategoryInfo)
        {
            DataProvider.Instance().UpdateCategory(objCategoryInfo.CategoryID,objCategoryInfo.Name,objCategoryInfo.Description,
                objCategoryInfo.ParentID,objCategoryInfo.Depth, objCategoryInfo.ViewOrder,objCategoryInfo.AdminRoles,objCategoryInfo.EditRoles,
                objCategoryInfo.ViewRoles,objCategoryInfo.CreatedByUserName,objCategoryInfo.CreatedByUserID, DateTime.Now,objCategoryInfo.IsActive);
        }

        /// <summary>
        /// 保存分类信息
        /// </summary>,
        /// <param name="objCategoryInfo"></param>
        public void SaveCategoryInfo(CategoryInfo objCategoryInfo)
        {
            if (objCategoryInfo == null)
            {
                return;
            }
            int parentId = objCategoryInfo.ParentID;
            int depth = ArticleConstants.TopDepth;
            if (!Null.IsNull(parentId))
            {
                CategoryInfo parentCategory=this.GetCategory(parentId);
                if (parentCategory != null)
                {
                    depth = parentCategory.Depth + 1;
                }
            }
            objCategoryInfo.Depth = depth;
            objCategoryInfo.CreatedDate = DateTime.Now;
            if (Null.IsNull(objCategoryInfo.CategoryID))
            {
                this.AddCategory(objCategoryInfo);
            }
            else
            {
                this.UpdateCategory(objCategoryInfo);
            }
        }
    }
}
