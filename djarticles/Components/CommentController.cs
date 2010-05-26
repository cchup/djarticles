using System;
using DotNetNuke.Common.Utilities;
using System.Collections.Generic;

namespace DjArticles.Components
{

    public class CommentController
    {
        /// <summary>
        /// 查询与该文章相关的所有评论
        /// 查询出的评论文章以树形结构返回
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public List<CommentInfo> GetCommentsByIArticleID(int articleId)
        {
            List<CommentInfo> allComments= CBO.FillCollection<CommentInfo>(DataProvider.Instance().GetCommentsByArticleID(articleId));
            //构建Map对应关系
            Dictionary<long, CommentInfo> commentsMap = new Dictionary<long, CommentInfo>();
            foreach (CommentInfo comment in allComments)
            {
                commentsMap.Add(comment.CommentID, comment);
            }
            //构建评论树列表
            List<CommentInfo> comments = new List<CommentInfo>();
            foreach (CommentInfo comment in allComments)
            {
                if (Null.IsNull(comment.ParentID))
                {
                    comments.Add(comment);
                }
                else
                {
                    CommentInfo parent = commentsMap[comment.ParentID];
                    if (parent != null)
                    {
                        parent.AddSubCommentInfo(comment);
                    }
                }
                if (!Null.IsNull(comment.ReferenceCommentID))
                {
                    CommentInfo reference = commentsMap[comment.ReferenceCommentID];
                    if (reference != null)
                    {
                        setReferenceCommentContent(comment, reference);
                    }
                }
            }
            return comments;
        }

        /// <summary>
        /// 设置引用内容
        /// </summary>
        /// <param name="nowComment"></param>
        /// <param name="referenceComment"></param>
        private void setReferenceCommentContent(CommentInfo nowComment, CommentInfo referenceComment)
        {
            if (nowComment == null || referenceComment == null)
            {
                return;
            }
            string referenceContent = referenceComment.Comment;
            referenceContent = "<p class=\"refCmt\">" + referenceContent + "</p>";
            nowComment.Comment = referenceContent + nowComment.Comment;
        }

        /// <summary>
        /// 添加新的评论
        /// </summary>
        /// <param name="commentInfo">评论数据对象</param>
        /// <returns></returns>
        public int AddComment(CommentInfo commentInfo)
        {
            if (commentInfo == null)
            {
                return　Null.NullInteger;
            }
            commentInfo.CreatedDate = DateTime.Now;
            return DataProvider.Instance().AddComment(commentInfo.ArticleID, "", commentInfo.Comment, commentInfo.ReferenceCommentID, commentInfo.ParentID, commentInfo.CreatedByUserID,
                    commentInfo.CreatedByUserName, commentInfo.CreatedDate, "", "", "", "",commentInfo.Ip);
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public int DeleteComment(int commentId)
        {
            throw new NotImplementedException();
        }

    }
}