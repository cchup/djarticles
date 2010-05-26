/************************************************************************/
/* GridView控件
 * 1、 自定义颜色
 * 2、 自动分页显示，以及自动处理分页事件
/* 侯德军 2009/12/06                                                    */
/************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Collections;

[assembly: WebResource("DjGridView.bmp", "image/bmp")]
namespace DjArticles.Controls.GridView
{

    [ToolboxData("<{0}:DjGridView runat=server></{0}:DjGridView>")]
    [ToolboxBitmap(typeof(DjGridView), "DjGridView.bmp")]
    public class DjGridView : System.Web.UI.WebControls.GridView
    {
        #region field
        private Color oddRowBackColor = Color.FromName("#FFFFFF");
        private Color evenRowBackColor = Color.FromName("#F7F6F3");
        private Color mouseOverBackColor = Color.FromName("#FFFF77");
        private Color headerRowBackColor = Color.FromName("#E7E7E7");
        private Color footerRowBackColor = Color.FromName("#5D7B9D");

        private FontUnit _fontSize = FontUnit.Empty;
        private int _recordCount = 0;

        protected NetPager pager = null;

        private static readonly object eventDataSourceBind=new object();

        private bool _isEmptyDataSource = false;
        #endregion

        #region properties
        /// <summary>
        /// 奇数行背景颜色
        /// </summary>
        [System.ComponentModel.Category("Appearance"),
        System.ComponentModel.Description("奇数行背景颜色")]
        public System.Drawing.Color OddRowBackColor
        {
            get
            {
                return oddRowBackColor;
            }
            set
            {
                oddRowBackColor = value;
            }
        }

        /// <summary>
        /// 偶数行背景颜色
        /// </summary>
        [System.ComponentModel.Category("Appearance"),
        System.ComponentModel.Description("偶数行背景颜色")]
        public System.Drawing.Color EvenRowBackColor
        {
            get
            {
                return evenRowBackColor;
            }
            set
            {
                evenRowBackColor = value;
            }
        }

        /// <summary>
        /// 鼠标停靠的行的背景颜色
        /// </summary>
        [System.ComponentModel.Category("Appearance"),
        System.ComponentModel.Description("鼠标停靠的行的背景颜色.")]
        public System.Drawing.Color MouseOverBackColor
        {
            get
            {
                return mouseOverBackColor;
            }
            set
            {
                mouseOverBackColor = value;
            }
        }

        /// <summary>
        /// 自定义字体大小
        /// </summary>
        [System.ComponentModel.Category("Appearance"),
        System.ComponentModel.Description("自定义字体大小")]
        public FontUnit CustomFontSize
        {
            get
            {
                return _fontSize;
            }
            set
            {
                _fontSize = value;
            }
        }

        /// <summary>
        /// 标题行的背景颜色
        /// </summary>
        [System.ComponentModel.Category("Appearance"),
        System.ComponentModel.Description("标题行的背景颜色")]
        public Color HeaderRowBackColor
        {
            get { return headerRowBackColor; }
            set { headerRowBackColor = value; }
        }

        /// <summary>
        /// 分页行的背景颜色
        /// </summary>
        [System.ComponentModel.Category("Appearance"),
        System.ComponentModel.Description("分页行的背景颜色")]
        public Color FooterRowBackColor
        {
            get { return footerRowBackColor; }
            set { footerRowBackColor = value; }
        }

        public bool CustomPager {

            get { return (bool?)ViewState["CustomPager"]??true; }
            set { ViewState["CustomPager"] = value; }
        }

        /// <summary>
        /// 绑定数据源事件
        /// </summary>
        [System.ComponentModel.Category("Action"),
        System.ComponentModel.Description("")]
        public event EventHandler DataSourceBind
        {
            add {
                if (base.Events[eventDataSourceBind] == null)
                {
                    base.Events.AddHandler(eventDataSourceBind, value);
                }
            }
            remove { base.Events.RemoveHandler(eventDataSourceBind, value); }
        }

        #endregion

        public DjGridView()
        {
            //设置默认值
            this.AllowPaging = true;
            this.PageSize = 15;
        }

        protected override void OnRowDataBound(System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               if (e.Row.RowIndex % 2 == 0)    
                {
                    if (oddRowBackColor != System.Drawing.Color.Empty)
                    {
                        e.Row.Style[HtmlTextWriterStyle.BackgroundColor] = ColorTranslator.ToHtml(oddRowBackColor);
                    }

                    if (mouseOverBackColor != System.Drawing.Color.Empty)
                    {
                        e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='" + System.Drawing.ColorTranslator.ToHtml(mouseOverBackColor) + "'";
                        e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='" + System.Drawing.ColorTranslator.ToHtml(oddRowBackColor) + "'";
                    }
                }
                else   
                {
                    if (evenRowBackColor != System.Drawing.Color.Empty)
                    {
                        e.Row.Style[HtmlTextWriterStyle.BackgroundColor] = ColorTranslator.ToHtml(evenRowBackColor);
                    }

                    if (mouseOverBackColor != System.Drawing.Color.Empty)
                    {
                        e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='" + System.Drawing.ColorTranslator.ToHtml(mouseOverBackColor) + "'";
                        e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='" + System.Drawing.ColorTranslator.ToHtml(evenRowBackColor) + "'";
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Pager)
            {
                e.Row.BackColor = System.Drawing.Color.White;
                e.Row.HorizontalAlign = HorizontalAlign.Right;
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.BackColor = headerRowBackColor;
                e.Row.Font.Bold = true;
                e.Row.HorizontalAlign = HorizontalAlign.Center;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.BackColor =footerRowBackColor;
                e.Row.Font.Bold = true;
            }

            base.OnRowDataBound(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (this.EmptyDataTemplate == null && this.EmptyDataText == null)
            {
                this.EmptyDataText = "没有查询到任何数据";
            }
            ObjectDataSource ods = this.Page.FindControl(this.DataSourceID) as ObjectDataSource;  
            if (ods != null)
            {
                ods.Selected += new ObjectDataSourceStatusEventHandler(ods_Selected);
            }
            this.AllowPaging = true;
            base.OnLoad(e);
        }

        #region 分页方法

        private void ods_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.ReturnValue is IListSource)
            {
                _recordCount = ((IListSource)e.ReturnValue).GetList().Count;
            }
        }

        /// <summary>
        /// 初始化分页信息栏
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnSpan"></param>
        /// <param name="pagedDataSource"></param>
        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            if (CustomPager)
            {
                CreateCustomPager(row, columnSpan, pagedDataSource);
            }
            else
            {
                base.InitializePager(row, columnSpan, pagedDataSource);
            }
           
        }

        /// <summary>
        /// 创建自定义分页实现
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnSpan"></param>
        /// <param name="pagedDataSource"></param>
        protected virtual void CreateCustomPager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            int pageCount = pagedDataSource.PageCount;              
            int pageIndex = pagedDataSource.CurrentPageIndex;   
            int pageButtonCount = PagerSettings.PageButtonCount;    
            _recordCount = pagedDataSource.DataSourceCount;
            if (pager == null)
            {
                pager = new NetPager();
                pager.PageChanged += delegate(object sender,PageChangingEventArgs e) { this.OnPageChanged(sender, e); };
            }
            row.Height = (row.Height == Unit.Empty ? Unit.Pixel(23) : row.Height);
            TableCell cell = new TableCell();
            row.Cells.Add(cell);
            if (columnSpan > 1)
            {
                cell.ColumnSpan = columnSpan;
            }
            cell.Controls.Add(pager);
            this.pager.RecordCount = _recordCount;
            this.pager.CurrentPageIndex = pageIndex+1;
            this.pager.PageSize = pagedDataSource.PageSize;
        }

        /// <summary>
        /// 选择页更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnPageChanged(object sender, PageChangingEventArgs e)
        {
            int index=e.NewPageIndex;
            if (index>0)
            {
                index--;
            }
            this.PageIndex = index;
            EventHandler dataSourceBind = (EventHandler)this.Events[eventDataSourceBind];
            if (dataSourceBind == null)
            {
                throw new ApplicationException("重新设定了当前页，需要重新绑定数据源，但未指定数据源绑定事件");
            }
            dataSourceBind(this, e);
        }

        #endregion

        protected override void PerformDataBinding(System.Collections.IEnumerable data)
        {
            if (DesignMode)
            {
                base.PerformDataBinding(data);
                return;
            }
            int objCount = 0;
            foreach (Object o in data)
            {
                objCount++;
            }
            if (objCount > 0)
            {
                base.PerformDataBinding(data);
                return;
            }
            if (data.GetType() == typeof(DataView))
            {
                DataView dv = data as DataView;
                dv.Table.Rows.InsertAt(dv.Table.NewRow(), 0);
                base.PerformDataBinding(data);
                return;
            }
            else
            {
                _isEmptyDataSource = true;
                //自动设定的一个空数据对象，用户绑定数据对象为空时，占位使用
                base.PerformDataBinding(new Object []{ new Object() });
                return;
            }
        }

        /// <summary>
        /// 创建空数据源占位行
        /// </summary>
        private void CreateEmptyDataRow(GridViewRow row)
        {
            TableCell cell = new TableCell();
            cell.ColumnSpan = this.Columns.Count;
            Literal lable=new Literal();
            lable.Text = "没有查询到任何数据！";
            cell.Controls.Add(lable);
            row.Cells.Clear();
            row.Cells.Add(cell);
        }

        protected override void InitializeRow(GridViewRow row, DataControlField[] fields)
        {
            if ( _isEmptyDataSource&&row.RowType== DataControlRowType.DataRow)
            {
                //自动设定显示空数据对象信息
                CreateEmptyDataRow(row);
                return;
            }
            base.InitializeRow(row, fields);
        }
    }
}
