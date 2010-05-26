using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DjArticles.Components;

namespace DjArticles
{

    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// The ViewArticles class displays the content 
    /// </summary> 
    /// <remarks> 
    /// </remarks> 
    /// <history> 
    /// </history> 
    /// ----------------------------------------------------------------------------- 
    partial class ViewArticle : ArticlePortalModuleBase, IActionable
    {

        #region "Event Handlers"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Page_Load runs when the control is loaded 
        /// </summary> 
        /// ----------------------------------------------------------------------------- 
        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// lstContent_ItemDataBound runs when items are bound. Here the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------------------------------- 
        protected void lstContent_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {
            string strContent = "";

            // add content to template 
            if (!string.IsNullOrEmpty((string)Settings["template"]))
            {
                strContent = (string)Settings["template"];
                ArrayList objProperties = CBO.GetPropertyInfo(typeof(ArticleInfo));
                foreach (PropertyInfo objPropertyInfo in objProperties)
                {
                    strContent = strContent.Replace("[" + objPropertyInfo.Name.ToUpper() + "]", Server.HtmlDecode(DataBinder.Eval(e.Item.DataItem, objPropertyInfo.Name).ToString()));
                }
            }
            else
            {
                strContent = DataBinder.Eval(e.Item.DataItem, "Content").ToString();
            }

            // assign the content 
            Label lblContent = (Label)e.Item.FindControl("lblContent");
            lblContent.Text = strContent;
        }

        #endregion

        #region "Optional Interfaces"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Registers the module actions required for interfacing with the portal framework 
        /// </summary> 
        /// <value></value> 
        /// <returns></returns> 
        /// <remarks></remarks> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                Actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile),
                   ModuleActionType.AddContent, "", "add.gif", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit,
                    true, false);
                return Actions;
            }
        }

        #endregion

    }

}