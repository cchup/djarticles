<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticlesListSettings.ascx.cs"
    Inherits="DjArticles.ArticlesListSettings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="DualList" Src="~/controls/DualListControl.ascx" %>
<table class="normal" cellspacing="0" cellpadding="2" summary="Edit Articles Design Table"
    border="0">
    <tbody valign="top">
        <tr>
            <td width="150px" class="SubHead">
                <dnn:label id="plFilterByCategory" runat="server" controlname="chkFilterByCategory"
                    suffix=":" />
            </td>
            <td>
                <asp:CheckBox ID="chkFilterByCategory" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="150px" class="SubHead">
                <dnn:label id="plCategory" runat="server" controlname="ctlCategories" suffix=":" />
            </td>
            <td>
                <asp:Label ID="lblNoCategories" runat="server" Text="<br>还没有可用分类" />
                <asp:DropDownList ID="cboCategory" runat="server" 
                    DataTextField="Name" DataValueField="CategoryID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plWillPage" runat="server" controlname="chkWillPage" suffix=":" />
            </td>
            <td>
                <asp:CheckBox ID="chkWillPage" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plArticlesPerPage" runat="server" controlname="drpNumber" suffix=":" />
            </td>
            <td>
                <asp:TextBox ID="txtArticlesPerPage" MaxLength="3" Columns="2" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="^\d+$"
                    ControlToValidate="txtArticlesPerPage" ErrorMessage="Must be a positive number."
                    Display="Dynamic" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plTemplate" runat="server" controlname="drpTemplate" suffix=":" />
            </td>
            <td>
                 <asp:DropDownList ID="drpTemplate" runat="server">
                    <asp:ListItem Value="Standard" Selected="True" ResourceKey="Template_Standard" />
                    <asp:ListItem Value="TitleOnly" ResourceKey="Template_TitleOnly" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plSortField" runat="server" controlname="drpSortField" suffix=":" />
            </td>
            <td backgroundcolor="red">
                <asp:DropDownList ID="drpSortField" runat="server">
                    <asp:ListItem Value="CreatedDate" Selected="True" ResourceKey="SortFieldCreatedDate" />
                    <asp:ListItem Value="Title" ResourceKey="SortFieldTitle" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plAllowComments" runat="server" controlname="chkAllowComments" suffix=":" />
            </td>
            <td class="Normal">
                <asp:CheckBox ID="chkAllowComments" ResourceKey="chkAllowComments" runat="server" />
                <asp:CheckBox ID="chkAnonymousComments" ResourceKey="chkAnonymousComments" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plDateRange" runat="server" controlname="drpDateRange" suffix=":" />
            </td>
            <td>
                <asp:DropDownList ID="drpDateRange" runat="server">
                    <asp:ListItem Value="-1" Selected="True" ResourceKey="NoRestriction" />
                    <asp:ListItem Value="-7" ResourceKey="dateRange1Week" />
                    <asp:ListItem Value="-14" ResourceKey="dateRange2Weeks" />
                    <asp:ListItem Value="-30" ResourceKey="dateRange1Month" />
                    <asp:ListItem Value="-90" ResourceKey="dateRange3Months" />
                    <asp:ListItem Value="-180" ResourceKey="dateRange6Months" />
                    <asp:ListItem Value="-365" ResourceKey="dateRange1Year" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plDisplayedFields" runat="server" suffix=":" />
            </td>
            <td class="Normal">
                <asp:CheckBox ID="chkShowCategory" ResourceKey="chkShowCategory" runat="server" />
                <asp:CheckBox ID="chkShowReadMore" ResourceKey="chkShowReadMore" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plMoreArticles" runat="server" controlname="chkMoreArticles" suffix=":" />
            </td>
            <td>
                <asp:CheckBox ID="chkMoreArticles" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plMoreArticlesPage" runat="server" controlname="drpMoreArticlesPage" suffix=":" />
            </td>
            <td>
                 <asp:DropDownList ID="drpMoreArticlesPage" runat="server">
                 </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plDetialArticlesPage" runat="server" controlname="drpDetialArticlesPage" suffix=":" />
            </td>
            <td>
                 <asp:DropDownList ID="drpDetialArticlesPage" runat="server">
                 </asp:DropDownList>
            </td>
        </tr>
          <tr>
            <td class="SubHead">
                <dnn:label id="plAcceptParameter" runat="server" suffix=":" />
            </td>
            <td class="Normal">
                <asp:CheckBox ID="chkAcceptParameter" ResourceKey="chkAcceptParameter" runat="server" />
            </td>
        </tr>
    </tbody>
</table>
