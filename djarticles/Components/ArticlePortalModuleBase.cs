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
        /// 当前用户是否已登录
        /// </summary>
        protected bool IsLoginUser
        {
            get
            {
                if (Null.IsNull(this.UserId))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

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
        /// <param name="path">当前控件的相对路径</param>
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
        protected int GetIntParameter(string parameterName)
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
        /// <param name="parameters">绑定参数，第一个参数指定默认值，第二个参数指定绑定格式</param>
        /// <returns></returns>
        protected string EvalValue(object value,params string[] parameters)
        {
            string defaultValue = "";
            string format = "";
            if (parameters != null)
            {
                if (parameters.Length > 0)
                {
                    defaultValue = parameters[0];
                }
                if (parameters.Length > 1)
                {
                    format = parameters[1];
                }
            }
            string paravalue = defaultValue;
            if (value != null)
            {
                string _value = value.ToString();
                if (!string.IsNullOrEmpty(_value))
                {
                    paravalue = _value;
                }
            }
            if (string.IsNullOrEmpty(format))
            {
                return paravalue;
            }
            else
            {
                return string.Format(format, paravalue);
            }
        }

        /// <summary>
        /// 获取模块设置值(整型）
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        protected int GetSettingInt(string settingKey, params int[] parameters)
        {
            int defaultValue = Null.NullInteger;
            if (parameters != null && parameters.Length > 0)
            {
                defaultValue = parameters[0];
            }
            object _value = Settings[settingKey];
            if (_value == null)
            {
                return defaultValue;
            }
            int settingValue = defaultValue;
            if (!int.TryParse(_value.ToString(), out settingValue))
            {
                settingValue = defaultValue;
            }
            return settingValue;
        }

        /// <summary>
        /// 获取模块设置值(布尔）
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        protected bool GetSettingBool(string settingKey, params bool[] parameters)
        {
            bool defaultValue = false;
            if (parameters != null && parameters.Length > 0)
            {
                defaultValue = parameters[0];
            }
            object _value = Settings[settingKey];
            if (_value == null)
            {
                return defaultValue;
            }
            bool settingValue = defaultValue;
            if (!bool.TryParse(_value.ToString(), out settingValue))
            {
                settingValue = defaultValue;
            }
            return settingValue;
        }

        /// <summary>
        /// 获取模块设置值(字符串）
        /// </summary>
        /// <param name="settingKey"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected string GetSettingString(string settingKey, params string[] parameters)
        {
            string defaultValue = "";
            if (parameters != null && parameters.Length > 0)
            {
                defaultValue = parameters[0];
            }
            object _value = Settings[settingKey];
            if (_value == null)
            {
                return defaultValue;
            }
            string settingValue = defaultValue;
            if (!string.IsNullOrEmpty(_value.ToString()))
            {
                settingValue = _value.ToString();
            }
            return settingValue;
        }

    }
}
