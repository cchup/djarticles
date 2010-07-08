<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="CURRENTDATE" Src="~/Admin/Skins/CurrentDate.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="NAV" Src="~/Admin/Skins/Nav.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LINKS" Src="~/Admin/Skins/Links.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="STYLES" Src="~/Admin/Skins/Styles.ascx" %>

<script src="<%= SkinPath %>js/jquery.cookie.js" type="text/javascript"></script>
<script language="javascript" src="<%= SkinPath %>js/popup.js" type="text/javascript"></script>
<script type="text/javascript">
	//<![CDATA[
	$(function(){
		var $li =$("#themes li");
		$li.click(function(){
			switchSkin( this.id );
		});
		var cookie_skin = $.cookie("MyCssSkin_"+"<%=PortalSettings.ActiveTab.TabID %>");
		if (cookie_skin) {
			switchSkin( cookie_skin );
		}
		//attach the popop options on the page
		$(".options").bindPopup("options");
		$("#close").bindClosePopup();
	});
  // swith the client theme
	function switchSkin(skinName){
			 $("#"+skinName).addClass("selected")
						  .siblings().removeClass("selected"); 
			$("#cssfile").attr("href","<% =SkinPath %>css/theme/"+ skinName +".css");
			$.cookie( "MyCssSkin_"+"<%=PortalSettings.ActiveTab.TabID %>" ,  skinName , { path: '/', expires: 10 });
	}
	//]]>
</script>
<div id="Brisk_wrapper">
	<div id="brisk_header">
		<div class="logo">
			<dnn:LOGO runat="server" id="dnnLOGO" />
		</div>
	 	<div class="topbar">
	 		<div id="options" style="display:none;">
				<img src="<%= SkinPath %>images/close.png" onclick="disablePopups()" class="close" alt="Close" />
					<div id="themes">
						<h2>Desktop Background</h2>
						<ul>
							<li title="business" id="business"><img src="<%= SkinPath %>images/background/thumbnail/business.gif" alt="Business" /></li>
							<li title="vista" id="vista"><img src="<%= SkinPath %>images/background/thumbnail/vista.gif" alt="Vista" /></li>
							<li title="toyama" id="toyama"><img src="<%= SkinPath %>images/background/thumbnail/toyama.gif" alt="Toyama" /></li>
							<li title="grainy" id="grainy"><img src="<%= SkinPath %>images/background/thumbnail/grainy.gif" alt="Grainy" /></li>
							<li title="grassland"  id="grassland" class="selected"><img src="<%= SkinPath %>images/background/thumbnail/grasslands.gif" alt="Grassland" /></li>
							<li title="seasky" id="seasky"><img src="<%= SkinPath %>images/background/thumbnail/seasky.gif" alt="Seasky" /></li>
							<li title="splendid" id="splendid"><img src="<%= SkinPath %>images/background/thumbnail/splendid.gif" alt="Splendid" /></li>
							<li title="stereo"  id="stereo"><img src="<%= SkinPath %>images/background/thumbnail/stereo.gif" alt="Stereo" /></li>
						</ul>
					</div>
				<div id="layout">
					<h2>Page Width and Font Size</h2>
					<div class="Widgets">
						 <object id="SizeWidget" codetype="dotnetnuke/client" codebase="StyleSheetWidget" declare="declare">
							<param name="baseUrl" value="<%= SkinPath %>css/variations/" />
							<param name="template" value="&lt;div title='{TEXT}' {ID} {CLASS}&gt;&lt;/div&gt;" />
							<param name="default" value="widthfull" />
							<param name="Width 1024" value="width1024" />
							<param name="Width 1280" value="width1280" />
							<param name="Full Width" value="widthfull" />
						</object>
						<object id="TextSizeWidget" codetype="dotnetnuke/client" codebase="StyleSheetWidget" declare="declare">
							<param name="baseUrl" value="<%= SkinPath %>css/variations/" />
							<param name="template" value="&lt;div title='{TEXT}' {ID} {CLASS}&gt;&lt;/div&gt;" />
							<param name="default" value="SmallText" />
							<param name="Small Text" value="SmallText" />
							<param name="Medium Text" value="MediumText" />
							<param name="Large Text" value="LargeText" />
						</object>
	            	</div>                
				</div>
			</div>
			<dnn:CURRENTDATE runat="server" id="dnnCURRENTDATE"  CssClass="CurrentDate" />
			 <span title="Page Options" class="options">Page Options</span>
			<dnn:LANGUAGE runat="server" id="dnnLANGUAGE" showMenu="False" showLinks="True" />
		</div>
		<div runat="server" id="HeadPane"  class="HeadPane" visible="false" ></div>
	</div>
	<div class="clear_float spacer"></div>
	<div class="brisk_bread_left">
		<div class="brisk_bread_right">
			<div class="brisk_bread_bg">
				<div class="float_left">
					You are here &gt;
					<dnn:BREADCRUMB runat="server" id="dnnBREADCRUMB"  CssClass="Breadcrumb" RootLevel="0" Separator="&gt;" />
				</div>
				<div class="float_right" >
				<dnn:USER runat="server" id="dnnUSER"  CssClass="user" />
				<dnn:LOGIN runat="server" id="dnnLOGIN"  CssClass="login" />
				</div>
			</div>
		</div>
	</div>
	<div class="clear_float spacer"></div>
		<div runat="server" id="BannerPane"  class="BannerPane" visible="false" ></div>
	<div class="clear_float spacer"></div>
	<div class="dnnpanes">
		<div runat="server" id="TopLeftPane"  class="TopLeftPane float_left" visible="false" ></div>
		<div runat="server" id="TopRightPane"  class="TopRightPane float_right" visible="false" ></div>
		<div class="clear_float spacer"></div>
	</div>
	<div class="clear_float"></div>
	<div id="brisk_innermain_content">
		<div runat="server" id="TopPane"  class="TopPane" visible="false" ></div>
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td valign="top" class="LeftPane" id="LeftPane" runat="server"></td>
				<td valign="top" id="ContentPane" class="ContentPane" runat="server"></td>
				<td valign="top" id="RightPane" class="RightPane" runat="server"></td>
			</tr>
		</table>
		<div class="dnnpanes">
			<div runat="server" id="MainaPane"  class="MainaPane float_left" visible="false" ></div>
			<div runat="server" id="MainbPane"  class="MainbPane float_left" visible="false" ></div>
			<div runat="server" id="MaincPane"  class="MaincPane float_right" visible="false" ></div>
			<div class="clear_float spacer"></div>
		</div>
		<div class="dnnpanes">
			<div runat="server" id="BoxaPane"  class="BoxaPane float_left" visible="false" ></div>
			<div runat="server" id="BoxbPane"  class="BoxbPane float_left" visible="false" ></div>
			<div runat="server" id="BoxcPane"  class="BoxcPane float_left" visible="false" ></div>
			<div runat="server" id="BoxdPane"  class="BoxdPane float_right" visible="false" ></div>
			<div class="clear_float spacer"></div>
		</div>
		<div class="clear_float"></div>
	</div>
