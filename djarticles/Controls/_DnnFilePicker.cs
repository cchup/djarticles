/**-
 * 此文件是DnnFilePicker反编译的C#版，尽供代码参考
 * --**/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetNuke.Web.UI.WebControls;
using DotNetNuke.Web.UI;
using DotNetNuke.UI.WebControls;
using System.Collections;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Common;
using DotNetNuke.Entities.Users;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.FileSystem;
using System.Runtime.CompilerServices;
using DotNetNuke.Security.Permissions;
using System.IO;

namespace DjArticles.Controls
{
    public class _DnnFilePicker : CompositeControl, ILocalizable
    {
        // Fields
        private bool _Localize = true;
        private string _LocalResourceFile;
        private int _MaxHeight = 100;
        private int _MaxWidth = 0x87;
        private DropDownList cboFiles;
        private DropDownList cboFolders;
        private CommandButton cmdCancel;
        private CommandButton cmdSave;
        private CommandButton cmdUpload;
        private HtmlTableCell commandCell;
        private HtmlTableRow commandRow;
        private HtmlTableCell fileCell;
        private HtmlTableRow fileRow;
        private HtmlTable fileTable;
        private HtmlTableCell folderCell;
        private HtmlTableRow folderRow;
        private Image imgPreview;
        private Label lblFile;
        private Label lblFolder;
        private Label lblMessage;
        private HtmlTableCell messageCell;
        private HtmlTableRow messageRow;
        private HtmlTableCell preViewCell;
        private HtmlInputFile txtFile;

        // Methods
        private void AddButton(ref CommandButton button, string imageUrl)
        {
            button = new CommandButton();
            button.EnableViewState = false;
            button.CausesValidation=false;
            button.ControlStyle.CssClass = this.CommandCssClass;
            if (!string.IsNullOrEmpty(imageUrl))
            {
                button.DisplayIcon=true;
                button.ImageUrl=imageUrl;
            }
            button.Visible = false;
            this.commandCell.Controls.Add(button);
        }

        private void AddCommandRow()
        {
            this.commandRow = new HtmlTableRow();
            this.commandRow.Visible = false;
            this.commandCell = new HtmlTableCell();
            this.AddButton(ref this.cmdUpload, "~/images/up.gif");
            this.cmdUpload.Click+=new EventHandler(this.UploadFile);
            this.AddButton(ref this.cmdSave, "~/images/save.gif");
            this.cmdSave.Click+=new EventHandler(this.SaveFile);
            this.commandCell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
            this.AddButton(ref this.cmdCancel, "~/images/lt.gif");
            this.cmdCancel.Click+=new EventHandler(this.CancelUpload);
            this.commandRow.Cells.Add(this.commandCell);
            this.fileTable.Rows.Add(this.commandRow);
        }

        private void AddFileRow()
        {
            this.fileRow = new HtmlTableRow();
            this.fileCell = new HtmlTableCell();
            this.lblFile = new Label();
            this.lblFile.EnableViewState = false;
            this.fileCell.Controls.Add(this.lblFile);
            this.fileCell.Controls.Add(new LiteralControl("<br/>"));
            this.cboFiles = new DropDownList();
            this.cboFiles.ID = "File";
            this.cboFiles.DataTextField = "Text";
            this.cboFiles.DataValueField = "Value";
            this.cboFiles.AutoPostBack = true;
            this.cboFiles.SelectedIndexChanged += new EventHandler(this.FileChanged);
            this.fileCell.Controls.Add(this.cboFiles);
            this.txtFile = new HtmlInputFile();
            this.fileCell.Controls.Add(this.txtFile);
            this.fileRow.Cells.Add(this.fileCell);
            this.fileTable.Rows.Add(this.fileRow);
        }

