Imports Microsoft.VisualBasic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.PivotGrid.Internal

Namespace WpfApplication3
	Public Class TreeViewFieldsPresenterEx
		Inherits TreeViewFieldsPresenter
        Public Shared ReadOnly FilterCriteriaProperty As DependencyProperty = DependencyProperty.Register("FilterCriteria", GetType(String), GetType(TreeViewFieldsPresenterEx), New PropertyMetadata(Nothing, AddressOf FilterCriteriaChanged))

		Private Shared Sub FilterCriteriaChanged(ByVal dependencyObject As DependencyObject, ByVal dependencyPropertyChangedEventArgs As DependencyPropertyChangedEventArgs)
			Dim control = TryCast(dependencyObject, TreeViewFieldsPresenterEx)
			If control Is Nothing Then
				Return
			End If
			control.ApplyFilter()
		End Sub

		Private Sub ApplyFilter()
			If (Not IsLoaded) OrElse Items.Count=0 Then
				Return
			End If

			For Each item As TreeViewItem In Items

				FilterChildNodes(item)
			Next item
		End Sub

		Private Sub FilterChildNodes(ByVal node As TreeViewItem)
			If node.HasItems Then
				Dim visibleNodeCount = node.Items.Cast(Of TreeViewItem)().Select(Function(i) AnonymousMethod1(i)).Where(Function(i) i.Visibility = System.Windows.Visibility.Visible).ToArray()

				If visibleNodeCount.Count() = 0 Then
					node.Visibility = System.Windows.Visibility.Collapsed
				Else
					node.Visibility = System.Windows.Visibility.Visible
				End If
			Else
				Dim header = TryCast(node.Header, TreeViewFieldHeader)
				If header IsNot Nothing Then
					node.Visibility = If(header.DisplayText.ToLower().Contains(FilterCriteria.ToLower()), Visibility.Visible, Visibility.Collapsed)
				End If
			End If
		End Sub
		
		'INSTANT VB TODO TASK: The return type of this anonymous method could not be determined by Instant VB:
		Private Function AnonymousMethod1(ByVal i As Object) As Object
			FilterChildNodes(i)
			Return i
		End Function

		Public Property FilterCriteria() As String
			Get
				Return CStr(GetValue(FilterCriteriaProperty))
			End Get
			Set(ByVal value As String)
				SetValue(FilterCriteriaProperty, value)
			End Set
		End Property

	End Class
End Namespace
