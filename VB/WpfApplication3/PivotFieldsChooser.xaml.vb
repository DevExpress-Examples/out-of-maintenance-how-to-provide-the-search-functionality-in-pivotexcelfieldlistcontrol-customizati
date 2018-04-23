Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input

Namespace WpfApplication3
	Partial Public Class PivotFieldsChooser
		Inherits ResourceDictionary
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub ClearIcon_OnMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Dim icon = TryCast(sender, Image)
			If icon Is Nothing Then
				Return
			End If
			Dim grid = icon.FindAncestor(Of Grid)()
			If grid Is Nothing Then
				Return
			End If
			Dim box = grid.FindVisualChild(Of TextBox)()
			If box Is Nothing Then
				Return
			End If
			box.Text = String.Empty
		End Sub
	End Class
End Namespace
