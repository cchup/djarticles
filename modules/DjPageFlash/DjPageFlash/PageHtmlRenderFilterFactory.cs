using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Threading;

namespace DjPageFlash
{
    public class PageHtmlRenderFilterFactory
    {
        private static object SyncObject = new object();

        /// <summary>
        /// 对当前Response设置过滤处理
        /// </summary>
        /// <param name="response"></param>
        public static void SetPageHtmlRenderFilter(HttpResponse response,string pageKey)
        {
            if (response != null)
            {
                //同步控制只需要一个线程来进行文件输出,如果同时有多个线程到此时，只需要一个线程来处理即可
                if (Monitor.TryEnter(SyncObject, 0))
                {
                    try
                    {
                        response.Filter = new PageHtmlRenderFilter(response.Filter, pageKey);
                    }
                    finally
                    {
                        Monitor.Exit(SyncObject);
                    }
                }
            }
        }


    }
}
