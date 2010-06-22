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
Imports DotNetNuke
Imports System.Web
Imports System.Web.UI.WebControls


Namespace DotNetNuke.Modules.Feedback

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' The FeedbackLists Class provides the UI for adding/edit Feedback Lists
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[smehrotra]	01/22/2007	Moved Feedback Lists from Lists table to its own table.
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public MustInherit Class FeedbackLists
        Inherits Entities.Modules.PortalModuleBase
#Region "Controls"
        Protected WithEvents dgItems As System.Web.UI.WebControls.DataGrid
        Protected WithEvents rbListType As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents checkBoxIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtBoxListName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBoxListValue As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtListID As System.Web.UI.WebControls.HiddenField
        Protected WithEvents cmdSaveEntry As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdReturn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents trErrorRow As System.Web.UI.HtmlControls.HtmlTableRow
#End Region
#Region "Private Members"
        Private _currentListType As FeedbackList.Type = FeedbackList.Type.Category
        Private _currentListID As Integer = -1
        Private objFeedbackController As New FeedbackController
#End Region
#Region "Private Methods"
        Private Sub BindData()
            'Used to load the datagrid with possible values based on the list type.
            Dim arryListItems As ArrayList = objFeedbackController.GetFeedbackList(False, PortalId, -1, _currentListType, False)
            'Now bind this to the datagrid.
            dgItems.DataSource = arryListItems
            dgItems.DataBind()

        End Sub
        Private Sub BindListData()
            'Use this to load the values for this list item.
            Dim arryFeedbackItem As ArrayList = objFeedbackController.GetFeedbackList(True, PortalId, _currentListID, FeedbackList.Type.Category, True)
            If arryFeedbackItem.Count > 0 Then
                Dim objFeedbackItem As FeedbackList = CType(arryFeedbackItem(0), FeedbackList)
                txtBoxListValue.Text = objFeedbackItem.ListValue
                txtBoxListName.Text = objFeedbackItem.Name
                checkBoxIsActive.Checked = CType(objFeedbackItem.IsActive, Boolean)
            Else
                'This is not a valid ListItem - reset the values and get out.
                _currentListID = -1
            End If
            txtListID.Value = _currentListID.ToString()
        End Sub
        Private Sub MoveListItems(ByVal Direction As String, ByVal listID As Integer)
            Dim objFeedbackList As FeedbackList = New FeedbackList()
            Dim arryFeedback As ArrayList = objFeedbackController.GetFeedbackList(True, PortalId, listID, FeedbackList.Type.Category, True)
            If arryFeedback.Count > 0 Then
                objFeedbackList = CType(arryFeedback(0), FeedbackList)
            
                Select Case Direction.ToUpper()
                    Case "UP"
                        objFeedbackController.ChangeListSortOrder(objFeedbackList.ListID, objFeedbackList.ListType, objFeedbackList.SortOrder, objFeedbackList.SortOrder - 1)
                    Case "DOWN"
                        objFeedbackController.ChangeListSortOrder(objFeedbackList.ListID, objFeedbackList.ListType, objFeedbackList.SortOrder, objFeedbackList.SortOrder + 1)
                End Select
            End If
            'Now redirect the user back to the current page.
            Response.Redirect(EditUrl("", "", "Feedback Lists", "ListType=" & CType(objFeedbackList.ListType, String)))

        End Sub
#End Region
#Region "Public Methods"

