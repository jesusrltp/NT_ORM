Imports NT_ORM.RADIISNT.OracleDAL
Namespace RADIISNT.BLL
    Public Class States
        Inherits BaseBusinessObjectCollection(Of State)
        'Method to get the list of States by Country
        Public Shared Function GetStatesByCountry(ByVal environment As String, ByVal countrycode As String) As States

            Dim obj As New States
            obj.MapObjects(StateDataservice.GetStatesByCountry(environment, countrycode))
            Return obj
        End Function
    End Class
End Namespace
