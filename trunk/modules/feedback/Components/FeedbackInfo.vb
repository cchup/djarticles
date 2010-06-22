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
    Public Class FeedbackInfo
        Enum FeedbackStatusType
            StatusPending
            StatusPrivate
            StatusPublic
            StatusArchive
            StatusDelete
        End Enum

#Region "Private Members"

        Private m_feedbackID As Integer
        Private m_status As FeedbackStatusType
        'Private m_feedBackGUID As String
        Private m_dateCreated As Date
        Private m_createdByEmail As String
        Private m_approvedBy As Integer
        Private m_moduleID As Integer
        Private m_categoryID As String
        Private m_totalRecords As Integer
        Private m_message As String
        Private m_subject As String
        Private m_PortalID As Integer
        Private m_createdByName As String
        Private m_CategoryValue As String
        Private m_Telephone As String
        Private m_OrgName As String
#End Region

#Region "Public Properties"

        Public Property FeedbackID() As Integer
            Get
                Return m_feedbackID
            End Get
            Set(ByVal Value As Integer)
                m_feedbackID = Value
            End Set
        End Property

        Public Property Status() As FeedbackStatusType
            Get
                Return m_status
            End Get
            Set(ByVal Value As FeedbackStatusType)
                m_status = Value
            End Set
        End Property

        'Public Property FeedBackGUID() As String
        '    Get
        '        Return m_feedBackGUID
        '    End Get
        '    Set(ByVal Value As String)
        '        m_feedBackGUID = Value
        '    End Set
        'End Property

        Public Property DateCreated() As Date
            Get
                Return m_dateCreated
            End Get
            Set(ByVal Value As Date)
                m_dateCreated = Value
            End Set
        End Property

        Public Property CreatedByEmail() As String
            Get
                Return m_createdByEmail
            End Get
            Set(ByVal Value As String)
                m_createdByEmail = Value
            End Set
        End Property

        Public Property ApprovedBy() As Integer
            Get
                Return m_approvedBy
            End Get
            Set(ByVal Value As Integer)
                m_approvedBy = Value
            End Set
        End Property

        Public Property ModuleID() As Integer
            Get
                Return m_moduleID
            End Get
            Set(ByVal Value As Integer)
                m_moduleID = Value
            End Set
        End Property

        Public Property CategoryID() As String
            Get
                Return m_categoryID
            End Get
            Set(ByVal Value As String)
                m_categoryID = Value
            End Set
        End Property
        Public Property CategoryValue() As String
            Get
                Return m_CategoryValue
            End Get
            Set(ByVal Value As String)
                m_CategoryValue = Value
            End Set
        End Property

        Public Property TotalRecords() As Integer
            Get
                Return m_totalRecords
            End Get
            Set(ByVal Value As Integer)
                m_totalRecords = Value
            End Set
        End Property

        Public Property Message() As String
            Get
                Return m_message
            End Get
            Set(ByVal Value As String)
                m_message = Value
            End Set
        End Property

        Public Property Subject() As String
            Get
                Return m_subject
            End Get
            Set(ByVal Value As String)
                m_subject = Value
            End Set
        End Property
        Public Property PortalID() As Integer
            Get
                Return m_PortalID
            End Get
            Set(ByVal value As Integer)
                m_PortalID = value
            End Set
        End Property
        Public Property CreatedByName() As String
            Get
                Return m_createdByName
            End Get
            Set(ByVal value As String)
                m_createdByName = value
            End Set
        End Property
        Public Property Telephone() As String
            Get
                Return m_Telephone
            End Get
            Set(ByVal value As String)
                m_Telephone = value
            End Set
        End Property
        Public Property OrgName() As String
            Get
                Return m_OrgName
            End Get
            Set(ByVal value As String)
                m_OrgName = value
            End Set
        End Property
#End Region

    End Class
    Public Class FeedbackList
        Enum Type As Integer
            Category = 1
            Subject = 2
        End Enum
        Enum Active
            No
            Yes
        End Enum
#Region "Private Members"
        Private m_ListID As Integer
        Private m_PortalID As Integer
        Private m_ListType As Type
        Private m_IsActive As Active
        Private m_Name As String
        Private m_ListValue As String
        Private m_SortOrder As Integer
