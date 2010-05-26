using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetNuke.Common.Utilities;
using DotNetNuke.UI.UserControls;

namespace DjArticles.Common
{
    /// <summary>
    /// webcontrol控件处理代码
    /// </summary>
    public class WebControlUtils
    {
        /// <summary>
        /// 从HiddenField控件中获取Int值
        /// </summary>
        /// <param name="hiddenField">HiddenField控件对象</param>
        /// <returns></returns>
        public static int GetObjectIntValue(HiddenField hiddenField) 
        {
            if (hiddenField == null)
            {
                return Null.NullInteger ;
            }
            string _value = hiddenField.Value;
            int value = Null.NullInteger;
            if (!int.TryParse(_value, out value))
            {
                value = Null.NullInteger;
            }
            return value;
        }

        /// <summary>
        /// 从DropDownList控件中获取选择项的值
        /// </summary>
        /// <param name="dropDownControl"></param>
        /// <returns></returns>
        public static int GetObjectIntValue(DropDownList dropDownControl)
        {
            if (dropDownControl == null)
            {
                return Null.NullInteger;
            }
            string _value = dropDownControl.SelectedValue;
            int value = Null.NullInteger;
            if (!int.TryParse(_value, out value))
            {
                value = Null.NullInteger;
            }
            return value;
        }

        /// <summary>
        /// 设置编辑器控件值
        /// </summary>
        /// <param name="userControl"></param>
        /// <param name="value"></param>
        public static void SetTextEditorValue(UserControl userControl, string value)
        {
            TextEditor editorControl = userControl as TextEditor;
            if (editorControl == null)
            {
                return;
            }
            editorControl.Text = value;
        }

        /// <summary>
        /// 获取编辑器控件值
        /// </summary>
        /// <param name="userControl"></param>
        /// <returns></returns>
        public static string GetTextEditorValue(UserControl userControl)
        {
            TextEditor editorControl = userControl as TextEditor;
            if (editorControl == null)
            {
                return "";
            }
            if (editorControl.RichText != null)
            {
                return editorControl.RichText.Text;
            }
            return editorControl.Text;
        }
    }
}
