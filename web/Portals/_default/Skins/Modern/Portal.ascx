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
<!-- Main Template starts -->
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
  	<div id="dlt" class="contentpart_left">
        <div id="lt">
              <div class="leftpane" id="leftpane" runat="server" visible="false"></div>
        </div>
      </div>
      <div id="mn" class="contentpart_right">
         <div class="toppane" id="toppane" runat="server" visible="false"></div>
         <div class="bannerpane" id="bannerpane" runat="server" visible="false"></div>
         <div class="breadcrumbarea"><dnn:TEXT runat="server" id="dnnTEXT" CssClass="breadcrumb_text" Text="You are here：" ResourceKey="Breadcrumb" /> : <dnn:BREADCRUMB runat="server" id="dnnBREADCRUMB" RootLevel="0" Separator="&nbsp;<img src=&quot;images/arrow.gif&quot; border=&quot;0&quot; alt=&quot;arrow&quot; /&gt;&nbsp;" CssClass="Breadcrumb" /></div>
         <div class="contentpane" id="contentpane" runat="server" visible="false"></div>
         <div class="con_contentarea">
            <div id="bolt" class="con_contentarea_left">
               <div id="blt">
                    <div class="bottomleftpane" id="bottomleftpane" runat="server" visible="false"></div>
               </div>    
            </div>
             <div id="brt" class="con_contentarea_right">
                  <div class="bottomrightpane" id="bottomrightpane" runat="server" visible="false"></div>
             </div>
             <div class="clr"></div>
         </div>
        <div class="bottompane" id="bottompane" runat="server" visible="false"></div>
	</div>
    <div class="clr"></div>
   </div>
<div class="footerpart">
        	<div class="footerpart_left"><dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" CssClass="footer" /></div>
            <div align="right" class="footerpart_right">
            	Developed By：<a href="mailto:houdejun214@163.com" target="_blank">侯德军</a>
            </div>
        </div>
        <div class="clr"></div>
	</div>
</div>
<!-- Main Template ends -->

<script type="text/javascript">
<!--

function getDim () {  
document.getElementById('dlt').style.width="auto";
// match box models

gl = document.getElementById('dlt').offsetWidth;
if(gl==0) { 
document.getElementById('mn').style.width="761px";
}else {
document.getElementById('mn').style.width="668px";
document.getElementById('lt').style.width="240px";
}
}
 getDim();
 
function getDim1 () {  
document.getElementById('bolt').style.width="auto";
// match box models

gl1 = document.getElementById('bolt').offsetWidth;
if(gl1==0) { 
document.getElementById('brt').style.width="520px";
}else {
document.getElementById('brt').style.width="324px";
document.getElementById('blt').style.width="344px";
}
}
 
 getDim1(); 
 
 function getDim2 () {  
document.getElementById('dlt').style.width="auto";
// match box models

gl2 = document.getElementById('dlt').offsetWidth;
if(gl2==0) { 
document.getElementById('blt').style.width="380px";
document.getElementById('brt').style.width="380px";
}else {
document.getElementById('blt').style.width="344px";
document.getElementById('brt').style.width="324px";
}
}
 getDim2();

 //-->
 </script>
<dnn:STYLES runat="server" id="dnnSTYLES" Name="Sidemenu" StyleSheet="Navigation/styles.css" UseSkinPath="True" />
