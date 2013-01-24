Imports System.ComponentModel
Namespace RADIISNT.BLL
    Public Class State
        Inherits BaseBusinessObject
        Private _statecode As String
        Public Property StateCode() As String
            Get
                Return _statecode
            End Get
            Set(ByVal value As String)
                _statecode = value
            End Set
        End Property
        Private _statename As String
        Public Property StateName() As String
            Get
                Return _statename
            End Get
            Set(ByVal value As String)
                _statename = value
            End Set
        End Property

#Region "Methods"
        Public Function GetRuleViolations() As List(Of RuleViolation)
            If String.IsNullOrEmpty(StateCode) Then
                GetRuleViolations.Add(New RuleViolation("State Code is Required", "StateCode"))
            End If
        End Function
        Public Overrides Function MapData(ByVal row As DataRow) As Boolean
            _statecode = row("STATE_CODE")
            _statename = row("STATE_NAME")
            Return MyBase.MapData(row)
        End Function
#End Region
    End Class

End Namespace