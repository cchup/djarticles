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
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Common.Utilities


Namespace DotNetNuke.Modules.Feedback

	Public Class Moderation
		Inherits PortalModuleBase
#Region "Controls"
        Protected WithEvents dgPendingFeedback As System.Web.UI.WebControls.DataGrid
        Protected WithEvents dgPrivateFeedback As System.Web.UI.WebControls.DataGrid
        Protected WithEvents dgPublicFeedback As System.Web.UI.WebControls.DataGrid
        Protected WithEvents dgArchiveFeedback As System.Web.UI.WebControls.DataGrid
        Protected CurrentPage As Integer = 1
        Protected CurrentPage2 As Integer = 1
        Protected CurrentPage3 As Integer = 1
        Protected CurrentPage4 As Integer = 1
        Private categoryID As String = ""

        Protected WithEvents ctlPagingControl As DotNetNuke.UI.WebControls.PagingControl
        Protected WithEvents ctlPagingControl2 As DotNetNuke.UI.WebControls.PagingControl
        Protected WithEvents ctlPagingControl3 As DotNetNuke.UI.WebControls.PagingControl
        Protected WithEvents ctlPagingControl4 As DotNetNuke.UI.WebControls.PagingControl
        Protected WithEvents cmdReturn As System.Web.UI.WebControls.LinkButton

#End Region
#Region "Private Methods"
        Private Sub BindData()
            'Grab a list of all the pending feedback and present to the user in a datagrid.
            Dim TotalRecords As Integer = 0
            Dim oFb As New FeedbackController
            Dim arr As ArrayList = oFb.GetCategoryFeedback(PortalId, categoryID, FeedbackInfo.FeedbackStatusType.StatusPending, CurrentPage, 10)
            If arr.Count > 0 Then
                TotalRecords = CType(arr(0), FeedbackInfo).TotalRecords
            End If
            Me.dgPendingFeedback.DataSource = arr
            Me.dgPendingFeedback.DataBind()
            ctlPagingControl.TotalRecords = TotalRecords
            ctlPagingControl.PageSize = 10
            ctlPagingControl.CurrentPage = CurrentPage
            Dim strQuerystring As String = "Grid=1&ctl=Feedback Moderation&mid=" & ModuleId & "&PageRecords=10"
            ctlPagingControl.QuerystringParams = strQuerystring
            ctlPagingControl.TabID = TabId
           

            Dim arrPrivate As ArrayList = oFb.GetCategoryFeedback(PortalId, categoryID, FeedbackInfo.FeedbackStatusType.StatusPrivate, CurrentPage2, 10)
            Dim TotalRecords2 As Integer = 0
            If arrPrivate.Count > 0 Then
                TotalRecords2 = CType(arrPrivate(0), FeedbackInfo).TotalRecords
            End If
            Me.dgPrivateFeedback.DataSource = arrPrivate
            Me.dgPrivateFeedback.DataBind()
            ctlPagingControl2.TotalRecords = TotalRecords2
            ctlPagingControl2.PageSize = 10
            ctlPagingControl2.CurrentPage = CurrentPage2
            Dim strQuerystring2 As String = "Grid=2&ctl=Feedback Moderation&mid=" & ModuleId & "&PageRecords=10"
            ctlPagingControl2.QuerystringParams = strQuerystring2
            ctlPagingControl2.TabID = TabId

            Dim arrPublic As ArrayList = oFb.GetCategoryFeedback(PortalId, categoryID, FeedbackInfo.FeedbackStatusType.StatusPublic, CurrentPage3, 10)
            Dim TotalRecords3 As Integer = 0
            If arrPublic.Count > 0 Then
                TotalRecords3 = CType(arrPublic(0), FeedbackInfo).TotalRecords
            End If
            Me.dgPublicFeedback.DataSource = arrPublic
            Me.dgPublicFeedback.DataBind()
            ctlPagingControl3.TotalRecords = TotalRecords3
            ctlPagingControl3.PageSize = 10
            ctlPagingControl3.CurrentPage = CurrentPage3
            Dim strQuerystring3 As String = "Grid=3&ctl=Feedback Moderation&mid=" & ModuleId & "&PageRecords=10"
            ctlPagingControl3.QuerystringParams = strQuerystring3
            ctlPagingControl3.TabID = TabId

            Dim arrArchive As ArrayList = oFb.GetCategoryFeedback(PortalId, categoryID, FeedbackInfo.FeedbackStatusType.StatusArchive, CurrentPage4, 10)
            Dim TotalRecords4 As Integer = 0
            If arrArchive.Count > 0 Then
                TotalRecords4 = CType(arrArchive(0), FeedbackInfo).TotalRecords
            End If
            Me.dgArchiveFeedback.DataSource = arrArchive
            Me.dgArchiveFeedback.DataBind()
            ctlPagingControl4.TotalRecords = TotalRecords4
            ctlPagingControl4.PageSize = 10
            ctlPagingControl4.CurrentPage = CurrentPage4
            Dim strQuerystring4 As String = "Grid=4&ctl=Feedback Moderation&mid=" & ModuleId & "&PageRecords=10"
            ctlPagingControl4.QuerystringParams = strQuerystring4
            ctlPagingControl4.TabID = TabId

        End Sub
        Private Sub UpdateFeedbackStatus(ByVal ModuleID As Integer, ByVal FeedbackID As Integer, ByVal status As Integer)
            Dim changeStatus As FeedbackInfo.FeedbackStatusType
            Dim oFb As New FeedbackController

            Select Case status
                Case 1
                    changeStatus = FeedbackInfo.FeedbackStatusType.StatusPrivate
                Case 2
                    changeStatus = FeedbackInfo.FeedbackStatusType.StatusPublic
                Case 3
                    changeStatus = FeedbackInfo.FeedbackStatusType.StatusArchive
                Case 4
                    changeStatus = FeedbackInfo.FeedbackStatusType.StatusDelete
                Case 0
                    changeStatus = FeedbackInfo.FeedbackStatusType.StatusPending
            End Select
            oFb.UpdateFeedbackStatus(ModuleID, FeedbackID, changeStatus)
            'Now redirect the user back to the same page.
            Response.Redirect(EditUrl("", "", "Feedback Moderation"))
        End Sub
