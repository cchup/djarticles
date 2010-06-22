'
' DotNetNuke® - http://www.dotnetnuke.com
' Copyright (c) 2002-2007
' by DotNetNuke Corporation
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
Namespace DotNetNuke.Modules.Feedback
    Public Class FeedbackController
        Implements Entities.Modules.IUpgradeable

        Public Sub CreateFeedback(ByVal o As FeedbackInfo)
            DataProvider.Instance().CreateFeedback(o.PortalID, o.CategoryID, o.CreatedByEmail, o.ModuleID, o.Status, o.Message, o.Subject, o.CreatedByName, o.Telephone, o.OrgName)
        End Sub

        Public Function GetCategoryFeedback(ByVal PortalID As Integer, ByVal CategoryID As String, ByVal Status As FeedbackInfo.FeedbackStatusType, ByVal CurrentPage As Integer, ByVal PageSize As Integer) As ArrayList
            Return DotNetNuke.Common.Utilities.CBO.FillCollection(DataProvider.Instance().GetCategoryFeedback(PortalID, CategoryID, Status, CurrentPage, PageSize), GetType(FeedbackInfo))
        End Function



        Public Function GetFeedback(ByVal FeedbackID As Integer) As ArrayList
            Return DotNetNuke.Common.Utilities.CBO.FillCollection(DataProvider.Instance().GetFeedback(FeedbackID), GetType(FeedbackInfo))
        End Function

        Public Sub UpdateFeedbackStatus(ByVal ModuleID As Integer, ByVal FeedbackID As Integer, ByVal Status As FeedbackInfo.FeedbackStatusType)
            DataProvider.Instance().UpdateFeedbackStatus(ModuleID, FeedbackID, Status)
        End Sub

        Public Function AddFeedbackList(ByVal o As FeedbackList) As Integer
            DataProvider.Instance().AddFeedbackList(o.PortalID, o.ListType, o.Name, o.ListValue, CType(IIf(CType(o.IsActive, String) = "0", False, True), Boolean))
        End Function
        Public Function GetFeedbackList(ByVal SingleRowOperation As Boolean, ByVal PortalID As Integer, ByVal ListID As Integer, ByVal ListType As FeedbackList.Type, ByVal ActiveOnly As Boolean) As ArrayList
            Return DotNetNuke.Common.Utilities.CBO.FillCollection(DataProvider.Instance().GetFeedbackList(SingleRowOperation, PortalID, ListID, ListType, ActiveOnly), GetType(FeedbackList))
        End Function
        Public Sub EditFeedbackList(ByVal IsDeleteOperation As Boolean, ByVal o As FeedbackList)
            DataProvider.Instance().EditFeedbackList(IsDeleteOperation, o.ListID, o.PortalID, o.ListType, o.Name, o.ListValue, CType(IIf(CType(o.IsActive, String) = "0", False, True), Boolean))
        End Sub
        Public Sub ChangeListSortOrder(ByVal ListID As Integer, ByVal ListType As FeedbackList.Type, ByVal OldSortNum As Integer, ByVal NewSortNum As Integer)
            DataProvider.Instance().ChangeSortOrder(ListID, ListType, OldSortNum, NewSortNum)
        End Sub

        Public Function FeedbackListItemExists(ByVal o As FeedbackList) As Boolean
            Dim success As Boolean = False

            'Grab a list of all the feedback items for the current list type from this portal.
            Dim feedbackArryList As ArrayList = GetFeedbackList(False, o.PortalID, -99, o.ListType, False)
            For Each listItem As FeedbackList In feedbackArryList
                If listItem.Name.ToLower = o.Name.ToLower() Then
                    success = True
                    Exit For
                End If
            Next

            Return success
        End Function
        Public Function VerifyNoDuplicateFeedbackListItemName(ByVal o As FeedbackList) As Boolean
            Dim success As Boolean = True

            'Grab a list of all the feedback items for the current list type from this portal.
            Dim feedbackArryList As ArrayList = GetFeedbackList(False, o.PortalID, -99, o.ListType, False)
            For Each listItem As FeedbackList In feedbackArryList
                If listItem.Name.ToLower = o.Name.ToLower() And (o.ListID <> listItem.ListID) Then
                    success = False
                    Exit For
                End If
            Next

            Return success
        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Implements the upgrade interface for DotNetNuke
        ''' </summary>
        ''' <history>
        ''' 	[scullmann]     12/30/2005	First Implementation
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function UpgradeModule(ByVal Version As String) As String Implements Entities.Modules.IUpgradeable.UpgradeModule
            InitPermissions()
            Return Version
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     adds the module specific permissions
        ''' </summary>
        ''' <history>
        ''' 	[scullmann]     12/30/2005	First Implementation
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub InitPermissions()
            Dim bModeratePosts As Boolean, bManageLists As Boolean

            Dim moduleDefId As Integer
            Dim pc As New DotNetNuke.Security.Permissions.PermissionController
            Dim permissions As ArrayList = pc.GetPermissionByCodeAndKey(PermissionName.Code, Nothing)
            Dim dc As New DotNetNuke.Entities.Modules.DesktopModuleController
            Dim desktopInfo As DotNetNuke.Entities.Modules.DesktopModuleInfo
            desktopInfo = dc.GetDesktopModuleByName(Definition.ModuleFriendlyName)
            Dim mc As New DotNetNuke.Entities.Modules.Definitions.ModuleDefinitionController
            Dim mInfo As DotNetNuke.Entities.Modules.Definitions.ModuleDefinitionInfo
            mInfo = mc.GetModuleDefinitionByName(desktopInfo.DesktopModuleID, Definition.ModuleFriendlyName)
            moduleDefId = mInfo.ModuleDefID
            For Each p As DotNetNuke.Security.Permissions.PermissionInfo In permissions
                If p.PermissionKey = PermissionName.ModerateFeedbackPosts And p.ModuleDefID = moduleDefId Then bModeratePosts = True
                If p.PermissionKey = PermissionName.ManageFeedbackLists And p.ModuleDefID = moduleDefId Then bManageLists = True
            Next
            If Not bModeratePosts Then
                Dim p As New DotNetNuke.Security.Permissions.PermissionInfo
                p.ModuleDefID = moduleDefId
                p.PermissionCode = PermissionName.Code
                p.PermissionKey = PermissionName.ModerateFeedbackPosts
                p.PermissionName = "Moderate Posts"
                pc.AddPermission(p)
            End If
            If Not bManageLists Then
                Dim p As New DotNetNuke.Security.Permissions.PermissionInfo
                p.ModuleDefID = moduleDefId
                p.PermissionCode = PermissionName.Code
                p.PermissionKey = PermissionName.ManageFeedbackLists
                p.PermissionName = "Manage Feedback Lists"
                pc.AddPermission(p)
            End If

        End Sub
    End Class
End Namespace