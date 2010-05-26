using System;
namespace DjArticles.Components
{
    public class ArticleInfo
    {
        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        private int articleID;

        public int ArticleID
        {
            get { return articleID; }
            set { articleID = value; }
        }
        private string createdByUserName;

        public string CreatedByUserName
        {
            get { return createdByUserName; }
            set { createdByUserName = value; }
        }

        private int createdByUserID;

        public int CreatedByUserID
        {
            get { return createdByUserID; }
            set { createdByUserID = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }
        private string copyFrom;

        public string CopyFrom
        {
            get { return copyFrom; }
            set { copyFrom = value; }
        }
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        private string keyWords;

        public string KeyWords
        {
            get { return keyWords; }
            set { keyWords = value; }
        }
        private string summary;

        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private bool hot;

        public bool Hot
        {
            get { return hot; }
            set { hot = value; }
        }
        private bool onTop;

        public bool OnTop
        {
            get { return onTop; }
            set { onTop = value; }
        }
        private byte stars;

        public byte Stars
        {
            get { return stars; }
            set { stars = value; }
        }
        private bool passed;

        public bool Passed
        {
            get { return passed; }
            set { passed = value; }
        }
        private int hits;

        public int Hits
        {
            get { return hits; }
            set { hits = value; }
        }
        private string defaultPicUrl;

        public string DefaultPicUrl
        {
            get { return defaultPicUrl; }
            set { defaultPicUrl = value; }
        }
        private bool allowPrint;

        public bool AllowPrint
        {
            get { return allowPrint; }
            set { allowPrint = value; }
        }
        private bool allowComment;

        public bool AllowComment
        {
            get { return allowComment; }
            set { allowComment = value; }
        }
        private int commentCount;

        public int CommentCount
        {
            get { return commentCount; }
            set { commentCount = value; }
        }

    }
}