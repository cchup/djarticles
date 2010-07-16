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
    <div id="header">
    	<div id="logo"><dnn:LOGO runat="server" id="dnnLOGO" /></div>
    	<div id="globalnav"><dnn:USER runat="server" id="dnnUSER" CssClass="user" />&nbsp;&nbsp;|&nbsp;&nbsp;<dnn:LOGIN runat="server" id="dnnLOGIN" CssClass="user" /></div>
    	<div id="breadcrumbs_box" class="content_borderless" >
    		<b class="ft"><b></b></b>
    		<div id="breadcrumbs">
    			<dnn:BREADCRUMB runat="server" id="dnnBREADCRUMB" RootLevel="0" Separator="&nbsp;>&nbsp;" CssClass="Breadcrumb" />
    		</div>
    		<div id="head_search">
    			<span id="SearchContainer"><dnn:SEARCH runat="server" id="dnnSEARCH" CssClass="search" showWeb="False" showsite="False" Submit=" " /></span>
			</div>
			<div class="clearfloat"></div>
			<b class="fb"><b></b></b>
		</div>
    </div>
    <div class="clearfloat"></div>
    <div id="body">
    	<div id="contentpane">
			<div class="ContentPane" id="ContentPane" runat="server" visible="false"></div>
		</div>
    	<div id="rightsidepane">
    		<div id="sidemenu">
    			<dnn:DNNRADMENU runat="server" id="dnnRADMENU"  EnableEmbeddedSkins="false" SelectedPathHeaderItemCss="focused" SelectedPathItemCss="focused" ShowPath="true" Skin="Topmenu" />
    		</div>
		 	<div class="RightPane" id="RightPane" runat="server" visible="false"></div>
		</div>
		<div class="clearfloat"></div>
    </div>
   <div class="clear"></div>
</div>
<dnn:STYLES runat="server" id="dnnSTYLES" Name="Sidemenu" StyleSheet="Navigation/styles.css" UseSkinPath="True" />
