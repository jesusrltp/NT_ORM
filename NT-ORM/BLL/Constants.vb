Namespace RADIISNT.BLL
    Public NotInheritable Class Constants
        '/// <summary>
        '/// The value used to represent a null DateTime value
        '/// </summary>
        Public Shared ReadOnly Property NullDateTime() As DateTime
            Get
                Return DateTime.MinValue
            End Get
        End Property


        '/// <summary>
        '/// The value used to represent a null decimal value
        '/// </summary>
        Public Shared ReadOnly Property NullDecimal() As Decimal
            Get
                Return Decimal.MinValue
            End Get
        End Property


        '/// <summary>
        '/// The value used to represent a null double value
        '/// </summary>
        Public Shared ReadOnly Property NullDouble() As Double
            Get
                Return Double.MinValue
            End Get
        End Property


        '/// <summary>
        '/// The value used to represent a null Guid value
        '/// </summary>
        Public Shared ReadOnly Property NullGuid() As Guid
            Get
                Return Guid.Empty
            End Get
        End Property

        '/// <summary>
        '/// The value used to represent a null int value
        '/// </summary>
        Public Shared ReadOnly Property NullInt() As Integer
            Get
                Return Integer.MinValue
            End Get
        End Property

        '/// <summary>
        '/// The value used to represent a null long value
        '/// </summary>
        Public Shared ReadOnly Property NullLong() As Long
            Get
                Return Long.MinValue
            End Get
        End Property

        '/// <summary>
        '/// The value used to represent a null float value
        '/// </summary>
        Public Shared ReadOnly Property NullFloat() As Single
            Get
                Return Single.MinValue
            End Get
        End Property

        '/// <summary>
        '/// The value used to represent a null string value
        '/// </summary>
        Public Shared ReadOnly Property NullString() As String
            Get
                Return String.Empty
            End Get
        End Property

        'only for SQL datasources
        '    /// <summary>
        '    /// Maximum DateTime value allowed by SQL Server
        '    /// </summary>
        '    public static DateTime SqlMaxDate = new DateTime(9999, 1, 3, 23, 59, 59);

        '    /// <summary>
        '    /// Minimum DateTime value allowed by SQL Server
        '    /// </summary>
        '    public static DateTime SqlMinDate = new DateTime(1753, 1, 1, 00, 00, 00);
        '}

#Region "Provider Module constants"
        Public Shared ReadOnly Property GoddYearCode() As String
            Get
                Return "C94886"
            End Get
        End Property
#End Region
    End Class
End Namespace