#End Region
#Region "Public Properties"
        Public Property ListID() As Integer
            Get
                Return m_ListID
            End Get
            Set(ByVal value As Integer)
                m_ListID = value
            End Set
        End Property
        Public Property PortalID() As Integer
            Get
                Return m_PortalID
            End Get
            Set(ByVal value As Integer)
                m_PortalID = value
            End Set
        End Property
        Public Property ListType() As Type
            Get
                Return m_ListType
            End Get
            Set(ByVal value As Type)
                Select Case Convert.ToInt32(value)
                    Case 1
                        m_ListType = Type.Category
                    Case 2
                        m_ListType = Type.Subject
                End Select
            End Set
        End Property
        Public Property IsActive() As Active
            Get
                Return m_IsActive
            End Get
            Set(ByVal value As Active)
                Select Case Convert.ToInt32(value)
                    Case 0
                        m_IsActive = Active.No
                    Case Else
                        m_IsActive = Active.Yes
                End Select
            End Set
        End Property
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property
        Public Property ListValue() As String
            Get
                Return m_ListValue
            End Get
            Set(ByVal value As String)
                m_ListValue = value
            End Set
        End Property
        Public Property SortOrder() As Integer
            Get
                Return m_SortOrder
            End Get
            Set(ByVal value As Integer)
                m_SortOrder = value
            End Set
        End Property
