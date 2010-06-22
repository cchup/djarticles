<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="DjArticles.CategoryList" %>
<asp:Label ID="lblMessage" runat="server" />
<ul class="LinksWrap">
    <asp:Repeater ID="lstCategory" runat="server"
        EnableViewState="false">
        <ItemTemplate>
            <%# Eval("MenuHtml")%>
        </ItemTemplate>
    </asp:Repeater>
    
    
</ul>

