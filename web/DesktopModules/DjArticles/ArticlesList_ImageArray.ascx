﻿<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="ArticlesListBase.ascx.cs"
    Inherits="DjArticles.ArticlesListBase" %>
<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<asp:Label ID="lblMessage" runat="server" />
<ul class="article_list_ImageArray">
    <asp:Repeater ID="lstArticles" runat="server" OnItemDataBound="Item_Bound" EnableViewState="false"
        OnItemCommand="lstArticles_ItemCommand">
        <ItemTemplate>
            <li><span><a href='<%# GetArticleDetailUrl(DataBinder.Eval(Container.DataItem,"ArticleID"))  %>'>
                <asp:Image ID="imgArticleImage" ToolTip='<%# DataBinder.Eval(Container.DataItem,"Title") %>' runat="server" CssClass="thumbnail" />
            </a></span></li>
        </ItemTemplate>
        <FooterTemplate>
            <div class="clear"></div>
            <div class="MoreArticlesLink">
                <asp:HyperLink ID="lnkMoreArticles" NavigateUrl='<%# GetMoreArticleDetialUrl() %>'
                    ResourceKey="MoreArticles" runat="server" /></div>
        </FooterTemplate>
    </asp:Repeater>
    
</ul>
<dnnsc:PagingControl id="ctlPagingControl" runat="server" />
