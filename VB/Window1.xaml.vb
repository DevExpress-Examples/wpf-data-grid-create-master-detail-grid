Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports DevExpress.Wpf.Grid

Namespace MasterDetailInside

	Partial Public Class Window1
		Inherits Window

		#Region "ExpandedProperty"
		Public Shared ReadOnly ExpandedProperty As DependencyProperty

		Public Shared Sub SetExpanded(ByVal element As DependencyObject, ByVal value As Boolean)
			element.SetValue(ExpandedProperty, value)
		End Sub

		Public Shared Function GetExpanded(ByVal element As DependencyObject) As Boolean
			Return CBool(element.GetValue(ExpandedProperty))
		End Function

		Shared Sub New()
			ExpandedProperty = DependencyProperty.RegisterAttached("Expanded", GetType(Boolean), GetType(Window1), New PropertyMetadata(False))
		End Sub
		#End Region

		#Region "Test data objects"
		Public Class TestRecord
			Public Sub New(ByVal column1 As String, ByVal column2 As TestRecordList2)
				Me.column1_Renamed = column1
				Me.column2_Renamed = column2
			End Sub

			Private column1_Renamed As String
			Public Property Column1() As String
				Get
					Return column1_Renamed
				End Get
				Set(ByVal value As String)
					column1_Renamed = value
				End Set
			End Property

			Private column2_Renamed As TestRecordList2
			Public Property Column2() As Object
				Get
					Return column2_Renamed
				End Get
				Set(ByVal value As Object)
					column2_Renamed = CType(value, TestRecordList2)
				End Set
			End Property

		End Class

		Public Class TestRecordList
			Inherits List(Of TestRecord)

		End Class

		Public Class TestRecord2
			Public Sub New(ByVal column1 As String, ByVal column2 As String)
				Me.column1_Renamed = column1
				Me.column2_Renamed = column2
			End Sub

			Private column1_Renamed As String
			Public Property Column1() As String
				Get
					Return column1_Renamed
				End Get
				Set(ByVal value As String)
					column1_Renamed = value
				End Set
			End Property

			Private column2_Renamed As String
			Public Property Column2() As String
				Get
					Return column2_Renamed
				End Get
				Set(ByVal value As String)
					column2_Renamed = value
				End Set
			End Property
		End Class

		Public Class TestRecordList2
			Inherits List(Of TestRecord2)
			Public Overrides Function ToString() As String
				Return "Detail (Count = " & Count.ToString() & ")"
			End Function
		End Class
		#End Region

		Private recListMain As TestRecordList
		Public Sub New()
			InitializeComponent()

			recListMain = New TestRecordList()

			Dim rnd As New Random()
			For i As Integer = 0 To 49
				Dim recList As New TestRecordList2()
				recListMain.Add(New TestRecord("col 1 row " & i, recList))
				Dim count As Integer = rnd.Next(40) + 10
				For j As Integer = 0 To count - 1
					recList.Add(New TestRecord2("detatil " & i & " col 1 row " & j, "detatil " & i & " col 2 row " & j))
				Next j
			Next i

			grid.DataSource = recListMain
		End Sub

		Private odd As Boolean = True
		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If odd Then
				TryCast(grid.View, TableView).MoveFocusedRow(40)
				odd = False
			Else
				odd = True
				TryCast(grid.View, TableView).MoveFocusedRow(0)
			End If
		End Sub
	End Class


End Namespace
