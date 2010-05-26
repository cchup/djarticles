/************************************************************************/
/* 分页控件，显示分页信息和提供分页导航功能。
 * 此控件源于AspNetPager
 * http://www.webdiyer.com/AspNetPager/
/* 侯德军 2009/05/21                                                    */
/************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.IO;
using System.Web.UI.Design;
using System.Security.Permissions;

namespace DjArticles.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [ParseChildren(false)]
    [PersistChildren(false)]
    [Designer(typeof(PagerDesigner))]
    [ToolboxData("<{0}:NetPager runat=server></{0}:NetPager>")]
    public class NetPager : DJBaseControl, IPostBackEventHandler, IPostBackDataHandler
    {

        #region field

        private const string PagingInfoFormat = "总记录：{0} &nbsp;&nbsp;页码：{1}/{2}&nbsp;&nbsp;每页：{3}";
        private const string UrlPageIndexName = "djnetpage";
        private Unit PagingButtonSpacing = Unit.Pixel(5);

        private string currentUrl = null;
        private NameValueCollection urlParams = null;
        private string inputPageIndex;

        private static readonly object EventPageChanging = new object();
        private static readonly object EventPageChanged = new object();

        #endregion

        #region 分页属性
        [ReadOnly(true),
        Browsable(false),
        Description("当前页的索引,从1开始"),
        Category("分页"),
        DefaultValue(1),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentPageIndex
        {
            get
            {
                object currentPageIndex = ViewState["CurrentPageIndex"];
                int pindex = (currentPageIndex == null) ? 1 : (int)currentPageIndex;
                if (pindex > PageCount && PageCount > 0)
                    return PageCount;
                else if (pindex < 1)
                    return 1;
                return pindex;
            }
            set
            {
                int cpage = value;
                if (cpage < 1)
                    cpage = 1;
                else if (cpage > this.PageCount)
                    cpage = this.PageCount;
                ViewState["CurrentPageIndex"] = cpage;
            }
        }

        [Browsable(false),
        Description("要分页的所有记录的总数，该值须在程序运行时设置，默认值为225是为设计时支持而设置的参照值。"),
        Category("Data"),
        DefaultValue(0)]
        public int RecordCount
        {
            get
            {
                return GetViewStateInt("Recordcount", 255);
            }
            set { ViewState["Recordcount"] = value; }
        }

        [Browsable(true),
        Description("分页大小"),
        Category("分页"),
        DefaultValue(10)]
        public int PageSize
        {
            get
            {
                return GetViewStateInt("PageSize", 10);
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }

        [Browsable(false),
        Description("总的页数"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageCount
        {
            get
            {
                if (RecordCount == 0)
                    return 1;
                return (int)Math.Ceiling((double)RecordCount / (double)PageSize);
            }
        }

        [Browsable(false),
        Description("当前页的记录开始索引"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StartRecordIndex
        {
            get
            {
                return (CurrentPageIndex - 1) * PageSize + 1;
            }
        }

        [Browsable(false),
        Description("当前页的记录结束索引"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int EndRecordIndex
        {
            get
            {
                return RecordCount - RecordsRemain;
            }
        }

        [Browsable(false),
        Description("当前页后面还未显示的纪录数"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RecordsRemain
        {
            get
            {
                if (CurrentPageIndex < PageCount)
                    return RecordCount - (CurrentPageIndex * PageSize);
                return 0;
            }
        }

        [Browsable(true),
        Description("是否用Url的方式回传")]
        public bool UrlPaging
        {
            get { return GetViewStateBoolean("UrlPaging", false); }
            set { ViewState["UrlPaging"] = value; }
        }

        [Browsable(true),
        Themeable(false),
        Category("Behavior"),
        DefaultValue(false),
        Description("回传地址是否可以进行Url重写")]
        public bool EnableUrlRewriting
        {
            get { return GetViewStateBoolean("UrlRewriting", false); }
            set { ViewState["UrlRewriting"] = value; }
        }

        [Browsable(true),
        Themeable(false),
        Category("Behavior"),
        DefaultValue(null)]
        public string UrlRewritePattern
        {
            get
            {
                string defaultURPattern = null;
                if (EnableUrlRewriting)
                {
                    string filePath = Page.Request.FilePath;
                    return Path.GetFileNameWithoutExtension(filePath) + "_{0}" + Path.GetExtension(filePath);
                }
                return GetViewStateString("URPattern", defaultURPattern);
            }

            set { ViewState["URPattern"] = value; }
        }
        #endregion

        #region 分页显示样式相关
        [Browsable(true),
        Themeable(false),
        Description("总记录数显示文本"),
        Category("分页"),
        DefaultValue("总记录")]
        public string TotalRecordText
        {
            get
            {
                return GetViewStateString("TotalRecordText");
            }
            set { ViewState["TotalRecordText"] = value; }
        }

        [Browsable(true),
       Themeable(false),
       Description("每页记录数大小显示文本"),
       Category("分页"),
       DefaultValue("每页")]
        public string PageSizeText
        {
            get
            {
                return GetViewStateString("PageSizeText");
            }
            set { ViewState["PageSizeText"] = value; }
        }


        [Browsable(true),
       Themeable(false),
       Description("当前页码显示文本"),
       Category("分页"),
       DefaultValue("页码")]
        public string PageNumberText
        {
            get
            {
                return GetViewStateString("PageNumberText");
            }
            set { ViewState["PageNumberText"] = value; }
        }

        [Browsable(true),
        Themeable(false),
        Description("第一页按钮显示的文本"),
        Category("分页"),
        DefaultValue("首页")]
        public string FirstPageText
        {
            get
            {
                return GetViewStateString("FirstPageText", "首页");
            }
            set { ViewState["FirstPageText"] = value; }
        }

        [Browsable(true),
        Themeable(false),
        Description("上一页按钮显示的文本"),
        Category("分页"),
        DefaultValue("上一页")]
        public string PrevPageText
        {
            get
            {
                return GetViewStateString("PrevPageText", "上一页");
            }
            set { ViewState["PrevPageText"] = value; }
        }

        [Browsable(true),
        Themeable(false),
        Description("下一页按钮显示的文本"),
        Category("分页"),
        DefaultValue("下一页")]
        public string NextPageText
        {
            get
            {
                return GetViewStateString("NextPageText", "下一页");
            }
            set { ViewState["NextPageText"] = value; }
        }

        [Browsable(true),
        Themeable(false),
        Description("最后一页按钮显示的文本"),
        Category("cat_Navigation"),
        DefaultValue("尾页")]
        public string LastPageText
        {
            get
            {
                return GetViewStateString("LastPageText", "尾页");
            }
            set { ViewState["LastPageText"] = value; }
        }

        [Browsable(true),
        Themeable(false),
        Description("最多要显示的页索引按钮的个数"),
        Category("cat_Navigation"),
        DefaultValue(10)]
        public int NumericButtonCount
        {
            get
            {
                return GetViewStateInt("NumericButtonCount", 10);
            }
            set { ViewState["NumericButtonCount"] = value; }
        }

        #endregion

        #region 其他
        [Browsable(true),
        Themeable(false),
        Category("Behavior"),
        Description("设置当页数为1时是否始终要显示分页控件"),
        DefaultValue(true)]
        public bool AlwaysShow
        {
            get
            {
                return GetViewStateBoolean("AlwaysShow", true);
            }
            set
            {
                ViewState["AlwaysShow"] = value;
            }
        }
        #endregion

        /// <summary>
        /// 控件加载方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (UrlPaging)
            {
                currentUrl = Page.Request.Path;
                urlParams = Page.Request.QueryString;
                if (!Page.IsPostBack)
                {
                    string pageIndex = Page.Request.QueryString[UrlPageIndexName];
                    int index = 1;
                    if (!string.IsNullOrEmpty(pageIndex))
                    {
                        try
                        {
                            index = int.Parse(pageIndex);
                        }
                        catch { }
                    }
                    PageChangingEventArgs args = new PageChangingEventArgs(index);
                    OnPageChanging(args);
                }
            }
            else
            {
                inputPageIndex = Page.Request.Form[this.UniqueID + "_input"];
            }

        }

        #region 绘制分页控件内容

        /// <summary>
        /// 渲染控件的开始标签
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "23px");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
        }


        /// <summary>
        /// 渲染控件的结束标签
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.RenderEndTag();
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            if (PageCount > 1 || (PageCount <= 1 && AlwaysShow))
            {
                output.AddAttribute(HtmlTextWriterAttribute.Width, "100%");
                output.AddAttribute(HtmlTextWriterAttribute.Style, Style.Value);
                if (Height != Unit.Empty)
                    output.AddStyleAttribute(HtmlTextWriterStyle.Height, Height.ToString());
                output.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                output.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "5");
                output.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
                output.RenderBeginTag(HtmlTextWriterTag.Table);
                output.RenderBeginTag(HtmlTextWriterTag.Tr);
                //内容渲染
                RenderPagingInfo(output);
                RenderPagingIndex(output);
                output.RenderEndTag();
                output.RenderEndTag();
            }
        }

        /// <summary>
        /// 输出分页信息
        /// </summary>
        /// <param name="output"></param>
        private void RenderPagingInfo(HtmlTextWriter output)
        {
            string pageInfo = string.Format(PagingInfoFormat,
                this.RecordCount,
                this.CurrentPageIndex,
                this.PageCount,
                this.PageSize);
            output.AddAttribute(HtmlTextWriterAttribute.Align, "left");
            output.AddStyleAttribute(HtmlTextWriterStyle.PaddingLeft, "15px");
            output.RenderBeginTag(HtmlTextWriterTag.Td);
            output.Write(pageInfo);
            output.RenderEndTag();
        }

        /// <summary>
        /// 输出分页导航
        /// </summary>
        /// <param name="output"></param>
        private void RenderPagingIndex(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Align, "right");
            output.AddStyleAttribute(HtmlTextWriterStyle.PaddingRight, "15px");
            output.RenderBeginTag(HtmlTextWriterTag.Td);
            ///开始输出分页导航
            int midpage = ((CurrentPageIndex - 1) / NumericButtonCount);
            int pageoffset = midpage * NumericButtonCount;
            int endpage = ((pageoffset + NumericButtonCount) > PageCount) ? PageCount : (pageoffset + NumericButtonCount);
            RenderNavigationButton(output, NavigationButtonType.First, 0);
            RenderNavigationButton(output, NavigationButtonType.Prev, 0);
            if (CurrentPageIndex > NumericButtonCount)
            {
                RenderMoreButton(output, pageoffset);
            }
            for (int i = pageoffset + 1; i <= endpage; i++)
            {
                RenderNavigationButton(output, NavigationButtonType.PagingIndex, i);
            }
            if (PageCount > NumericButtonCount && endpage < PageCount)
            {
                RenderMoreButton(output, endpage + 1);
            }
            RenderNavigationButton(output, NavigationButtonType.Next, 0);
            RenderNavigationButton(output, NavigationButtonType.Last, 0);
            ///结束输出分页导航
            output.RenderEndTag();
        }

        /// <summary>
        /// 输出按钮
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="btntype"></param>
        /// <param name="btnPageIndex">只有当按钮类型为NavigationButtonType.PagingIndex才有效</param>
        private void RenderNavigationButton(HtmlTextWriter writer, NavigationButtonType btntype, int btnPageIndex)
        {
            string linktext = "";
            bool disabled;
            int pageIndex;
            if (btntype == NavigationButtonType.First || btntype == NavigationButtonType.Prev)
            {   ///输出 首页 和 上一页
                disabled = (CurrentPageIndex <= 1);
                pageIndex = (btntype == NavigationButtonType.First) ? 1 : (CurrentPageIndex - 1);
                linktext = (btntype == NavigationButtonType.First) ? FirstPageText : PrevPageText;
            }
            else if (btntype == NavigationButtonType.Next || btntype == NavigationButtonType.Last)
            {   ///输出 下一页 和 尾页
                disabled = (CurrentPageIndex >= PageCount);
                pageIndex = (btntype == NavigationButtonType.Last) ? PageCount : (CurrentPageIndex + 1);
                linktext = (btntype == NavigationButtonType.Next) ? NextPageText : LastPageText;
            }
            else
            {
                bool isCurrent = (btnPageIndex == CurrentPageIndex);
                disabled = isCurrent;
                pageIndex = btnPageIndex;
                linktext = btnPageIndex.ToString();
                if (isCurrent)
                {
                    writer.AddStyleAttribute(HtmlTextWriterStyle.FontWeight, "Bold");
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "red");
                }
            }
            WriteSpacingStyle(writer);
            if (!disabled)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Href, GetHrefString(pageIndex));
            }
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write(linktext);
            writer.RenderEndTag();
        }

        /// <summary>
        /// 输出更多按钮
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="pageIndex"></param>
        private void RenderMoreButton(HtmlTextWriter writer, int pageIndex)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            WriteCssClass(writer);
            WriteSpacingStyle(writer);
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.AddAttribute(HtmlTextWriterAttribute.Href, GetHrefString(pageIndex));
            writer.Write("...");
            writer.RenderEndTag();
            writer.RenderEndTag();
        }

        /// <summary>
        /// 添加Css属性
        /// </summary>
        /// <param name="writer"></param>
        private void WriteCssClass(HtmlTextWriter writer)
        {
            if (this.CssClass != null && this.CssClass.Trim().Length > 0)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
            }
        }

        /// <summary>
        /// 输出右边距空白间隔样式
        /// </summary>
        /// <param name="writer"></param>
        private void WriteSpacingStyle(HtmlTextWriter writer)
        {
            if (PagingButtonSpacing.Value != 0)
                writer.AddStyleAttribute(HtmlTextWriterStyle.MarginRight, PagingButtonSpacing.ToString());
        }

        /// <summary>
        /// 获取指定分页的导航链接字符串
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private string GetHrefString(int pageIndex)
        {
            if (UrlPaging)
            {
                if (EnableUrlRewriting)
                {
                    Regex reg = new Regex("(?<p>%(?<m>[^%]+)%)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    MatchCollection mts = reg.Matches(UrlRewritePattern);
                    string prmValue;
                    foreach (Match m in mts)
                    {
                        prmValue = urlParams[m.Groups["m"].Value];
                        if (prmValue != null)
                            UrlRewritePattern = UrlRewritePattern.Replace(m.Groups["p"].Value, prmValue);
                    }
                    return ResolveUrl(string.Format(UrlRewritePattern, (pageIndex == -1) ? "\"+pi+\"" : pageIndex.ToString()));
                }
                else
                {
                    NameValueCollection col = new NameValueCollection();
                    col.Add(UrlPageIndexName, (pageIndex == -1) ? "\"+pi+\"" : pageIndex.ToString());
                    return BuildUrlString(col);
                }
            }
            return Page.ClientScript.GetPostBackClientHyperlink(this, pageIndex.ToString());
        }

        /// <summary>
        /// 将指定的链接参数添加到当前的连接参数中
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        private string BuildUrlString(NameValueCollection col)
        {
            int i;
            string tempstr = "";
            if (urlParams == null || urlParams.Count <= 0)
            {
                for (i = 0; i < col.Count; i++)
                {
                    tempstr += String.Concat("&", col.Keys[i], "=", col[i]);
                }
                return String.Concat(Path.GetFileName(currentUrl), "?", tempstr.Substring(1));
            }
            NameValueCollection newCol = new NameValueCollection(urlParams);
            string[] newColKeys = newCol.AllKeys;
            for (i = 0; i < newColKeys.Length; i++)
            {
                if (newColKeys[i] != null)
                    newColKeys[i] = newColKeys[i].ToLower();
            }
            for (i = 0; i < col.Count; i++)
            {
                if (Array.IndexOf(newColKeys, col.Keys[i].ToLower()) < 0)
                    newCol.Add(col.Keys[i], col[i]);
                else
                    newCol[col.Keys[i]] = col[i];
            }
            StringBuilder sb = new StringBuilder();
            for (i = 0; i < newCol.Count; i++)
            {
                if (newCol.Keys[i] != null)
                {
                    sb.Append("&");
                    sb.Append(newCol.Keys[i]);
                    sb.Append("=");
                    if (newCol.Keys[i] == UrlPageIndexName)
                        sb.Append(newCol[i]);
                    else
                        sb.Append(Page.Server.UrlEncode(newCol[i]));
                }
            }
            return String.Concat(Path.GetFileName(currentUrl), "?", sb.ToString().Substring(1));
        }

        #endregion

        #region Events
        public event PageChangingEventHandler PageChanging
        {
            add
            {
                base.Events.AddHandler(EventPageChanging, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventPageChanging, value);
            }
        }

        public event PageChangingEventHandler PageChanged
        {
            add
            {
                base.Events.AddHandler(EventPageChanged, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventPageChanged, value);
            }
        }

        #endregion

        #region IPostBackEventHandler Implementation


        public void RaisePostBackEvent(string args)
        {
            int pageIndex = CurrentPageIndex;
            try
            {
                if (args == null || args == "")
                    args = inputPageIndex;
                pageIndex = int.Parse(args);
            }
            catch { }
            PageChangingEventArgs pcArgs = new PageChangingEventArgs(pageIndex);
            OnPageChanging(pcArgs);
        }


        #endregion

        #region IPostBackDataHandler Implementation

        public virtual bool LoadPostData(string pkey, NameValueCollection pcol)
        {
            string str = pcol[this.UniqueID + "_input"];
            if (str != null && str.Trim().Length > 0)
            {
                try
                {
                    int pindex = int.Parse(str);
                    if (pindex > 0 && pindex <= PageCount)
                    {
                        inputPageIndex = str;
                        Page.RegisterRequiresRaiseEvent(this);
                    }
                }
                catch
                { }
            }
            return false;
        }

        public virtual void RaisePostDataChangedEvent() { }

        #endregion

        #region Methods

        private void OnPageChanging(PageChangingEventArgs e)
        {
            this.CurrentPageIndex = e.NewPageIndex;
            OnPageChanged(e);
            PageChangingEventHandler handler = (PageChangingEventHandler)base.Events[EventPageChanged];
            if (handler != null && !e.Cancel)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPageChanged(PageChangingEventArgs e)
        {
            // do nothing
        }

        #endregion


        /// <summary>
        /// 导航页按钮类型
        /// </summary>
        enum NavigationButtonType
        {
            First,
            Prev,
            PagingIndex,
            Next,
            Last,
        }
    }

    public delegate void PageChangingEventHandler(object src, PageChangingEventArgs e);

    public sealed class PageChangingEventArgs : CancelEventArgs
    {
        private readonly int _newpageindex;

        public PageChangingEventArgs(int newPageIndex)
        {
            this._newpageindex = newPageIndex;
        }

        /// <summary>
        /// 当前显示页码，以1开始的索引
        /// </summary>
        public int NewPageIndex
        {
            get { return _newpageindex; }
        }
    }

    public class PagerDesigner : ControlDesigner
    {
        private NetPager netPager;

        public override string GetEditableDesignerRegionContent(System.Web.UI.Design.EditableDesignerRegion region)
        {
            region.Selectable = false;
            return null;
        }

        public override string GetDesignTimeHtml()
        {

            netPager = (NetPager)Component;
            netPager.RecordCount = 225;
            StringWriter sw = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            netPager.RenderControl(writer);
            return sw.ToString();
        }

        protected override string GetErrorDesignTimeHtml(Exception e)
        {
            string errorstr = "Error creating control：" + e.Message;
            return CreatePlaceHolderDesignTimeHtml(errorstr);
        }
    }
}
