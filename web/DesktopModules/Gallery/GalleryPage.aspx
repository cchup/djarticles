﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GalleryPage.aspx.vb" Inherits="DotNetNuke.Modules.Gallery.GalleryPageBase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=PageTitle%></title>
    <meta content="Microsoft Visual Studio.NET 8.0" name="GENERATOR" />
    <meta content="Visual Basic 7.0" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta http-equiv="Content-Style-Type" content="text/css"/>
    <meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema" />
    <link href="<%= GalleryConfig.Css() %>" type="text/css" rel="stylesheet" />
    
    <script type="text/javascript" language="javascript" src='<%=Page.ResolveUrl("DesktopModules/Gallery/Popup/gallerypopup.js")%>'></script>
    <script type="text/javascript" language="javascript">			
		function closeWindow()
		{
		    window.close();
		}
		
		function windowClosed(event)
		{
            //  William Severance - added function to ensure that popUp is set to null
            //  regardless of whether window is closed by close button or X. Otherwise, the next time
            //  a pop up attempts to open, it will throw exception since popUp will still
            //  be defined but have no properties.
            
		    if (opener) opener.popUp=null;
		}

		function testOpener() {
		    //var baseurl = window.location.protocol + '//' + window.location.host + window.location.pathname.substr(0, window.location.pathname.indexOf("/", 1) + 1) + 'default.aspx';
		    if (opener) {
		        var rgxTabId = /tabid[\/=](\d+)/i
		        var openerTabId = rgxTabId.exec(opener.window.location.href);
		        var popupTabId = rgxTabId.exec(window.location.href);
		        var openertabid = '';
		        var popuptabid = '';
		        if (openerTabId != null && popupTabId != null) {
		            openertabid = openerTabId[1];
		            popuptabid = popupTabId[1];
		            if (openertabid != popuptabid) {
		                window.location.replace("about:blank");  //window.location.replace(baseurl);
		            }
		        }
		    }
		    else {
		        window.location.replace("about:blank");  //window.location.replace(baseurl);
		    }
		}
    </script>    
</head>

<body onunload="javascript:windowClosed();">
    <form id="Form1" method="post" runat="server">
        <script type="text/javascript" language="javascript">
            testOpener();
        </script>
        <table id="tblControl" cellpadding="0" cellspacing="0" class="Gallery_Container" style="vertical-align:middle; text-align:center; margin-left:auto; margin-right:auto; height:100%; width:100%">
            <tr id="rowControl">
                <td id="cellControl" class="Gallery_Row">
                    <asp:PlaceHolder ID="phControl" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td class="Gallery_Header" style="vertical-align: middle; text-align: center; white-space:nowrap; height:28px;">
                     <asp:Button ID="btnClose" runat="server" OnClientClick="javascript:closeWindow();return false;" CssClass="Button" Text="Close" Width="80px" />     
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
