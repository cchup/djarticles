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
Imports System.Web.UI

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
    Partial Public Class Settings
        Inherits Entities.Modules.ModuleSettingsBase

#Region "Controls"

        ' module options
        Protected plSendTo As UI.UserControls.LabelControl
        Protected WithEvents tblFeedbackSettings As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents txtSendFrom As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSendTo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWidth As System.Web.UI.WebControls.TextBox
        Protected WithEvents valSendTo As System.Web.UI.WebControls.RegularExpressionValidator
        Protected WithEvents valWidth As System.Web.UI.WebControls.RegularExpressionValidator
        Protected WithEvents valRows As System.Web.UI.WebControls.RegularExpressionValidator
        Protected WithEvents chkSendCopy As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkOptout As System.Web.UI.WebControls.CheckBox
        Protected WithEvents cboCategory As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboModerationCategory As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkCategory As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkCategoryMailto As System.Web.UI.WebControls.CheckBox
        Protected WithEvents cboSubject As System.Web.UI.WebControls.DropDownList
        Protected WithEvents rbSubject As System.Web.UI.WebControls.RadioButton
        Protected WithEvents rbSubjectListVisible As System.Web.UI.WebControls.RadioButton
        Protected WithEvents rbSubjectHidden As System.Web.UI.WebControls.RadioButton
        Protected WithEvents chkModerated As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkNotify As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkAsync As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkUseCaptcha As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkRequireNameField As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtRows As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblErrorMsg As System.Web.UI.WebControls.Label


        Protected WithEvents chkTelephoneHidden As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkTelephoneRequire As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkOrgNameHidden As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkOrgNameRequire As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkEmailRequire As System.Web.UI.WebControls.CheckBox
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
                    'bind the categories from the Feedback lists table
                    Dim oLists As New FeedbackController
                    Dim categoryList As ArrayList = oLists.GetFeedbackList(False, PortalId, -1, FeedbackList.Type.Category, True)
                    Dim subjectList As ArrayList = oLists.GetFeedbackList(False, PortalId, -1, FeedbackList.Type.Subject, True)

                    Me.cboCategory.DataSource = categoryList
                    Me.cboCategory.DataTextField = "Name"
                    Me.cboCategory.DataValueField = "ListID"
                    Me.cboCategory.DataBind()

                    'Load the moderation category here too
                    Me.cboModerationCategory.DataSource = categoryList
                    Me.cboModerationCategory.DataTextField = "Name"
                    Me.cboModerationCategory.DataValueField = "ListID"
                    Me.cboModerationCategory.DataBind()


                    Me.cboSubject.DataSource = subjectList
                    Me.cboSubject.DataTextField = "Name"
                    Me.cboSubject.DataValueField = "ListValue"
                    Me.cboSubject.DataBind()

                    'Add the defaults
                    Me.cboCategory.Items.Insert(0, New System.Web.UI.WebControls.ListItem(Localization.GetString("NoneSelected", Definition.SharedResources), ""))
                    Me.cboModerationCategory.Items.Insert(0, New System.Web.UI.WebControls.ListItem(Localization.GetString("NoneSelected", Definition.SharedResources), ""))
                    Me.cboSubject.Items.Insert(0, New System.Web.UI.WebControls.ListItem(Localization.GetString("NoneSelected", Definition.SharedResources), ""))

                    'get the settings
                    txtSendFrom.Text = CType(ModuleSettings("Feedback_SendFrom"), String)
                    txtSendTo.Text = CType(ModuleSettings("Feedback_SendTo"), String)
                    txtWidth.Text = CType(ModuleSettings("Feedback_Width"), String)
                    txtRows.Text = CType(ModuleSettings("Feedback_Rows"), String)
                    If Not IsNothing(ModuleSettings("Feedback_SubjectEdit")) Then
                        Select Case ModuleSettings("Feedback_SubjectEdit").ToString().ToUpper()
                            Case "FALSE"
                                'this is for legacy feedback modules
                                rbSubjectHidden.Checked = True
                            Case "TRUE"
                                'this is for legacy feedback modules
                                rbSubject.Checked = True
                            Case "1"
                                rbSubjectListVisible.Checked = True
                            Case "2"
                                rbSubject.Checked = True
                            Case "3"
                                rbSubjectHidden.Checked = True
                        End Select
                    Else
                        rbSubject.Checked = True
                    End If

                    Me.chkSendCopy.Checked = CType(ModuleSettings("Feedback_SendCopy"), Boolean)
                    Me.chkOptout.Checked = CType(ModuleSettings("Feedback_OptOut"), Boolean)
                    Me.chkModerated.Checked = CType(ModuleSettings("Feedback_Moderated"), Boolean)
                    Me.chkAsync.Checked = CType(ModuleSettings("Feedback_Async"), Boolean)
                    Me.chkCategoryMailto.Checked = CType(ModuleSettings("Feedback_CategoryAsSendTo"), Boolean)
                    Me.chkCategory.Checked = CType(ModuleSettings("Feedback_CategorySelect"), Boolean)
                    Me.chkUseCaptcha.Checked = CType(ModuleSettings("Feedback_UseCaptcha"), Boolean)
                    Me.chkRequireNameField.Checked = CType(ModuleSettings("Feedback_RequireName"), Boolean)

                    Me.chkTelephoneHidden.Checked = CType(ModuleSettings("Feedback_TelephoneHidden"), Boolean)
                    Me.chkTelephoneRequire.Checked = CType(ModuleSettings("Feedback_RequireTelephone"), Boolean)
                    Me.chkOrgNameHidden.Checked = CType(ModuleSettings("Feedback_OrgNameHidden"), Boolean)
                    Me.chkOrgNameRequire.Checked = CType(ModuleSettings("Feedback_RequireOrgName"), Boolean)
                    Me.chkEmailRequire.Checked = CType(ModuleSettings("Feedback_RequireEmail"), Boolean)


                    Me.cboCategory.SelectedIndex = Me.cboCategory.Items.IndexOf(Me.cboCategory.Items.FindByValue(CType(ModuleSettings("Feedback_Category"), String)))
                    Me.cboModerationCategory.SelectedIndex = Me.cboModerationCategory.Items.IndexOf(Me.cboModerationCategory.Items.FindByValue(CType(ModuleSettings("Feedback_ModCategory"), String)))
                    Me.cboSubject.SelectedIndex = Me.cboSubject.Items.IndexOf(Me.cboSubject.Items.FindByValue(CType(ModuleSettings("Feedback_Subject"), String)))

                   
                    'SM check whether categories have been setup or else disable the checkboxes for subjects and categories.
                    If cboCategory.Items.Count = 1 Then
                        chkCategory.Enabled = False
                        chkCategoryMailto.Enabled = False
                        chkCategory.Checked = False
                        chkCategoryMailto.Checked = False
                    End If

                    'SM do the same thing for subjects.
                    If cboSubject.Items.Count = 1 Then
                        rbSubjectListVisible.Enabled = False
                     End If

                End If
            Catch exc As Exception           'Module failed to load
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
                'Check whether categories have been activated without creating a category item first.
                If (Me.chkCategory.Checked AndAlso Me.cboCategory.SelectedItem.Value = "") Then
                    Me.lblErrorMsg.Text = Localization.GetString("emptyCategoryMsg", Definition.SharedResources)
                    Me.lblErrorMsg.Visible = True
                    Exit Sub
                End If
                If Page.IsValid Then
                    Dim objModules As New Entities.Modules.ModuleController



                    objModules.UpdateModuleSetting(ModuleId, "Feedback_SendFrom", txtSendFrom.Text)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_SendTo", txtSendTo.Text)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_Width", txtWidth.Text)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_Rows", txtRows.Text)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_Subject", Me.cboSubject.SelectedItem.Value)
                    If rbSubjectListVisible.Checked Then
                        objModules.UpdateModuleSetting(ModuleId, "Feedback_SubjectEdit", "1")
                    ElseIf rbSubject.Checked Then
                        objModules.UpdateModuleSetting(ModuleId, "Feedback_SubjectEdit", "2")
                    ElseIf rbSubjectHidden.Checked Then
                        objModules.UpdateModuleSetting(ModuleId, "Feedback_SubjectEdit", "3")
                    End If
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_SendCopy", Me.chkSendCopy.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_OptOut", Me.chkOptout.Checked.ToString)
                    'objModules.UpdateModuleSetting(ModuleId, "Feedback_Notify", Me.chkNotify.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_Moderated", Me.chkModerated.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_Async", Me.chkAsync.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_CategoryAsSendTo", Me.chkCategoryMailto.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_CategorySelect", Me.chkCategory.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_Category", Me.cboCategory.SelectedItem.Value)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_ModCategory", Me.cboModerationCategory.SelectedItem.Value)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_UseCaptcha", Me.chkUseCaptcha.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_RequireName", Me.chkRequireNameField.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_TelephoneHidden", Me.chkTelephoneHidden.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_RequireTelephone", Me.chkTelephoneRequire.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_OrgNameHidden", Me.chkOrgNameHidden.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_RequireOrgName", Me.chkOrgNameRequire.Checked.ToString)
                    objModules.UpdateModuleSetting(ModuleId, "Feedback_RequireEmail", Me.chkEmailRequire.Checked.ToString)
                End If
            Catch exc As Exception    'Module failed to load
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