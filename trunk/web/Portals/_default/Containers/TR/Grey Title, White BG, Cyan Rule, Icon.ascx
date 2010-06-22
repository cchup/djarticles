<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ICON" Src="~/Admin/Containers/Icon.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="VISIBILITY" Src="~/Admin/Containers/Visibility.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>
<div class="IconTitleBlueWidth">
  <div class="IconTitleBlueTopMIddle">
    <div class="TitleActionscell">
      <dnn:ACTIONS runat="server" id="ModuleMenu"  ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" />
    </div>
	<div class="IconTitleBlueIcon">
		  <dnn:ICON runat="server" id="ICON"  />
		</div>		
    <div class="IconTitleBlueTitle">
      <h2>	  
        <dnn:TITLE runat="server" id="Title"  CssClass="ContainerTitle" />
      </h2>
    </div>
    <div class="IconTitleBlueVisibilitycell">
      <dnn:VISIBILITY runat="server" id="Visibility"  />
    </div>
    <div class="ClearFloat"></div>
  </div>
  <div class="IconTitleBlueContentpane" id="ContentPane" runat="server"></div>
</div>
<div class="BottomAction">
  <dnn:ACTIONBUTTON runat="server" id="AddContent"  CommandName="AddContent.Action" DisplayIcon="True" DisplayLink="True" />
  <!-- Add Action -->
  <dnn:ACTIONBUTTON runat="server" id="Settings"  CommandName="ModuleSettings.Action" DisplayIcon="True" DisplayLink="True" />
  <!-- Module Settings Action -->
  <dnn:ACTIONBUTTON runat="server" id="Syndicate"  CommandName="SyndicateModule.Action" DisplayIcon="True" DisplayLink="False" />
  <!-- RSS Syndication Action -->
</div>
