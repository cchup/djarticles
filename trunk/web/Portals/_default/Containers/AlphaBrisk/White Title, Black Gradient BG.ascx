<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ICON" Src="~/Admin/Containers/Icon.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>
<div class="Black_Gradient_l">
	<div class="Black_Gradient_r">
		<div class="Black_Gradient">
			<dnn:ICON runat="server" id="dnnICON"  />
			<dnn:TITLE runat="server" id="dnnTITLE"  CssClass="bgtitle" />				
			<dnn:ACTIONS runat="server" id="dnnACTIONS"  ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" />
			<div class="clear_float"></div>		
			<div id="ContentPane" runat="server" class="c_contentpane"></div>
    		<div class="c_footer">
       			<dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON1"  CommandName="AddContent.Action" DisplayIcon="True" DisplayLink="True" />
        		<dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON2"  CommandName="SyndicateModule.Action" DisplayIcon="True" DisplayLink="false" />
    		</div>
		</div>
	</div>
</div>