        private void AddFolderRow()
        {
            this.folderRow = new HtmlTableRow();
            this.folderCell = new HtmlTableCell();
            this.lblFolder = new Label();
            this.lblFolder.EnableViewState = false;
            this.folderCell.Controls.Add(this.lblFolder);
            this.folderCell.Controls.Add(new LiteralControl("<br/>"));
            this.cboFolders = new DropDownList();
            this.cboFolders.ID = "Folder";
            this.cboFolders.AutoPostBack = true;
            this.cboFolders.SelectedIndexChanged += new EventHandler(this.FolderChanged);
            this.folderCell.Controls.Add(this.cboFolders);
            this.LoadFolders();
            this.preViewCell = new HtmlTableCell();
            this.preViewCell.VAlign = "top";
            this.preViewCell.RowSpan = 3;
            this.imgPreview = new Image();
            this.preViewCell.Controls.Add(this.imgPreview);
            this.folderRow.Cells.Add(this.folderCell);
            this.folderRow.Cells.Add(this.preViewCell);
            this.fileTable.Rows.Add(this.folderRow);
        }

        private void AddMessageRow()
        {
            this.messageRow = new HtmlTableRow();
            this.messageCell = new HtmlTableCell();
            this.messageCell.ColSpan = 2;
            this.lblMessage = new Label();
            this.lblMessage.EnableViewState = false;
            this.lblMessage.CssClass = "NormalRed";
            this.lblMessage.Text = "";
            this.messageCell.Controls.Add(this.lblMessage);
            this.messageRow.Cells.Add(this.messageCell);
            this.fileTable.Rows.Add(this.messageRow);
        }

        private void CancelUpload(object sender, EventArgs e)
        {
            this.Mode = FileControlMode.Normal;
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            this.fileTable = new HtmlTable();
            this.AddFolderRow();
            this.AddFileRow();
            this.AddCommandRow();
            this.AddMessageRow();
            this.Controls.Add(this.fileTable);
            base.CreateChildControls();
        }

        private void FileChanged(object sender, EventArgs e)
        {
            this.SetFilePath();
        }

        private void FolderChanged(object sender, EventArgs e)
        {
            this.LoadFiles();
            this.SetFilePath();
        }

        private ArrayList GetFileList(bool NoneSpecified, string Folder)
        {
            if (this.IsHost)
            {
                return Globals.GetFileList(Null.NullInteger, this.FileFilter, NoneSpecified, this.cboFolders.SelectedItem.Value);
            }
            return Globals.GetFileList(this.PortalId, this.FileFilter, NoneSpecified, this.cboFolders.SelectedItem.Value);
        }

        private bool IsUserFolder(string folderPath)
        {
            return (folderPath.ToLowerInvariant().StartsWith("users/") && folderPath.EndsWith(string.Format("/{0}/", UserController.GetCurrentUserInfo().UserID.ToString())));
        }

        private void LoadFiles()
        {
            this.cboFiles.DataSource = this.GetFileList(!this.Required, this.cboFolders.SelectedItem.Value);
            this.cboFiles.DataBind();
        }

