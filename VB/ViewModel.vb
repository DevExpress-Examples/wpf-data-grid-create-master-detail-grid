Imports System.Collections.Generic

Namespace MasterDetailInside

    Public Class ViewModel

        Private dataField As List(Of ParentTestData)

        Public ReadOnly Property Data As List(Of ParentTestData)
            Get
                If dataField Is Nothing Then
                    dataField = New List(Of ParentTestData)()
                    For i As Integer = 0 To 100 - 1
                        Dim parentTestData As ParentTestData = New ParentTestData() With {.Text = "Master" & i, .Number = i, .Data = New List(Of TestData)()}
                        For j As Integer = 0 To 50 - 1
                            parentTestData.Data.Add(New TestData() With {.Text = "Detail" & j & " Master" & i, .Number = j, .Ready = j Mod 2 <> 0})
                        Next

                        dataField.Add(parentTestData)
                    Next
                End If

                Return dataField
            End Get
        End Property
    End Class

    Public Class TestData

        Public Property Ready As Boolean

        Public Property Text As String

        Public Property Number As Integer
    End Class

    Public Class ParentTestData

        Public Property Text As String

        Public Property Number As Integer

        Public Property Data As List(Of TestData)
    End Class
End Namespace
