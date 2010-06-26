using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DjArticles.Components;
using DjArticles.Common;
using DotNetNuke.Common.Utilities;
using System.Collections.Generic;
using DotNetNuke.Entities.Users;

namespace DjArticles
{
    public partial class ArticleDetail : ArticlePortalModuleBase
    {
        #region Private Members

        private ArticlesController controller = new ArticlesController();

        private CommentController commentController = new CommentController();

        private readonly string  defaultGravatarImg="~/DesktopModules/DjArticles/images/noimage.gif";

        private int articleId = Null.NullInteger;

        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
        }

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
        }

        private string createdByUserName;

        public string CreatedByUserName
        {
            get { return createdByUserName; }
        }

        private int createdByUserID;

        public int CreatedByUserID
        {
            get { return createdByUserID; }
        }
        private string title;

        public string Title
        {
            get { return title; }
        }

        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
        }
        private string copyFrom;

        public string CopyFrom
        {
            get { return copyFrom; }
        }
        private string author;

        public string Author
        {
            get { return author; }
        }
        private string keyWords;

        public string KeyWords
        {
            get { return keyWords; }
        }
        private string summary;

        public string Summary
        {
            get { return summary; }
        }
        private string content;

        public string Content
        {
            get { return content; }
        }
        private bool hot;

        public bool Hot
        {
            get { return hot; }
        }
        private bool onTop;

        public bool OnTop
        {
            get { return onTop; }
        }
        private byte stars;

        public byte Stars
        {
            get { return stars; }
        }
        private bool passed;

        public bool Passed
        {
            get { return passed; }
        }
        private int hits;

        public int Hits
        {
            get { return hits; }
        }
        private string defaultPicUrl;

        public string DefaultPicUrl
        {
            get { return defaultPicUrl; }
        }
        private bool allowPrint;

        public bool AllowPrint
        {
            get { return allowPrint; }
        }
        private bool allowComment;

        public bool AllowComment
        {
            get { return allowComment; }
        }
        private int commentCount;

        public int CommentCount
        {
            get { return commentCount; }
        }

        #endregion

        #region Private Method


        /// <summary>
        /// 根据ArticleId信息获取完整的Article信息
        /// </summary>
        /// <param name="articleId"></param>
        private void SetArticleInfo(int articleId)
        {
            if (articleId == Null.NullInteger)
            {
                return;
            }
            ArticleInfo article = controller.GetArticleForView(articleId);
            if (article != null)
            {
                this.title = article.Title;
                this.summary = article.Summary;
                this.keyWords = article.KeyWords;
                this.content = article.Content;
                this.copyFrom = article.CopyFrom;
                this.createdByUserID = article.CreatedByUserID;
                this.createdByUserName = article.CreatedByUserName;
                this.createdDate = article.CreatedDate;
                this.defaultPicUrl = article.DefaultPicUrl;
                this.allowComment = article.AllowComment;
                this.allowPrint = article.AllowPrint;
                this.author = article.Author;
                this.commentCount = article.CommentCount;
                this.hits = article.Hits;
                this.hot = article.Hot;
                this.stars = article.Stars;
                // 设置控件值
                this.lblTitle.Text = this.title;
                if (!string.IsNullOrEmpty(this.defaultPicUrl))
                {
                    this.imgArticleImage.Visible = true;
                    this.imgArticleImage.ImageUrl = this.GetFileResolveUrl(this.defaultPicUrl);
                }
                else
                {
                    this.imgArticleImage.Visible = false;
                }
                this.ltlContent.Text = Server.HtmlDecode(this.content);
                this.lblCreateDate.Text = this.createdDate.ToString("yyyy年M月d日 hh:mm:ss");
                this.lblHits.Text = this.hits.ToString();
                this.hdfArticleId.Value = this.articleId.ToString(); 
                this.lblCommentCount1.Text = this.commentCount.ToString();
                this.lblCommentCount2.Text = this.commentCount.ToString();
                this.lblKeywords.Text = this.keyWords;
                this.cmdAddComment.Enabled = !this.allowComment;
                this.BindingComments(articleId);
            }

        }

        /// <summary>
        /// 设置其他显示信息
        /// </summary>
        private void SetOtherInfo()
        {
            this.txtAuthor.ReadOnly = false;
            this.txtEmail.ReadOnly = false;
            this.cmdAddComment.Enabled = false;
            if (!Null.IsNull(this.UserId))
            {
                this.txtAuthor.Text = this.UserInfo.DisplayName;
                this.txtEmail.Text = this.UserInfo.Email;
                this.txtAuthor.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
                if (!string.IsNullOrEmpty(this.UserInfo.Profile.Photo))
                {
                    imgGravatarPreview.ImageUrl = this.UserInfo.Profile.Photo;
                }
                this.cmdAddComment.Enabled = true;
            }
            if (string.IsNullOrEmpty(imgGravatarPreview.ImageUrl))
            {
                imgGravatarPreview.ImageUrl = defaultGravatarImg;
            }
            //
            //ctlCaptcha.ErrorMessage = this.GetString("InvalidCaptcha");
            //ctlCaptcha.Text = this.GetString("CaptchaText");
            //设置登录是否可见
            if (Null.IsNull(this.UserId))
            {
                this.cmdLogin.Visible = true;
            }
            else
            {
                this.cmdLogin.Visible = false;
            }

        }

        /// <summary>
        /// 绑定评论数据源
        /// </summary>
        /// <param name="articleId"></param>
        private void BindingComments(int articleId)
        {
            List<CommentInfo> comments = commentController.GetCommentsByIArticleID(articleId);
            this.lblComments.Text = string.Format(GetString("lblComments"), comments.Count);
            this.lstComments.DataSource = comments;
            this.lstComments.DataBind();
        }

        /// <summary>
        /// 发表评论
        /// </summary>
        private void PostComment()
        {
            string commentMessage = this.txtComment.Text;
            articleId = WebControlUtils.GetObjectIntValue(this.hdfArticleId);
            if (Null.IsNull(articleId))
            {
                return;
            }
            if (string.IsNullOrEmpty(commentMessage))
            {
                throw new ArticlesException("评论内容为空！");
            }
            if (this.UserId == Null.NullInteger)
            {
                throw new ArticlesException("您还未登录！");
            }
            int referenceId = WebControlUtils.GetObjectIntValue(this.hdfReferenceId);
            CommentInfo commentInfo = new CommentInfo();
            commentInfo.Comment = commentMessage;
            commentInfo.ArticleID = articleId;
            commentInfo.CreatedByUserID = this.UserId;
            commentInfo.CreatedByUserName = this.UserInfo.FullName;
            commentInfo.Ip = Request.UserHostAddress;
            commentController.AddComment(commentInfo);
            this.BindingComments(articleId);
        }

        /// <summary>
        /// 设置评论信息
        /// </summary>
        /// <param name="commentInfo"></param>
        private void SetEditCommentInfo(CommentInfo commentInfo)
        {
            this.hdfCommentId.Value = commentInfo.CommentID.ToString();
            this.txtComment.Text = commentInfo.Comment;
            this.hdfReferenceId.Value = commentInfo.ReferenceCommentID.ToString();
        }

        /// <summary>
        /// 清理评论信息
        /// </summary>
        private void ClearPostComment()
        {
            this.hdfReferenceId.Value = "";
            this.hdfCommentId.Value = "";
            this.txtComment.Text = "";
        }

        #endregion

        #region Event Handler

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                articleId = this.GetIntParameter("ArticleId");
                if (articleId != Null.NullInteger)
                {
                    SetArticleInfo(articleId);
                    SetOtherInfo();
                    //ctlCaptcha.ErrorMessage = GetString("InvalidCaptcha");
                    //ctlCaptcha.Text = GetString("CaptchaText");
                }
            }
        }

        protected void lbnDelete_Click(object sender, EventArgs e)
        {

        }
        protected void lstComments_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            CommentInfo commentInfo=e.Item.DataItem as CommentInfo;
            ImageButton lnkEditComment = e.Item.FindControl("lnkEditComment") as ImageButton;
            LinkButton btEditComment = e.Item.FindControl("btEditComment") as LinkButton;

            ImageButton lnkDeleteComment = e.Item.FindControl("lnkDeleteComment") as ImageButton;
            LinkButton btDeleteComment = e.Item.FindControl("btDeleteComment") as LinkButton;
            if (commentInfo != null)
            {
                Label lblUserName = e.Item.FindControl("lblUserName") as Label;
                Label lblCommentDate = e.Item.FindControl("lblCommentDate") as Label;
                Image imgGravatar = e.Item.FindControl("imgGravatar") as Image;
                lblUserName.Text = commentInfo.CreatedByUserName;
                lblCommentDate.Text = commentInfo.CreatedDate.ToString(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat);
                UserController userController = new UserController();
                UserInfo user = userController.GetUser(this.PortalId, commentInfo.CreatedByUserID);
                if (user != null && !string.IsNullOrEmpty(user.Profile.Photo))
                {
                    imgGravatar.ImageUrl = user.Profile.Photo;
                }
                else
                {
                    imgGravatar.ImageUrl = defaultGravatarImg;
                }
            }
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            
        }

        protected void cmdAddComment_Click(object sender, EventArgs e)
        {
            this.valCommentAuthor.Enabled = true;
            this.valComment.Enabled = true;
            if (Page.IsValid )
            {
                PostComment();
            }
        }


        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            ClearPostComment();
        }

        protected void lstComments_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ShowMessage(e.CommandName + "," + e.CommandArgument);
            this.valCommentAuthor.Enabled = false;
            this.valComment.Enabled = false;
            int commentId=Null.NullInteger;
            if(e.CommandArgument!=null){
                int.TryParse(e.CommandArgument.ToString(),out commentId);
            }
            if (Null.IsNull(commentId))
            {
                return;
            }
            switch (e.CommandName.ToLower())
            {
                case "editcomment":

                    break;
                case "deletecomment":
                    commentController.DeleteComment(commentId);
                    break;
                default:
                    break;
            }
            articleId = this.GetIntParameter("ArticleId");
            this.BindingComments(articleId);
            ShowMessage("删除成功！");
        }
        #endregion


    }
}