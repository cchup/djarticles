using System;
using System.Collections.Generic;
using System.Web.UI;
namespace DjArticles.Components
{
    public class CategoryInfo  
    {
        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int parentID;

        public int ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        private int depth;

        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }
        private int viewOrder;

        public int ViewOrder
        {
            get { return viewOrder; }
            set { viewOrder = value; }
        }
        private string adminRoles;

        public string AdminRoles
        {
            get { return adminRoles; }
            set { adminRoles = value; }
        }
        private string editRoles;

        public string EditRoles
        {
            get { return editRoles; }
            set { editRoles = value; }
        }
        private string viewRoles;

        public string ViewRoles
        {
            get { return viewRoles; }
            set { viewRoles = value; }
        }
        private int createdByUserID;

        public int CreatedByUserID
        {
            get { return createdByUserID; }
            set { createdByUserID = value; }
        }
        private string createdByUserName;

        public string CreatedByUserName
        {
            get { return createdByUserName; }
            set { createdByUserName = value; }
        }
        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }
        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        private List<CategoryInfo> childCategorys=new List<CategoryInfo>();

        /// <summary>
        /// 获取所有的子分类
        /// </summary>
        public List<CategoryInfo> ChildCategorys
        {
            get
            {
                if (childCategorys == null)
                {
                    return new List<CategoryInfo>();
                };
                return childCategorys;
            }
        }

        /// <summary>
        /// 添加子分类
        /// </summary>
        /// <param name="category"></param>
        public void AddChildCategory(CategoryInfo category)
        {
            if (category == null)
            {
                return;
            }
            category.parentID = this.categoryID;
            childCategorys.Add(category);
        }
    }
}