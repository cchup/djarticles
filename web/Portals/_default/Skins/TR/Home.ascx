<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="DNNRADMENU" Src="~/Admin/Skins/DNNRadMenu/DNNRadMenu.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LINKS" Src="~/Admin/Skins/Links.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="STYLES" Src="~/Admin/Skins/Styles.ascx" %>

<!--[if lt IE 7.]>
<script defer type="text/javascript" src="<%= SkinPath %>images/pngfix.js"></script>
<![endif]-->
<!-- BG Table start -->
<div class="BGTable">
  <!-- BG Table 1 start -->
  <div class="BGTable1">
    <!-- BG Table 2 start -->
    <div class="BGTable2">
      <!-- Container start -->
      <div class="Container">
        <!-- Logo Panel start -->
        <div class="LogoPane">
          <dnn:LOGO runat="server" id="dnnLOGO"  />
        </div>
        <!-- Logo Panel end -->
        <!-- Bookmark panel start -->
        <div class="BookMarkPane" id="BookMarkPane" runat="server" visible="false"> <span class="BookMarkLeft"></span> <span class="BookMarkRight"></span> </div>
        <!-- Bookmark panel end -->
        <div class="ClearFloat"></div>
        <!-- Twitter panel start -->
        <div class="TwitterPane" id="TwitterPane" runat="server" visible="false"></div>
        <!-- Twitter panel end -->
        <!-- Body Content Top start -->
        <div class="BodyContentTop">
          <!-- Font sizer panel start -->
          <div class="FontSizerPane">
            <div class="Widgets">
              <object id="TextSizeWidget" codetype="dotnetnuke/client" codebase="StyleSheetWidget" declare="declare">
                <param name="baseUrl" value="<%= SkinPath %>variations/" />
                <param name="template" value="&lt;div title='{TEXT}' {ID} {CLASS}&gt;&lt;/div&gt;" />
                <param name="default" value="MediumText" />
                <param name="Small Text" value="SmallText" />
                <param name="Medium Text" value="MediumText" />
                <param name="Large Text" value="LargeText" />
              </object>
            </div>
          </div>
          <!-- Font sizer panel end -->
          <!-- Login panel start -->
          <div class="LoginPane">
            <dnn:LOGIN runat="server" id="dnnLOGIN"  CssClass="Login" Text="登录" LogoffText="退出" RegisterText="注册"/>
            |
            <dnn:USER runat="server" id="dnnUSER"  CssClass="User" />
          </div>
          <!-- Login panel end -->
          <br class="ClearFloat" />
        </div>
        <!-- Body Content Top end -->
        <!-- Body Content Middle start -->
        <div class="BodyContentMiddle">
          <!-- Nav Panel start -->
          <div class="NavPane"> <span class="NavLeft">&nbsp;</span> <span class="NavRight">&nbsp;</span>
            <div class="NavInner">
              <dnn:DNNRADMENU runat="server" id="dnnDNNRADMENU"  style="float:left;height:auto;width:auto;" Skin="TRMenu" SelectedPathHeaderItemCss="rmSelected" SelectedPathItemCss="rmSelected" EnableEmbeddedSkins="false" ShowPath="true" />
            </div>
            <!-- Search panel start -->
            <div class="SearchPane">
              <dnn:SEARCH runat="server" id="dnnSEARCH"  CssClass="ServerSkinWidget" UseDropDownList="false" ShowWeb="false" ShowSite="false" Submit="<img src=&quot;images/search.gif&quot; border=&quot;0&quot; alt=&quot;Search&quot; /&gt;" />
            </div>
            <!-- Search panel end -->
            <br class="ClearFloat" />
          </div>
          <!-- Nav Panel end -->
          <!-- Contant Pane 1 start -->
          <div class="ContentPane1">
            <div class="ContentPane2" id="ContentPane2" runat="server" visible="false"></div>
            <div class="ContentPane3" id="ContentPane3" runat="server" visible="false"></div>
            <div class="ClearFloat"></div>
          </div>
          <!-- Contant Pane 1 end -->
        </div>
        <!-- Body Content Middle end -->
        <!-- Bottom Joint start -->
        <div class="BodyContentJoint"></div>
        <!-- Bottom Joint end -->
        <!-- Body Content Middle start -->
        <div class="BodyContentMiddle">
          <div class="ContentPane" id="ContentPane" runat="server" visible="false"></div>
          <!-- Contant panel 4 start -->
          <div class="ContentPane4">
            <div class="ContentPane1T" id="ContentPane1" runat="server" visible="false"></div>
            <div class="ContentPane5" id="ContentPane5" runat="server" visible="false"></div>
            <div class="ContentPane6" id="ContentPane6" runat="server" visible="false"></div>
            <div class="ContentPane7" id="ContentPane7" runat="server" visible="false"></div>
            <div class="ClearFloat"></div>
          </div>
          <!-- Contant panel 4 end -->
        </div>
        <!-- Body Content Middle end -->
        <!-- Bottom Joint start -->
        <div class="BodyContentJoint"></div>
        <!-- Bottom Joint end -->
        <!-- Body Content Middle start -->
        <div class="BodyContentMiddle">
          <!-- Contant panel 4 start -->
          <div class="ContentPane4">
            <div class="ContentPane5" id="ContentPane8" runat="server" visible="false"></div>
            <div class="ContentPane6" id="ContentPane9" runat="server" visible="false"></div>
            <div class="ContentPane7" id="ContentPane10" runat="server" visible="false"></div>
            <div class="ClearFloat"></div>
          </div>
          <!-- Contant panel 4 end -->
        </div>
        <!-- Body Content Middle end -->
        <!-- Body Content Bottom Start -->
        <div class="BodyContentBottom"></div>
        <!-- Body Content Bottom end -->
      </div>
      <!-- Container end -->
      <!-- Bottom Panel start -->
      <div class="BottomPane">
        <!-- Footer panel start -->
        <div class="FooterPane">
          <div class="FooterInner">
            <div class="FooterLeft">
              <dnn:LINKS runat="server" id="dnnLINKS"  CssClass="Link" Level="Root" Separator="&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;" />
              <div class="ClearFloat"></div>
              <dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT"  CssClass="Copyright" />
            </div>
            <div class="FooterRight">
              <dnn:PRIVACY runat="server" id="dnnPRIVACY"  CssClass="Footer" />
              &nbsp;
              <dnn:TERMS runat="server" id="dnnTERMS"  CssClass="Footer" />
            </div>
          </div>
        </div>
        <!-- Footer panel end -->
      </div>
      <!-- Bottom Panel end -->
    </div>
    <!-- BG Table 2 end -->
  </div>
  <!-- BG Table 1 end -->
</div>
<!-- BG Table end -->
<dnn:STYLES runat="server" id="StylesIE"  Name="IE" StyleSheet="ie.css" Condition="IE" UseSkinPath="true" />

