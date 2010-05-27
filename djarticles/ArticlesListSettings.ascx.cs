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
using DotNetNuke.Services.Exceptions;
using DjArticles.Components;

namespace DjArticles
{
    public partial class ArticlesListSettings : ModuleSettingsBase
    {
        #region Private Members

        CategoryController categoryController = new CategoryController();
        ModuleController objModuleController = new ModuleController();
        #endregion

        #region Members Methods

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// LoadSettings loads the settings from the Database and displays them 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public override void LoadSettings()
        {
            try
            {

                BindCategories();
                if (string.IsNullOrEmpty(TabModuleSettings["ArticlesPerPage"] as string))
                {
                    txtArticlesPerPage.Text = "10";
                }
                else
                {
                    txtArticlesPerPage.Text = TabModuleSettings["ArticlesPerPage"] as string;
                }
                drpSortField.SelectedValue = TabModuleSettings["SortField"] as string;
                drpDateRange.SelectedValue = TabModuleSettings["DateRange"] as string;
                cboCategory.SelectedValue = TabModuleSettings["FilterCategoryID"] as string;
                chkShowCategory.Checked = (TabModuleSettings["ShowCategory"] as string == "True");
                chkShowReadMore.Checked = (TabModuleSettings["ShowReadMore"] as string == "True");
                chkAllowComments.Checked = (TabModuleSettings["AllowComments"] as string == "True");
                chkAnonymousComments.Checked = (TabModuleSettings["AnonymousComments"] as string == "True");
                chkMoreArticles.Checked = (TabModuleSettings["MoreArticles"] as string == "True");
                chkWillPage.Checked = (TabModuleSettings["WillPage"] as string == "True");
                chkFilterByCategory.Checked = (TabModuleSettings["FilterByCategory"] as string == "True");
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// UpdateSettings saves the modified settings to the Database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public override void UpdateSettings()
        {
            try
            {
                objModuleController.UpdateTabModuleSetting(this.TabModuleId, "ArticlesPerPage", txtArticlesPerPage.Text);
                objModuleController.UpdateTabModuleSetting(this.TabModuleId, "SortField", drpSortField.SelectedValue);
                objModuleController.UpdateTabModuleSetting(this.TabModuleId, "DateRange", drpDateRange.SelectedValue);
                objModuleController.UpdateTabModuleSetting(this.TabModuleId, "ShowCategory", chkShowCategory.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(this.TabModuleId, "ShowReadMore", chkShowReadMore.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(this.TabModuleId, "AllowComments", chkAllowComments.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(this.TabModuleId, "AnonymousComments", chkAnonymousComments.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(this.TabModuleId, "MoreArticles", chkMoreArticles.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(this.TabModuleId, "WillPage", chkWillPage.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(this.TabModuleId, "FilterByCategory", chkFilterByCategory.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(this.TabModuleId, "FilterCategoryID", cboCategory.SelectedValue);
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// <summary>
        /// 绑定分类信息源
        /// </summary>
        private void BindCategories()
        {
            ArrayList categorys=categoryController.GetCategoriesForDropDownList();
            if (categorys == null || categorys.Count <= 0)
            {
                this.lblNoCategories.Visible = true;
                this.cboCategory.Visible = false;
            }
            else
            {
                this.lblNoCategories.Visible = false;
                this.cboCategory.Visible = true;
                this.cboCategory.DataSource = categorys;
                this.cboCategory.DataBind();
            }
        }

        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    LoadSettings();
                }
                catch (Exception exc)
                {
                    Exceptions.ProcessModuleLoadException(this, exc);
                }
               
            }
        }
        #endregion

    }
}