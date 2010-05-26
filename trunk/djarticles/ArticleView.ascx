<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleView.ascx.cs" Inherits="DjArticles.ArticleView" EnableViewState="false" %>
<div class="articleMain">
    <h1 class="articleItem articleTitle">
        <asp:HiddenField ID="hdfArticleId" runat="server" />
        <asp:Label ID="lblTitle" runat="server" />
    </h1>
    <div class="articleItem articleInfo">
        <p>
           <asp:Label ID="lblCreateDate" runat="server" /> | <asp:Label ID="lblHits" runat="server" /> 次阅读 | 【已有条<%# EvalValue(CommentCount) %>评论】<a href="#postcomment" target="_self">发表评论</a>
        </p>
        <p>
            关键字：<%# KeyWords %>
        </p>
    </div>  
    <div class="articleItem articleContent">
        <asp:Literal ID="ltlContent" runat="server" />
        <p align="right">
        【 <a href="#postcomment" target="_self">发表评论</a>】 <font style="color: #c00; font-size: 12px;">
            <%#EvalValue(CommentCount)%></font>条    
        </p>
    </div>
    <div class="articleItem articleRelative">
    </div>
    <div class="articleItem articleComment">
        <div class="commentTitle"><a href="#postcomment">发表评论</a> /网友评论（共<%# EvalValue(CommentCount) %>条评论）</div>
        <div>
            <asp:DataList ID="dalComments" runat="server">
                <ItemTemplate>
                    <div>
                        <div style="float:left;">
                            <a href="#"><img src="#" alt=""/></a>
                        </div>
                        <div>
                            <span>  <%#Eval("CreatedDate", "yyyy年M月d日 hh:mm:ss")%> <span style="color:#0087af;"><%#Eval("CreatedByUserName")%></span> </span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="postnew" >
            <a name="postcomment" href="#postcomment">发表评论</a><br />
            <asp:HiddenField ID="hdfReferenceId" runat="server" />
            <asp:TextBox TextMode="MultiLine" ID="txtMessage" runat="server"></asp:TextBox><br />
            <asp:button id="btnPostComment" CssClass="submit" runat="server" 
                text="Submit Comment" resourcekey="btnSubmit" onclick="btnPostComment_Click" />
            <div style="clear:both;"></div>
        </div>
    </div>
</div>