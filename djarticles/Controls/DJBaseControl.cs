/************************************************************************/
/* 自定义服务器控件基类
/* 侯德军 2009/05/22                                                    */
/************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.HtmlControls;

namespace DjArticles
{
    [ToolboxData("")]
    public class DJBaseControl:WebControl
    {
        private string newClientID;
        public override string ClientID
        {
            get
            {
                if (!string.IsNullOrEmpty(newClientID))
                {
                    return newClientID;
                }
                return base.ClientID;
            }
        }

        public DJBaseControl(HtmlTextWriterTag tag)
            : base(tag)
        {

        }

        public DJBaseControl()
        {
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            if (this.Width!=Unit.Empty)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Width, this.Width.ToString());
            }
            if (this.Height != Unit.Empty)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Height, this.Height.ToString());
            }
        }
 
        /// <summary>
        /// 获取视图状态值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual string GetViewStateString(string key)
        {
            ///状态键为空返回空的状态值
            if (string.IsNullOrEmpty(key))
            {
                return ""; 
            }
            object stateObject = ViewState[key];
            return stateObject == null ? "" : stateObject.ToString();
        }

        /// <summary>
        /// 获取视图状态值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual string GetViewStateString(string key,string defaultValue)
        {
            ///状态键为空返回空的状态值
            if (string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }
            object stateObject = ViewState[key];
            return stateObject == null ? defaultValue : stateObject.ToString();
        }

        /// <summary>
        /// 获取视图状态的整形值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual int GetViewStateInt(string key,int defaultValue)
        {
            if (string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }
            object stateObject = ViewState[key];
            return (stateObject == null) ? defaultValue : (int)stateObject;
        }

        /// <summary>
        /// 获取视图状态的Bool值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual bool GetViewStateBoolean(string key,bool defaultValue)
        {
            if (string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }
            object stateObject = ViewState[key];
            return (stateObject == null) ? defaultValue : (bool)stateObject;
        }

        /// <summary>
        /// 重设clientID
        /// </summary>
        /// <param name="newClientID"></param>
        internal void ReSetClientID(string newClientID)
        {
            this.newClientID = newClientID;
        }

        /// <summary>
        /// 添加脚本资源引用
        /// </summary>
        /// <param name="resource"></param>
        protected void AddScriptResource(string resource)
        {
            this.Page.ClientScript.RegisterClientScriptResource(this.GetType(), resource);
        }

        /// <summary>
        /// 添加相关css引用
        /// </summary>
        /// <param name="resource"></param>
        protected void AddCssResource(string resource)
        {
            //添加相关css引用
            string resourceurl = Page.ClientScript.GetWebResourceUrl(this.GetType(), resource);
            var lnk = new HtmlLink { Href = resourceurl };
            lnk.Attributes["rel"] = "stylesheet";
            lnk.Attributes["type"] = "text/css";
            Page.Header.Controls.Add(lnk);
        }
    }
}
