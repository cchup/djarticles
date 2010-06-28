<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticlesListBase.ascx.cs"
    Inherits="DjArticles.ArticlesListBase" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" runat="server" />
<ul class="article_list_title">
    <asp:Repeater ID="lstArticles" runat="server" OnItemDataBound="Item_Bound" EnableViewState="false"
        OnItemCommand="lstArticles_ItemCommand">
        <ItemTemplate>
            <li><span class="article_title">
                <asp:HyperLink CssClass="Normal" ID="titleLink" runat="server" NavigateUrl='<%# GetArticleDetailUrl(DataBinder.Eval(Container.DataItem,"ArticleID"))  %>'
                    Text='<%# Eval("Title") %>' />
            </span><span class="article_other">
                <%# Eval("CreatedDate", "{0:yyyy-MM-dd}") %>
            </span>
                <div class="clear">
                </div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            <div class="MoreArticlesLink">
                <asp:HyperLink ID="lnkMoreArticles" NavigateUrl='<%# GetMoreArticleDetialUrl() %>'
                    ResourceKey="MoreArticles" runat="server" /></div>
        </FooterTemplate>
    </asp:Repeater>
</ul>
<dnnsc:PagingControl ID="ctlPagingControl" runat="server" />
