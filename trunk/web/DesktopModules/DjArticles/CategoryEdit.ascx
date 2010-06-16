<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryEdit.ascx.cs"
    Inherits="DjArticles.CategoryEdit" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="DualList" Src="~/controls/DualListControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table cellspacing="0" cellpadding="0" width="600" summary="Edit Category Design Table">
    <tr valign="top" id="trp" runat="server">
        <td class="SubHead" width="150">
            <asp:HiddenField ID="hfCategoryID" runat="server" />
            <dnn:label id="plParentCategory" runat="server" controlname="cboParentCategory" suffix=":">
            </dnn:label>
        </td>
        <td width="450">
            <asp:DropDownList ID="cboParentCategory" runat="server" Width="300" CssClass="NormalTextBox" 
                DataTextField="Name" DataValueField="CategoryID">
            </asp:DropDownList>
            <br>
            <asp:RequiredFieldValidator ID="valParentCategory" resourcekey="ParentCategory.ErrorMessage"
                runat="server" CssClass="NormalRed" ControlToValidate="cboParentCategory" ErrorMessage="必须选择父分类"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:label id="plName" runat="server" controlname="txtName" suffix=":">
            </dnn:label>
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="300" CssClass="NormalTextBox"></asp:TextBox>
            <br>
            <asp:RequiredFieldValidator ID="valName" resourcekey="Name.ErrorMessage" runat="server"
                CssClass="NormalRed" ControlToValidate="txtName" ErrorMessage="必须输入分类名称 "
                Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:label id="plDescription" runat="server" controlname="txtDescription" text="Description"
                suffix=":">
            </dnn:label>
        </td>
        <td>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="300"
                Rows="5" CssClass="NormalTextBox"></asp:TextBox>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:label id="plIsActive" runat="server" controlname="chkIsActive" suffix=":">
            </dnn:label>
        </td>
        <td>
            <asp:CheckBox ID="chkIsActive" runat="server" CssClass="NormalTextBox"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <dnn:sectionhead id="dshAuthorize" cssclass="Head" runat="server" isexpanded="False"
                text="Authorize Settings" section="tblAuthorize" resourcekey="dshAuthorize" />
        </td>
    </tr>
</table>
<table id="tblAuthorize" runat="server" cellspacing="0" cellpadding="0" width="600"
    summary="Authorize Settings">
    <tr valign="top">
        <td class="SubHead">
            <dnn:label id="plAdminRoles" runat="server" controlname="ctlAdminRoles" suffix=":">
            </dnn:label>
        </td>
        <td>
            <portal:duallist id="ctlAdminRoles" runat="server" ListBoxWidth="130" ListBoxHeight="130"
                DataValueField="RoleName" DataTextField="RoleName">
            </portal:duallist>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:label id="plEditRoles" runat="server" controlname="ctlEditRoles" suffix=":">
            </dnn:label>
        </td>
        <td>
            <portal:duallist id="ctlEditRoles" runat="server" ListBoxWidth="130" ListBoxHeight="130"
                DataValueField="RoleName" DataTextField="RoleName">
            </portal:duallist>
        </td>
    </tr>
    <tr valign="top">
        <td class="SubHead">
            <dnn:label id="plViewRoles" runat="server" controlname="ctlViewRoles" suffix=":">
            </dnn:label>
        </td>
        <td>
            <portal:duallist id="ctlViewRoles" runat="server" ListBoxWidth="130" ListBoxHeight="130"
                DataValueField="RoleName" DataTextField="RoleName">
            </portal:duallist>
        </td>
    </tr>
</table>
<asp:Button ID="btnSave" runat="server" Text="保 存" onclick="btnSave_Click" />
<asp:Button ID="btnCancel" runat="server" Text="取 消"
     CausesValidation="false" 
    onclick="btnCancel_Click" />
