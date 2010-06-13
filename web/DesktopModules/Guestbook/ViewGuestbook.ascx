<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewGuestbook.ascx.cs" Inherits="ICG.Modules.Guestbook.ViewGuestbook" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>

<asp:datalist id="lstContent" datakeyfield="ItemID" runat="server" cellpadding="4"  style="width:100%;" OnItemDataBound="lstContent_ItemDataBound">
  <HeaderTemplate>
    <%= _HeaderTemplate %>
  </HeaderTemplate>
  <ItemTemplate>
  
  </ItemTemplate>
  <FooterTemplate>
    <%= _FooterTemplate %>
  </FooterTemplate>
</asp:datalist>
<dnn:PagingControl id="dnnPager" runat="server" CssClass="HideBorder" Visible="false" CSSClassLinkInactive="Inactive" />
<asp:Panel ID="pnlNoRecords" Visible="false" runat="server">
    <asp:Label ID="litNoRecordsMessage" runat="server" CssClass="Normal" ></asp:Label>
</asp:Panel>
<hr />

<asp:Label ID="lblSignDisabled" runat="server" resourcekey="DisabledSignPrompt" Visible="false" />
<dnn:sectionhead id="dshSignEntry" cssclass="NormalBold" runat="server" section="tblSignEntry" resourcekey="SignGuestbook"
				 includerule="false" /><br />
<table border="0" cellpadding="1" runat="server" id="tblSignEntry">
    <tr>
        <td class="NormalBold" align="right" width="100px">
            <dnn:label id="lblName" runat="server" controlname="lblName" suffix=":"></dnn:label>
        </td>
        <td class="Normal" align="left">
            <asp:TextBox ID="txtName" runat="server" MaxLength="200"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valTxtName" runat="server" ControlToValidate="txtName" Text="Required" ValidationGroup="ICGGuestbook"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr runat="server" id="trEmail">
        <td class="NormalBold" align="right" width="100px">
            <dnn:label id="lblEmail" runat="server" controlname="lblEmail" suffix=":"></dnn:label>
        </td>
        <td class="Normal" align="left">
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="255"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valTxtEmailReq" runat="server" ControlToValidate="txtEmail" Text="Required" ValidationGroup="ICGGuestbook"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="valTxtEmailExpr" runat="server" ControlToValidate="txtEmail" Text="Valid Email Required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ICGGuestbook"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr runat="server" id="trWebsite">
        <td class="NormalBold" align="right" width="100px">
            <dnn:label id="lblWebsite" runat="server" controlname="lblWebsite" suffix=":"></dnn:label>
        </td>
        <td class="Normal" align="left">
            <asp:TextBox ID="txtWebsite" runat="server" maxLength="255"></asp:TextBox>
            <asp:RegularExpressionValidator ID="valWebsiteValid" runat="server" ControlToValidate="txtWebsite" Text="Website must be valid" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" ValidationGroup="ICGGuestbook"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr runat="server" id="trLocation">
        <td class="NormalBold" align="right" width="100px">
            <dnn:label id="lblLocation" runat="server" controlname="lblLocation" suffix=":"></dnn:label>
        </td>
        <td class="Normal" align="left">
            <asp:TextBox ID="txtLocation" runat="server" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valTxtLocation" runat="server" ControlToValidate="txtLocation" Text="Required" ValidationGroup="ICGGuestbook"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr runat="server" id="trRating">
        <td class="NormalBold" align="right" width="100px">
            <dnn:label id="lblRating" runat="server" controlname="lblRating" suffix=":"></dnn:label>
        </td>
        <td class="Normal" align="left">
            <asp:DropDownList ID="lstRating" runat="server" >
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem Selected="True">10</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="NormalBold" align="right" width="100px" valign="top">
            <dnn:label id="lblComments" runat="server" controlname="lblComments" suffix=":"></dnn:label>
        </td>
        <td class="Normal" align="left">
            <asp:TextBox ID="txtComments" runat="server" Height="200px" Width="300px" TextMode="multiline"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valTxtComments" runat="server" ControlToValidate="txtComments" ErrorMessage="Required" ValidationGroup="ICGGuestbook"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr runat="server" id="trCaptcha">
        <td class="NormalBold" align="right" width="100px" valign="top">
            <dnn:Label ID="lblCaptcha" runat="server" ControlName="ctlCaptcha" Suffix=":" />
        </td>
        <td>
            <dnn:CaptchaControl ID="ctlCaptcha" CaptchaHeight="40" CaptchaWidth="150" ErrorStyle-CssClass="NormalRed" cssclass="Normal" runat="server" ErrorMessage="The typed code must match the image, please try again"/>
        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:LinkButton ID="btnSignGuestbook" runat="server" CssClass="normal" resourcekey="btnSignGuestbook" OnClick="btnSignGuestbook_Click" ValidationGroup="ICGGuestbook"></asp:LinkButton>
        </td>
    </tr>
</table>
