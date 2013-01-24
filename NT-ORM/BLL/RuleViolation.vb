Public Class RuleViolation
    Private errmess As String
    Sub New(ByVal errormessage As String)
        errmess = errormessage
    End Sub
    Sub New(ByVal errormessage As String, ByVal propertyname As String)
        errmess = errormessage
        propname = propertyname
    End Sub

    Public Property ErrorMessage() As String
        Get
            Return errmess
        End Get
        Set(ByVal value As String)
            errmess = value
        End Set
    End Property
    Private propname As String
    Public Property PropertyName() As String
        Get
            Return propname
        End Get
        Set(ByVal value As String)
            propname = value
        End Set
    End Property

End Class
