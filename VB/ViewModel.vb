Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace MasterDetailInside
    Public Class ViewModel

        Private data_Renamed As List(Of ParentTestData)
        Public ReadOnly Property Data() As List(Of ParentTestData)
            Get
                If data_Renamed Is Nothing Then
                    data_Renamed = New List(Of ParentTestData)()
                    For i As Integer = 0 To 99
                        Dim parentTestData As New ParentTestData() With { _
                            .Text = "Master" & i, _
                            .Number = i, _
                            .Data = New List(Of TestData)() _
                        }
                        For j As Integer = 0 To 49
                            parentTestData.Data.Add(New TestData() With { _
                                .Text = "Detail" & j & " Master" & i, _
                                .Number = j, _
                                .Ready = j Mod 2 <> 0 _
                            })
                        Next j
                        data_Renamed.Add(parentTestData)
                    Next i
                End If
                Return data_Renamed
            End Get
        End Property
    End Class

    Public Class TestData
        Public Property Ready() As Boolean
        Public Property Text() As String
        Public Property Number() As Integer
    End Class
    Public Class ParentTestData
        Public Property Text() As String
        Public Property Number() As Integer
        Public Property Data() As List(Of TestData)
    End Class
End Namespace
