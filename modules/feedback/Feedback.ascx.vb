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
Imports DotNetNuke.Security
Imports System.Web

Namespace DotNetNuke.Modules.Feedback

	''' -----------------------------------------------------------------------------
	''' <summary>
	''' The Feedback Class provides the UI for displaying the Feedback
	''' </summary>
	''' <returns></returns>
	''' <remarks>
	''' </remarks>
	''' <history>
	''' 	[cnurse]	9/22/2004	Moved Feedback to a separate Project
	''' </history>
	''' -----------------------------------------------------------------------------
	Public MustInherit Class Feedback
		Inherits Entities.Modules.PortalModuleBase
        Implements Entities.Modules.IActionable
        Implements Entities.Modules.IPortable

#Region "Controls"

        Protected plEmail As UI.UserControls.LabelControl
        Protected pnlFeedbackFormFields As System.Web.UI.WebControls.Panel
        Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents valEmail1 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents valEmail2 As System.Web.UI.WebControls.RegularExpressionValidator
        Protected plName As UI.UserControls.LabelControl
		Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
		Protected plSubject As UI.UserControls.LabelControl
		Protected WithEvents txtSubject As System.Web.UI.WebControls.TextBox
		Protected plBody As UI.UserControls.LabelControl
		Protected WithEvents txtBody As System.Web.UI.WebControls.TextBox
        Protected plCopy As UI.UserControls.LabelControl
        Protected WithEvents chkCopy As System.Web.UI.WebControls.CheckBox
        Protected WithEvents valName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtTelephone As System.Web.UI.WebControls.TextBox
        Protected WithEvents valTelephone As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtOrgName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valOrgName As System.Web.UI.WebControls.RequiredFieldValidator

		'tasks
		Protected WithEvents cmdSend As System.Web.UI.WebControls.LinkButton
		Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
		Protected WithEvents trCopy As System.Web.UI.HtmlControls.HtmlTableRow
		Protected WithEvents trCategory As System.Web.UI.HtmlControls.HtmlTableRow
		Protected WithEvents cboCategory As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboSubject As System.Web.UI.WebControls.DropDownList
        Protected WithEvents trSubject As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents trSubject2 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents trCaptcha1 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents trCaptcha2 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents ctlCaptcha As DotNetNuke.UI.WebControls.CaptchaControl
        Protected WithEvents trOrgName As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents trTelephone As System.Web.UI.HtmlControls.HtmlTableRow

#End Region
#Region "Private Members"
        Private sendCopy As Boolean = False
        Private optOut As Boolean = False
        Private useCaptcha As Boolean = False
        Private requireNameField As Boolean = False
        Private requireTelephoneField As Boolean = False
        Private requireOrgNameField As Boolean = False
        Private telephoneFieldVisible As Boolean = False
        Private orgNameFieldVisible As Boolean = False
        Private requiredEmailField As Boolean = False
#End Region

#Region "Public Methods"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' GetUser fills the Email/Name fields if a user is logged in
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/22/2004	Moved Feedback to a separate Project
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub GetUser()

            If Request.IsAuthenticated Then

                Dim objUsers As New Entities.Users.UserController

                Dim objUser As Entities.Users.UserInfo = objUsers.GetUser(PortalId, UserInfo.UserID)
                If Not objUser Is Nothing Then
                    txtEmail.Text = objUser.Membership.Email.ToString
                    txtName.Text = objUser.Profile.FullName.ToString
                    txtTelephone.Text = objUser.Profile.Telephone

                End If
            End If

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' InitializeForm sets the form up
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/22/2004	Moved Feedback to a separate Project
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub InitializeForm()
            Try
                txtEmail.Text = ""
                txtName.Text = ""
                txtSubject.Text = ""
                txtBody.Text = ""
                chkCopy.Checked = True
                pnlFeedbackFormFields.Visible = True
                cmdCancel.Visible = False
                GetUser()
            Catch exc As Exception           'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

#Region "Event Handlers"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Page_Load runs when the control is loaded
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/22/2004	Moved Feedback to a separate Project
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'New setting to turn on captcha - these need to be outside the postback 
                If Not IsNothing(Settings("Feedback_UseCaptcha")) Then
                    useCaptcha = CType(Settings("Feedback_UseCaptcha"), Boolean)
                End If
                'Check whether the name field is required.
                If Not IsNothing(Settings("Feedback_RequireName")) Then
                    requireNameField = CType(Settings("Feedback_RequireName"), Boolean)
                End If
                If Not IsNothing(Settings("Feedback_RequireTelephone")) Then
                    requireTelephoneField = CType(Settings("Feedback_RequireTelephone"), Boolean)
                End If
                If Not IsNothing(Settings("Feedback_RequireOrgName")) Then
                    requireOrgNameField = CType(Settings("Feedback_RequireOrgName"), Boolean)
                End If
                If Not IsNothing(Settings("Feedback_OrgNameHidden")) Then
                    orgNameFieldVisible = Not CType(Settings("Feedback_OrgNameHidden"), Boolean)
                End If
                If Not IsNothing(Settings("Feedback_TelephoneHidden")) Then
                    telephoneFieldVisible = Not CType(Settings("Feedback_TelephoneHidden"), Boolean)
                End If
                If Not IsNothing(Settings("Feedback_RequireEmail")) Then
                    requiredEmailField = CType(Settings("Feedback_RequireEmail"), Boolean)
                End If
                'Turn on or off the required field 
                trOrgName.Visible = orgNameFieldVisible
                trTelephone.Visible = telephoneFieldVisible
                valName.Enabled = (orgNameFieldVisible And requireNameField)
                valTelephone.Enabled = (telephoneFieldVisible And requireTelephoneField)
                valOrgName.Enabled = requireOrgNameField
                valEmail1.Enabled = requiredEmailField

                trCaptcha1.Visible = useCaptcha
                trCaptcha2.Visible = useCaptcha
                If useCaptcha Then
                    ctlCaptcha.ErrorMessage = Localization.GetString("InvalidCaptcha", Me.LocalResourceFile)
                    ctlCaptcha.Text = Localization.GetString("CaptchaText", Me.LocalResourceFile)
                End If
                If Not Page.IsPostBack Then
                    InitializeForm()
                    Dim rows As String = CType(Settings("Feedback_Rows"), String)
                    Dim width As String = CType(Settings("Feedback_Width"), String)
                    If rows <> String.Empty Then
                        txtBody.Rows = Integer.Parse(rows)
                    End If
                    If IsNothing(width) Then
                        width = ""
                    End If
                    If width <> String.Empty And Not width.Contains("%") Then
                        txtEmail.Width = System.Web.UI.WebControls.Unit.Parse(width)
                        txtName.Width = System.Web.UI.WebControls.Unit.Parse(width)
                        txtSubject.Width = System.Web.UI.WebControls.Unit.Parse(width)
                        txtBody.Width = System.Web.UI.WebControls.Unit.Parse(width)
                        cboCategory.Width = System.Web.UI.WebControls.Unit.Parse(width)
                        cboSubject.Width = System.Web.UI.WebControls.Unit.Parse(width)
                    ElseIf width <> String.Empty And width.Contains("%") Then
                        txtEmail.Width = System.Web.UI.WebControls.Unit.Percentage(Convert.ToDouble(width.Replace("%", "")))
                        txtName.Width = System.Web.UI.WebControls.Unit.Percentage(Convert.ToDouble(width.Replace("%", "")))
                        txtSubject.Width = System.Web.UI.WebControls.Unit.Percentage(Convert.ToDouble(width.Replace("%", "")))
                        txtBody.Width = System.Web.UI.WebControls.Unit.Percentage(Convert.ToDouble(width.Replace("%", "")))
                        cboCategory.Width = System.Web.UI.WebControls.Unit.Percentage(Convert.ToDouble(width.Replace("%", "")))
                        cboSubject.Width = System.Web.UI.WebControls.Unit.Percentage(Convert.ToDouble(width.Replace("%", "")))
                    End If



                    '<SM=bind the categories from the Feedback Lists table
                    Dim oLists As New FeedbackController
                    Dim aList As ArrayList = oLists.GetFeedbackList(False, PortalId, -1, FeedbackList.Type.Category, True)
                    Me.cboCategory.DataSource = aList
                    Me.cboCategory.DataTextField = "Name"
                    Me.cboCategory.DataValueField = "ListID"
                    Me.cboCategory.DataBind()
                    Dim Category As String = CType(Settings("Feedback_Category"), String)
                    Dim CategorySelect As Boolean = CType(Settings("Feedback_CategorySelect"), Boolean)
                    Dim Subject As String = CType(Settings("Feedback_Subject"), String)
                    Dim SubjectEdit As String = CType(Settings("Feedback_SubjectEdit"), String)
                    sendCopy = CType(Settings("Feedback_SendCopy"), Boolean)
                    optOut = CType(Settings("Feedback_OptOut"), Boolean)

                    'Set both rows to false and then show one based on whether the values from the settings are correct.
                    trSubject.Visible = False
                    trSubject2.Visible = False
                    If Not IsNothing(SubjectEdit) Then
                        Select Case SubjectEdit.ToString().ToUpper()
                            Case "FALSE"
                                'included for legacy support.
                                'Don't do anything here since we've already set it to false.
                            Case "TRUE"
                                'included for legacy support.
                                trSubject2.Visible = True
                            Case "1"
                                'Show the dropdown list of subjects
                                trSubject.Visible = True
                                Dim subjectList As ArrayList = oLists.GetFeedbackList(False, PortalId, -1, FeedbackList.Type.Subject, True)
                                Me.cboSubject.DataSource = subjectList
                                Me.cboSubject.DataTextField = "Name"
                                Me.cboSubject.DataValueField = "ListValue"
                                Me.cboSubject.DataBind()

                            Case "2"
                                'show the text box for subject
                                trSubject2.Visible = True
                            Case "3"
                                'We want to hide the subject row in general - don't do anything here.
                        End Select
                    End If


                    'If the administrator has chosen to allow the user to optout then make the trCopy row visible
                    If optOut Then
                        'If sendCopy AndAlso optOut Then
                        Me.trCopy.Visible = True
                    Else
                        Me.trCopy.Visible = False
                    End If
                    Me.chkCopy.Checked = sendCopy
                    Me.trCategory.Visible = CategorySelect


                End If

            Catch exc As Exception           'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Public Function IsEmail(ByVal Email As String, ByVal portalid As Integer) As Boolean
            Dim pattern As String = CStr(Entities.Users.UserController.GetUserSettings(portalid)("Security_EmailValidation"))
            Return System.Text.RegularExpressions.Regex.Match(Email, pattern).Success
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' cmdCancel_Click runs when the cancel button is clicked
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/22/2004	Updated to reflect design changes for Help, 508 support
        '''                       and localisation
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Try

                'InitializeForm()
                'lblMessage.Text = ""
                'Redirect to the front same page.
                Response.Redirect(NavigateURL(TabId))
            Catch exc As Exception           'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' cmdSend_Click runs when the send button is clicked
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/22/2004	Updated to reflect design changes for Help, 508 support
        '''                       and localisation
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub cmdSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSend.Click
            'To Handle Firefox users.
            If Not Page.IsValid Then
                Exit Sub
            End If
            If (useCaptcha And ctlCaptcha.IsValid) OrElse (Not useCaptcha) Then

                Try
                    Dim sendAsync As Boolean = False
                    If Not IsNothing(Settings("Feedback_Async")) Then
                        sendAsync = CType(Settings("Feedback_Async"), Boolean)
                    End If

                    Dim objPortalSecurity As New DotNetNuke.Security.PortalSecurity
                    Dim strBody As String = objPortalSecurity.InputFilter(txtBody.Text, _
                                            PortalSecurity.FilterFlag.NoScripting And _
                                            PortalSecurity.FilterFlag.NoSQL )
                    sendCopy = CType(Settings("Feedback_SendCopy"), Boolean)
                    optOut = CType(Settings("Feedback_OptOut"), Boolean)
                    Dim Moderated As Boolean = CType(Settings("Feedback_Moderated"), Boolean)
                    'Dim Notify As Boolean = CType(Settings("notify"), Boolean)
                    Dim Category As String = CType(Settings("Feedback_Category"), String)
                    Dim CategorySelect As Boolean = CType(Settings("Feedback_CategorySelect"), Boolean)
                    Dim feedback_subject As String = CType(Settings("Feedback_Subject"), String)

                    If (CategorySelect AndAlso Me.cboCategory.SelectedValue <> "") Then
                        Category = CType(Me.cboCategory.SelectedItem.Value, String)
                    End If
                    'Grab the value of the send to here. If it's blank then assume that the Administrator wants the emails
                    'to be sent to the Portal Administrator.
                    Dim strSendTo As String = CType(Settings("Feedback_SendTo"), String)
                    If strSendTo = "" Then
                        strSendTo = PortalSettings.Email
                    End If
                    'Grab the send from. If it's blank then assume user will provide values. otherwise replace the user's email with this one.
                    Dim strSendFrom As String = CType(Settings("Feedback_SendFrom"), String)



                    Dim oLists As New FeedbackController
                    If trCategory.Visible And CType(Settings("Feedback_CategoryAsSendTo"), Boolean) Then
                        Dim categoryList As ArrayList = oLists.GetFeedbackList(False, PortalId, -1, FeedbackList.Type.Category, True)
                        If categoryList.Count > 0 Then
                            Dim categoryvalue As String = ""
                            For Each item As FeedbackList In categoryList
                                If item.ListID = Integer.Parse(cboCategory.SelectedValue) Then
                                    categoryvalue = item.ListValue
                                    Exit For
                                End If
                            Next
                            If IsEmail(categoryvalue, PortalId) Then strSendTo = categoryvalue
                        End If
                    End If

                    Dim oFeedback As New FeedbackInfo
                    oFeedback.PortalID = PortalId
                    oFeedback.CreatedByName = objPortalSecurity.InputFilter(txtName.Text, PortalSecurity.FilterFlag.NoScripting And _
                                            PortalSecurity.FilterFlag.NoMarkup)
                    oFeedback.CreatedByEmail = objPortalSecurity.InputFilter(txtEmail.Text, PortalSecurity.FilterFlag.NoScripting And _
                                            PortalSecurity.FilterFlag.NoMarkup)

                    oFeedback.Telephone = objPortalSecurity.InputFilter(txtTelephone.Text, PortalSecurity.FilterFlag.NoScripting And _
                                           PortalSecurity.FilterFlag.NoMarkup)

                    oFeedback.OrgName = objPortalSecurity.InputFilter(txtOrgName.Text, PortalSecurity.FilterFlag.NoScripting And _
                                           PortalSecurity.FilterFlag.NoMarkup)
                    oFeedback.ModuleID = ModuleId
                    oFeedback.CategoryID = Category
                    oFeedback.Message = strBody
                    'Append the name of the submitter in the message being generated.
                    'If Not String.IsNullOrEmpty(oFeedback.CreatedByName) Then
                    '    oFeedback.Message = oFeedback.Message + " " + Localization.GetString("SubmittedBy", Me.LocalResourceFile) + " " + oFeedback.CreatedByName
                    'End If
                    'Check whether we're getting the subject from the dropdownlist or the text box.
                    If trSubject.Visible Then
                        'grab it from the drop down list.
                        oFeedback.Subject = Me.cboSubject.SelectedValue
                    ElseIf trSubject2.Visible Then
                        'grab it from the text box.
                        oFeedback.Subject = objPortalSecurity.InputFilter(txtSubject.Text, _
                                            PortalSecurity.FilterFlag.NoScripting And _
                                            PortalSecurity.FilterFlag.NoMarkup)

                    Else
                        'The admin might have chosen a subject but not made it visible.
                        If Not String.IsNullOrEmpty(feedback_subject) Then
                            'Grab the subject value and not the id.
                            Dim feedbackController As New FeedbackController()
                            Dim arryFeedbackItem As ArrayList = feedbackController.GetFeedbackList(True, PortalId, Convert.ToInt32(feedback_subject), FeedbackList.Type.Subject, False)
                            If (arryFeedbackItem.Count > 0) Then
                                Dim objFeedbackItem As FeedbackList = CType(arryFeedbackItem(0), FeedbackList)
                                oFeedback.Subject = objFeedbackItem.ListValue
                            End If
                        Else
                            oFeedback.Subject = ""
                        End If

                    End If

                    'If the Module is moderated then flag it appropriately.
                    If Moderated Then
                        oFeedback.Status = FeedbackInfo.FeedbackStatusType.StatusPending
                    Else
                        'approve automatically
                        oFeedback.Status = FeedbackInfo.FeedbackStatusType.StatusPublic
                    End If


                    'Now we try to save the feedback in the feedback table.
                    'If the status is pending then send an email to the Administrator asking him to log in and
                    'approve the message. In all other cases send the email directly to user if requested.
                    Try
                        'Only do this if there is an email address that the user has entered - this is to prevent
                        'users from clicking on the Send button repeatedly.
                        If txtEmail.Text <> "" Then
                            Dim objFeedbackController As New FeedbackController
                            objFeedbackController.CreateFeedback(oFeedback)
                            'If sendCopy is checked then assume that we have to send a copy to the user.
                            'If the user opts out then don't send.

                            'Create a copy of the email object
                            Dim objFeedbackEmail As New FeedbackEmail
                            If Not String.IsNullOrEmpty(strSendFrom) Then
                                objFeedbackEmail.SendFromEmail = strSendFrom
                            Else
                                objFeedbackEmail.SendFromEmail = PortalSettings.Email
                            End If
                            objFeedbackEmail.SendToEmail = oFeedback.CreatedByEmail
                            objFeedbackEmail.Subject = oFeedback.Subject
                            objFeedbackEmail.Message = oFeedback.Message

                            If sendCopy Then
                                'Check whether the user has checked or unchecked the option.
                                If chkCopy.Checked Then
                                    'User wants a copy of the feedback that was just submitted. -Send it as an email from the site to the user.
                                    If sendAsync Then
                                        Dim objThread As New System.Threading.Thread(AddressOf objFeedbackEmail.SendEmail)
                                        objThread.Start()
                                    Else
                                        objFeedbackEmail.SendEmail()
                                    End If
                                ElseIf Not optOut Then
                                    'User is not given the option of opting out - so still send the email.
                                    'User wants a copy of the feedback that was just submitted. -Send it as an email from the site to the user.
                                    If sendAsync Then
                                        Dim objThread As New System.Threading.Thread(AddressOf objFeedbackEmail.SendEmail)
                                        objThread.Start()
                                    Else
                                        objFeedbackEmail.SendEmail()
                                    End If
                                End If
                            Else
                                'the admin may have chosen not to choose sendcopy but due to optout the chkCopy is visible
                                If optOut And chkCopy.Checked Then
                                    'User wants a copy of the feedback that was just submitted. -Send it as an email from the site to the user.
                                    If sendAsync Then
                                        Dim objThread As New System.Threading.Thread(AddressOf objFeedbackEmail.SendEmail)
                                        objThread.Start()
                                    Else
                                        objFeedbackEmail.SendEmail()
                                    End If
                                End If
                            End If

                            'Send a copy of the feedback to whatever address has been setup for the send to.
                            objFeedbackEmail = New FeedbackEmail
                            objFeedbackEmail.ReplyToEmail = oFeedback.CreatedByEmail

                            If Not String.IsNullOrEmpty(strSendFrom) Then
                                objFeedbackEmail.SendFromEmail = strSendFrom
                            Else
                                objFeedbackEmail.SendFromEmail = oFeedback.CreatedByEmail
                            End If
                            objFeedbackEmail.SendToEmail = strSendTo
                            objFeedbackEmail.Subject = oFeedback.Subject
                            objFeedbackEmail.Message = oFeedback.Message
                            If sendAsync Then
                                Dim objThread As New System.Threading.Thread(AddressOf objFeedbackEmail.SendEmail)
                                objThread.Start()
                            Else
                                objFeedbackEmail.SendEmail()
                            End If
                            'Now send a message to the Administrator if this is a moderated Feedback Module and there are posts that need to be moderated.
                            If oFeedback.Status = FeedbackInfo.FeedbackStatusType.StatusPending Then
                                Dim strChangePendingSubmission As String = Localization.GetString("MessagePending", Me.LocalResourceFile)
                                'Grab the link for the moderation page.
                                Dim strModerateLink As String = "<a href='" & EditUrl("", "", "Feedback Moderation") & "'>" & Localization.GetString("Moderate", Me.LocalResourceFile) & "</a>"
                                strChangePendingSubmission += vbCrLf & strModerateLink
                                objFeedbackEmail = New FeedbackEmail
                                objFeedbackEmail.SendFromEmail = PortalSettings.Email
                                objFeedbackEmail.SendToEmail = strSendTo
                                objFeedbackEmail.Subject = oFeedback.Subject
                                objFeedbackEmail.Message = strChangePendingSubmission
                                If sendAsync Then
                                    Dim objThread As New System.Threading.Thread(AddressOf objFeedbackEmail.SendEmail)
                                    objThread.Start()
                                Else
                                    objFeedbackEmail.SendEmail()
                                End If
                            End If
                            'Display a message and let the user know that his message was sent
                            lblMessage.Text = Localization.GetString("MessageSent", Me.LocalResourceFile)
                            'Hide the rest of the form fields.
                             InitializeForm()
                            pnlFeedbackFormFields.Visible = False
                            cmdCancel.Visible = True
                        End If
                    Catch ex As Exception
                        ProcessModuleLoadException(Me, ex)
                    End Try
                Catch exc As Exception           'Module failed to load
                    ProcessModuleLoadException(Me, exc)
                End Try
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
            ' base module properties
            MyBase.HelpURL = "http://www.dotnetnuke.com/" & glbDefaultPage & "?tabid=787"

        End Sub

#End Region
#Region "Optional Interfaces"

        Public ReadOnly Property ModuleActions() As Entities.Modules.Actions.ModuleActionCollection Implements Entities.Modules.IActionable.ModuleActions
            Get
                Dim Actions As New Entities.Modules.Actions.ModuleActionCollection
                Dim ModSecurity As New Security.ModuleSecurity(ModuleId, TabId)
                'check whether we have permission to moderate posts.
                Try
                    If ModSecurity.IsAllowedToModeratePosts Then 'user is allowed to moderate posts
                        'Actions.Add(GetNextActionID, Localization.GetString(Entities.Modules.Actions.ModuleActionType.AddContent, LocalResourceFile), Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl(), False, SecurityAccessLevel.View, True, False)
                        Actions.Add(GetNextActionID, DotNetNuke.Services.Localization.Localization.GetString(Entities.Modules.Actions.ModuleActionType.ContentOptions, LocalResourceFile), Entities.Modules.Actions.ModuleActionType.ContentOptions, "", "", EditUrl("", "", "Feedback Moderation"), False, DotNetNuke.Security.SecurityAccessLevel.View, True, False)
                    End If
                    If ModSecurity.IsAllowedToManageLists Then
                        Actions.Add(GetNextActionID, DotNetNuke.Services.Localization.Localization.GetString(Entities.Modules.Actions.ModuleActionType.EditContent, LocalResourceFile), Entities.Modules.Actions.ModuleActionType.EditContent, "", "", EditUrl("", "", "Feedback Lists"), False, DotNetNuke.Security.SecurityAccessLevel.View, True, False)
                    End If
                Catch
                    ' This try/catch is to avoid loosing control about your current Feedback module
                End Try
                 Return Actions
            End Get
        End Property
        Public Function ExportModule(ByVal ModuleID As Integer) As String Implements Entities.Modules.IPortable.ExportModule
            ' included as a stub only so that the core knows this module Implements Entities.Modules.IPortable
            ExportModule = Nothing
        End Function
        Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
            ' included as a stub only so that the core knows this module Implements Entities.Modules.IPortable
        End Sub


#End Region

    End Class

End Namespace
