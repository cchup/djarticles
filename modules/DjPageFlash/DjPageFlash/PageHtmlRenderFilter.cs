using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;

namespace DjPageFlash
{
    public class PageHtmlRenderFilter:Stream
    {
        private Stream m_sink;
        private long m_position;
        private FileStream fs;
        private string filePath = string.Empty;
        private string pageKey = string.Empty;

        public PageHtmlRenderFilter(Stream sink, string pageKey)
        {
            this.m_sink = sink;
            this.pageKey = pageKey;
            this.filePath = GetHtmlUrl();
        }

        // The following members of Stream must be overriden.
        public override bool CanRead
        { get { return true; } }

        public override bool CanSeek
        { get { return false; } }

        public override bool CanWrite
        { get { return false; } }

        public override long Length
        { get { return 0; } }

        public override long Position
        {
            get { return m_position; }
            set { m_position = value; }
        }

        public override long Seek(long offset, System.IO.SeekOrigin direction)
        {
            return 0;
        }

        public override void SetLength(long length)
        {
            this.m_sink.SetLength(length);
        }

        public override void Close()
        {
            this.m_sink.Close();
            if (this.fs != null)
            {
                this.fs.Close();
            }
        }

        public override void Flush()
        {
            this.m_sink.Flush();
            this.UpdatePageCacheState();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return m_sink.Read(buffer, offset, count);
        }

        // Override the Write method to filter Response to a file.
        public override void Write(byte[] buffer, int offset, int count)
        {
            //Write out the response to the browser.
            this.m_sink.Write(buffer, 0, count);
            //Write out the response to the local file
            string fullFilePath = HttpContext.Current.Server.MapPath(filePath);
            //首先判断有没有系统错误
            if (HttpContext.Current.Error == null)
            {
                try
                {
                    //创建文件夹
                    CreateDirectory(Path.GetDirectoryName(fullFilePath));
                    if (fs == null)
                    {
                        this.fs = new FileStream(fullFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                    }
                    //将数据写入静态文件.
                    this.fs.Write(buffer, 0, count);
                }
                catch
                {
                    if (fs != null)
                    {
                        //关闭流
                        this.fs.Close();
                        //删除静态页面
                        if (File.Exists(fullFilePath))
                        {
                            File.Delete(fullFilePath);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 更新当前页面的状态
        /// </summary>
        protected virtual void UpdatePageCacheState()
        {
            PageCache.UpdatePageStaticHtmlInfo(this.pageKey, this.filePath);
        }

        /// <summary>
        /// 获取要生成的静态文件的路径
        /// </summary>
        /// <returns></returns>
        protected virtual string GetHtmlUrl()
        {
            return @"/Portals/1/Cache/Tabs/" + Guid.NewGuid().ToString("N")+".html";
        }

        /// <summary>
        /// 创建文件夹，如果文件夹存在则返回，如果文件夹不存在则创建该文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        private void CreateDirectory(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            if (Directory.Exists(path))
            {
                return;
            }

            Directory.CreateDirectory(path);
        }
    }
}
