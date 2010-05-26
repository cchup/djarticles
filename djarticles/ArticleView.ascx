﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleView.ascx.cs"
    Inherits="DjArticles.ArticleView" %>
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
            次阅读 | 【已有条<%= CommentCount %>评论】<a href="#postcomment" target="_self">发表评论</a>
        </p>
        <p>
            关键字：<%# KeyWords %>
        </p>
    </div>
    <div class="articleItem articleContent">
        <asp:Literal ID="ltlContent" runat="server" />
        <p align="right">
            【<a href="#postcomment" target="_self">发表评论</a>】 <font style="color: #c00; font-size: 12px;">
                <%#EvalValue(CommentCount)%></font>条
        </p>
    </div>
    <div class="articleItem articleRelative">
    </div>
    <div class="articleItem articleComment">
        <div class="commentTitle">
            <a href="#postcomment">发表评论</a> /网友评论（共<%= CommentCount %>条评论）</div>
        <div>
            <asp:DataList ID="dalComments" runat="server" Width="100%">
                <ItemTemplate>
                    <div class="commentlist">
                        <div class="head">
                            <a href="#">
                                <img src="#" alt="" /></a>
                        </div>
                        <div class="comment">
                            <span>
                                <h4>
                                    <span style="color:#999"><%# Eval("CreatedDate", "{0:yyyy年M月d日 hh:mm:ss}")%></span> 
                                    <span style="color:#003366;">
                                        <%#Eval("CreatedByUserName")%></span>
                                </h4>
                            </span>
                            <p>
                                <%# Eval("Comment") %></p>
                        </div>
                        <div class="clear" />
                        <div class="ditail">
                            <a href="#">回复</a> <a href="#">引用</a> <a href="#">支持（）</a> <a href="#">反对（）</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <a name="postcomment" href="#postcomment">发表评论</a><br />
        <div class="postnew">
            <asp:HiddenField ID="hdfReferenceId" runat="server" />
            <asp:TextBox TextMode="MultiLine" ID="txtMessage" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSubmit" resourcekey="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <div class="clear" />
        </div>
    </div>
</div>
