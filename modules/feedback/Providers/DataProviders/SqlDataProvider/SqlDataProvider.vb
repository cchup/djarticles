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
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace DotNetNuke.Modules.Feedback

	''' -----------------------------------------------------------------------------
	''' <summary>
	''' The SqlDataProvider Class is an SQL Server implementation of the DataProvider Abstract
	''' class that provides the DataLayer for the Feedback Module.
	''' </summary>
    ''' -----------------------------------------------------------------------------
	Public Class SqlDataProvider

		Inherits DataProvider

#Region "Private Members"

		Private Const ProviderType As String = "data"

		Private _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration(ProviderType)
		Private _connectionString As String
		Private _providerPath As String
		Private _objectQualifier As String
		Private _databaseOwner As String

#End Region

#Region "Constructors"

		Public Sub New()

            ' Read the configuration specific information for this provider
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)

            ' Read the attributes for this provider
            'Get Connection string from web.config
            _connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString()

            If _connectionString = "" Then
                ' Use connection string specified in provider
                _connectionString = objProvider.Attributes("connectionString")
            End If

            _providerPath = objProvider.Attributes("providerPath")

            _objectQualifier = objProvider.Attributes("objectQualifier")
            If _objectQualifier <> "" And _objectQualifier.EndsWith("_") = False Then
                _objectQualifier += "_"
            End If

            _databaseOwner = objProvider.Attributes("databaseOwner")
            If _databaseOwner <> "" And _databaseOwner.EndsWith(".") = False Then
                _databaseOwner += "."
            End If
          

		End Sub

#End Region

#Region "Properties"

		Public ReadOnly Property ConnectionString() As String
			Get
				Return _connectionString
			End Get
		End Property

		Public ReadOnly Property ProviderPath() As String
			Get
				Return _providerPath
			End Get
		End Property

		Public ReadOnly Property ObjectQualifier() As String
			Get
				Return _objectQualifier
			End Get
		End Property

		Public ReadOnly Property DatabaseOwner() As String
			Get
				Return _databaseOwner
			End Get
		End Property

#End Region

#Region "Public Methods"

		Private Function GetNull(ByVal Field As Object) As Object
			Return Common.Utilities.Null.GetNull(Field, DBNull.Value)
		End Function

#End Region

        Public Overrides Sub CreateFeedback(ByVal PortalID As Integer, ByVal CategoryID As String, ByVal CreatedByEmail As String, _
  ByVal ModuleID As Integer, ByVal Status As FeedbackInfo.FeedbackStatusType, ByVal Message As String, ByVal Subject As String, ByVal CreatedByName As String, ByVal Telephone As String, ByVal OrgName As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "CreateFeedback", _
            PortalID, GetNull(CategoryID), CreatedByEmail, ModuleID, Status, Message, Subject, CreatedByName, Telephone, OrgName)
        End Sub

		Public Overrides Function GetFeedback(ByVal FeedbackID As Integer) As System.Data.IDataReader
			Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetFeedback", FeedbackID), IDataReader)
		End Function


        Public Overrides Function GetCategoryFeedback(ByVal PortalID As Integer, ByVal CategoryID As String, ByVal Status As FeedbackInfo.FeedbackStatusType, ByVal CurrentPage As Integer, ByVal PageSize As Integer) As System.Data.IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetCategoryFeedback", PortalID, CategoryID, Status, CurrentPage, PageSize), IDataReader)
        End Function

        Public Overrides Sub UpdateFeedbackStatus(ByVal ModuleID As Integer, ByVal FeedbackID As Integer, ByVal Status As FeedbackInfo.FeedbackStatusType)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateFeedbackStatus", ModuleID, FeedbackID, Status)
        End Sub

        Public Overrides Function AddFeedbackList(ByVal PortalID As Integer, ByVal ListType As Integer, ByVal Name As String, ByVal ListValue As String, ByVal IsActive As Boolean) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddFeedbackList", PortalID, ListType, Name, ListValue, IsActive), Integer)
        End Function
        Public Overrides Function GetFeedbackList(ByVal SingleRowOperation As Boolean, ByVal PortalID As Integer, ByVal ListID As Integer, ByVal ListType As Integer, ByVal ActiveOnly As Boolean) As System.Data.IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetFeedbackList", SingleRowOperation, PortalID, ListID, ListType, ActiveOnly), IDataReader)
        End Function
        Public Overrides Sub EditFeedbackList(ByVal IsDeleteOperation As Boolean, ByVal ListID As Integer, ByVal PortalID As Integer, ByVal ListType As Integer, ByVal Name As String, ByVal ListValue As String, ByVal IsActive As Boolean)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "EditFeedbackList", IsDeleteOperation, ListID, PortalID, ListType, Name, ListValue, IsActive)
        End Sub
        Public Overrides Sub ChangeSortOrder(ByVal ListID As Integer, ByVal ListType As Integer, ByVal OldSortNum As Integer, ByVal NewSortNum As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "ChangeSortOrder", ListID, ListType, OldSortNum, NewSortNum)
        End Sub

      
    End Class

End Namespace