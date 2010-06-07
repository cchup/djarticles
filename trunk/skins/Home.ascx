<%@ Control language="vb" CodeBehind="~/admin/Skins/skin.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="NAV" Src="~/Admin/Skins/Nav.ascx" %>
<script runat="server">
		 Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Ctype(dnnSEARCH.FindControl("txtSearch"),Textbox).attributes.add("onfocus","ClearSearch()")
			Ctype(dnnSEARCH.FindControl("txtSearch"),Textbox).attributes.add("onblur","GetSearch()")
		 End Sub

		
		</script>
<table width="950" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td align="left" valign="top"><div id="PageMaster">
  <div id="header"><div id="Logo">
        	<dnn:LOGO runat="server" id="dnnLOGO" />
        </div>
    <div id="header_right">
      <div id="login">
        <div id="login_l"></div>
        <div id="logi_mid">
          <div id="login_t"><dnn:LOGIN runat="server" id="dnnLOGIN" CssClass="login_t" /></div>
        </div>
        <div id="login_r"></div>
      </div>
      <div id="search_b">
        <div class="search_l"></div>
        <div class="search_bg"><dnn:SEARCH runat="server" id="dnnSEARCH" CssClass="dnnSearchCss" ShowSite="False" ShowWeb="False" Submit="<img src=&quot;images/submit.jpg&quot; align=top border=0 alt=&quot;&quot;>" /></div>
		<div class="search_r"></div>
      </div>
    </div>
  </div>
  <div>
    <div id="but_l"></div> 
    <div id="but_m"><div id="Menu">
      <dnn:NAV runat="server" ID="dnnNAV" ProviderName="DNNMenuNavigationProvider" ControlOrientation="Horizontal" IndicateChildren="False" CSSControl="NavMenu" /></div>
    </div>
	<div id="but_r"></div> 
  </div>
  <div id="banner_img">
    <div id="banner_t">
      <div id="TopPane" runat="server"></div>
    </div>
  </div>
  <div id="mid">
    <div><div id="mid_content">
      <div id="ContentPane" runat="server"></div>
    </div><div id="mid_right">
      <div id="RightPane1" runat="server"></div>
    </div>
      <div id="mid1"><div id="mid_1">
        <div id="MidPane1" runat="server"></div>
      </div>
	  <div id="mid_2">
	    <div id="MidPane2" runat="server"></div>
	  </div>
    </div>
	
  </div>
</div>
  <div id="footer">
    <div id="foot_l"></div>
	<div id="foot_m">
	  <div id="footer_mid"><div id="footerLeft" class="verdana12wht_nor_c"><dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" CssClass="verdana12wht_nor_c" /></div>
              <div id="footerRight" class="verdana12wht_nor_c"><dnn:TERMS runat="server" id="dnnTERMS" CssClass="verdana12wht_nor_c" /> | <dnn:PRIVACY runat="server" id="dnnPRIVACY" CssClass="verdana12wht_nor_c" /></div>
	  </div>
	</div>
	<div id="foot_r"></div>
  </div>
</div></td>
  </tr>
</table>

<script language="javascript" type="text/javascript" >
 document.getElementById('<%=dnnSEARCH.FindControl("txtSearch").ClientID() %>').value="Search";
 
 
 
 function ClearSearch()
 {
 if (document.getElementById('<%=dnnSEARCH.FindControl("txtSearch").ClientID() %>').value=="Search")
 
 {
 document.getElementById('<%=dnnSEARCH.FindControl("txtSearch").ClientID() %>').value="";
	
 }
 return ;
 }
 
 function GetSearch()
 {
 if (document.getElementById('<%=dnnSEARCH.FindControl("txtSearch").ClientID() %>').value=="")
 
 {
 document.getElementById('<%=dnnSEARCH.FindControl("txtSearch").ClientID() %>').value="Search";
	
 }
  
 }
 
</script> 

