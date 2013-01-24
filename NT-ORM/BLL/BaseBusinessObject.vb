Namespace RADIISNT.BLL
    <Serializable()> _
    Public MustInherit Class BaseBusinessObject

        '//////////////////////////////////////////////////////////////////////////////
        Public Overridable Function MapData(ByVal ds As DataSet) As Boolean
            Try

                If Not ds Is Nothing And ds.Tables.Count > 0 And ds.Tables(0).Rows.Count > 0 Then
                    Return MapData(ds.Tables(0))
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function
        '//////////////////////////////////////////////////////////////////////////////
        Public Overridable Function MapData(ByVal dt As DataTable) As Boolean
            If Not dt Is Nothing And dt.Rows.Count > 0 Then
                Return MapData(dt.Rows(0))
            Else
                Return False
            End If
        End Function
        '//////////////////////////////////////////////////////////////////////////////
        Public Overridable Function MapData(ByVal row As DataRow) As Boolean
            'You can put common data mapping items here (e.g. create date, modified date, etc)
            Return True
        End Function
#Region "Get Functions"
        '//////////////////////////////////////////////////////////////////////////////
        Protected Shared Function GetInt(ByVal row As DataRow, ByVal columnName As String) As Integer
            Return IIf(Not row(columnName) Is DBNull.Value, Convert.ToInt32(row(columnName)), Constants.NullInt)
        End Function

        '//////////////////////////////////////////////////////////////////////////////
        Protected Shared Function GetDateTime(ByVal row As DataRow, ByVal columnName As String) As DateTime
            Return IIf(Not row(columnName) Is DBNull.Value, Convert.ToDateTime(row(columnName)), Constants.NullDateTime)
        End Function

        '//////////////////////////////////////////////////////////////////////////////
        Protected Shared Function GetDecimal(ByVal row As DataRow, ByVal columnName As String) As Decimal
            Return IIf(Not row(columnName) Is DBNull.Value, Convert.ToDecimal(row(columnName)), Constants.NullDecimal)
        End Function


        '//////////////////////////////////////////////////////////////////////////////
        Protected Shared Function GetBool(ByVal row As DataRow, ByVal columnName As String) As Boolean
            Return IIf(Not row(columnName) Is DBNull.Value, Convert.ToBoolean(row(columnName)), False)
        End Function

        '//////////////////////////////////////////////////////////////////////////////
        Protected Shared Function GetString(ByVal row As DataRow, ByVal columnName As String) As String
            Return IIf(Not row(columnName) Is DBNull.Value, Convert.ToString(row(columnName)), Constants.NullString)
        End Function

        '//////////////////////////////////////////////////////////////////////////////
        Protected Shared Function GetDouble(ByVal row As DataRow, ByVal columnName As String) As Double
            Return IIf(Not row(columnName) Is DBNull.Value, Convert.ToDouble(row(columnName)), Constants.NullDouble)
        End Function

        '//////////////////////////////////////////////////////////////////////////////
        Protected Shared Function GetFloat(ByVal row As DataRow, ByVal columnName As String) As Single
            Return IIf(Not row(columnName) Is DBNull.Value, Convert.ToSingle(row(columnName)), Constants.NullFloat)
        End Function

        '//////////////////////////////////////////////////////////////////////////////
        Protected Shared Function GetGuid(ByVal row As DataRow, ByVal columnName As String) As Guid
            Return IIf(Not row(columnName) Is DBNull.Value, Convert.ToString(row(columnName)), Constants.NullGuid)
        End Function

        '//////////////////////////////////////////////////////////////////////////////
        Protected Shared Function GetLong(ByVal row As DataRow, ByVal columnName As String) As Long
            Return IIf(Not row(columnName) Is DBNull.Value, CLng(row(columnName)), Constants.NullLong)
        End Function
#End Region
    End Class
End Namespace

