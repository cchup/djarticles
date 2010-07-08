<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<script type="text/javascript">
	$(function(){
		$(".feedback").bindPopup("feedback");
		$("#close").bindClosePopup();
	})
</script>
<span class="feedback fbbutton"></span>
<div id="feedback" style="display: none;">
		<img src="<%= SkinPath %>images/close.png" onclick="disablePopups()" class="close" alt="Close" />
		<dnn:TITLE runat="server" id="dnnTITLE"  CssClass="title" />				
		<dnn:ACTIONS runat="server" id="dnnACTIONS"  ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" />
	<div id="ContentPane" runat="server" class="containerpane"></div>
</div>
