<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ICON" Src="~/Admin/Containers/Icon.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="VISIBILITY" Src="~/Admin/Containers/Visibility.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>
<div class="wbdbc">
<div class="stl"><div class="str"><div class="st"></div></div></div>
<div class="sml"><div class="smr"><div class="sm">
	<span class="float_left">
			<dnn:ICON runat="server" id="dnnICON"  />
			<dnn:TITLE runat="server" id="dnnTITLE"  CssClass="Title" />				
			<dnn:ACTIONS runat="server" id="dnnACTIONS"  ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" />
	</span>
	<span class="float_right">
            <dnn:VISIBILITY runat="server" id="dnnVISIBILITY"  minicon="images/minusb.gif" maxicon="images/plusb.gif" />
	</span>
	<div class="clear_float"></div>		
	<div id="ContentPane" runat="server" class="c_contentpane"></div>
    <div class="c_footer">
       			<dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON1"  CommandName="AddContent.Action" DisplayIcon="True" DisplayLink="True" />
        		<dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON2"  CommandName="SyndicateModule.Action" DisplayIcon="True" DisplayLink="false" />
       			<dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON3"  CommandName="PrintModule.Action" DisplayIcon="True" DisplayLink="false" />
        		<dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON4"  CommandName="ModuleSettings.Action" DisplayIcon="True" DisplayLink="false" />
    </div>
</div></div></div>
<div class="sbl"><div class="sbr"><div class="sb"></div></div></div>
</div>
