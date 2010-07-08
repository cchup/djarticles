<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Register TagPrefix="dnn" TagName="CURRENTDATE" Src="~/Admin/Skins/CurrentDate.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="NAV" Src="~/Admin/Skins/Nav.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TEXT" Src="~/Admin/Skins/Text.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LINKS" Src="~/Admin/Skins/Links.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<div id="ControlPanel" runat="server"></div>
<table summary="" width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="skinmaster full" id="green">
  <tr>
    <td valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0" summary="">
                        <tr>
                          <td class="language" valign="middle"><div class="languagetxt"><dnn:LANGUAGE runat="server" id="dnnLANGUAGE" showMenu="False" showLinks="True" /></div><div class="datetxt right"><dnn:CURRENTDATE runat="server" id="dnnCURRENTDATE" CssClass="datetxt" /></div></td>
                        </tr>
                    </table><div class="frame_top">
      <div class="frame_bottom">
      <div class="frame_left">
      <div class="frame_right">
      <div class="frame_top_left">
      <div class="frame_top_right">
      <div class="frame_bottom_left">
      <div class="frame_bottom_right">
      <table summary="" width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td height="88" valign="bottom" class="skinpad"><table summary="" width="100%" border="0" cellspacing="0" cellpadding="0" class="breadcrumbtxt">
            <tr>
              <td height="88" align="left" valign="bottom" nowrap="nowrap" id="logintxt"><div><div><div><dnn:LOGIN runat="server" id="dnnLOGIN" CssClass="logintxt" /></div></div></div><div><div><div><dnn:USER runat="server" id="dnnUSER" CssClass="logintxt" /></div></div></div></td>
              <td height="88" align="right" valign="bottom" class="top_image" nowrap="nowrap"><img src="<%= SkinPath %>images/spacer.gif" class="maple_top" width="214" height="88" hspace="0" vspace="0" border="0" alt="" /></td>
            </tr>
          </table></td>
        </tr>
        <tr>
          <td valign="top" align="center" class="skinpad"><table summary="" width="100%" border="0" cellpadding="0" cellspacing="0" class="back_grass">
            <tr>
              <td height="5" valign="middle" class="logo"><dnn:LOGO runat="server" id="dnnLOGO" /></td>
              <td height="5" align="right" valign="top"><img src="<%= SkinPath %>images/spacer.gif" class="maple" width="417" height="156" hspace="0" vspace="0" border="0" alt="" /></td>
            </tr>
          </table></td>
        </tr>
        <tr>
          <td valign="top" align="center" class="skinpad"><div class="tabmenu"><dnn:NAV runat="server" id="dnnNAV" ProviderName="DNNMenuNavigationProvider" IndicateChildren="False" ControlOrientation="Horizontal" CSSControl="mainMenu" SeparatorLeftHTML="<img src=&quot;images/spacer.gif&quot; class=&quot;menu_separator_left&quot; border=&quot;0&quot; width=&quot;2&quot; height=&quot;32&quot; hspace=&quot;0&quot; vspace=&quot;0&quot; alt=&quot;&quot;/>" SeparatorRightHTML="<img src=&quot;images/spacer.gif&quot; class=&quot;menu_separator_right&quot; border=&quot;0&quot; width=&quot;2&quot; height=&quot;32&quot; hspace=&quot;0&quot; vspace=&quot;0&quot; alt=&quot;&quot;/>" /></div></td>
        </tr>
        <tr>
          <td height="28" class="skinpad"><table summary="" width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="31" align="left" valign="middle" class="breadcrumbtxt" nowrap="nowrap"><dnn:TEXT runat="server" id="dnnTEXT" CssClass="breadcrumbtxt" Text="You are here: " resourceKey="Breadcrumb" replaceTokens="True" /><dnn:BREADCRUMB runat="server" id="dnnBREADCRUMB" CssClass="breadcrumbtxt" Separator="&nbsp;&raquo;&nbsp;" RootLevel="0" /></td>
                <td height="31" align="right" valign="top" class="search"><dnn:SEARCH runat="server" id="dnnSEARCH" Submit="&lt;img src=&quot;images/spacer.gif&quot; class=&quot;search&quot; border=&quot;0&quot; hspace=&quot;0&quot; vspace=&quot;0&quot; alt=&quot;Search&quot;/&gt;" ShowSite="false" ShowWeb="false" /></td>
              </tr>
          </table></td>
        </tr>
        <tr>
          <td height="170" valign="top" class="skinpad"><table summary="" width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td align="left" valign="top"><table summary="" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td valign="top" class="main"><table summary="" width="100%" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td width="100%" align="center" valign="top"><div class="toppane" id="TopPane" runat="server"></div>
                              <table summary="" width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                  <td valign="top" class="leftpane" id="LeftPane" runat="server"></td>
                                  <td width="100%" class="contentpane" id="ContentPane" runat="server" valign="top"></td>
                                  <td valign="top" class="rightpane" id="RightPane" runat="server"></td>
                                </tr>
                              </table>
                              <div class="bottompane" id="BottomPane" runat="server"></div></td>
                          </tr>
                        </table></td>
                    </tr>
                  </table></td>
              </tr>
            </table></td>
        </tr>
        <tr>
          <td height="20" align="center" class="linktxt"><dnn:LINKS runat="server" id="dnnLINKS" CssClass="linktxt" Level="Root" Separator="<img src='images/separator_links.gif' width='5' height='6' hspace='0' vspace='1' border='0' alt='' />" /></td>
        </tr>
      </table>
      </div></div></div></div></div></div></div></div><table summary="" width="100%" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td height="20" align="center" class="footertxt"><dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" CssClass="footertxt_1st" /><a href="http://www.dynnamite.co.uk" target="_blank" class="footertxt">Designed by DyNNamite</a><dnn:TERMS runat="server" id="dnnTERMS" CssClass="footertxt" /><dnn:PRIVACY runat="server" id="dnnPRIVACY" CssClass="footertxt" /></td>
              </tr>
            </table></td>
  </tr>
</table>

