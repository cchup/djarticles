<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="VISIBILITY" Src="~/Admin/Containers/Visibility.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>
<div class="Sandal">
	<div class="sandal_top_lt"><div class="sandal_top_rt"><div class="sandal_top_bg"><img src="<%= SkinPath %>spacer.gif" alt="" /></div></div></div>
    <div class="sandal_bg">
        <div class="head_pad_sandal">
            <div class="con_full_width">
                <div class="action_pad Head">
                   <dnn:ACTIONS runat="server" id="dnnACTIONS" ProviderName="DNNMenuNavigationProvider" />
                </div>
                <div class="action_pad Head">
                    <dnn:TITLE runat="server" id="dnnTITLE" CssClass="Head" />
                </div>
                <div class="visibility_pad Head">
                    <dnn:VISIBILITY runat="server" id="dnnVISIBILITY" />	
                </div>
            </div>
        </div><div class="clear_both"></div>
        <div class="content_pad2">
            <div class="con_full_width">
                <div id="ContentPane" runat="server" style="text-align:left;"></div>	
            </div>
        </div>
        <div class="bottom_pad" align="right">
            <div class="con_full_width">
                <span class="Head"><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON1" CommandName="AddContent.Action" DisplayIcon="True" DisplayLink="True" /></span>
                <span class="Head align_pad"><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON2" CommandName="SyndicateModule.Action" DisplayIcon="True" DisplayLink="False" /><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON3" CommandName="PrintModule.Action" DisplayIcon="True" DisplayLink="False" /><dnn:ACTIONBUTTON runat="server" id="dnnACTIONBUTTON4" CommandName="ModuleSettings.Action" DisplayIcon="True" DisplayLink="False" /></span>
            </div>
        </div>
    </div>
    <div class="sandal_bot_lt"><div class="sandal_bot_rt"><div class="sandal_bot_bg"><img src="<%= SkinPath %>spacer.gif" alt="" /></div></div></div>
</div>
<div><img src="<%= SkinPath %>spacer.gif" height="15" alt="" /></div>
