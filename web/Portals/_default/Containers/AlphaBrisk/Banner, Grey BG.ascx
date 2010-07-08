<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<div class="bannercontainer empty">
<div class="stl"><div class="str"><div class="st"></div></div></div>
<div class="sml"><div class="smr"><div class="sm">
			<dnn:ACTIONS runat="server" id="dnnACTIONS"  ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" />
<div id="ContentPane" runat="server" class="contentpane"></div>
</div></div></div>
<div class="sbl"><div class="sbr"><div class="sb"></div></div></div>
</div>











































































