<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="VISIBILITY" Src="~/Admin/Containers/Visibility.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>
<div class="feedbackWidth">
    <div class="TitleActionscell">
      <dnn:ACTIONS runat="server" id="ModuleMenu"  ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" />
    </div>
    <div class="feedbackVisibilitycell">
      <dnn:VISIBILITY runat="server" id="Visibility"  />
    </div>
    <div class="ClearFloat"></div>
  <div class="feedbackContentpane" id="ContentPane" runat="server"></div>
</div>
<div class="BottomAction">
  <dnn:ACTIONBUTTON runat="server" id="AddContent"  CommandName="AddContent.Action" DisplayIcon="True" DisplayLink="True" />
  <!-- Add Action -->
  <dnn:ACTIONBUTTON runat="server" id="Settings"  CommandName="ModuleSettings.Action" DisplayIcon="True" DisplayLink="True" />
  <!-- Module Settings Action -->
  <dnn:ACTIONBUTTON runat="server" id="Syndicate"  CommandName="SyndicateModule.Action" DisplayIcon="True" DisplayLink="False" />
  <!-- RSS Syndication Action -->
</div>


