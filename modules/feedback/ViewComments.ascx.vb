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
	Public MustInherit Class ViewComments
		Inherits DotNetNuke.Entities.Modules.PortalModuleBase
		Protected CurrentPage As Integer = -1
		Protected TotalPages As Integer = -1
        Protected WithEvents lblAuthor As System.Web.UI.WebControls.Label
        Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
        Protected WithEvents lblCategory As System.Web.UI.WebControls.Label
        Protected WithEvents lblDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblFeedbackID As System.Web.UI.WebControls.Label
        Protected WithEvents lblSubject As System.Web.UI.WebControls.Label
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents ddlRecordsPerPage As System.Web.UI.WebControls.DropDownList
		Protected WithEvents dlComments As System.Web.UI.WebControls.DataList
		Protected WithEvents pnlModuleContent As System.Web.UI.WebControls.Panel
        Protected WithEvents ctlPagingControl As DotNetNuke.UI.WebControls.PagingControl
      
#Region " Web Form Designer Generated Code "

		'This call is required by the Web Form Designer.
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub

		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: This method call is required by the Web Form Designer
			'Do not modify it using the code editor.
			InitializeComponent()

		End Sub

#End Region

		Public Sub Page_Load(ByVal Source As System.Object, ByVal E As System.EventArgs) Handles MyBase.Load
			If Not Request.QueryString("CurrentPage") Is Nothing Then
				CurrentPage = CType(Request.QueryString("CurrentPage"), Integer)
			Else
				CurrentPage = 1
			End If

            If Not Page.IsPostBack Then

                If Not Request.QueryString("PageRecords") Is Nothing Then
                    ddlRecordsPerPage.SelectedValue = Request.QueryString("PageRecords")
                End If
                'Possible enhancements here include more variation in the display of the comments within the grid.
                BindData()

            End If


        End Sub

		Sub BindData()

			Dim PageSize As Integer = Convert.ToInt32(ddlRecordsPerPage.SelectedItem.Value)
			Dim oFb As New FeedbackController
			Dim TotalRecords As Integer = 0

            Dim Category As String = ""
            If Not Settings("Feedback_ViewCategory") Is Nothing Then
                Category = CType(Settings("Feedback_ViewCategory"), String)
            End If
            If IsNothing(Category) Then
                Category = ""
            End If

           
            Dim arr As ArrayList = oFb.GetCategoryFeedback(PortalId, Category, FeedbackInfo.FeedbackStatusType.StatusPublic, CurrentPage, PageSize)
			If arr.Count > 0 Then
				TotalRecords = CType(arr(0), FeedbackInfo).TotalRecords
			End If



			Me.dlComments.DataSource = arr
			Me.dlComments.DataBind()
            

			ctlPagingControl.TotalRecords = TotalRecords
			ctlPagingControl.PageSize = PageSize
			ctlPagingControl.CurrentPage = CurrentPage
            Dim strQuerystring As String = ""
			If ddlRecordsPerPage.SelectedIndex <> 0 Then
				strQuerystring = "PageRecords=" & ddlRecordsPerPage.SelectedValue
			End If

			ctlPagingControl.QuerystringParams = strQuerystring
			ctlPagingControl.TabID = TabId

		End Sub

		Private Sub ddlRecordsPerPage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlRecordsPerPage.SelectedIndexChanged
			CurrentPage = 1
			BindData()
        End Sub

        Private Sub dlComments_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlComments.ItemDataBound
            'Dim hideEmail As Boolean = False
            Dim hideName As Boolean = False
            Dim hideSubject As Boolean = False
            'If Not Settings("Feedback_HideEmail") Is Nothing Then
            '    hideEmail = CType(Settings("Feedback_HideEmail"), Boolean)
            'End If
            If Not Settings("Feedback_HideName") Is Nothing Then
                hideName = CType(Settings("Feedback_HideName"), Boolean)
            End If
            If Not Settings("Feedback_HideSubject") Is Nothing Then
                hideSubject = CType(Settings("Feedback_HideSubject"), Boolean)
            End If
            If e.Item.ItemType = Web.UI.WebControls.ListItemType.Item Or e.Item.ItemType = Web.UI.WebControls.ListItemType.AlternatingItem Then
                'If hideEmail Then
                '    e.Item.FindControl("lblEmail").Visible = False
                'End If
                If hideName Then
                    e.Item.FindControl("lblAuthor").Visible = False
                End If
                If hideSubject Then
                    e.Item.FindControl("lblSubject").Visible = False
                End If
            End If
            'set default value
            Dim lblEmail As System.Web.UI.WebControls.Label
            lblEmail = CType(e.Item.FindControl("lblEmail"), System.Web.UI.WebControls.Label)
            If Not lblEmail Is Nothing Then
                If String.IsNullOrEmpty(lblEmail.Text) Then
                    lblEmail.Text = "无"
                End If
            End If
            Dim lblOrgName As System.Web.UI.WebControls.Label
            lblOrgName = CType(e.Item.FindControl("lblOrgName"), System.Web.UI.WebControls.Label)
            If Not lblOrgName Is Nothing Then
                If String.IsNullOrEmpty(lblOrgName.Text) Then
                    lblOrgName.Text = "无"
                End If
            End If
            Dim lblTelephone As System.Web.UI.WebControls.Label
            lblTelephone = CType(e.Item.FindControl("lblTelephone"), System.Web.UI.WebControls.Label)
            If Not lblTelephone Is Nothing Then
                If String.IsNullOrEmpty(lblTelephone.Text) Then
                    lblTelephone.Text = "无"
                End If
            End If
        End Sub
        
    End Class
End Namespace
