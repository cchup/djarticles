<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>
<div class="BlueBGTitleWidth">
	<div class="BlueBGTitleBG">
	<span class="BlueBGTitleTL"></span>
	<span class="BlueBGTitleTR"></span>
	<span class="BlueBGTitleBL"></span>
	<span class="BlueBGTitleBR"></span>
  <div class="BlueBGTitleTopMIddle">
    <div class="TitleActionscell">
      <dnn:ACTIONS runat="server" id="ModuleMenu"  ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" />
    </div>
  </div>
     <div class="BlueBGTitleTitle">
      <h2>	  
        <dnn:TITLE runat="server" id="Title"  CssClass="ContainerTitle" />
      </h2>
    </div>
	</div>
  <div class="BlueBGTitleContentpane" id="ContentPane" runat="server"></div>
  <div class="ClearFloat"></div>
</div>
<div class="BottomAction">
  <dnn:ACTIONBUTTON runat="server" id="AddContent"  CommandName="AddContent.Action" DisplayIcon="True" DisplayLink="True" />
  <!-- Add Action -->
  <dnn:ACTIONBUTTON runat="server" id="Settings"  CommandName="ModuleSettings.Action" DisplayIcon="True" DisplayLink="True" />
  <!-- Module Settings Action -->
  <dnn:ACTIONBUTTON runat="server" id="Syndicate"  CommandName="SyndicateModule.Action" DisplayIcon="True" DisplayLink="False" />
  <!-- RSS Syndication Action -->
</div>

