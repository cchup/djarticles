<%@ Control language="vb" CodeBehind="~/admin/Containers/container.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="SOLPARTACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<link href="<%= SkinPath %>container.css" rel="stylesheet" type="text/css">
<div id="cont02wrapper">
  <div class="container02_cl"><img src="<%= SkinPath %>images/cont_cl.jpg" /></div>
     <div id="container02">
	 <div id="sol_03"><dnn:SOLPARTACTIONS runat="server" id="dnnSOLPARTACTIONS" /></div>    
	 <div id="title_03"><dnn:TITLE runat="server" id="dnnTITLE" CssClass="verdana22wht" /></div>
	 </div>
  <div class="container02_cr" align="right"><img src="<%= SkinPath %>images/cont_cr.jpg" /></div>
</div>
  <div class="container02_cont" id="ContentPane" runat="server"></div>
