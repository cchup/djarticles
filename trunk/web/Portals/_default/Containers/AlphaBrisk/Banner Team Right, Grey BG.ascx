<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="bannercontainer rightteam">
	<div class="stl"><div class="str"><div class="st"></div></div></div>
	<div class="sml"><div class="smr"><div class="sm">
			<dnn:ACTIONS runat="server" id="dnnACTIONS"  ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" />
	<div id="ContentPane" runat="server" class="contentpane">
			<dnn:TITLE runat="server" id="dnnTITLE"  CssClass="bannertitle" />				
	</div>
	</div></div></div>
	<div class="sbl"><div class="sbr"><div class="sb"></div></div></div>
</div>
