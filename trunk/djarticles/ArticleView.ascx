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
            次阅读 | 【已有条<%= CommentCount %>评论】<a href="#postcomment" target="_self">发表评论</a>
        </p>
        <p>
            关键字：<%= KeyWords %>
        </p>
    </div>
    <div class="articleItem articleContent">
        <asp:Literal ID="ltlContent" runat="server" />
        <p align="right">
            【<a href="#postcomment" target="_self">发表评论</a>】 <font style="color: #c00; font-size: 12px;">
                <% =CommentCount %></font>条
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
                                <asp:Image runat="server" ID="imgAvatar" ImageUrl='<%# EvalValue(Eval("AvatarPic"),"~/images/no_avatar.gif") %>' /></a>
                        </div>
                        <div class="comment">
                            <span>
                                <h4>
                                    <span style="color: #999">
                                        <%# Eval("CreatedDate", "{0:yyyy年M月d日 hh:mm:ss}")%></span> <span style="color: #003366;">
                                            <%# EvalValue(Eval("CreatedByUserName"),"匿名用户")%></span>
                                </h4>
                            </span>
                            <p>
                                <%# Eval("Comment") %></p>
                        </div>
                        <div class="clear" />
                        <div class="ditail">
                            <a href="#">回复</a> <a href="#">引用</a> <a href="#">支持(<%# Eval("Approve") %>)</a>
                            <a href="#">反对(<%# Eval("Oppose ") %>)</a>
                            <asp:LinkButton ID="lbnDelete" runat="server" Visible="<%# IsEditable %>" 
                                onclick="lbnDelete_Click">删除</asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <a name="postcomment" href="#postcomment">发表评论</a><br />
        <div class="postnew">
            <asp:HiddenField ID="hdfReferenceId" runat="server" />
            <asp:TextBox TextMode="MultiLine" ID="txtMessage" runat="server"  onclick="if(event.ctrlKey&&event.keyCode==13){event.returnValue=false;event.cancel=true;this.form.submit.click();this.blur();};"></asp:TextBox><br />
            <asp:Button ID="btnSubmit" resourcekey="btnSubmit" CssClass="submit" runat="server"
                Text="发表评论" OnClick="btnSubmit_Click" />
            <div class="clear" />
        </div>
    </div>
</div>
