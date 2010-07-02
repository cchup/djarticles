using System;
using System.Collections.Generic;
using System.Text;

namespace DjPageFlash
{
    /// <summary>
    /// 标识页面状态信息的类
    /// </summary>
    public class PageState
    {
        private PageCacheStateType pageCacheState;

        public PageCacheStateType PageCacheState
        {
            get { return pageCacheState; }
            set { pageCacheState = value; }
        }

        private string staticHtmlPageUrl;

        public string StaticHtmlPageUrl
        {
            get { return staticHtmlPageUrl; }
            set { staticHtmlPageUrl = value; }
        }
    }


    /// <summary>
    /// 页面状态枚举
    /// </summary>
    public enum PageCacheStateType
    {
        /// <summary>
        /// 初始状态,没有任何处理
        /// </summary>
        Init,
        /// <summary>
        /// 已静态化处理可以从静态文件中获取该页面信息。
        /// </summary>
        Static,
    }
}

