<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryManage.ascx.cs"
    Inherits="DjArticles.CategoryManage" %>
<dj:djgridview id="grdCategories" runat="server" enableviewstate="False" allowpaging="true"
    custompager="True" width="100%" autogeneratecolumns="False" pagesize="15">
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="Name">
            <HeaderStyle Width="200px" CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="False" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Description" HeaderText="Description">
            <HeaderStyle CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="False" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="CreatedByUserName" HeaderText="CreatedByUserName">
            <HeaderStyle CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="False" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="AdminRoles" HeaderText="AdminUsers">
            <HeaderStyle CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="False" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="EditRoles" HeaderText="EditUsers">
            <HeaderStyle CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="False" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="IsActived">
            <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="NormalBold"></HeaderStyle>
            <ItemTemplate>
                <asp:Image runat="server" ID="imgActived" ImageUrl="~/images/checked.gif" Visible='<%# EvalChecked(Eval("IsActive")) %>'/>
                <asp:Image runat="server" ID="imgNotActived" ImageUrl="~/images/unchecked.gif" Visible='<%# !EvalChecked(Eval("IsActive")) %>'/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderStyle Width="30px"></HeaderStyle>
            <ItemTemplate>
                <asp:HyperLink ID="editLink" NavigateUrl='<%# EditUrl("CategoryID",DataBinder.Eval(Container.DataItem,"CategoryID").ToString(),"CategoryEdit") %>'
                    runat="server">
                    <asp:Image ID="editLinkImage" ImageUrl="~/images/edit.gif" Visible="<%# IsEditable %>"
                        AlternateText="Edit" runat="server" resourcekey="Edit" />
                </asp:HyperLink>
            </ItemTemplate>
       </asp:TemplateField>
       <asp:TemplateField>
       <HeaderStyle Width="30px"></HeaderStyle>
             <ItemTemplate>
                <asp:linkButton id="btnDelete" 
                    runat="server" onclick="btnDelete_Click" onclientclick='return confirm(&quot;你确认要删除吗?&quot;)'>
                    <asp:Image ID="editLinkImage" ImageUrl="~/images/delete.gif" Visible="<%# IsEditable %>"
                        AlternateText="Delete" runat="server" resourcekey="Delete" />
                </asp:linkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</dj:djgridview>
<table class="table_default" cellspacing="1">
    <tr class="gray">
        <td align="right">
            <asp:Button ID="btnNew" runat="server" Text="添加新分类" OnClick="btnNew_Click" />
             &nbsp;<asp:Button ID="btnCancel" runat="server" Text="返 回" 
                onclick="btnCancel_Click" />
       </td>
    </tr>
</table>

