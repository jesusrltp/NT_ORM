Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Namespace RADIISNT.BLL
    ' A strongly typed collection of BaseBusinessObject.
    <Serializable()> _
    Public MustInherit Class BaseBusinessObjectCollection(Of T As {BaseBusinessObject, New})
        Inherits List(Of T)

        ' Add an BaseBusinessObject.
        Public Overloads Sub Add(ByVal value As BaseBusinessObject)
            Me.Add(value)
        End Sub
        ' Return True if the collection contains this BaseBusinessObject.
        Public Overloads Function Contains(ByVal value As BaseBusinessObject) As Boolean
            Return Me.Contains(value)
        End Function
        ' Return this BaseBusinessObject's index.
        Public Overloads Function IndexOf(ByVal value As BaseBusinessObject) As Integer
            Return Me.IndexOf(value)
        End Function
        ' Insert a new BaseBusinessObject.
        Public Overloads Sub Insert(ByVal index As Integer, ByVal value As BaseBusinessObject)
            Me.Insert(index, value)
        End Sub

        ' Return the BaseBusinessObject at this position.
        Default Public Overloads ReadOnly Property Item(ByVal index As Integer) As BaseBusinessObject
            Get
                Return DirectCast(Me.Item(index), BaseBusinessObject)
            End Get
        End Property

        ' Remove an BaseBusinessObject.
        Public Overloads Sub Remove(ByVal value As BaseBusinessObject)
            Me.Remove(value)
        End Sub

        '////////////////////////////////////////////////////////////////////////////////////////////
        Public Function MapObjects(ByVal ds As DataSet) As Boolean
            If Not ds Is Nothing And ds.Tables.Count > 0 Then
                Return MapObjects(ds.Tables(0))
            Else
                Return False
            End If
        End Function
        '////////////////////////////////////////////////////////////////////////////////////////////
        Public Function MapObjects(ByVal dt As DataTable) As Boolean
            Clear()
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Dim obj As New T
                obj.MapData(dt.Rows(i))
                Me.Add(obj)
            Next
            Return True
        End Function
    End Class
End Namespace