#End Region
#Region "Event Handlers"
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Check security here.
            Dim ModSecurity As New Security.ModuleSecurity(ModuleId, TabId)
            If Not ModSecurity.IsAllowedToManageLists() Then
                Response.Redirect(AccessDeniedURL(), True)
            End If
            'When user comes in, check which item is checked and then load the corresponding lists.
            If Not Page.IsPostBack Then
                'Localize the Headers
                Localization.LocalizeDataGrid(dgItems, Me.LocalResourceFile)

                If Not IsNothing(Request.Params("MoveDirection")) Then
                    Dim direction As String = Request.Params("MoveDirection")
                    Dim listID As Integer = Convert.ToInt32(Request.Params("ListID"))
                    MoveListItems(direction, listID)
                End If
                'Check whether we're passing in a ListID in which case we want to edit it.
                If Not IsNothing(Request.Params("ListID")) Then
                    _currentListID = Convert.ToInt32(Request.Params("ListID"))
                End If
                BindData()
                BindListData()
            End If
        End Sub
        Private Sub cmdSaveEntry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSaveEntry.Click
            'User wants to save a List Item.
            Dim objFeedbackList As FeedbackList = New FeedbackList()
            'Start filling in the values for this object
            Select Case rbListType.SelectedIndex.ToString()
                Case "0"
                    objFeedbackList.ListType = FeedbackList.Type.Category

                Case "1"
                    objFeedbackList.ListType = FeedbackList.Type.Subject
            End Select
            objFeedbackList.ListID = Convert.ToInt32(txtListID.Value)
            objFeedbackList.Name = txtBoxListName.Text
            objFeedbackList.ListValue = txtBoxListValue.Text
            objFeedbackList.PortalID = PortalSettings.PortalId
            objFeedbackList.IsActive = CType(IIf(checkBoxIsActive.Checked, FeedbackList.Active.Yes, FeedbackList.Active.No), FeedbackList.Active)
            'If it's a new one, then save, otherwise edit it.
            If objFeedbackList.ListID = -1 Then
                'Lets do a quick check to see if this item already exists. the db doesn't allow for saving of duplicates but we should
                'display a message to the user too indicating that the entry already exists.
                If Not objFeedbackController.FeedbackListItemExists(objFeedbackList) Then
                    objFeedbackController.AddFeedbackList(objFeedbackList)
                Else
                    trErrorRow.Visible = True
                    Exit Sub
                End If
            Else
                If objFeedbackController.VerifyNoDuplicateFeedbackListItemName(objFeedbackList) Then
                    objFeedbackController.EditFeedbackList(False, objFeedbackList)
                Else
                    trErrorRow.Visible = True
                    Exit Sub
                End If

            End If
            Response.Redirect(EditUrl("", "", "Feedback Lists", "ListType=" & CType(objFeedbackList.ListType, String)))
        End Sub
        Private Sub cmdReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReturn.Click
            Response.Redirect(NavigateURL())
        End Sub
        Private Sub rbListType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbListType.SelectedIndexChanged
            Select Case rbListType.SelectedIndex.ToString()
                Case "0"
                    Response.Redirect(EditUrl("", "", "Feedback Lists", "ListType=1"))
                Case "1"
                    Response.Redirect(EditUrl("", "", "Feedback Lists", "ListType=2"))
            End Select
        End Sub
        Private Sub dgItems_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgItems.DeleteCommand
            'User wants to delete a List Item.
            'Grab the ID and then delete this item from the database.
            Try
                Dim item As System.Web.UI.WebControls.DataGridItem = e.Item
                Dim ListID As Integer = Int32.Parse(e.CommandArgument.ToString)

                Dim arryFeedbackList As ArrayList = objFeedbackController.GetFeedbackList(True, PortalId, ListID, FeedbackList.Type.Category, True)

                If Not arryFeedbackList Is Nothing Then
                    objFeedbackController.EditFeedbackList(True, CType(arryFeedbackList(0), FeedbackList))
                End If
                'Grab the correct List Type so that you can send the user back to the correct page.
                Select Case rbListType.SelectedIndex.ToString()
                    Case "0"
                        _currentListType = FeedbackList.Type.Category

                    Case "1"
                        _currentListType = FeedbackList.Type.Subject
                End Select
                Response.Redirect(EditUrl("", "", "Feedback Lists", "ListType=" & CType(_currentListType, String)))

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try


        End Sub
        Private Sub dgItems_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgItems.ItemDataBound
            Dim totalRows As Integer = 0
            If Not IsNothing(dgItems.DataSource) Then
                totalRows = CType(dgItems.DataSource, ArrayList).Count
            End If
            'Hide the move up for the first item and the move down for the last item.
            Dim item As DataGridItem = e.Item

            If item.ItemType = ListItemType.Item Or _
                    item.ItemType = ListItemType.AlternatingItem Or _
                    item.ItemType = ListItemType.SelectedItem Then

                Dim imgColumnControl As System.Web.UI.Control = item.Controls(0).Controls(0)
                If TypeOf imgColumnControl Is HyperLink Then
                    Dim MoveImage As HyperLink = CType(imgColumnControl, HyperLink)
                    If item.ItemIndex = 0 Then
                        MoveImage.Visible = False
                    End If
                End If
                Dim imgColumnControl2 As System.Web.UI.Control = item.Controls(1).Controls(0)
                If TypeOf imgColumnControl2 Is HyperLink Then
                    Dim MoveImage As HyperLink = CType(imgColumnControl2, HyperLink)
                    If item.ItemIndex = totalRows - 1 Then
                        MoveImage.Visible = False
                    End If
                End If
               
            End If


        End Sub
#End Region
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            If Not IsNothing(Request.Params("ListType")) Then
                Select Case Request.Params("ListType").ToString()
                    Case "1"
                        _currentListType = FeedbackList.Type.Category
                    Case "2"
                        _currentListType = FeedbackList.Type.Subject
                    Case Else
                        'Assume that this is incorrect and set it back to the first one.
                        _currentListType = FeedbackList.Type.Category
                End Select
                rbListType.SelectedIndex = rbListType.Items.IndexOf(rbListType.Items.FindByValue(CType(_currentListType, String)))
            Else
                'Assume it's 1
                _currentListType = FeedbackList.Type.Category
            End If
            For Each column As System.Web.UI.WebControls.DataGridColumn In dgItems.Columns
                If column.GetType Is GetType(DotNetNuke.UI.WebControls.ImageCommandColumn) Then
                    'Manage Delete Confirm JS
                    Dim imageColumn As DotNetNuke.UI.WebControls.ImageCommandColumn = CType(column, DotNetNuke.UI.WebControls.ImageCommandColumn)
                    If imageColumn.CommandName = "Delete" Then
                        imageColumn.OnClickJS = Localization.GetString("DeleteItem")
                    End If
                    'Manage Edit Column NavigateURLFormatString
                    If imageColumn.CommandName = "Edit" Then
                        'The Friendly URL parser does not like non-alphanumeric characters
                        'so first create the format string with a dummy value and then
                        'replace the dummy value with the FormatString place holder
                        Dim formatString As String = EditUrl("", "", "Feedback Lists", "ListType=" & CType(_currentListType, String), "ListID=" & "KEYFIELD")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    If imageColumn.CommandName = "MoveUp" Then
                        Dim formatString As String = EditUrl("", "", "Feedback Lists", "ListType=" & CType(_currentListType, String), "ListID=" & "KEYFIELD", "MoveDirection=Up")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    If imageColumn.CommandName = "MoveDown" Then
                        Dim formatString As String = EditUrl("", "", "Feedback Lists", "ListType=" & CType(_currentListType, String), "ListID=" & "KEYFIELD", "MoveDirection=Down")
                        formatString = formatString.Replace("KEYFIELD", "{0}")
                        imageColumn.NavigateURLFormatString = formatString
                    End If
                    'Localize Image Column Text
                    If imageColumn.CommandName <> "" Then
                        imageColumn.Text = Localization.GetString(imageColumn.CommandName, Me.LocalResourceFile)
                    End If
                End If
            Next
        End Sub

#End Region
    End Class
End Namespace
