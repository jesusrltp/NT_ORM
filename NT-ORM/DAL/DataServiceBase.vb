
Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports System.Configuration
Namespace RADIISNT.OracleDAL
    Public Class DataServiceBase
        '////////////////////////////////////////////////////////////////////////
        '// Fields
        '////////////////////////////////////////////////////////////////////////
        Private _isOwner As Boolean = False    'True if service owns the transaction        
        Private _txn As OracleTransaction     'Reference to the current transaction
        'these two are to generate the oracle connection string 
        '////////////////////////////////////////////////////////////////////////
        '// Properties 
        '////////////////////////////////////////////////////////////////////////
        Public Property Txn() As IDbTransaction
            Get
                Return _txn
            End Get
            Set(ByVal Value As IDbTransaction)
                _txn = Value
            End Set
        End Property

        '////////////////////////////////////////////////////////////////////////
        '// Constructors
        '////////////////////////////////////////////////////////////////////////
        Public Sub New()
        End Sub
        Public Sub New(ByVal txn As IDbTransaction)
            If txn Is Nothing Then
                _isOwner = True
            Else
                _txn = txn
                _isOwner = False
            End If
        End Sub
        '////////////////////////////////////////////////////////////////////////
        '// Connection and Transaction Methods
        '////////////////////////////////////////////////////////////////////////
        Protected Shared Function GetConnectionString(ByVal environment As String, ByVal oradatabase As String, ByVal orauser As String) As String
            Select Case environment
                Case "development"
                    Return "Data Source=DBNAME;User Id=userid;Password=password;"
                Case "qa"
                    Return "Data Source=DBNAME;User Id=userid;Password=password;"
                Case "production"
                    Return "Data Source=DBNAME;User Id=userid;Password=password;"
            End Select
        End Function

        Public Shared Function BeginTransaction(ByVal environment As String, ByVal oradatabase As String, ByVal orauser As String) As IDbTransaction
            Dim txnConnection As New OracleConnection(GetConnectionString(environment, oradatabase, orauser))
            txnConnection.Open()
            Return txnConnection.BeginTransaction()
        End Function
        '///////////
        '///Excecute Command Methods
        '//////////
        Protected Function ExecuteCommand(ByRef cmd As OracleCommand, ByVal environment As String, ByVal oradatabase As String, ByVal orauser As String) As DataSet
            Dim cnx As OracleConnection = Nothing
            Dim ds As New DataSet
            Dim da As New OracleDataAdapter
            Try
                da.SelectCommand = cmd
                '//Determine the transaction owner and process accordingly
                If _isOwner Then
                    cnx = New OracleConnection(GetConnectionString(environment, oradatabase, orauser))
                    cmd.Connection = cnx
                    cnx.Open()
                Else
                    cmd.Connection = _txn.Connection
                    'cmd.Transaction = _txn
                End If
                '//Fill the dataset
                da.Fill(ds)
            Catch ex As Exception
                Dim err As String = ex.Message
            Finally

                If Not da Is Nothing Then da.Dispose()
                If Not cmd Is Nothing Then
                    Do While cmd.Parameters.Count > 0
                        cmd.Parameters.RemoveAt(0)
                    Loop
                    cmd.Dispose()
                End If
                If _isOwner Then
                    cnx.Dispose() '//Implicitly calls cnx.Close()
                End If
            End Try
            Return ds

        End Function

        '///////////
        '//End of Excecute commad methods
        '///////////



        '////////////////////////////////////////////////////////////////////////
        '// ExecuteDataSet Methods
        '////////////////////////////////////////////////////////////////////////
        Protected Function ExecuteDataSet(ByVal procName As String, ByVal environment As String, ByVal oradatabase As String, ByVal orauser As String, ByVal ParamArray procParams() As IDataParameter) As DataSet
            Dim cmd As OracleCommand
            Return ExecuteDataSet(cmd, environment, oradatabase, orauser, procName, procParams)
        End Function

        Protected Function ExecuteDataSet(ByRef cmd As OracleCommand, ByVal environment As String, ByVal oradatabase As String, ByVal orauser As String, ByVal procName As String, ByVal procParams() As IDataParameter) As DataSet
            Dim cnx As OracleConnection = Nothing
            Dim ds As New DataSet
            Dim da As New OracleDataAdapter
            cmd = Nothing

            Try
                '//Setup command object
                cmd = New OracleCommand(procName)
                cmd.CommandType = CommandType.StoredProcedure
                If Not procParams Is Nothing Then
                    Dim index As Integer
                    For index = 0 To procParams.Length - 1
                        cmd.Parameters.Add(procParams(index))
                    Next
                End If
                da.SelectCommand = cmd
                '//Determine the transaction owner and process accordingly
                If _isOwner Then
                    cnx = New OracleConnection(GetConnectionString(environment, oradatabase, orauser))
                    cmd.Connection = cnx
                    cnx.Open()
                Else
                    cmd.Connection = _txn.Connection
                    'cmd.Transaction = _txn
                End If
                '//Fill the dataset
                da.Fill(ds)
            Catch ex As Exception
                Dim err As String = ex.Message
            Finally

                If Not da Is Nothing Then da.Dispose()
                If Not cmd Is Nothing Then
                    Do While cmd.Parameters.Count > 0
                        cmd.Parameters.RemoveAt(0)
                    Loop
                    cmd.Dispose()
                End If
                If _isOwner Then
                    cnx.Dispose() '//Implicitly calls cnx.Close()
                End If
            End Try
            Return ds

        End Function

        ' ////////////////////////////////////////////////////////////////////////
        '// ExecuteNonQuery Methods
        '////////////////////////////////////////////////////////////////////////
        Protected Sub ExecuteNonQuery(ByVal procName As String, ByVal environment As String, ByVal oradatabase As String, ByVal orauser As String, ByVal ParamArray procParams() As IDataParameter)
            Dim cmd As OracleCommand
            ExecuteNonQuery(cmd, environment, oradatabase, orauser, procName, procParams)
        End Sub
        Protected Sub ExecuteNonQuery(ByRef cmd As OracleCommand, ByVal environment As String, ByVal oradatabase As String, ByVal orauser As String, ByVal procName As String, ByVal procParams() As IDataParameter)
            '//Method variables
            Dim cnx As OracleConnection = Nothing
            cmd = Nothing  '//Avoids "Use of unassigned variable" compiler error
            Try
                '//Setup command object
                cmd = New OracleCommand(procName)
                cmd.CommandType = CommandType.StoredProcedure
                Dim index As Integer
                For index = 0 To procParams.Length - 1
                    cmd.Parameters.Add(procParams(index))
                Next

                '//Determine the transaction owner and process accordingly
                If (_isOwner) Then
                    cnx = New OracleConnection(GetConnectionString(environment, oradatabase, orauser))
                    cmd.Connection = cnx
                    cnx.Open()
                Else
                    cmd.Connection = _txn.Connection
                End If
                'OracleCommandBuilder.DeriveParameters(cmd)
                'For index = 0 To procParams.Length - 1
                '    'cmd.Parameters.Add(procParams(index))
                '    cmd.Parameters(CType(procParams(index), OracleParameter).ParameterName).Value = CType(procParams(index), OracleParameter).Value
                'Next
                '//Execute the command
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                If (_isOwner) Then cnx.Dispose() '//Implicitly calls cnx.Close()
                If Not cmd Is Nothing Then
                    Do While cmd.Parameters.Count > 0
                        cmd.Parameters.RemoveAt(0)
                    Loop
                    cmd.Dispose()
                End If
            End Try
        End Sub

    End Class
End Namespace

