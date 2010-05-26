<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleManage.ascx.cs" Inherits="DjArticles.ArticleManage" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<div>
        <dnn:label id="lblCategory" runat="server" controlname="lblContent" 
            suffix=":" />
        <asp:DropDownList ID="cboCategory" runat="server" Width="300" CssClass="NormalTextBox"
            DataTextField="Name" DataValueField="CategoryID">
        </asp:DropDownList>
        <asp:LinkButton ID="cmdSearch" resourcekey="cmdSearch" runat="server"
             BorderStyle="none" Text="Search" onclick="cmdSearch_Click"  >
                 <asp:Image ID="Image1" ImageUrl="~/images/search_go.gif"  
                        AlternateText="Search" runat="server" resourcekey="cmdSearch" />
        </asp:LinkButton>&nbsp;
        <asp:LinkButton ID="cmdCategoryManage" resourcekey="cmdCategoryManage" runat="server"
             BorderStyle="none" Text="Manage" onclick="cmdCategoryManage_Click" 
            style="height: 19px"  ></asp:LinkButton>&nbsp;
</div>

<dj:djgridview id="grdArticles" runat="server" enableviewstate="False" allowpaging="true"
    custompager="True" width="90%" autogeneratecolumns="False" pagesize="15">
    <Columns>
        <asp:BoundField DataField="CategoryName" HeaderText="CategoryName">
            <HeaderStyle Width="200px" CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="False" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Title" HeaderText="Title">
            <HeaderStyle CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="False" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Summary" HeaderText="Summary">
            <HeaderStyle CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="False" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="CreatedByUserName" HeaderText="CreatedByUserName">
            <HeaderStyle CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="False" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate">
            <HeaderStyle CssClass="NormalBold"></HeaderStyle>
            <ItemStyle Wrap="False" CssClass="Normal"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="Passed">
            <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="NormalBold"></HeaderStyle>
            <ItemTemplate>
                <asp:Image runat="server" ID="imgActived" ImageUrl="~/images/checked.gif" Visible='<%# EvalChecked(Eval("Passed")) %>'/>
                <asp:Image runat="server" ID="imgNotActived" ImageUrl="~/images/unchecked.gif" Visible='<%# !EvalChecked(Eval("Passed")) %>'/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderStyle Width="30px"></HeaderStyle>
            <ItemTemplate>
                <asp:HyperLink ID="editPreview" NavigateUrl='<%# EditUrl("ArticleID",DataBinder.Eval(Container.DataItem,"ArticleID").ToString(),"ArticleView") %>'
                    runat="server">
                    <asp:Image ID="editLinkImage" ImageUrl="~/images/preview.jpg"  
                        AlternateText="Preview" runat="server" resourcekey="Preview" />
                </asp:HyperLink>
            </ItemTemplate>
       </asp:TemplateField>
        <asp:TemplateField>
            <HeaderStyle Width="30px"></HeaderStyle>
            <ItemTemplate>
                <asp:HyperLink ID="editLink" NavigateUrl='<%# EditUrl("ArticleID",DataBinder.Eval(Container.DataItem,"ArticleID").ToString(),"ArticleEdit") %>'
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
                    runat="server" onclientclick='return confirm(&quot;你确认要删除吗?&quot;)'>
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
            <asp:Button ID="btnPass" runat="server" Text="发  表" onclick="btnPass_Click"  />  
            &nbsp;<asp:Button ID="btnNotPass" runat="server" Text="不发表" 
                onclick="btnNotPass_Click" />
            &nbsp;<asp:Button ID="btnNew" runat="server" Text="新  增" 
                onclick="btnNew_Click"/>
        </td>
    </tr>
</table>