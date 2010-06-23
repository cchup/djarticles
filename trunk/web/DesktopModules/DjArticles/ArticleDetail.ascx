﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleDetail.ascx.cs"
    Inherits="DjArticles.ArticleDetail" %>
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
            次阅读 | 【已有条<asp:Label ID="lblCommentCount1" runat="server" Text=""/>评论】<a href="#postcomment" target="_self">发表评论</a>
        </p>
        <p>
            关键字：<asp:Label ID="lblKeywords" runat="server" Text=""/>
        </p>
    </div>
    <div class="articleItem articleContent">
        <asp:Literal ID="ltlContent" runat="server" />
        <p align="right">
            【<a href="#postcomment" target="_self">发表评论</a>】 <font style="color: #c00; font-size: 12px;">
                <asp:Label ID="lblCommentCount2" runat="server" Text=""/></asp:Label>
                </font>条
        </p>
    </div>
    <div class="articleItem articleRelative">
    </div>
    <!-- Comments Section 该内容布局来至Blog Module -->
    <asp:Panel ID="pnlComments" runat="server">
        <p>
            <a id="Comments" name="Comments"></a><a href="#AddComment">
                <asp:Label ID="lblComments" runat="server" CssClass="Comments" /></a>
        </p>
        <asp:ImageButton ID="lnkDeleteAllUnapproved" runat="server" ImageUrl="~/images/delete.gif"
            Visible="false" CausesValidation="false" AlternateText="Delete Unaproved" />
        <asp:DataList ID="lstComments" runat="server" Width="100%"
            EnableViewState="true" 
            onitemdatabound="lstComments_ItemDataBound" 
            onitemcommand="lstComments_ItemCommand">
            <ItemTemplate>
                <asp:Panel ID="divBubble" runat="server" CssClass="BubbleOwner">
                    <blockquote>
                        <asp:Panel ID="divGravatar" runat="server" CssClass="Gravatar">
                            <asp:Image runat="server" Width="48" ID="imgGravatar" AlternateText="Gravatar" />
                        </asp:Panel>
                        <p>
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
        <asp:HiddenField ID="hdfCommentId" runat="server" />
        <asp:ValidationSummary ID="valSummary" runat="server" CssClass="NormalRed" Enabled="False" />
        <asp:RequiredFieldValidator ID="valCommentAuthor" runat="server" ResourceKey="valCommentAuthor.ErrorMessage"
            CssClass="NormalRed"  ErrorMessage="Author is required" ControlToValidate="txtAuthor"
            EnableClientScript="False" />
        <asp:RequiredFieldValidator ID="valComment" runat="server" ResourceKey="valComment.ErrorMessage"
            CssClass="NormalRed"  ErrorMessage="Comment is required" ControlToValidate="txtComment"
            EnableClientScript="False" />
        <asp:RequiredFieldValidator ID="valEmail" runat="server" ResourceKey="valCommentEmail.ErrorMessage"
            CssClass="NormalRed"  ErrorMessage="Email is required" ControlToValidate="txtEmail"
            EnableClientScript="False" />
        <asp:RegularExpressionValidator ID="velEmail" runat="server" ResourceKey="valCommentEmail.InvalidMessage"
            EnableClientScript="false"
             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
        <br />
        <table cellspacing="1" cellpadding="1" width="100%" border="0">
            <tr>
                <td class="LeftTD" width="13%">
                    <asp:Label ID="lblAuthor" runat="server" ResourceKey="lblAuthor" CssClass="NormalBold"
                        Width="80px" />
                </td>
                <td id="tdAuthor" runat="server">
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
                <td >   
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