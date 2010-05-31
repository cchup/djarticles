<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticlesListBase.ascx.cs" Inherits="DjArticles.ArticlesListBase" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" Runat="server" />
<style>
.FancyHeader {
	background-color: #AA0700;
	color: white;
	font-size: 18px;
}
.FancyBody {
	background-color: #E1D5BB;
	color: #91856B;
	border-top: 1px dotted black;
}
</style>
<asp:DataList id="lstArticles" CssClass="ArticleList" runat="server" OnItemDataBound="Item_Bound" EnableViewState="false" CellPadding="4" Width="100%">
	<SeparatorTemplate><hr></SeparatorTemplate>
	<ItemTemplate>
		<table cellpadding="3" cellspacing="0" style="width:100%; border: 1px solid black;">
			<tr class="FancyHeader">
				<td>
					<asp:HyperLink id="titleLink" runat="server" text='<%# Eval("Title") %>' />
				</td>
				<td align="right">
					<asp:Label id="lblCategories" class="CategoryList" runat="server" />
				</td>
			</tr>
			<tr>
				<td colspan="2" class="FancyBody">
					<div>
						<asp:Label id="lblPublishDate" class="NormalRed" runat="server" text='<%# DotNetNuke.Services.Localization.Localization.GetString("PublishDate.Text", LocalResourceFile) + DataBinder.Eval(Container.DataItem,"CreatedDate").ToShortDateString() %>' />
					</div>
					<asp:Image ID="imgArticleImage" runat="server" vspace="3" hspace="3" />
					<asp:Label id="lblDescription" class="Normal" runat="server" text='<%# Server.HtmlDecode(Eval("Summary")) %>' />
					&nbsp;&nbsp;<asp:HyperLink id="lnkReadMore" ResourceKey="ReadMore" visible="false" class="NormalBold" runat="server" />
					<asp:HyperLink id="lnkComments" class="CommentsLink" runat="server" />
				</td>
			</tr>
		</table>
	</ItemTemplate>
	<FooterTemplate>
		<div class="MoreArticlesLink"><asp:HyperLink id="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" /></div>
	</FooterTemplate>
</asp:DataList>
<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
