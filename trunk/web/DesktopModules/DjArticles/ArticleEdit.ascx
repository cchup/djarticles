<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleEdit.ascx.cs"
    Inherits="DjArticles.ArticleEdit" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="URL" Src="~/controls/URLControl.ascx" %>
<script type="text/javascript">
    //<![CDATA[
    function OnClientItemSelected(sender, args)
    {
        var pvwImage = $get("pvwImage");
        var imageSrc = args.get_item().get_url();

        if (imageSrc.match(/\.(gif|jpg)$/gi))
        {
            pvwImage.src = imageSrc;
            pvwImage.style.display = "";
        }
        else
        {
            pvwImage.src = imageSrc;
            pvwImage.style.display = "none";
        }
    }
    //]]>
</script>
<%--<telerik:RadScriptManager ID="RadScriptManager1" runat="Server" />--%>
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
                BorderStyle="none" Text="Manage" CausesValidation="False" OnClick="cmdCategoryManage_Click"></asp:LinkButton>&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" resourcekey="valCategory.ErrorMessage"
                runat="server" ErrorMessage="<br>Category is required" ControlToValidate="cboCategory"
                ValidationExpression="\d*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr height="30px">
        <td class="SubHead" width="125">
            <dnn:Label id="lblTitle" runat="server" controlname="txtTitle" suffix=":">
            </dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" MaxLength="100" Width="500" CssClass="NormalTextBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" resourcekey="valTitle.ErrorMessage"
                ControlToValidate="txtTitle" CssClass="NormalRed" ErrorMessage="<br>Title is required"
                runat="server" />
        </td>
    </tr>
    <tr  height="30px">
        <td class="SubHead" width="125">
            <dnn:label id="lblImage" runat="server" controlname="ctlImage" suffix=":" />
        </td>
        <td>
            <%--<telerik:RadFileExplorer runat="server" ID="reImage" Width="500px" Height="300px"
                    OnClientItemSelected="OnClientItemSelected" EnableOpenFile="false">
                </telerik:RadFileExplorer>
            <fieldset style="width: 270px; height: 270px">
                    <legend>Preview</legend>
                    <img id="pvwImage" src="" alt="" style="display: none; margin: 10px; width: 250px;
                        height: 225px;" />
            </fieldset>
            <%--<dnn:DnnFilePicker ID="ctlImage" runat="server" style="width:450px" Required="False" ShowSecure="True" ShowDatabase="False" />--%>
        <dj:ImageFilePicker runat="server"  ID="ctlImage" runat="server" style="width:450px" Required="False" ShowSecure="True" ShowDatabase="False"  >
        </dj:ImageFilePicker>
        </td>
    </tr>
    <tr height="40px">
        <td class="SubHead" width="125">
            <dnn:Label id="lblKeyWords" runat="server" controlname="txtKeyWords" suffix=":">
            </dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtKeyWords" runat="server" MaxLength="100" Width="500" Height="30"
                CssClass="NormalTextBox" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" resourcekey="valKeyWords.ErrorMessage"
                ControlToValidate="txtKeyWords" CssClass="NormalRed" ErrorMessage="<br>KeyWords is required"
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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" resourcekey="valSummary.ErrorMessage"
                ControlToValidate="txtSummary" CssClass="NormalRed" ErrorMessage="<br>Summary is required"
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
                ControlToValidate="txtContent" CssClass="NormalRed" ErrorMessage="<br>Content is required"
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
