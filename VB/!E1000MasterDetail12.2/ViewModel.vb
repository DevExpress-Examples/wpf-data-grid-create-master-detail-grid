Imports Microsoft.VisualBasic
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
						Dim parentTestData As New ParentTestData() With {.Text = "Master" & i, .Number = i, .Data = New List(Of TestData)()}
						For j As Integer = 0 To 49
							parentTestData.Data.Add(New TestData() With {.Text = "Detail" & j & " Master" & i, .Number = j, .Ready = j Mod 2 <> 0})
						Next j
						data_Renamed.Add(parentTestData)
					Next i
				End If
				Return data_Renamed
			End Get
		End Property
	End Class

	Public Class TestData
		Private privateReady As Boolean
		Public Property Ready() As Boolean
			Get
				Return privateReady
			End Get
			Set(ByVal value As Boolean)
				privateReady = value
			End Set
		End Property
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
	End Class
	Public Class ParentTestData
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
		Private privateData As List(Of TestData)
		Public Property Data() As List(Of TestData)
			Get
				Return privateData
			End Get
			Set(ByVal value As List(Of TestData))
				privateData = value
			End Set
		End Property
	End Class
End Namespace
