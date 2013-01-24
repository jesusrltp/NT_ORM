Imports Oracle.DataAccess.Client
Namespace RADIISNT.OracleDAL
    Public Class StateDataservice
        Inherits DataServiceBase
        Public Sub New()
        End Sub
        Public Sub New(ByRef txn As IDbTransaction)
            MyBase.New(txn)
        End Sub
#Region "Methods"
        Public Shared Function GetStatesByCountry(ByVal environment As String, ByVal countrycode As String) As DataSet
            Dim V_COUNTRY_CODE As New OracleParameter("V_COUNTRY_CODE", OracleDbType.Varchar2, countrycode, ParameterDirection.Input)
            V_COUNTRY_CODE.Size = 2000
            Dim OUT_STATE As New OracleParameter("OUT_STATE", OracleDbType.RefCursor, ParameterDirection.Output)

            Dim stateDS As New StateDataservice(Nothing)
            Return stateDS.ExecuteDataSet("USP_GET_STATE_LIST", environment, "NTADMIN", "RADIISNT", V_COUNTRY_CODE, OUT_STATE)
        End Function
       
#End Region
    End Class

End Namespace
