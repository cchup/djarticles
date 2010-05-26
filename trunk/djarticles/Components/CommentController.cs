using System;
using DotNetNuke.Common.Utilities;
using System.Collections.Generic;

namespace DjArticles.Components
{

    public class CommentController
    {
        /// <summary>
        /// ��ѯ���������ص���������
        /// ��ѯ�����������������νṹ����
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public List<CommentInfo> GetCommentsByIArticleID(int articleId)
        {
            List<CommentInfo> allComments= CBO.FillCollection<CommentInfo>(DataProvider.Instance().GetCommentsByArticleID(articleId));
            //����Map��Ӧ��ϵ
            Dictionary<long, CommentInfo> commentsMap = new Dictionary<long, CommentInfo>();
            foreach (CommentInfo comment in allComments)
            {
                commentsMap.Add(comment.CommentID, comment);
            }
            //�����������б�
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
        /// ������������
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
        /// ����µ�����
        /// </summary>
        /// <param name="commentInfo">�������ݶ���</param>
        /// <returns></returns>
        public int AddComment(CommentInfo commentInfo)
        {
            if (commentInfo == null)
            {
                return��Null.NullInteger;
            }
            commentInfo.CreatedDate = DateTime.Now;
            return DataProvider.Instance().AddComment(commentInfo.ArticleID, "", commentInfo.Comment, commentInfo.ReferenceCommentID, commentInfo.ParentID, commentInfo.CreatedByUserID,
                    commentInfo.CreatedByUserName, commentInfo.CreatedDate, "", "", "", "",commentInfo.Ip);
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public int DeleteComment(int commentId)
        {
            throw new NotImplementedException();
        }

    }
}