#End Region
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
            'Grab the Current page.
            Dim currentGrid As Integer = 1
            If Not Request.Params("Grid") Is Nothing Then
                currentGrid = CType(Request.Params("Grid"), Integer)
            End If
            If Not Request.Params("CurrentPage") Is Nothing Then
                Select Case currentGrid
                    Case 1
                        CurrentPage = CType(Request.Params("CurrentPage"), Integer)
                    Case 2
                        CurrentPage2 = CType(Request.Params("CurrentPage"), Integer)
                    Case 3
                        CurrentPage3 = CType(Request.Params("CurrentPage"), Integer)
                    Case 4
                        CurrentPage4 = CType(Request.Params("CurrentPage"), Integer)
                End Select
            Else
                CurrentPage = 1
                CurrentPage2 = 1
                CurrentPage3 = 1
                CurrentPage4 = 1
            End If
            For Each column As System.Web.UI.WebControls.DataGridColumn In dgPendingFeedback.Columns
                If column.GetType Is GetType(DotNetNuke.UI.WebControls.ImageCommandColumn) Then
                    Dim imageColumn As DotNetNuke.UI.WebControls.ImageCommandColumn = CType(column, DotNetNuke.UI.WebControls.ImageCommandColumn)

                    'Manage Edit Column NavigateURLFormatString
                    If imageColumn.CommandName = "Publish" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusPublic, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    If imageColumn.CommandName = "SetPrivate" Then
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusPrivate, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    If imageColumn.CommandName = "Archive" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusArchive, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    If imageColumn.CommandName = "Delete" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusDelete, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                        imageColumn.OnClickJS = Localization.GetString("DeleteItem")
                    End If
                    'Localize Image Column Text
                    If imageColumn.CommandName <> "" Then
                        imageColumn.Text = Localization.GetString(imageColumn.CommandName, Me.LocalResourceFile)
                    End If
                End If
            Next
            For Each column As System.Web.UI.WebControls.DataGridColumn In dgPrivateFeedback.Columns
                If column.GetType Is GetType(DotNetNuke.UI.WebControls.ImageCommandColumn) Then
                    Dim imageColumn As DotNetNuke.UI.WebControls.ImageCommandColumn = CType(column, DotNetNuke.UI.WebControls.ImageCommandColumn)

                    'Manage Edit Column NavigateURLFormatString
                    If imageColumn.CommandName = "Publish" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusPublic, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    If imageColumn.CommandName = "Archive" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusArchive, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    If imageColumn.CommandName = "Delete" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusDelete, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                        imageColumn.OnClickJS = Localization.GetString("DeleteItem")

                    End If
                    'Localize Image Column Text
                    If imageColumn.CommandName <> "" Then
                        imageColumn.Text = Localization.GetString(imageColumn.CommandName, Me.LocalResourceFile)
                    End If
                End If
            Next

            'Go after the published items
            For Each column As System.Web.UI.WebControls.DataGridColumn In dgPublicFeedback.Columns
                If column.GetType Is GetType(DotNetNuke.UI.WebControls.ImageCommandColumn) Then
                    Dim imageColumn As DotNetNuke.UI.WebControls.ImageCommandColumn = CType(column, DotNetNuke.UI.WebControls.ImageCommandColumn)

                    'Manage Edit Column NavigateURLFormatString
                    If imageColumn.CommandName = "Archive" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusArchive, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    If imageColumn.CommandName = "SetPrivate" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusPrivate, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    If imageColumn.CommandName = "Delete" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusDelete, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                        imageColumn.OnClickJS = Localization.GetString("DeleteItem")

                    End If
                    'Localize Image Column Text
                    If imageColumn.CommandName <> "" Then
                        imageColumn.Text = Localization.GetString(imageColumn.CommandName, Me.LocalResourceFile)
                    End If
                End If
            Next
            'Go after the archived items
            For Each column As System.Web.UI.WebControls.DataGridColumn In dgArchiveFeedback.Columns
                If column.GetType Is GetType(DotNetNuke.UI.WebControls.ImageCommandColumn) Then
                    Dim imageColumn As DotNetNuke.UI.WebControls.ImageCommandColumn = CType(column, DotNetNuke.UI.WebControls.ImageCommandColumn)

                    'Manage Edit Column NavigateURLFormatString
                    If imageColumn.CommandName = "Publish" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusPublic, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    If imageColumn.CommandName = "SetPrivate" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusPrivate, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    If imageColumn.CommandName = "Delete" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Moderation", "ChangeStatus=" & CType(FeedbackInfo.FeedbackStatusType.StatusDelete, String), "FeedbackID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                        imageColumn.OnClickJS = Localization.GetString("DeleteItem")

                    End If
                    'Localize Image Column Text
                    If imageColumn.CommandName <> "" Then
                        imageColumn.Text = Localization.GetString(imageColumn.CommandName, Me.LocalResourceFile)
                    End If
                End If
            Next
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Check security here
            Dim ModSecurity As New Security.ModuleSecurity(ModuleId, TabId)
            If Not ModSecurity.IsAllowedToModeratePosts() Then
                Response.Redirect(AccessDeniedURL(), True)
            End If
            'Show the list of posts which need moderation.
            If Not Request.Params("ChangeStatus") Is Nothing Then
                Dim changeStatus As Integer
                Dim feedbackID As Integer
                changeStatus = CType(Request.Params("ChangeStatus"), Integer)
                feedbackID = CType(Request.Params("FeedbackID"), Integer)
                UpdateFeedbackStatus(ModuleId, feedbackID, changeStatus)
            End If
            'Grab the category ID from the settings - if this exists then use it otherwise load the moderation for all posts.
            categoryID = CType(Settings("Feedback_ModCategory"), String)
            If IsNothing(categoryID) Then
                categoryID = ""
            End If
            'Localize the Headers
            Localization.LocalizeDataGrid(dgPublicFeedback, Definition.SharedResources)
            Localization.LocalizeDataGrid(dgPrivateFeedback, Definition.SharedResources)
            Localization.LocalizeDataGrid(dgArchiveFeedback, Definition.SharedResources)
            Localization.LocalizeDataGrid(dgPendingFeedback, Definition.SharedResources)

            BindData()


        End Sub
        Private Sub cmdReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReturn.Click
            Response.Redirect(NavigateURL())
        End Sub
        Private Sub DeletePost(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPendingFeedback.DeleteCommand, dgArchiveFeedback.DeleteCommand, dgPrivateFeedback.DeleteCommand, dgPublicFeedback.DeleteCommand

            'Get the index of the row to delete
            If IsNumeric(e.CommandArgument) Then
                Dim feedbackID As Integer = Convert.ToInt32(e.CommandArgument)
                Dim oFb As New FeedbackController
                oFb.UpdateFeedbackStatus(ModuleId, feedbackID, FeedbackInfo.FeedbackStatusType.StatusDelete)
                'Now redirect the user back to the same page.
            End If

            Response.Redirect(EditUrl("", "", "Feedback Moderation"))
        End Sub
    End Class

End Namespace
