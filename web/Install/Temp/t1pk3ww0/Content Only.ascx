<%@ Control language="vb" CodeBehind="~/admin/Containers/container.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>


<table cellspacing="0" cellpadding="0">
  <tr>
    <td><dnn:ACTIONS runat="server" id="dnnACTIONS" /></td>
  </tr>
  <tr>
    <td align="left" valign="top" runat="server" id="ContentPane">
    </td>
  </tr>
</table>





