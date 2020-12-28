Imports DevExpress.Mvvm
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text

Namespace MasterDetailInside
	Public Class ViewModel
'INSTANT VB NOTE: The field data was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private data_Conflict As ObservableCollection(Of ParentTestData)
		Public ReadOnly Property Data() As ObservableCollection(Of ParentTestData)
			Get
				If data_Conflict Is Nothing Then
					data_Conflict = New ObservableCollection(Of ParentTestData)()
					For i As Integer = 0 To 99
						Dim parentTestData As New ParentTestData() With {
							.Text = "Master" & i,
							.Number = i,
							.Data = New ObservableCollection(Of TestData)()
						}
						For j As Integer = 0 To 49
							parentTestData.Data.Add(New TestData() With {
								.Text = "Detail" & j & " Master" & i,
								.Number = j,
								.Ready = j Mod 2 <> 0
							})
						Next j
						data_Conflict.Add(parentTestData)
					Next i
				End If
				Return data_Conflict
			End Get
		End Property
	End Class

	Public Class TestData
		Inherits BindableBase

		Public Property Ready() As Boolean
			Get
				Return GetProperty(Function() Ready)
			End Get
			Set(ByVal value As Boolean)
				SetProperty(Function() Ready, value)
			End Set
		End Property
		Public Property Text() As String
			Get
				Return GetProperty(Function() Text)
			End Get
			Set(ByVal value As String)
				SetProperty(Function() Text, value)
			End Set
		End Property
		Public Property Number() As Integer
			Get
				Return GetProperty(Function() Number)
			End Get
			Set(ByVal value As Integer)
				SetProperty(Function() Number, value)
			End Set
		End Property
	End Class

	Public Class ParentTestData
		Inherits BindableBase

		Public Property Text() As String
			Get
				Return GetProperty(Function() Text)
			End Get
			Set(ByVal value As String)
				SetProperty(Function() Text, value)
			End Set
		End Property
		Public Property Number() As Integer
			Get
				Return GetProperty(Function() Number)
			End Get
			Set(ByVal value As Integer)
				SetProperty(Function() Number, value)
			End Set
		End Property
		Public Property Data() As ObservableCollection(Of TestData)
			Get
				Return GetProperty(Function() Data)
			End Get
			Set(ByVal value As ObservableCollection(Of TestData))
				SetProperty(Function() Data, value)
			End Set
		End Property
	End Class
End Namespace
