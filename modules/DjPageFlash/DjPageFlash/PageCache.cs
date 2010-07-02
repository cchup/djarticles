using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Web;

namespace DjPageFlash
{
    public class PageCache
    {
        private PageCache()
        {

        }
        private static Hashtable cacheMap = null;
        /// <summary>
        ///  url连接匹配正则表达式字符串
        /// </summary>
        private static string matchRegexUrl = @"tabid/(\d*)/";
        static PageCache()
        {
            cacheMap = new Hashtable();
        }

        /// <summary>
        /// 更新整个缓存信息
        /// </summary>
        public static void UpdateCacheMap()
        {
        }

        /// <summary>
        /// url连接匹配正则表达式字符串
        /// </summary>
        public static string MatchRegexUrl
        {
            get { return matchRegexUrl; }
        }

        /// <summary>
        /// 获取当前页面的缓存状态
        /// </summary>
        /// <param name="pageKey"></param>
        /// <returns></returns>
        public static PageCacheStateType GetPageCacheState(string pageKey)
        {
            PageState pageState=cacheMap[pageKey] as PageState;
            if (pageState== null)
            {
                //还不包含该页的状态信息，返回初始状态
                return PageCacheStateType.Init;
            }
            if (pageState.PageCacheState == PageCacheStateType.Static)
            {
                if (!File.Exists(HttpContext.Current.Server.MapPath(pageState.StaticHtmlPageUrl)))
                {
                    pageState.PageCacheState = PageCacheStateType.Init;
                }
            }
            return pageState.PageCacheState;
        }

        public static string GetPageStaticHtmlUrl(string pageKey)
        {
            PageState pageState = cacheMap[pageKey] as PageState;
            if (pageState != null && pageState.PageCacheState== PageCacheStateType.Static)
            {
                return pageState.StaticHtmlPageUrl;
            }
            //还不包含该页的状态信息,或该页面还未静态化处理，返回空
            return "";
        }

        /// <summary>
        /// 更新当前页面的状态信息，标识该页面已经生成了Html静态页面
        /// </summary>
        /// <param name="pageKey"></param>
        /// <param name="htmlUrl"></param>
        /// <returns></returns>
        public static void UpdatePageStaticHtmlInfo(string pageKey, string htmlUrl)
        {
            PageState pageState = cacheMap[pageKey] as PageState;
            if (pageState ==null)
            {
                pageState=new PageState();
                cacheMap[pageKey] = pageState;
            }
            pageState.StaticHtmlPageUrl = htmlUrl;
            pageState.PageCacheState = PageCacheStateType.Static;
        }
    }

}