<div class="leftnav float_left">
	<div class="LeftMenu_l"><div class="LeftMenu_r"><div class="LeftMenu"></div></div></div>
		<div class="lm">
			<div class="rm">
				<div class="mbox">
				<dnn:NAV runat="server" id="dnnNAV"  ProviderName="DNNMenuNavigationProvider" IndicateChildren="false" ControlOrientation="Vertical" CSSControl="leftMenu" ToolTip="Title" />
				</div>
			</div>
		</div>
	<div class="mbl"><div class="mbr"><div class="mb"></div></div></div>
	<div class="clear_float spacer"></div>
	<div runat="server" id="MenuBotPane"  class="MenuBotPane" visible="false" ></div>
	</div>
	<div runat="server" id="BottomPane"  class="BottomPane" visible="false" ></div>	
	<div class="clear_float spacer"></div>
	<div class="brisk_links_left">
		<div class="brisk_links_right">
			<div class="brisk_links_bg">
				<dnn:LINKS runat="server" id="dnnLINKS"  CssClass="links" Level="Root" Separator="|" />
			</div>
		</div>
	</div>
	<div class="clear_float spacer"></div>
	<div class="float_left">
		<dnn:PRIVACY runat="server" id="dnnPRIVACY"  CssClass="privacy" />
		<span class="Separator">|</span>
		<dnn:TERMS runat="server" id="dnnTERMS"  CssClass="terms" />
	 	<span class="Separator">|</span>
    	<a href="http://www.dnnskin.net" class="terms" title="Design by DnnSkin.net">DnnSkin.Net</a>
	</div>
	<div class="float_right">
		<dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT"  CssClass="copyright" />
	</div>
		<div runat="server" id="FooterPane"  class="FooterPane" visible="false" ></div>
</div>
    <dnn:STYLES runat="server" id="StylesIE6"  Name="IE6Minus" StyleSheet="css/ie6skin.css" Condition="LT IE 7" UseSkinPath="true" />
    <dnn:STYLES runat="server" id="cssflie"  Name="cssfile" StyleSheet="css/theme/grassland.css" UseSkinPath="true" />
	
