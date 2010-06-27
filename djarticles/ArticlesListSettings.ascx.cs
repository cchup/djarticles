﻿using System;
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
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Common.Utilities;

namespace DjArticles
{
    public partial class ArticlesListSettings : ModuleSettingsBase
    {
        #region Private Members

        CategoryController categoryController = new CategoryController();
      
        TabController tabController = new TabController();
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
            if (IsPostBack)
            {
                return;
            }
            try
            {

                BindCategories();
                BindPages();
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
                drpTemplate.SelectedValue = TabModuleSettings["Template"] as string;
                cboCategory.SelectedValue = TabModuleSettings["FilterCategoryID"] as string;
                drpMoreArticlesPage.SelectedValue=TabModuleSettings["MoreArticlesPage"] as string;
                drpDetialArticlesPage.SelectedValue = TabModuleSettings["DetailArticlesPage"] as string;

                chkShowCategory.Checked = (TabModuleSettings["ShowCategory"] as string == "True");
                chkShowReadMore.Checked = (TabModuleSettings["ShowReadMore"] as string == "True");
                chkAllowComments.Checked = (TabModuleSettings["AllowComments"] as string == "True");
                chkAnonymousComments.Checked = (TabModuleSettings["AnonymousComments"] as string == "True");
                chkMoreArticles.Checked = (TabModuleSettings["MoreArticles"] as string == "True");
                chkWillPage.Checked = (TabModuleSettings["WillPage"] as string == "True");
                chkFilterByCategory.Checked = (TabModuleSettings["FilterByCategory"] as string == "True");
                chkAcceptParameter.Checked = (TabModuleSettings["AcceptParameter"] as string == "True");
                //
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
                ModuleController objModuleController = new ModuleController();
                objModuleController.UpdateTabModuleSetting(TabModuleId, "ArticlesPerPage", txtArticlesPerPage.Text);
                objModuleController.UpdateTabModuleSetting(TabModuleId, "SortField", drpSortField.SelectedValue);
                objModuleController.UpdateTabModuleSetting(TabModuleId, "DateRange", drpDateRange.SelectedValue);
                objModuleController.UpdateTabModuleSetting(TabModuleId, "Template", drpTemplate.SelectedValue);
                objModuleController.UpdateTabModuleSetting(TabModuleId, "ShowCategory", chkShowCategory.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(TabModuleId, "ShowReadMore", chkShowReadMore.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(TabModuleId, "AllowComments", chkAllowComments.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(TabModuleId, "AnonymousComments", chkAnonymousComments.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(TabModuleId, "MoreArticles", chkMoreArticles.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(TabModuleId, "WillPage", chkWillPage.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(TabModuleId, "FilterByCategory", chkFilterByCategory.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(TabModuleId, "FilterCategoryID", cboCategory.SelectedValue);
                objModuleController.UpdateTabModuleSetting(TabModuleId, "AcceptParameter", chkAcceptParameter.Checked.ToString());
                objModuleController.UpdateTabModuleSetting(TabModuleId, "MoreArticlesPage", drpMoreArticlesPage.SelectedValue);
                objModuleController.UpdateTabModuleSetting(TabModuleId, "DetailArticlesPage", drpDetialArticlesPage.SelectedValue);
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
        /// <summary>
        /// 绑定所有页面数据源
        /// </summary>
        private void BindPages()
        {
            TabCollection tabCollection = tabController.GetTabsByPortal(this.PortalId);
            TabInfo emptyTab = new TabInfo();
            emptyTab.TabName = "--无--";
            emptyTab.TabID = Null.NullInteger;
            tabCollection.Add(emptyTab);
            this.drpMoreArticlesPage.DataSource = tabCollection.Values;
            this.drpMoreArticlesPage.DataTextField="TabName";
            this.drpMoreArticlesPage.DataValueField="TabID";
            this.drpMoreArticlesPage.DataBind();

            this.drpDetialArticlesPage.DataSource = tabCollection.Values;
            this.drpDetialArticlesPage.DataTextField = "TabName";
            this.drpDetialArticlesPage.DataValueField = "TabID";
            this.drpDetialArticlesPage.DataBind();
        }

        #endregion
    }
}