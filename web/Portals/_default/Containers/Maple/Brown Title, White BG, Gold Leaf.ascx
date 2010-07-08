<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ICON" Src="~/Admin/Containers/Icon.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>
<table border="0" align="center" cellpadding="0" cellspacing="0" class="containermaster">
  <tr>
    <td valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td valign="top" class="leaf_back"><table width="100%" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td class="leaf_yellow"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td valign="middle" nowrap="nowrap"><dnn:ACTIONS runat="server" id="dnnACTIONS" ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" /></td>
                      <td valign="middle" width="100%" nowrap="nowrap"><h1><dnn:TITLE runat="server" id="dnnTITLE" CSSClass="title" /></h1></td>
                      <td valign="middle" nowrap="nowrap"><dnn:ICON runat="server" id="dnnICON" /></td>
                    </tr>
                  </table></td>
              </tr>
              <tr>
                <td id="ContentPane" runat="server" class="content" valign="top"></td>
              </tr>
            </table></td>
        </tr>
        <tr>
          <td><table width="100%" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td width="100%" valign="middle" nowrap="nowrap" style="line-height:1px;"><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON1" CommandName="AddContent.Action" DisplayIcon="True" DisplayLink="True" /></td>
                <td valign="middle" nowrap="nowrap" style="line-height:0px; font-size:1px;"><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON2" CommandName="ModuleSettings.Action" DisplayIcon="True" DisplayLink="False" /></td>
                <td valign="middle" nowrap="nowrap" style="line-height:0px; font-size:1px;"><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON3" CommandName="SyndicateModule.Action" DisplayIcon="True" DisplayLink="False" /></td>
                <td valign="middle" nowrap="nowrap" style="line-height:0px; font-size:1px;"><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON4" CommandName="ModuleHelp.Action" DisplayIcon="True" DisplayLink="False" /></td>
                <td valign="middle" nowrap="nowrap" style="line-height:0px; font-size:1px;" class="print"><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON5" CommandName="PrintModule.Action" DisplayIcon="True" DisplayLink="False" /></td>
              </tr>
            </table></td>
        </tr>
      </table><img src="<%= SkinPath %>container_images/spacer.gif" width="200px" height="1" hspace="0" vspace="0" alt="" class="containerwidth" /></td>
  </tr>
</table>