#End Region
    End Class
  
    Public Class FeedbackEmail
        Private _sendToEmail As String = ""
        Private _sendFromEmail As String = ""
        Private _subject As String = ""
        Private _message As String = ""
        Private _replyToEmail As String = ""
        Public Property SendToEmail() As String
            Get
                Return _sendToEmail
            End Get
            Set(ByVal value As String)
                _sendToEmail = value
            End Set
        End Property
        Public Property SendFromEmail() As String
            Get
                Return _sendFromEmail
            End Get
            Set(ByVal value As String)
                _sendFromEmail = value
            End Set
        End Property
        Public Property Subject() As String
            Get
                Return _subject
            End Get
            Set(ByVal value As String)
                _subject = value
            End Set
        End Property
        Public Property Message() As String
            Get
                Return _message
            End Get
            Set(ByVal value As String)
                _message = value
            End Set
        End Property
        Public Property ReplyToEmail() As String
            Get
                Return _replyToEmail
            End Get
            Set(ByVal value As String)
                _replyToEmail = value
            End Set
        End Property
        Public Sub SendEmail()
            If Not String.IsNullOrEmpty(ReplyToEmail) Then
                Dim SMTPEnableSSL As Boolean = False
                If Convert.ToString(Common.Globals.HostSettings("SMTPEnableSSL")) = "Y" Then
                    SMTPEnableSSL = True
                End If
                SendMail(SendFromEmail, SendToEmail, "", "", ReplyToEmail, DotNetNuke.Services.Mail.MailPriority.Normal, Subject, Services.Mail.MailFormat.Text, System.Text.Encoding.UTF8, _message, "", "", "", "", SMTPEnableSSL)
            Else
                Services.Mail.Mail.SendMail(SendFromEmail, SendToEmail, "", Subject, _message, "", "", "", "", "", "")
            End If
        End Sub


        Private Shared Function SendMail(ByVal MailFrom As String, ByVal MailTo As String, _
            ByVal Cc As String, ByVal Bcc As String, ByVal ReplyTo As String, _
            ByVal Priority As DotNetNuke.Services.Mail.MailPriority, ByVal Subject As String, _
            ByVal BodyFormat As DotNetNuke.Services.Mail.MailFormat, ByVal BodyEncoding As System.Text.Encoding, ByVal Body As String, _
             ByVal SMTPServer As String, ByVal SMTPAuthentication As String, _
            ByVal SMTPUsername As String, ByVal SMTPPassword As String, ByVal SMTPEnableSSL As Boolean) As String

            SendMail = ""

            ' SMTP server configuration
            If SMTPServer = "" Then
                If Convert.ToString(Common.Globals.HostSettings("SMTPServer")) <> "" Then
                    SMTPServer = Convert.ToString(Common.Globals.HostSettings("SMTPServer"))
                End If
            End If
            If SMTPAuthentication = "" Then
                If Convert.ToString(Common.Globals.HostSettings("SMTPAuthentication")) <> "" Then
                    SMTPAuthentication = Convert.ToString(Common.Globals.HostSettings("SMTPAuthentication"))
                End If
            End If
            If SMTPUsername = "" Then
                If Convert.ToString(Common.Globals.HostSettings("SMTPUsername")) <> "" Then
                    SMTPUsername = Convert.ToString(Common.Globals.HostSettings("SMTPUsername"))
                End If
            End If
            If SMTPPassword = "" Then
                If Convert.ToString(Common.Globals.HostSettings("SMTPPassword")) <> "" Then
                    SMTPPassword = Convert.ToString(Common.Globals.HostSettings("SMTPPassword"))
                End If
            End If

            ' translate semi-colon delimiters to commas as ASP.NET 2.0 does not support semi-colons
            MailTo = MailTo.Replace(";", ",")
            Cc = Cc.Replace(";", ",")
            Bcc = Bcc.Replace(";", ",")

            Dim objMail As System.Net.Mail.MailMessage = Nothing
            Try
                objMail = New System.Net.Mail.MailMessage(MailFrom, MailTo)
                If Cc <> "" Then
                    objMail.CC.Add(Cc)
                End If
                If Bcc <> "" Then
                    objMail.Bcc.Add(Bcc)
                End If
                If ReplyTo <> String.Empty Then objMail.ReplyTo = New System.Net.Mail.MailAddress(ReplyTo)
                objMail.Priority = CType(Priority, Net.Mail.MailPriority)
                objMail.IsBodyHtml = CBool(IIf(BodyFormat = DotNetNuke.Services.Mail.MailFormat.Html, True, False))

                'For Each myAtt As String In Attachment
                '    If myAtt <> "" Then objMail.Attachments.Add(New Net.Mail.Attachment(myAtt))
                'Next

                ' message
                objMail.SubjectEncoding = BodyEncoding
                objMail.Subject = HtmlUtils.StripWhiteSpace(Subject, True)
                objMail.BodyEncoding = BodyEncoding


                'added support for multipart html messages
                'add text part as alternate view
                'objMail.Body = Body
                Dim PlainView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(ConvertToText(Body), Nothing, "text/plain")
                objMail.AlternateViews.Add(PlainView)

                'if body contains html, add html part
                Dim objDNNMail As New DotNetNuke.Services.Mail.Mail
                If IsHTMLMail(Body) Then
                    Dim HTMLView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(Body, Nothing, "text/html")
                    objMail.AlternateViews.Add(HTMLView)
                End If

            Catch objException As Exception
                ' Problem creating Mail Object
                SendMail = MailTo + ": " + objException.Message
                LogException(objException)
            End Try

            If objMail IsNot Nothing Then

                ' external SMTP server alternate port
                Dim SmtpPort As Integer = Null.NullInteger
                Dim portPos As Integer = SMTPServer.IndexOf(":")
                If portPos > -1 Then
                    SmtpPort = Int32.Parse(SMTPServer.Substring(portPos + 1, SMTPServer.Length - portPos - 1))
                    SMTPServer = SMTPServer.Substring(0, portPos)
                End If

                Dim smtpClient As New Net.Mail.SmtpClient()

                If SMTPServer <> "" Then
                    smtpClient.Host = SMTPServer
                    If SmtpPort > Null.NullInteger Then
                        smtpClient.Port = SmtpPort
                    End If
                    Select Case SMTPAuthentication
                        Case "", "0" ' anonymous
                        Case "1" ' basic
                            If SMTPUsername <> "" And SMTPPassword <> "" Then
                                smtpClient.UseDefaultCredentials = False
                                smtpClient.Credentials = New System.Net.NetworkCredential(SMTPUsername, SMTPPassword)
                            End If
                        Case "2" ' NTLM
                            smtpClient.UseDefaultCredentials = True
                    End Select
                End If
                smtpClient.EnableSsl = SMTPEnableSSL

                Try
                    smtpClient.Send(objMail)
                    SendMail = ""
                Catch objException As Exception
                    ' mail configuration problem
                    If Not IsNothing(objException.InnerException) Then
                        SendMail = String.Concat(objException.Message, ControlChars.CrLf, objException.InnerException.Message)
                        LogException(objException.InnerException)
                    Else
                        SendMail = objException.Message
                        LogException(objException)
                    End If
                Finally
                    objMail.Dispose()
                End Try
            End If

        End Function
        Public Shared Function IsHTMLMail(ByVal Body As String) As Boolean
            Return System.Text.RegularExpressions.Regex.IsMatch(Body, "<[^>]*>")
        End Function

        Public Shared Function ConvertToText(ByVal sHTML As String) As String
            Dim sContent As String = sHTML
            sContent = sContent.Replace("<br />", vbCrLf)
            sContent = sContent.Replace("<br>", vbCrLf)
            sContent = HtmlUtils.FormatText(sContent, True)
            Return HtmlUtils.StripTags(sContent, True)
        End Function
    End Class

    Public Class Definition
        Public Const PathOfModule As String = "/DesktopModules/Feedback/"
        Public Const ModuleFriendlyName As String = "Feedback"
        Public Shared ReadOnly SharedResources As String = "~/" & Definition.PathOfModule & Services.Localization.Localization.LocalResourceDirectory & "/SharedRescources.resx"
    End Class

    Public Class PermissionName
        Public Const ModerateFeedbackPosts As String = "MODERATEPOSTS"
        Public Const ManageFeedbackLists As String = "MANAGELISTS"
        Public Const Code As String = "FEEDBACK_PERMISSION"

    End Class
End Namespace