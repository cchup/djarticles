using System;
using System.Collections.Generic;
namespace DjArticles.Components
{
    public class CommentInfo
    {
        private long commentID;

        public long CommentID
        {
            get { return commentID; }
            set { commentID = value; }
        }
        private int articleID;

        public int ArticleID
        {
            get { return articleID; }
            set { articleID = value; }
        }
        private long referenceCommentID;

        public long ReferenceCommentID
        {
            get { return referenceCommentID; }
            set { referenceCommentID = value; }
        }
        private long parentID;

        public long ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        private int createdByUserID;

        public int CreatedByUserID
        {
            get { return createdByUserID; }
            set { createdByUserID = value; }
        }
        private string createdByUserName;

        public string CreatedByUserName
        {
            get { return createdByUserName; }
            set { createdByUserName = value; }
        }
        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }
        private string qq;

        public string Qq
        {
            get { return qq; }
            set { qq = value; }
        }
        private string msn;

        public string Msn
        {
            get { return msn; }
            set { msn = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string homepage;

        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }
        private string ip;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        private List<CommentInfo> subCommentInfo = new List<CommentInfo>();

        public void AddSubCommentInfo(CommentInfo comment)
        {
            comment.parentID = this.commentID;
            subCommentInfo.Add(comment);
        }
    }
}