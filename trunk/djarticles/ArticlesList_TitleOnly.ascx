<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticlesListBase.ascx.cs"
    Inherits="DjArticles.ArticlesListBase" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" runat="server" />
<ul class="article_list_title">
    <asp:Repeater ID="lstArticles" runat="server" OnItemDataBound="Item_Bound"
        EnableViewState="false">
        <ItemTemplate>
            <li>
                <p>
                    <asp:HyperLink CssClass="Normal" ID="titleLink" runat="server" NavigateUrl='<%# EditUrl("ArticleID",DataBinder.Eval(Container.DataItem,"ArticleID").ToString(),"ArticleView") %>'  Text='<%# Eval("Title") %>' />
                </p>
                <span>
                    <%# Eval("CreatedDate", "{0:yyyy-MM-dd}") %>
                </span>
                <div class="clear"></div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            <div class="MoreArticlesLink">
                <asp:HyperLink ID="lnkMoreArticles" ResourceKey="MoreArticles" runat="server" /></div>
        </FooterTemplate>
    </asp:Repeater>
</ul>
<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
