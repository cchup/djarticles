<%@ Control language="vb" CodeBehind="~/admin/Containers/container.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="SOLPARTACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<link href="<%= SkinPath %>container.css" rel="stylesheet" type="text/css">
<div id="container01">
  <div id="container01_title_bg"><dnn:SOLPARTACTIONS runat="server" id="dnnSOLPARTACTIONS" /> <dnn:TITLE runat="server" id="dnnTITLE" CssClass="verdana22" /></div>
  
  <div id="container01_cont"><div  id="ContentPane" runat="server"></div>
  </div>
</div>



