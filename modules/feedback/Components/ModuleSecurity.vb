'
' DotNetNuke® - http://www.dotnetnuke.com
' Copyright (c) 2002-2006 by DotNetNuke Corp.
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'
Imports System
Imports System.Web.ui.WebControls
Imports DotNetNuke
Imports DotNetNuke.Security
Imports DotNetNuke.Entities.Portals

Namespace DotNetNuke.Modules.Feedback.Security
    Public Class ModuleSecurity
        Private hasModeratePermission As Boolean
        Private hasManageListPermission As Boolean
     

        Public Sub New(ByVal moduleId As Integer, ByVal tabId As Integer)
            Dim mc As New DotNetNuke.Entities.Modules.ModuleController
            Dim mp As DotNetNuke.Security.Permissions.ModulePermissionCollection = mc.GetModule(moduleId, tabId).ModulePermissions
            hasModeratePermission = Permissions.ModulePermissionController.HasModulePermission(mp, PermissionName.ModerateFeedbackPosts)
            hasManageListPermission = Permissions.ModulePermissionController.HasModulePermission(mp, PermissionName.ManageFeedbackLists)
        End Sub

     

        Public Function IsAllowedToModeratePosts() As Boolean
            Return hasModeratePermission
        End Function
        Public Function IsAllowedToManageLists() As Boolean
            Return hasManageListPermission
        End Function
        

        Public Function RoleNames(ByVal User As UserInfo) As String
            Dim roles As String = ""
            If Not (User.Roles Is Nothing) Then roles = "|" & String.Join("|", User.Roles)
            roles &= "|" & glbRoleAllUsersName
            Dim administratorRoleName As String
            administratorRoleName = GetPortalSettings.AdministratorRoleName
            If PortalSecurity.IsInRole(administratorRoleName) Then roles &= "|" & administratorRoleName
            Return roles & "|"
        End Function

        Public Shared Function UserId(ByVal Username As String, ByVal Portalid As Integer) As Integer
            Dim ui As UserInfo = DotNetNuke.Entities.Users.UserController.GetUserByName(Portalid, Username, False)
            If ui Is Nothing Then
                Return 0
            Else
                Return (ui.UserID)
            End If
        End Function
    End Class
End Namespace