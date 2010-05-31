<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticlesListBase.ascx.cs" Inherits="DjArticles.ArticlesListBase" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" Runat="server" />
<asp:DataList id="lstArticles" CssClass="ArticleList" runat="server" OnItemDataBound="Item_Bound" EnableViewState="false" CellPadding="4" Width="100%">
	<ItemTemplate>
		<div class="Article">
			<div style="float:right;">
				<asp:Label id="lblCategories" cssclass="CategoryList" runat="server" />
			</div>
		<div class="Head">
				<asp:HyperLink id="titleLink" runat="server" text='<%# Eval("Title") %>' NavigateUrl='<%# EditUrl("ArticleView","ArticleID",Eval("ArticleID").ToString()) %>' />
		</div>
			<asp:Label id="lblPublishDate"  cssclass="NormalRed" runat="server" text='<%# Eval("CreatedDate","{0:yyyyÄêMMÔÂddÈÕ hh:mm:ss}") %>' />
			<div class="normal">
				<asp:Image ID="imgArticleImage" runat="server" cssclass="thumbnail" />
				<asp:Label id="lblSubHead" cssclass="Subhead" runat="server" text='<%# Eval("Title") + "<br/>" %>' />
				<asp:Label id="lblDescription" cssclass="Normal" runat="server" text='<%#  Eval("Summary") %>' />
				&nbsp;&nbsp;<asp:HyperLink id="lnkReadMore" ResourceKey="ReadMore" cssclass="NormalBold" runat="server" />
			</div>
			<div><asp:HyperLink id="lnkComments" cssclass="CommentsLink" runat="server" /></div>
		</div>
	</ItemTemplate>
	<FooterTemplate>
		<div class="MoreArticlesLink"><asp:HyperLink id="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" /></div>
	</FooterTemplate>
</asp:DataList>
<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
