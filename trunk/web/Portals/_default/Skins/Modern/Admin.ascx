<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TEXT" Src="~/Admin/Skins/Text.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="STYLES" Src="~/Admin/Skins/Styles.ascx" %>
<%@ Register TagPrefix="dnn" TagName="DNNRADMENU" Src="~/Admin/Skins/DNNRadMenu/DNNRadMenu.ascx" %>
<!--
Skin Designed and developed by SalarO
http://www.salaro.com
Designer       : Bazeeth Ali
Skin Developer : Dilip
Released for free under Dotnetnuke License

Skin Information
Title        : salaro mss
DNN Version  : 5.2.2
-->
<div class="temp">
    <div class="main">
        <div class="menuarea">
        	<dnn:DNNRADMENU runat="server" id="dnnRADMENU"  EnableEmbeddedSkins="false" SelectedPathHeaderItemCss="focused" SelectedPathItemCss="focused" ShowPath="true" Skin="Topmenu" />
        </div>
        <div class="headerpart">
            <div class="headerpart_right">
                <div class="search_bg"><span id="SearchContainer"><dnn:SEARCH runat="server" id="dnnSEARCH" CssClass="search" showWeb="False" showsite="False" Submit="<img src=&quot;images/search.gif&quot; border=&quot;0&quot; alt=&quot;Search&quot; /&gt;" /></span></div>
                <div class="login_pad" align="right"><dnn:USER runat="server" id="dnnUSER" CssClass="user" />&nbsp;&nbsp;|&nbsp;&nbsp;<dnn:LOGIN runat="server" id="dnnLOGIN" CssClass="user" /></div>
            </div>
        <div class="headerpart_left"><dnn:LOGO runat="server" id="dnnLOGO" /></div>
        <div class="clr"></div>
        </div>
            <div class="contentpart">
                <div class="breadcrumbarea"><dnn:TEXT runat="server" id="dnnTEXT" CssClass="breadcrumb_text" Text="You are here" ResourceKey="Breadcrumb" /> : <dnn:BREADCRUMB runat="server" id="dnnBREADCRUMB" RootLevel="0" Separator="&nbsp;<img src=&quot;images/arrow.gif&quot; border=&quot;0&quot; alt=&quot;arrow&quot; /&gt;&nbsp;" CssClass="Breadcrumb" /></div>
                <div class="contentpane" id="contentpane" runat="server" visible="false"></div>
            </div>
            <div class="clr"></div>
        <div class="footerpart">
        	<div class="footerpart_left"><dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" CssClass="footer" /></div>
            <div align="right" class="footerpart_right">
            	<div class="footer">Developed By：<a href="mailto:houdejun214@163.com" target="_blank">侯德军</a></div>
            </div>
        </div>
        <div class="clr"></div>
    </div>
</div>
<dnn:STYLES runat="server" id="dnnSTYLES" Name="Sidemenu" StyleSheet="Navigation/styles.css" UseSkinPath="True" />

