<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticlesListBase.ascx.cs" Inherits="DjArticles.ArticlesListBase" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" Runat="server" />
<asp:DataList id="lstArticles" CssClass="ArticleList" runat="server" OnItemDataBound="Item_Bound" EnableViewState="false" CellPadding="4" Width="100%">
	<ItemTemplate>
		<asp:HyperLink cssclass="Normal" id="titleLink" runat="server" text='<%# Eval("Title") %>' />
		<div>
			<asp:HyperLink id="lnkComments" runat="server" />
		</div		
	</ItemTemplate>
	<FooterTemplate>
		<div class="MoreArticlesLink"><asp:HyperLink id="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" /></div>
	</FooterTemplate>
</asp:DataList>
<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
