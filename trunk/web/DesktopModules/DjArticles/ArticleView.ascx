<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleView.ascx.cs"
    Inherits="DjArticles.ArticleView" %>
<script type="text/javascript" src='<%=  ResolveUrl("jQComment.js")%>'> </script>
<div class="articleMain">
    <h1 class="articleItem articleTitle">
        <asp:HiddenField ID="hdfArticleId" runat="server" />
        <asp:Label ID="lblTitle" runat="server" />
    </h1>
    <div class="articleItem articleInfo">
        <p>
            <asp:Label ID="lblCreateDate" runat="server" />
            |
            <asp:Label ID="lblHits" runat="server" />
            次阅读 | 【已有<%= CommentCount %>条评论】<a href="#postcomment" target="_self">发表评论</a>
        </p>
        <p>
            关键字：<%= KeyWords %>
        </p>
    </div>
    <div class="articleItem articleContent">
        <asp:Literal ID="ltlContent" runat="server" />
        <p align="right">
           已有<font style="color: #c00; font-size: 12px;">
                <% =CommentCount %></font>条评论
        </p>
    </div>
    
</div>
