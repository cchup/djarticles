<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticlesListBase.ascx.cs" Inherits="DjArticles.ArticlesListBase" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" runat="server" />
<asp:Repeater ID="lstArticles" runat="server" OnItemDataBound="Item_Bound"
    EnableViewState="false">
    <ItemTemplate>
        <div class="Article">
            <h3>
                <asp:HyperLink ID="titleLink" runat="server" Text='<%# Eval("Title") %>' NavigateUrl='<%# EditUrl("ArticleID",DataBinder.Eval(Container.DataItem,"ArticleID").ToString(),"ArticleView") %>' />
            </h3>

            <p class="normal">
                <asp:Image ID="imgArticleImage" runat="server" CssClass="thumbnail" />
                <asp:Label ID="lblDescription" CssClass="Normal" runat="server" Text='<%#  Eval("Summary") %>' />
            </p>
            <div>
                
                <a href="#"><%# Eval("CreatedByUserName")%></a>
                发表于&nbsp;
                <asp:Label ID="lblPublishDate" CssClass="Normal" runat="server" Text='<%# Eval("CreatedDate","{0:yyyy-MM-dd hh:mm}") %>' />
                <asp:HyperLink ID="lnkComments" CssClass="CommentsLink" runat="server" /></div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        <div class="MoreArticlesLink">
            <asp:HyperLink ID="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" /></div>
    </FooterTemplate>
</asp:Repeater>
<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
