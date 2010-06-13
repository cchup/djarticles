<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="ICG.Modules.Guestbook.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td class="SubHead" width="300">
            <dnn:Label ID="lblUseCaptcha" runat="server" ControlName="chkUseCaptcha" Suffix=":" />
        </td>
        <td>
            <asp:CheckBox ID="chkUseCaptcha" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="300">
            <dnn:Label ID="lblDenyUnauthenticated" runat="server" ControlName="chkDenyUnauthenticated" Suffix=":" />
        </td>
        <td>
            <asp:CheckBox ID="chkDenyUnauthenticated" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="200">
            <dnn:Label ID="lblShowEmail" runat="server" ControlName="chkShowEmail" Suffix=":" />
        </td>
        <td>
            <asp:CheckBox ID="chkShowEmail" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="200">
            <dnn:Label ID="lblShowLocation" runat="server" ControlName="chkShowLocation" Suffix=":" />
        </td>
        <td>
            <asp:CheckBox ID="chkShowLocation" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="200">
            <dnn:Label ID="lblShowRating" runat="server" ControlName="chkShowRating" Suffix=":" />
        </td>
        <td>
            <asp:CheckBox ID="chkShowRating" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="200">
            <dnn:Label ID="lblShowWebsite" runat="server" ControlName="chkShowWebsite" Suffix=":" />
        </td>
        <td>
            <asp:CheckBox ID="chkShowWebsite" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="200">
            <dnn:Label ID="lblNotifyAddress" runat="server" ControlName="txtNotifyAddress" Suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtNotifyAddress" runat="server" MaxLength="500" CssClass="NormalTextbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NotifyAddressRequired" runat="server" Display="dynamic" CssClass="NormalRed"
                ControlToValidate="txtNotifyAddress" resourcekey="NotifyAddressRequired"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="NotifyAddressFormat" runat="server" Display="dynamic" CssClass="NormalRed"
                ControlToValidate="txtNotifyAddress" resourcekey="NotifyAddressFormat" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="200">
            <dnn:label ID="lblModerateEntries" runat="server" ControlName="chkModerateEntries" Suffix=":" />
        </td>
        <td>
            <asp:CheckBox ID="chkModerateEntries" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="200">
            <dnn:label id="lblPageSize" runat="server" controlname="ddlPageSize" Suffix=":" />
        </td>
        <td>
            <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="NormalTextbox">
                <asp:ListItem text="15" Value="15" />
                <asp:ListItem Text="25" Value="25" />
                <asp:ListItem Text="50" Value="50" />
                <asp:ListItem Text="75" Value="75" />
                <asp:ListItem Text="100" Value="100" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="200">
            <dnn:label id="lblSignExpanded" runat="server" controlname="chkSignExpanded" Suffix=":" />
        </td>
        <td>
            <asp:CheckBox ID="chkSignExpanded" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="200">
            <dnn:Label ID="lblAllowHtml" runat="server" ControlName="chkAllowHtml" Suffix=":" />
        </td>
        <td>
            <asp:CheckBox ID="chkAllowHtml" runat="server" />
        </td>
    </tr>
</table>