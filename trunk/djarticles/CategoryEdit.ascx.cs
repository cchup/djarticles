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
using DotNetNuke.Common.Utilities;
using DotNetNuke.UI.UserControls;
using DotNetNuke.Security.Roles;
using DjArticles.Common;
using DotNetNuke.Common;
using DotNetNuke.Entities.Users;

namespace DjArticles
{
    public partial class CategoryEdit : ArticlePortalModuleBase
    {
        #region Private Members

        private CategoryController controller = new CategoryController();

        private int categoryId = Null.NullInteger;

        #endregion
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Null.IsNull(this.UserId))
            {
                throw new ArticlesException("您还没有登陆不能执行该操作，请先登录！");
            }
            string _categoryId=Request.Params.Get("CategoryId");
            if (_categoryId != null)
            {
                if (!int.TryParse(_categoryId, out categoryId))
                {
                    categoryId = Null.NullInteger;
                }
            }
            if(!IsPostBack){
                this.BindCategoryDataSource();
                // 存在参数CategoryId
                if (!Null.IsNull(categoryId))
                {
                    CategoryInfo category = controller.GetCategory(categoryId);
                    if (category != null)
                    {
                        this.cboParentCategory.SelectedValue = category.ParentID.ToString();
                        this.txtName.Text = category.Name;
                        this.txtDescription.Text = category.Description;
                        this.chkIsActive.Checked = category.IsActive;
                        this.SetDualListValue(this.ctlAdminRoles, category.AdminRoles);
                        this.SetDualListValue(this.ctlEditRoles, category.EditRoles);
                        this.SetDualListValue(this.ctlViewRoles, category.ViewRoles);
                    }
                    else
                    {
                        throw new ArticlesException("未找到标识为【" + categoryId + "】的分类信息！");
                    }
                }
                else
                {
                    this.SetDualListValue(this.ctlAdminRoles, null);
                    this.SetDualListValue(this.ctlEditRoles, null);
                    this.SetDualListValue(this.ctlViewRoles, null);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CategoryInfo category = new CategoryInfo();
            category.Name = this.txtName.Text;
            category.Description = this.txtDescription.Text;
            category.IsActive = this.chkIsActive.Checked;
            category.ParentID = WebControlUtils.GetObjectIntValue(cboParentCategory);
            category.CategoryID = WebControlUtils.GetObjectIntValue(this.hfCategoryID);
            category.CreatedByUserID = this.UserId;
            UserController userController = new UserController();
            if (!Null.IsNull(category.CreatedByUserID))
            {
                UserInfo user=userController.GetUser(this.PortalId, this.UserId);
                if (user != null)
                {
                    category.CreatedByUserName = user.Username;
                }
            }
            controller.SaveCategoryInfo(category);
            // 保存成功返回到CategoryManager管理界面
            Response.Redirect(Globals.NavigateURL(), true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // 返回到CategoryManager管理界面
            Response.Redirect(EditUrl("CategoryManage"), true);
        }

        /// <summary>
        /// 绑定分类数据源
        /// </summary>
        private void BindCategoryDataSource()
        {
            this.cboParentCategory.DataSource = controller.GetCategoriesForDropDownList();
            this.cboParentCategory.DataBind();
        }
    }
}