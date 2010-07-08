<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="VISIBILITY" Src="~/Admin/Containers/Visibility.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>
<div class="green">
	<div class="green_bg">
      <div class="green_top_rt"><div class="green_top_bg">
            <div class="green_top_lt">
              <div class="head_pad">
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
            </div>
            </div>
      </div></div>
        <div class="green_rt_bg">
        	<div class="content_pad">
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
    </div>
</div>
<div><img src="<%= SkinPath %>spacer.gif" height="15" alt="" /></div>
