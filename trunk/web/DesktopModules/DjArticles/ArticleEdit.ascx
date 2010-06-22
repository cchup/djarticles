<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleEdit.ascx.cs"
    Inherits="DjArticles.ArticleEdit" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<table width="650" cellspacing="0" cellpadding="0" border="0">
    <tr height="30px">
        <td class="SubHead">
            <dnn:Label id="lblCategory" runat="server" controlname="lblContent" suffix=":" />
        </td>
        <td>
            <asp:HiddenField ID="hfArticleId" runat="server" />
            <asp:DropDownList ID="cboCategory" runat="server" Width="300" CssClass="NormalTextBox"
                DataTextField="Name" DataValueField="CategoryID">
            </asp:DropDownList>
            <asp:LinkButton ID="cmdCategoryManage" resourcekey="cmdCategoryManage" runat="server"
                 BorderStyle="none" Text="Manage" onclick="cmdCategoryManage_Click"  ></asp:LinkButton>&nbsp;
        </td>
    </tr>
    <tr  height="30px">
        <td class="SubHead" width="125">
            <dnn:Label id="lblTitle" runat="server" controlname="txtTitle" suffix=":">
            </dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" MaxLength="100" Width="500" CssClass="NormalTextBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" resourcekey="valContent.ErrorMessage"
                ControlToValidate="txtContent" CssClass="NormalRed" Display="Dynamic" ErrorMessage="<br>Content is required"
                runat="server" />
        </td>
    </tr>
    <tr  height="40px">
        <td class="SubHead" width="125">
            <dnn:Label id="lblKeyWords" runat="server" controlname="txtKeyWords" suffix=":">
            </dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtKeyWords" runat="server" MaxLength="100" Width="500" Height="30"
                CssClass="NormalTextBox" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" resourcekey="valContent.ErrorMessage"
                ControlToValidate="txtContent" CssClass="NormalRed" Display="Dynamic" ErrorMessage="<br>Content is required"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="125">
            <dnn:Label id="lblSummary" runat="server" controlname="txtSummary" suffix=":">
            </dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtSummary" runat="server" MaxLength="100" Width="500" Height="50"
                CssClass="NormalTextBox" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" resourcekey="valContent.ErrorMessage"
                ControlToValidate="txtContent" CssClass="NormalRed" Display="Dynamic" ErrorMessage="<br>Content is required"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="125">
            <dnn:Label id="lblContent" runat="server" controlname="lblContent" suffix=":">
            </dnn:Label>
        </td>
        <td>
            <dnn:texteditor id="txtContent" runat="server" height="550" width="500" />
            <asp:RequiredFieldValidator ID="valContent" resourcekey="valContent.ErrorMessage"
                ControlToValidate="txtContent" CssClass="NormalRed" Display="Dynamic" ErrorMessage="<br>Content is required"
                runat="server" />
        </td>
    </tr>
    <tr height="30">
        <td class="SubHead" width="125">
            <dnn:Label id="lblAllowComment" runat="server" controlname="cbAllowComment" suffix=":">
            </dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="cbAllowComment" runat="server" />
        </td>
    </tr>
    <tr height="30">
        <td class="SubHead" width="125">
            <dnn:Label id="lblAllowPrint" runat="server" controlname="cbAllowPrint" suffix=":">
            </dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="cbAllowPrint" runat="server" />
        </td>
    </tr>
    <tr height="30">
        <td class="SubHead" width="125">
            <dnn:Label id="lblOnTop" runat="server" controlname="cbOnTop" suffix=":">
            </dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="cbOnTop" runat="server" />
        </td>
    </tr>
    <tr height="30">
        <td class="SubHead" width="125">
            <dnn:Label id="lblPassed" runat="server" controlname="cbPassed" suffix=":">
            </dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="cbPassed" runat="server" />
        </td>
    </tr>
</table>
<p>
    <asp:LinkButton CssClass="CommandButton" ID="cmdUpdate" resourcekey="cmdUpdate" runat="server"
        BorderStyle="none" Text="Update" OnClick="cmdUpdate_Click"></asp:LinkButton>&nbsp;
    <asp:LinkButton CssClass="CommandButton" ID="cmdCancel" resourcekey="cmdCancel" runat="server"
        BorderStyle="none" Text="Cancel" CausesValidation="False" OnClick="cmdCancel_Click"></asp:LinkButton>&nbsp;
    <asp:LinkButton CssClass="CommandButton" ID="cmdDelete" resourcekey="cmdDelete" runat="server"
        BorderStyle="none" Text="Delete" CausesValidation="False" OnClick="cmdDelete_Click"></asp:LinkButton>&nbsp;
</p>
