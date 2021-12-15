Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel

Namespace MasterDetailInside

    Public Class ViewModel

        Private dataField As ObservableCollection(Of ParentTestData)

        Public ReadOnly Property Data As ObservableCollection(Of ParentTestData)
            Get
                If dataField Is Nothing Then
                    dataField = New ObservableCollection(Of ParentTestData)()
                    For i As Integer = 0 To 100 - 1
                        Dim parentTestData As ParentTestData = New ParentTestData() With {.Text = "Master" & i, .Number = i, .Data = New ObservableCollection(Of TestData)()}
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
        Inherits BindableBase

        Public Property Ready As Boolean
            Get
                Return GetProperty(Function() Me.Ready)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() Ready, value)
            End Set
        End Property

        Public Property Text As String
            Get
                Return GetProperty(Function() Me.Text)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() Text, value)
            End Set
        End Property

        Public Property Number As Integer
            Get
                Return GetProperty(Function() Me.Number)
            End Get

            Set(ByVal value As Integer)
                SetProperty(Function() Number, value)
            End Set
        End Property
    End Class

    Public Class ParentTestData
        Inherits BindableBase

        Public Property Text As String
            Get
                Return GetProperty(Function() Me.Text)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() Text, value)
            End Set
        End Property

        Public Property Number As Integer
            Get
                Return GetProperty(Function() Me.Number)
            End Get

            Set(ByVal value As Integer)
                SetProperty(Function() Number, value)
            End Set
        End Property

        Public Property Data As ObservableCollection(Of TestData)
            Get
                Return GetProperty(Function() Me.Data)
            End Get

            Set(ByVal value As ObservableCollection(Of TestData))
                SetProperty(Function() Data, value)
            End Set
        End Property
    End Class
End Namespace
