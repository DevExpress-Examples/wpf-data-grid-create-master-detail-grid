Imports DevExpress.Mvvm
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Namespace MasterDetailInside

    Public Class ParentDataItem
        Inherits BindableBase

        Public Property Text As String
            Get
                Return GetValue(Of String)()
            End Get

            Set(ByVal value As String)
                SetValue(value)
            End Set
        End Property

        Public Property Number As Integer
            Get
                Return GetValue(Of Integer)()
            End Get

            Set(ByVal value As Integer)
                SetValue(value)
            End Set
        End Property

        Public Property Data As ObservableCollection(Of DataItem)
            Get
                Return GetValue(Of ObservableCollection(Of DataItem))()
            End Get

            Set(ByVal value As ObservableCollection(Of DataItem))
                SetValue(value)
            End Set
        End Property
    End Class

    Public Class DataItem
        Inherits BindableBase

        Public Property Ready As Boolean
            Get
                Return GetValue(Of Boolean)()
            End Get

            Set(ByVal value As Boolean)
                SetValue(value)
            End Set
        End Property

        Public Property Text As String
            Get
                Return GetValue(Of String)()
            End Get

            Set(ByVal value As String)
                SetValue(value)
            End Set
        End Property

        Public Property Number As Integer
            Get
                Return GetValue(Of Integer)()
            End Get

            Set(ByVal value As Integer)
                SetValue(value)
            End Set
        End Property
    End Class

    Public Class ViewModel

        Public Property Data As ObservableCollection(Of ParentDataItem)

        Public Sub New()
            Data = New ObservableCollection(Of ParentDataItem)(GetData())
        End Sub

        Private Shared Iterator Function GetData() As IEnumerable(Of ParentDataItem)
            For i As Integer = 0 To 100 - 1
                Dim parentTestData = New ParentDataItem() With {.Text = "Master" & i, .Number = i, .Data = New ObservableCollection(Of DataItem)()}
                For j As Integer = 0 To 50 - 1
                    parentTestData.Data.Add(New DataItem() With {.Text = "Detail" & j & " Master" & i, .Number = j, .Ready = j Mod 2 <> 0})
                Next

                Yield parentTestData
            Next
        End Function
    End Class
End Namespace