        private void LoadFolders()
        {
            IEnumerator enumerator=null;
            this.cboFolders.Items.Clear();
            ArrayList list = FileSystemUtils.GetFoldersByUser(this.PortalId, this.ShowSecure, this.ShowDatabase, "READ,ADD");
            try
            {
                enumerator = list.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    FolderInfo current = (FolderInfo)enumerator.Current;
                    ListItem item = new ListItem();
                    if (current.FolderPath== Null.NullString)
                    {
                        item.Text = Utilities.GetLocalizedString("PortalRoot");
                    }
                    else
                    {
                        item.Text = current.FolderPath;
                    }
                    item.Value = current.FolderPath;
                    this.cboFolders.Items.Add(item);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            if (this.IncludePersonalFolder)
            {
                this.cboFolders.Items.Add(new ListItem(Utilities.GetLocalizedString("MyFolder"), string.Format("Users/{0}/", FileSystemUtils.GetUserFolderPath(UserController.GetCurrentUserInfo().UserID).Replace(@"\", "/"))));
            }
        }

        protected virtual void LocalizeStrings()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.LocalResourceFile = Utilities.GetLocalResourceFile(this);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (this.cboFolders.Items.Count > 0)
            {
                string str;
                string filePath;
                this.lblFolder.Text = Utilities.GetLocalizedString("Folder");
                this.lblFolder.CssClass = this.LabelCssClass;
                this.lblFile.Text = Utilities.GetLocalizedString("File");
                this.lblFile.CssClass = this.LabelCssClass;
                if (!string.IsNullOrEmpty(this.FilePath))
                {
                    str = this.FilePath.Substring(this.FilePath.LastIndexOf("/") + 1);
                    if (string.IsNullOrEmpty(str))
                    {
                        filePath = this.FilePath;
                    }
                    else
                    {
                        filePath = this.FilePath.Replace(str, "");
                    }
                }
                else
                {
                    str = this.FilePath;
                    filePath = string.Empty;
                }
                if (this.cboFolders.Items.FindByValue(filePath) != null)
                {
                    this.cboFolders.SelectedIndex = -1;
                    this.cboFolders.Items.FindByValue(filePath).Selected = true;
                }
                this.cboFolders.Width = this.Width;
                this.LoadFiles();
                if (this.cboFiles.Items.FindByText(str) != null)
                {
                    this.cboFiles.Items.FindByText(str).Selected = true;
                }
                if ((this.cboFiles.SelectedItem == null) || string.IsNullOrEmpty(this.cboFiles.SelectedItem.Value))
                {
                    this.FileID = -1;
                }
                else
                {
                    this.FileID = int.Parse(this.cboFiles.SelectedItem.Value);
                }
                this.cboFiles.Width = this.Width;
                if (!string.IsNullOrEmpty(filePath))
                {
                    filePath = filePath.Substring(0, filePath.Length - 1);
                }
                switch (this.Mode)
                {
                    case FileControlMode.Normal:
                        this.fileRow.Visible = true;
                        this.folderRow.Visible = true;
                        this.cboFiles.Visible = true;
                        this.ShowImage();
                        this.txtFile.Visible = false;
                        if ((FolderPermissionController.HasFolderPermission(this.PortalId, filePath, "ADD") || this.IsUserFolder(filePath)) && this.ShowUpLoad)
                        {
                            this.ShowButton(this.cmdUpload, "Upload");
                        }
                        goto Label_0290;

                    case FileControlMode.UpLoadFile:
                        this.cboFiles.Visible = false;
                        this.txtFile.Visible = true;
                        this.imgPreview.Visible = false;
                        this.ShowButton(this.cmdSave, "Save");
                        this.ShowButton(this.cmdCancel, "Cancel");
                        goto Label_0290;
                }
            }
            else
            {
                this.lblMessage.Text = Utilities.GetLocalizedString("NoPermission");
            }
        Label_0290:
            this.messageRow.Visible = !string.IsNullOrEmpty(this.lblMessage.Text);
        }

        private void SaveFile(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtFile.PostedFile.FileName))
            {
                string str2 = this.ParentFolder + this.cboFolders.SelectedItem.Value;
                string str = Path.GetExtension(this.txtFile.PostedFile.FileName).Replace(".", "");
                if (!string.IsNullOrEmpty(this.FileFilter) && !this.FileFilter.ToLower().Contains(str.ToLower()))
                {
                    this.lblMessage.Text = string.Format(DotNetNuke.Services.Localization.Localization.GetString("UploadError", this.LocalResourceFile), this.FileFilter, str);
                }
                else
                {
                    if (this.IsUserFolder(this.cboFolders.SelectedItem.Value) && (new FolderController().GetFolder(this.PortalId, str2, false) == null))
                    {
                        FileSystemUtils.AddUserFolder(this.PortalSettings, this.PortalSettings.HomeDirectoryMapPath, 0, this.PortalSettings.UserId);
                    }
                    this.lblMessage.Text = FileSystemUtils.UploadFile(str2.Replace("/", @"\"), this.txtFile.PostedFile, false);
                }
                if (string.IsNullOrEmpty(this.lblMessage.Text))
                {
                    string fileName = this.txtFile.PostedFile.FileName.Substring(this.txtFile.PostedFile.FileName.LastIndexOf(@"\") + 1);
                    this.SetFilePath(fileName);
                }
            }
            this.Mode = FileControlMode.Normal;
        }

        private void SetFilePath()
        {
            this.SetFilePath(this.cboFiles.SelectedItem.Text);
        }

        private void SetFilePath(string fileName)
        {
            if (string.IsNullOrEmpty(this.cboFolders.SelectedItem.Value))
            {
                this.FilePath = fileName;
            }
            else
            {
                this.FilePath = this.cboFolders.SelectedItem.Value + "/" + fileName;
            }
        }

        private void ShowButton(CommandButton button, string command)
        {
            button.Visible = true;
            if (!string.IsNullOrEmpty(command))
            {
                button.Text=Utilities.GetLocalizedString(command);
            }
            button.RegisterForPostback();
            this.commandRow.Visible = true;
        }

        private void ShowImage()
        {
            DotNetNuke.Services.FileSystem.FileInfo fileById = new FileController().GetFileById(this.FileID, this.PortalId);
            if (fileById != null)
            {
                this.imgPreview.ImageUrl = Globals.LinkClick("fileid=" + this.FileID.ToString(), this.PortalSettings.ActiveTab.TabID, Null.NullInteger);
                Utilities.CreateThumbnail(fileById, this.imgPreview, this.MaxWidth, this.MaxHeight);
                this.imgPreview.Visible = true;
            }
            else
            {
                this.imgPreview.Visible = false;
            }
        }

        private void UploadFile(object sender, EventArgs e)
        {
            this.Mode = FileControlMode.UpLoadFile;
        }

        // Properties
        public string CommandCssClass
        {
            get
            {
                string str = Convert.ToString(RuntimeHelpers.GetObjectValue(this.ViewState["CommandCssClass"]));
                if (string.IsNullOrEmpty(str))
                {
                    return "CommandButton";
                }
                return str;
            }
            set
            {
                this.ViewState["CommandCssClass"] = value;
            }
        }

        public bool Localize
        {
            get
            {
                return this._Localize;
            }
            set
            {
                this._Localize = value;
            }
        }

        public string LocalResourceFile
        {
            get
            {
                return this._LocalResourceFile;
            }
            set
            {
                this._LocalResourceFile = value;
            }
        }

        public string FileFilter
        {
            get
            {
                if (this.ViewState["FileFilter"] != null)
                {
                    return (string)this.ViewState["FileFilter"];
                }
                return "";
            }
            set
            {
                this.ViewState["FileFilter"] = value;
            }
        }

        public int FileID
        {
            get
            {
                this.EnsureChildControls();
                if (this.ViewState["FileID"] == null)
                {
                    int num2 = Null.NullInteger;
                    if (this.cboFiles.SelectedItem != null)
                    {
                        num2 = int.Parse(this.cboFiles.SelectedItem.Value);
                    }
                    this.ViewState["FileID"] = num2;
                }
                return Convert.ToInt32(RuntimeHelpers.GetObjectValue(this.ViewState["FileID"]));
            }
            set
            {
                this.EnsureChildControls();
                this.ViewState["FileID"] = value;
                if (string.IsNullOrEmpty(this.FilePath))
                {
                    DotNetNuke.Services.FileSystem.FileInfo fileById = new FileController().GetFileById(value, this.PortalId);
                    if (fileById != null)
                    {
                        this.SetFilePath(fileById.Folder + fileById.FileName);
                    }
                }
            }
        }

        public string FilePath
        {
            get
            {
                return Convert.ToString(RuntimeHelpers.GetObjectValue(this.ViewState["FilePath"]));
            }
            set
            {
                this.ViewState["FilePath"] = value;
            }
        }

        public bool IncludePersonalFolder
        {
            get
            {
                if (this.ViewState["IncludePersonalFolder"] == null)
                {
                    return false;
                }
                return Convert.ToBoolean(RuntimeHelpers.GetObjectValue(this.ViewState["IncludePersonalFolder"]));
            }
            set
            {
                this.ViewState["IncludePersonalFolder"] = value;
            }
        }

        protected bool IsHost
        {
            get
            {
                bool flag = Null.NullBoolean;
                if (this.PortalSettings.ActiveTab.ParentId == this.PortalSettings.SuperTabId)
                {
                    flag = true;
                }
                return flag;
            }
        }

        public string LabelCssClass
        {
            get
            {
                string str = Convert.ToString(RuntimeHelpers.GetObjectValue(this.ViewState["LabelCssClass"]));
                if (string.IsNullOrEmpty(str))
                {
                    return "NormalBold";
                }
                return str;
            }
            set
            {
                this.ViewState["LabelCssClass"] = value;
            }
        }

        public int MaxHeight
        {
            get
            {
                return this._MaxHeight;
            }
            set
            {
                this._MaxHeight = value;
            }
        }

        public int MaxWidth
        {
            get
            {
                return this._MaxWidth;
            }
            set
            {
                this._MaxWidth = value;
            }
        }

        protected FileControlMode Mode
        {
            get
            {
                if (this.ViewState["Mode"] == null)
                {
                    return FileControlMode.Normal;
                }
                return (FileControlMode)this.ViewState["Mode"];
            }
            set
            {
                this.ViewState["Mode"] = value;
            }
        }

        protected string ParentFolder
        {
            get
            {
                if (this.IsHost)
                {
                    return Globals.HostMapPath;
                }
                return this.PortalSettings.HomeDirectoryMapPath;
            }
        }

        protected int PortalId
        {
            get
            {
                int num = Null.NullInteger;
                if (!this.IsHost)
                {
                    num = this.PortalSettings.PortalId;
                }
                return num;
            }
        }

        protected PortalSettings PortalSettings
        {
            get
            {
                return PortalController.GetCurrentPortalSettings();
            }
        }

        public bool Required
        {
            get
            {
                if (this.ViewState["Required"] == null)
                {
                    return false;
                }
                return Convert.ToBoolean(RuntimeHelpers.GetObjectValue(this.ViewState["Required"]));
            }
            set
            {
                this.ViewState["Required"] = value;
            }
        }

        public bool ShowDatabase
        {
            get
            {
                if (this.ViewState["ShowDatabase"] == null)
                {
                    return false;
                }
                return Convert.ToBoolean(RuntimeHelpers.GetObjectValue(this.ViewState["ShowDatabase"]));
            }
            set
            {
                this.ViewState["ShowDatabase"] = value;
            }
        }

        public bool ShowSecure
        {
            get
            {
                if (this.ViewState["ShowSecure"] == null)
                {
                    return false;
                }
                return Convert.ToBoolean(RuntimeHelpers.GetObjectValue(this.ViewState["ShowSecure"]));
            }
            set
            {
                this.ViewState["ShowSecure"] = value;
            }
        }

        public bool ShowUpLoad
        {
            get
            {
                return ((this.ViewState["ShowUpLoad"] == null) || Convert.ToBoolean(RuntimeHelpers.GetObjectValue(this.ViewState["ShowUpLoad"])));
            }
            set
            {
                this.ViewState["ShowUpLoad"] = value;
            }
        }

        // Nested Types
        protected enum FileControlMode
        {
            Normal,
            UpLoadFile,
            Preview
        }


        #region ILocalizable 成员


        void ILocalizable.LocalizeStrings()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
