<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td align="left"><dnn:ACTIONS runat="server" id="dnnACTIONS" ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" /><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON1" CommandName="AddContent.Action" DisplayIcon="True" DisplayLink="True" /><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON2" CommandName="ModuleSettings.Action" DisplayIcon="True" DisplayLink="False" /></td>
    <td id="ContentPane" runat="server"></td>
  </tr>
</table>
