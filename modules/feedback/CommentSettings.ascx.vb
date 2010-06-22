'
' DotNetNuke® - http://www.dotnetnuke.com
' Copyright (c) 2002-2005
' by Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
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

Namespace DotNetNuke.Modules.Feedback

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' The Settings ModuleSettingsBase is used to manage the settings for the Feedback Module
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[cnurse]	11/11/2004  created
    ''' </history>
    ''' -----------------------------------------------------------------------------
	Public MustInherit Class CommentSettings
		Inherits Entities.Modules.ModuleSettingsBase
	
#Region "Controls"

        Protected WithEvents cboCategory As System.Web.UI.WebControls.DropDownList
        Protected WithEvents checkBoxHideEmail As System.Web.UI.WebControls.CheckBox
        Protected WithEvents checkBoxHideName As System.Web.UI.WebControls.CheckBox
        Protected WithEvents checkBoxHideSubject As System.Web.UI.WebControls.CheckBox
        Protected WithEvents checkHideTelephone As System.Web.UI.WebControls.CheckBox
        Protected WithEvents checkHideOrgName As System.Web.UI.WebControls.CheckBox
#End Region

#Region "Base Method Implementations"

		''' -----------------------------------------------------------------------------
		''' <summary>
		''' LoadSettings loads the settings from the Database and displays them
		''' </summary>
		''' <remarks>
		''' </remarks>
		''' <history>
		''' 	[cnurse]	11/11/2004  created
		''' </history>
		''' -----------------------------------------------------------------------------
		Public Overrides Sub LoadSettings()
			Try
				If (Page.IsPostBack = False) Then
                    'bind the categories from the Lists table
                    Dim oLists As New FeedbackController
                    Dim aList As ArrayList = oLists.GetFeedbackList(False, PortalId, -1, FeedbackList.Type.Category, True)
                    Me.cboCategory.DataSource = aList
                    Me.cboCategory.DataTextField = "Name"
                    Me.cboCategory.DataValueField = "ListID"
                    Me.cboCategory.DataBind()
                    Me.cboCategory.Items.Insert(0, New System.Web.UI.WebControls.ListItem(Localization.GetString("NoneSelected", Definition.SharedResources), ""))
                  
                    Me.cboCategory.SelectedIndex = Me.cboCategory.Items.IndexOf(Me.cboCategory.Items.FindByValue(CType(ModuleSettings("Feedback_ViewCategory"), String)))
                    Me.checkBoxHideEmail.Checked = CType(ModuleSettings("Feedback_HideEmail"), Boolean)
                    Me.checkBoxHideName.Checked = CType(ModuleSettings("Feedback_HideName"), Boolean)
                    Me.checkBoxHideSubject.Checked = CType(ModuleSettings("Feedback_HideSubject"), Boolean)
                    Me.checkHideTelephone.Checked = CType(ModuleSettings("Feedback_HideTelephone"), Boolean)
                    Me.checkHideOrgName.Checked = CType(ModuleSettings("Feedback_HideOrgName"), Boolean)
                End If
			Catch exc As Exception			 'Module failed to load
				ProcessModuleLoadException(Me, exc)
			End Try
		End Sub

		''' -----------------------------------------------------------------------------
		''' <summary>
		''' UpdateSettings saves the modified settings to the Database
		''' </summary>
		''' <remarks>
		''' </remarks>
		''' <history>
		''' 	[cnurse]	11/11/2004  created
		''' </history>
		''' -----------------------------------------------------------------------------
		Public Overrides Sub UpdateSettings()
			Try
				If Page.IsValid Then
					Dim objModules As New Entities.Modules.ModuleController

                    objModules.UpdateModuleSetting(ModuleId, "Feedback_ViewCategory", Me.cboCategory.SelectedItem.Value)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_HideEmail", Me.checkBoxHideEmail.Checked.ToString())
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_HideName", Me.checkBoxHideName.Checked.ToString())
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_HideSubject", Me.checkBoxHideSubject.Checked.ToString())
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_HideTelephone", Me.checkHideTelephone.Checked.ToString())
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_HideOrgName", Me.checkHideOrgName.Checked.ToString())
                End If
			Catch exc As Exception			 'Module failed to load
				ProcessModuleLoadException(Me, exc)
			End Try
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
		End Sub

#End Region


	End Class

End Namespace