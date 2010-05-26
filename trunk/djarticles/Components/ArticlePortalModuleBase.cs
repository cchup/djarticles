using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetNuke.Entities.Modules;
using DotNetNuke.UI.UserControls;
using DotNetNuke.Security.Roles;
using System.Collections;
using DotNetNuke.Entities.Users;
using DotNetNuke.Common.Utilities;

namespace DjArticles.Components
{
    public class ArticlePortalModuleBase : PortalModuleBase
    {
        private UserController userController = new UserController();

        /// <summary>
        /// 获取当前登陆用户名
        /// </summary>
        /// <returns></returns>
        protected string GetUserName()
        {
            string userName="";
            if (!Null.IsNull(this.UserId))
            {

                UserInfo user = this.UserInfo;
                if (user == null)
                {
                    user = userController.GetUser(this.PortalId, this.UserId);
                }
                if (user != null)
                {
                    userName = user.Username;
                }
            }
            return userName;
        }

        /// <summary>
        /// 获取是否选择的标识
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected bool EvalChecked(Object value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.ToString() == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 设置角色控件值
        /// </summary>
        /// <param name="userControl"></param>
        /// <param name="value"></param>
        protected void SetDualListValue(UserControl userControl, string value)
        {
            DualListControl duControl = userControl as DualListControl;
            if (duControl == null)
            {
                return;
            }

            RoleController controller = new RoleController();
            ArrayList allRoles = controller.GetPortalRoles(this.PortalId);
            if (string.IsNullOrEmpty(value))
            {
                duControl.Available = allRoles;
                return;
            }
            string[] roleNames = value.Split(',');
            ArrayList availableRoles = new ArrayList();
            ArrayList nowRoles = new ArrayList();
            //current roles 
            foreach (string roleName in roleNames)
            {
                RoleInfo role = new RoleInfo();
                role.RoleName = roleName;
                nowRoles.Add(role);
            }
            //set now availableRole
            foreach (RoleInfo role in allRoles)
            {
                bool hava = false;
                foreach (string roleName in roleNames)
                {
                    if (role.RoleName == roleName)
                    {
                        hava = true;

                    }
                }
                if (!hava)
                {
                    availableRoles.Add(role);
                }
            }
            duControl.Available = availableRoles;
            duControl.Assigned = nowRoles;
        }

        /// <summary>
        /// 获取引用路径
        /// </summary>
        /// <param name="path">相对于当前控件的相对路径</param>
        /// <returns></returns>
        protected string ResolveModuleUrl(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return base.ResolveUrl(path);
            }
            string controlPath = this.ControlPath;/// controlpath 返回的是/DesktopModules/DjArticles/
            if (path.IndexOf(path)!=-1)
            {
                return base.ResolveUrl(path);
            }
            return base.ResolveUrl(controlPath + "/" + path);
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <returns>参数int值</returns>
        protected int getIntParameter(string parameterName)
        {
            int value=Null.NullInteger;
            string _value = Request.Params.Get(parameterName);
            if (_value != null)
            {
                if (!int.TryParse(_value, out value))
                {
                    value = Null.NullInteger;
                }
            }
            return value;
        }

        /// <summary>
        /// 绑定值
        /// </summary>
        /// <param name="value">绑定对象</param>
        /// <returns></returns>
        protected string EvalValue(object value,params string[] formats)
        {
            if (value == null)
            {
                return "";
            }
            string _value = value.ToString();
            if (string.IsNullOrEmpty(_value))
            {
                return "";
            }
            string format = "";
            if (formats != null && formats.Length > 0)
            {
                format = formats[0];
            }
            if (string.IsNullOrEmpty(format))
            {
                return _value;
            }
            else
            {
                return string.Format(format, _value);
            }
        }
    }
}
