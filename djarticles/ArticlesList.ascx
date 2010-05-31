<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticlesList.ascx.cs" Inherits="DjArticles.ArticlesList" %>
<asp:Label ID="lblSearchResults" cssclass="SubHead" Visible="False" Runat="server" />
<asp:Placeholder ID="objPlaceholder" Runat="server" />
<br />
<asp:panel id="pnlSearch" cssclass="SearchPanel" visible="false" runat="server">
	<asp:textbox id="txtSearch" runat="server" cssclass="NormalTextBox" Columns="30" maxlength="50" />&nbsp;
	<asp:linkbutton id="cmdSearch" ResourceKey="Search" runat="server" BorderStyle="none" Text="Search Articles" CssClass="CommandButton" />
</asp:panel>