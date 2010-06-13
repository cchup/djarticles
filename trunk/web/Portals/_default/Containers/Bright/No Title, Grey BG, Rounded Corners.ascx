<%@ Control language="vb" CodeBehind="~/admin/Containers/container.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="SOLPARTACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0"><tbody>
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tbody>
        <tr>
          <td width="16" align="right" valign="top"><img src="<%= SkinPath %>images/corn_1.jpg" width="16" height="17" /></td>
          <td class="corn_tbg"><dnn:SOLPARTACTIONS runat="server" id="dnnSOLPARTACTIONS" />
              <img src="<%= SkinPath %>images/spacer.gif" width="1" height="17" /></td>
          <td width="16" align="left" valign="top"><img src="<%= SkinPath %>images/corn_2.jpg" width="16" height="17" /></td>
        </tr>
        <tr>
          <td align="right" valign="bottom" class="container02_LBG"><img src="<%= SkinPath %>images/cont02Left.jpg" width="16" height="90" /></td>
          <td align="left" valign="top" class="container02_mid"  id="ContentPane" runat="server"></td>
          <td align="left" valign="bottom" class="container02_RBG"><img src="<%= SkinPath %>images/cont02Right.jpg" width="16" height="90" /></td>
        </tr>
        <tr>
          <td align="right" valign="top"><img src="<%= SkinPath %>images/corn_4.jpg" width="16" height="17" /></td>
          <td class="container02_cbb"><img src="<%= SkinPath %>images/spacer.gif" width="1" height="17" /></td>
          <td align="left" valign="top"><img src="<%= SkinPath %>images/corn_3.jpg" width="16" height="17" /></td>
        </tr>
      </tbody>
    </table>
    </td>
  </tr>
  <tr>
    <td align="left" valign="top"><img src="<%= SkinPath %>images/spacer.gif" width="1" height="10" /></td>
  </tr>
   </tbody>
</table>


