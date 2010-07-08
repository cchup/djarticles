<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TEXT" Src="~/Admin/Skins/Text.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="STYLES" Src="~/Admin/Skins/Styles.ascx" %>
<%@ Register TagPrefix="dnn" TagName="DNNRADMENU" Src="~/Admin/Skins/DNNRadMenu/DNNRadMenu.ascx" %>
<div class="body_bg">
    <div align="center">
        <div class="banner_bg">
            <div class="overall_pad" align="left">
                <div class="logo_hgt">
                    <div class="logo_pad"><dnn:LOGO runat="server" id="dnnLOGO" /></div>
                    <div class="user_pad">
                        <div class="search_pad">
                            <div class="search_bg">
                                <span id="SearchContainer"><dnn:SEARCH runat="server" id="dnnSEARCH" CssClass="search" showWeb="False" showsite="False" Submit="&nbsp;<img src=&quot;images/search.gif&quot; border=&quot;0&quot; alt=&quot;&quot; />" /></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="menu_pad">
                	<dnn:DNNRADMENU runat="server" id="dnnRADMENU"  EnableEmbeddedSkins="false" SelectedPathHeaderItemCss="focused" SelectedPathItemCss="focused" ShowPath="true" Skin="Topmenu" />
                </div>
               <div class="bread_hgt">
                         <div class="user_right"> <div class="user">
                            <dnn:USER runat="server" id="dnnUSER" CssClass="user" />&nbsp;&nbsp;|&nbsp;&nbsp;<dnn:LOGIN runat="server" id="dnnLOGIN" CssClass="user" />
                        </div></div>
                    <div class="bread_pad">
                        <div class="bread_img"><dnn:TEXT runat="server" id="dnnTEXT" CssClass="breadcrumb_text" Text="You are here" ResourceKey="Breadcrumb" /> :&nbsp;&nbsp;<dnn:BREADCRUMB runat="server" id="dnnBREADCRUMB" RootLevel="0" Separator="&nbsp;>&nbsp;" CssClass="Breadcrumb" /></div>
                    </div>
                </div>
                <div>
                    <div class="overall_width">
                        <div class="ContentPane" id="ContentPane" runat="server" visible="false"></div>
                    </div>
                    <div class="clear_both"></div>
                </div>
                <div class="footer_line">
                    <div class="footer_ltpad">
                        <span class="footer"><dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" CssClass="footer" /></span>
                    </div>
                    <div class="footer_rtpad">
                    	<span class="footer">Designed and developed by</span> <a href="http://www.salaro.com/" target="_blank" class="footer_link">SalarO</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<dnn:STYLES runat="server" id="dnnSTYLES" Name="Sidemenu" StyleSheet="Navigation/styles.css" UseSkinPath="True" />
