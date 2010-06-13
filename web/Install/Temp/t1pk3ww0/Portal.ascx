<%@ Control Language="vb" CodeBehind="~/admin/Skins/skin.vb" AutoEventWireup="false"
    Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="STYLES" Src="~/Admin/Skins/Styles.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="DNNRADMENU" Src="~/Admin/Skins/DNNRadMenu/DNNRadMenu.ascx" %>

<script runat="server">
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CType(dnnSEARCH.FindControl("txtSearch"), TextBox).Attributes.Add("onfocus", "ClearSearch()")
        CType(dnnSEARCH.FindControl("txtSearch"), TextBox).Attributes.Add("onblur", "GetSearch()")
    End Sub
</script>

<link href="skin.css" rel="stylesheet" type="text/css">
<div id="PageMaster">
    <div id="header_wrap">
        <div id="header">
            <div id="Logo">
                <dnn:LOGO runat="server" ID="dnnLOGO" />
            </div>
            <div id="header_right">
                <div id="search_b">
                    <div class="search_l">
                    </div>
                    <div class="search_bg">
                        <dnn:SEARCH runat="server" ID="dnnSEARCH" CssClass="dnnSearchCss" ShowSite="False"
                            ShowWeb="False" Submit="<img src=&quot;images/submit.jpg&quot; align=top border=0 alt=&quot;&quot;>" />
                    </div>
                    <div class="search_r">
                    </div>
                </div>
                <div id="login">
                    <dnn:USER runat="server" ID="dnnRegister" CssClass="login_t" />
                    •
                    <dnn:LOGIN runat="server" ID="dnnLOGIN" CssClass="login_t" />
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="nav">
            <div id="Menu">
                 <dnn:DNNRADMENU runat="server" id="dnnRADMENU"  EnableEmbeddedSkins="false" SelectedPathHeaderItemCss="focused" SelectedPathItemCss="focused" ShowPath="true" Skin="Topmenu" />
            </div>
        </div>
    </div>
    <div id="banner_internal">
        <div id="banner_t">
            <div id="TopPane" runat="server">
            </div>
        </div>
        <div class="clear" />
    </div>
    <div id="mid">
        <div>
            <div id="mid_content">
                <div id="ContentPane" runat="server">
                </div>
            </div>
            <div id="mid_right">
                <div id="RightPane1" runat="server">
                </div>
            </div>
            <div id="mid1">
                <div id="mid_1">
                    <div id="MidPane1" runat="server">
                    </div>
                </div>
                <div id="mid_2">
                    <div id="MidPane2" runat="server">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="footer">
        <div id="foot_l">
        </div>
        <div id="foot_m">
            <div id="footer_mid">
                <div id="footerLeft" class="verdana12wht_nor_c">
                    <dnn:COPYRIGHT runat="server" ID="dnnCOPYRIGHT" CssClass="verdana12wht_nor_c" />
                </div>
                <div id="footerRight" class="verdana12wht_nor_c">
                    <dnn:TERMS runat="server" ID="dnnTERMS" CssClass="verdana12wht_nor_c" />
                    |
                    <dnn:PRIVACY runat="server" ID="dnnPRIVACY" CssClass="verdana12wht_nor_c" />
                </div>
            </div>
        </div>
        <div id="foot_r">
        </div>
    </div>
</div>

<script language="javascript" type="text/javascript">
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

<dnn:STYLES runat="server" id="dnnSTYLES" Name="Sidemenu" StyleSheet="Navigation/styles.css" UseSkinPath="True" />
