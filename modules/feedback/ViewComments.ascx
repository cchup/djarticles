<%@ Register TagPrefix="dnnsc" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ViewComments.ascx.vb"
    Inherits="DotNetNuke.Modules.Feedback.ViewComments" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<style type="text/css">
    .feedbacklist .blockquote
    {
        padding: 2px 5px 2px 5px;
        border: #aaa 1px solid;
        background-color:#e0e0e0;
        min-height:45px;
        margin:0px;
    }
    .feedbacklist .cite
    {
        position:relative;
        padding:7px 0px 10px 15px;
        background:url(images/comment_tip.gif) no-repeat 20px 0px;
        display:block;
        font-style:normal;
    }
</style>
<asp:Panel ID="pnlModuleContent" runat="server">
    <table width="100%" border="0">
        <tr>
            <td colspan="2">
                <asp:DataList ID="dlComments" Width="100%" runat="server" RepeatColumns="1">
                    <ItemTemplate>
                        <div class="feedbacklist">
                            <div class="blockquote">
                                <asp:Label ID="lblSubject" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Subject") %>'
                                    CssClass="subhead" />
                                <span style="line-height: 23px;">
                                    <asp:Label ID="lblMessage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Message") %>'
                                        CssClass="Normal" />
                                </span>
                            </div>
                            <div class="cite">
                                <span>
                                    <asp:Label ID="lblAuthor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedByName") %>'
                                        CssClass="NormalBold" />&nbsp;&nbsp;
                                    <asp:Label ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateCreated","{0:yyyy-M-d hh:mm:ss}") %>'
                                        CssClass="NormalBold" />&nbsp;&nbsp;
                                    <asp:Label ID="lblCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryValue") %>'
                                        CssClass="NormalBold" />&nbsp;&nbsp;
                                    <asp:Label ID="lblFeedbackID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FeedbackID") %>'
                                        Visible="False" />
                                </span><br />
                                <asp:Panel visible='<%# IsEditable %>' runat="server" class="feedback_contract">
                                    <%--  <asp:label ID="Label1" class="SubHead" Runat="server" resourcekey="lblContactInfo"></asp:label><br />--%>
                                    <asp:Label ID="Label2" class="NormalBold" runat="server" resourcekey="lblEmail"></asp:Label><asp:Label
                                        ID="lblEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedByEmail") %>'
                                        CssClass="Normal"  />&nbsp;&nbsp;
                                    <asp:Label ID="Label3" class="NormalBold" runat="server" resourcekey="lblTelephone"></asp:Label><asp:Label
                                        ID="lblTelephone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Telephone") %>'
                                        CssClass="Normal" />&nbsp;&nbsp;
                                    <asp:Label ID="Label6" class="NormalBold" runat="server" resourcekey="lblOrgName"></asp:Label><asp:Label
                                        ID="lblOrgName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OrgName") %>'
                                        CssClass="Normal" />
                                </asp:Panel >
                            </div>
                        </div>
                        <%--<hr style="width: 100%; size: 1;" />--%>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td style="white-space: nowrap;">
                <asp:Label ID="Label5" runat="server" resourcekey="RecordsPage" CssClass="SubHead">Records Per Page:</asp:Label>
                <asp:DropDownList ID="ddlRecordsPerPage" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="25">25</asp:ListItem>
                    <asp:ListItem Value="50">50</asp:ListItem>
                    <asp:ListItem Value="100">100</asp:ListItem>
                    <asp:ListItem Value="250">250</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="white-space: nowrap;">
                <dnnsc:pagingcontrol id="ctlPagingControl" runat="server"></dnnsc:pagingcontrol>
            </td>
        </tr>
    </table>
</asp:Panel>
