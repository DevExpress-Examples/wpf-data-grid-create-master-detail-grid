Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel

Namespace MasterDetailInside

    Public Class ViewModel

        Private _data As ObservableCollection(Of ParentTestData)

        Public ReadOnly Property Data As ObservableCollection(Of ParentTestData)
            Get
                If _data Is Nothing Then
                    _data = New ObservableCollection(Of ParentTestData)()
                    For i As Integer = 0 To 100 - 1
                        Dim parentTestData As ParentTestData = New ParentTestData() With {.Text = "Master" & i, .Number = i, .Data = New ObservableCollection(Of TestData)()}
                        For j As Integer = 0 To 50 - 1
                            parentTestData.Data.Add(New TestData() With {.Text = "Detail" & j & " Master" & i, .Number = j, .Ready = j Mod 2 <> 0})
                        Next

                        _data.Add(parentTestData)
                    Next
                End If

                Return _data
            End Get
        End Property
    End Class

    Public Class TestData
        Inherits BindableBase

        Protected _Ready As Boolean

        Public Property Ready As Boolean
            Get
                Return _Ready
            End Get

            Set(ByVal value As Boolean)
                SetProperty(_Ready, value, "Ready")
            End Set
        End Property

        Protected _Text As String

        Public Property Text As String
            Get
                Return _Text
            End Get

            Set(ByVal value As String)
                SetProperty(_Text, value, "Text")
            End Set
        End Property

        Protected _Number As Integer

        Public Property Number As Integer
            Get
                Return _Number
            End Get

            Set(ByVal value As Integer)
                SetProperty(_Number, value, "Number")
            End Set
        End Property
    End Class

    Public Class ParentTestData
        Inherits BindableBase

        Protected _Text As String

        Public Property Text As String
            Get
                Return _Text
            End Get

            Set(ByVal value As String)
                SetProperty(_Text, value, "Text")
            End Set
        End Property

        Protected _Number As Integer

        Public Property Number As Integer
            Get
                Return _Number
            End Get

            Set(ByVal value As Integer)
                SetProperty(_Number, value, "Number")
            End Set
        End Property

        Protected _Data As ObservableCollection(Of TestData)

        Public Property Data As ObservableCollection(Of TestData)
            Get
                Return _Data
            End Get

            Set(ByVal value As ObservableCollection(Of TestData))
                SetProperty(_Data, value, "Data")
            End Set
        End Property
    End Class
End Namespace
