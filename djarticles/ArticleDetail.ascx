<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleDetail.ascx.cs"
    Inherits="DjArticles.ArticleDetail" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
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
    <%--    <div class="articleItem articleComment">
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
                            <asp:LinkButton ID="lbnDelete" runat="server" Visible="<%# IsEditable %>" OnClick="lbnDelete_Click">删除</asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <a name="postcomment" href="#postcomment">发表评论</a><br />
        <div class="postnew">
            <asp:HiddenField ID="hdfReferenceId" runat="server" />
            <asp:TextBox TextMode="MultiLine" ID="txtMessage" runat="server" onclick="if(event.ctrlKey&&event.keyCode==13){event.returnValue=false;event.cancel=true;this.form.submit.click();this.blur();};"></asp:TextBox><br />
            <asp:Button ID="btnSubmit" resourcekey="btnSubmit" CssClass="submit" runat="server"
                Visible="<%# IsLoginUser%>" Text="发表评论" OnClick="btnSubmit_Click" />
            <div class="clear" />
        </div>
    </div>--%>
    <!-- Comments Section 该内容布局来至Blog Module -->
    <asp:Panel ID="pnlComments" runat="server">
        <p>
            <a id="Comments" name="Comments"></a><a href="#AddComment">
                <asp:Label ID="lblComments" runat="server" CssClass="Comments" /></a>
        </p>
        <asp:ImageButton ID="lnkDeleteAllUnapproved" runat="server" ImageUrl="~/images/delete.gif"
            Visible="false" CausesValidation="false" AlternateText="Delete Unaproved" />
        <asp:DataList ID="lstComments" runat="server" Width="100%" 
            onitemdatabound="lstComments_ItemDataBound">
            <ItemTemplate>
                <asp:Panel ID="divBubble" runat="server" CssClass="BubbleOwner">
                    <blockquote>
                        <asp:Panel ID="divGravatar" runat="server" CssClass="Gravatar">
                            <asp:Image runat="server" Width="48" ID="imgGravatar" AlternateText="Gravatar" />
                        </asp:Panel>
                        <p>
                            <asp:ImageButton ID="lnkEditComment" runat="server" Visible="<%# IsEditable %>" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CommentID") %>'
                                CommandName="EditComment" ImageUrl="~/images/edit.gif" AlternateText="Edit Comment" />
                            <asp:LinkButton ID="btEditComment" runat="server" Visible="<%# IsEditable %>" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CommentID") %>'
                                CommandName="EditComment" resourcekey="cmdEdit" CssClass="CommandButton" />
                             <asp:ImageButton ID="lnkDeleteComment" runat="server" Visible="<%# IsEditable %>" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CommentID") %>'
                                CommandName="DeleteComment" ImageUrl="~/images/delete.gif" CausesValidation="false"
                                AlternateText="Delete Comment" />
                            <asp:LinkButton ID="btDeleteComment" runat="server" Visible="<%# IsEditable %>" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CommentID") %>'
                                CommandName="DeleteComment" resourcekey="Delete" CssClass="CommandButton" CausesValidation="false" />
                            <asp:Label ID="lblTitle" runat="server" CssClass="NormalBold" />
                        </p>
                        <p>
                            <%# Server.HtmlDecode(DataBinder.Eval(Container.DataItem, "Comment").ToString())%>
                        </p>
                    </blockquote>
                    <cite>
                        <asp:Label ID="lblUserName" CssClass="NormalBold" runat="server" Text="Label" Visible="true" />
                        &nbsp;
                        <asp:Label ID="lblCommentDate" runat="server" CssClass="Normal" />
                    </cite>
                </asp:Panel>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <asp:Panel ID="pnlLogin" runat="server" Visible="false">
        <asp:LinkButton ID="cmdLogin" TabIndex="7" runat="server" CssClass="CommandButton"
            BorderStyle="None" ResourceKey="cmdLogin" onclick="cmdLogin_Click" />
    </asp:Panel>
    <asp:Panel ID="pnlAddComment" runat="server">
        <a id="AddComment" name="AddComment"></a>
        <asp:HiddenField ID="hdfReferenceId" runat="server" />
        <asp:ValidationSummary ID="valSummary" runat="server" CssClass="NormalRed" Enabled="False" />
        <asp:RequiredFieldValidator ID="valCommentAuthor" runat="server" ResourceKey="valCommentAuthor.ErrorMessage"
            CssClass="NormalRed" Enabled="False" ErrorMessage="Author is required" ControlToValidate="txtAuthor"
            Display="None" EnableClientScript="False" />
        <asp:RequiredFieldValidator ID="valComment" runat="server" ResourceKey="valComment.ErrorMessage"
            CssClass="NormalRed" Enabled="False" ErrorMessage="Comment is required" ControlToValidate="txtComment"
            Display="None" EnableClientScript="False" />
        <br />
        <table cellspacing="1" cellpadding="1" width="100%" border="0">
            <tr>
                <td class="LeftTD" width="13%">
                    <asp:Label ID="lblAuthor" runat="server" ResourceKey="lblAuthor" CssClass="NormalBold"
                        Width="80px" />
                </td>
                <td id="tdAuthor" valign="top" runat="server">
                    <asp:TextBox ID="txtAuthor" TabIndex="1" runat="server" Width="99%" />
                </td>
                <td id="tdGravatarPreview" valign="top" align="right" width="1%" rowspan="2" runat="server">
                    <div class="GravatarPreview">
                        <asp:Image ID="imgGravatarPreview" runat="server" AlternateText="Gravatar Preview" />
                    </div>
                </td>
            </tr>
            <tr >
                <td class="LeftTD" width="13%">
                    <asp:Label ID="lblEmail" runat="server" ResourceKey="lblEmail" CssClass="NormalBold" />
                </td>
                <td valign="top">   
                    <asp:TextBox ID="txtEmail" TabIndex="2" runat="server" Width="99%" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblComment" runat="server" ResourceKey="lblComment" CssClass="NormalBold" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="txtComment" TabIndex="5" runat="server" CssClass="NormalTextBox"
                        Width="99%" TextMode="MultiLine" Rows="8" />
                </td>
            </tr>
            <tr id="rowCaptcha" runat="server">
                <td colspan="3">
                    <asp:Label ID="lblCaptcha" runat="server" ResourceKey="lblCaptcha" CssClass="NormalBold"
                        Width="80px" />
                    <dnn:captchacontrol id="ctlCaptcha" tabindex="6" runat="server" cssclass="Normal"
                        errorstyle-cssclass="NormalRed" captchawidth="130" captchaheight="40" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="cmdAddComment" TabIndex="7" runat="server" ResourceKey="cmdAddComment"
                         CssClass="CommandButton" OnClick="cmdAddComment_Click"
                        BorderStyle="None" />&nbsp;&nbsp;
                    <asp:LinkButton ID="cmdCancel" TabIndex="8" runat="server" ResourceKey="cmdCancel"
                        OnClick="cmdCancel_Click"
                        CssClass="CommandButton" BorderStyle="None" CausesValidation="False" />&nbsp;
                </td>
            </tr>
        </table>
        <asp:TextBox ID="txtClientIP" runat="server" Visible="false" />
    </asp:Panel>
</div>