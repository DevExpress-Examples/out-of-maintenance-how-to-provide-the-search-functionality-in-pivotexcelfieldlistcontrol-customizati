Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Media

Namespace WpfApplication3
	Public Module VisualHelper
        Sub New()
        End Sub
        <System.Runtime.CompilerServices.Extension()> _
        Private Function GetParent(ByVal obj As DependencyObject) As DependencyObject
            If obj Is Nothing Then
                Return Nothing
            End If
            Dim ce = TryCast(obj, ContentElement)
            If ce IsNot Nothing Then
                Dim parent = ContentOperations.GetParent(ce)
                If parent IsNot Nothing Then
                    Return parent
                End If
                Dim fce = TryCast(ce, FrameworkContentElement)
                Return If(fce IsNot Nothing, fce.Parent, Nothing)
            End If
            Dim fe = TryCast(obj, FrameworkElement)
            If fe IsNot Nothing Then
                Dim parent = fe.Parent
                If parent IsNot Nothing Then
                    Return parent
                End If
            End If
            Return VisualTreeHelper.GetParent(obj)
        End Function

        <System.Runtime.CompilerServices.Extension()> _
        Public Function FindAncestor(Of T As DependencyObject)(ByVal descendant As DependencyObject) As T
            If descendant Is Nothing Then
                Return Nothing
            End If
            Dim current = descendant.GetParent()
            Do While current IsNot Nothing AndAlso Not (TypeOf current Is T)
                current = current.GetParent()
            Loop
            Return TryCast(current, T)
        End Function

        <System.Runtime.CompilerServices.Extension()> _
        Public Function FindVisualChild(Of TChild As DependencyObject)(ByVal obj As DependencyObject) As TChild
            If obj Is Nothing Then
                Return Nothing
            End If
            For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(obj) - 1
                Dim child = VisualTreeHelper.GetChild(obj, i)
                If child IsNot Nothing AndAlso TypeOf child Is TChild Then
                    Return CType(child, TChild)
                Else
                    Dim childOfChild = FindVisualChild(Of TChild)(child)
                    If childOfChild IsNot Nothing Then
                        Return childOfChild
                    End If
                End If
            Next i
            Return Nothing
        End Function
	End Module
End Namespace