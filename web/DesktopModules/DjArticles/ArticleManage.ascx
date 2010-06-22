﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleManage.ascx.cs" Inherits="DjArticles.ArticleManage" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<div>
    <p style="display:inline;">
        <dnn:label id="lblCategory" runat="server" controlname="lblContent" 
            suffix=":" />
        <asp:DropDownList ID="cboCategory" runat="server" CssClass="NormalTextBox"
            DataTextField="Name" DataValueField="CategoryID">
        </asp:DropDownList>
         <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/search_go.gif" resourcekey="cmdSearch"
             OnClick="cmdSearch_Click"  runat="server"/>
        <asp:LinkButton ID="cmdSearch" resourcekey="cmdSearch" runat="server"
             BorderStyle="none" Text="Search" onclick="cmdSearch_Click"  >
        </asp:LinkButton>&nbsp;&nbsp;|&nbsp;&nbsp;
        <asp:ImageButton ImageUrl="~/DesktopModules/DjArticles/images/category.jpg" resourcekey="cmdCategoryManage"
             OnClick="cmdCategoryManage_Click"  runat="server"/>
        <asp:LinkButton ID="cmdCategoryManage" resourcekey="cmdCategoryManage" runat="server"
             BorderStyle="none" Text="Manage" onclick="cmdCategoryManage_Click" 
            style="height: 19px"  ></asp:LinkButton>
     </p>
</div>

<dj:djgridview id="grdArticles" runat="server" allowpaging="true"
    custompager="True" autogeneratecolumns="False" pagesize="15"
     BackColor="#CAD9EA"  CellPadding="3"  GridLines="None"   
    CellSpacing="1"   Width="100%" onrowcommand="grdArticles_RowCommand" >
    <Columns>
        <asp:BoundField DataField="CategoryName" HeaderText="CategoryName">
            <HeaderStyle Width="10%" CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="true" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Title" HeaderText="Title">
            <HeaderStyle width="10%" CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="true" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Summary" HeaderText="Summary">
            <HeaderStyle  width="40%"  CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="true" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="CreatedByUserName" HeaderText="CreatedByUserName">
            <HeaderStyle CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="true" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate">
            <HeaderStyle CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="true" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="Passed">
            <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="NormalBold"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
                <asp:Image runat="server" ID="imgActived" ImageUrl="~/images/checked.gif" Visible='<%# EvalChecked(Eval("Passed")) %>'/>
                <asp:Image runat="server" ID="imgNotActived" ImageUrl="~/images/unchecked.gif" Visible='<%# !EvalChecked(Eval("Passed")) %>'/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderStyle Width="100px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
                <asp:HyperLink ID="editPreview" NavigateUrl='<%# EditUrl("ArticleID",DataBinder.Eval(Container.DataItem,"ArticleID").ToString(),"ArticleView") %>'
                    runat="server">
                    <asp:Image ID="previewLinkImage" ImageUrl="~/images/view.gif"  
                        AlternateText="Preview" runat="server" resourcekey="Preview" />
                </asp:HyperLink>
                <asp:HyperLink ID="editLink" NavigateUrl='<%# EditUrl("ArticleID",DataBinder.Eval(Container.DataItem,"ArticleID").ToString(),"ArticleEdit") %>'
                    runat="server">
                    <asp:Image ID="editLinkImage" ImageUrl="~/images/edit.gif" Visible="<%# IsEditable %>"
                        AlternateText="Edit" runat="server" resourcekey="Edit" />
                </asp:HyperLink>
                 <asp:linkButton id="btnDelete" CommandName="DeleteArticle" CommandArgument='<%#Eval("ArticleID") %>'
                    runat="server" onclientclick='return confirm(&quot;你确认要删除吗?&quot;)'>
                    <asp:Image ID="deleteLinkImage" ImageUrl="~/images/delete.gif" Visible="<%# IsEditable %>"
                        AlternateText="Delete" runat="server" resourcekey="Delete" />
                </asp:linkButton>
            </ItemTemplate>
       </asp:TemplateField>
    </Columns>
</dj:djgridview>
<table class="table_default" cellspacing="1">
    <tr class="gray">
        <td align="right">
            <asp:Button ID="btnPass" runat="server" Text="发  表" onclick="btnPass_Click"  />  
            &nbsp;<asp:Button ID="btnNotPass" runat="server" Text="不发表" 
                onclick="btnNotPass_Click" />
            &nbsp;<asp:Button ID="btnNew" runat="server" Text="新  增" 
                onclick="btnNew_Click"/>
        </td>
    </tr>
</table>