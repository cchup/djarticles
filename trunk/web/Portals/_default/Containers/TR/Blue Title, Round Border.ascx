<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ICON" Src="~/Admin/Containers/Icon.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="VISIBILITY" Src="~/Admin/Containers/Visibility.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>
<div class="BlueTitleRound">
<div class="stl"><div class="str"><div class="st"></div></div></div>
<div class="sml"><div class="smr"><div class="sm">
	<span class="BlueTitle">
			<dnn:TITLE runat="server" id="dnnTITLE"  CssClass="Title" />				
			<dnn:ACTIONS runat="server" id="dnnACTIONS"  ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" />
		<div class="ClearFloat"></div>
	</span>
	<div class="ClearFloat"></div>
	<div id="ContentPane" runat="server" class="c_contentpane"></div>
    <div class="c_footer">
        		<dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON4"  CommandName="ModuleSettings.Action" DisplayIcon="True" DisplayLink="false" />
    </div>
	<div class="ClearFloat"></div>
</div></div></div>
<div class="sbl"><div class="sbr"><div class="sb"></div></div></div>
</div>
