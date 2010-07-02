using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Threading;

namespace DjPageFlash
{
    public class PageFlash : BasePageFlash, IHttpModule
    {
        private const string Html_Render_Key = "willRenderHtml";

        
        /// <summary>
        /// 请求开始事件处理
        /// </summary>
        /// <param name="app"></param>
        protected override void OnBeginRequest(HttpApplication app)
        {
            //初始设置
            //SetWillRenderHtml(app.Context,false);
            //判断是否需要进行处理
            if (app.Request.RequestType != "GET")
            {
                return;
            }
            string requestUrl = app.Context.Request.RawUrl;
            string pageKeyValue = "";
            if (IsMatchPage(requestUrl, out pageKeyValue))
            {
                if (PageCache.GetPageCacheState(pageKeyValue) == PageCacheStateType.Static)
                {
                    //该页面已进行了静态化处理，获取该页的静态页面并转向
                    string staticUrl = PageCache.GetPageStaticHtmlUrl(pageKeyValue);
                    if (!string.IsNullOrEmpty(staticUrl))
                    {
                        RewriterUtils.RewriteUrl(app.Context, staticUrl);
                    }
                }
                else
                {
                    //该页还未进行静态化处理，但此处需要进行静态化处理
                    PageHtmlRenderFilterFactory.SetPageHtmlRenderFilter(app.Response, pageKeyValue);
                }
            }
        }

        /// <summary>
        /// 请求结束事件处理
        /// </summary>
        /// <param name="app"></param>
        protected override void OnEndRequest(HttpApplication app)
        {
        }

        #region helper method
        

        /// <summary>
        /// 判读请求Url是否匹配处理规则，如果是根据请求的Url地址获取该请求地址唯一标识的页面的关键参数值
        /// 如：http://192.168.1.101/default.aspx?tabid=101&ctl=edit
        /// 如果系统设置tabid为关键键来唯一标识一个页面，那么该方法返回101
        /// </summary>
        /// <param name="requestUrl">请求url地址</param>
        /// <param name="pageKey">返回关键键值</param>
        /// <returns>是否匹配</returns>
        private bool IsMatchPage(string requestUrl,out string pageKey)
        {
           Match match= Regex.Match(requestUrl, PageCache.MatchRegexUrl);
           if (match.Success)
           {
               if (match.Groups.Count > 0)
               {
                   pageKey= match.Groups[0].Value;
                   return true;
               }
           }
           pageKey = "";
           return false;
        }

        /// <summary>
        /// 从Session中获取状态是否需要输出静态文件
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool WillRenderHtml(HttpContext context)
        {
            object _willRenderHtml = context.Session[Html_Render_Key];
            if (_willRenderHtml != null && _willRenderHtml.ToString().ToLower() == "true")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 在Session中添加状态是否需要输出HTMl静态文件
        /// </summary>
        /// <param name="context"></param>
        /// <param name="willRenderHtml"></param>
        private void SetWillRenderHtml(HttpContext context, bool willRenderHtml)
        {
            context.Session[Html_Render_Key] = willRenderHtml.ToString();
        }
        #endregion
    }
}
