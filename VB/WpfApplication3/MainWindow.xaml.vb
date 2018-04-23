Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Linq
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid


Namespace WpfApplication3
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()

			pivotGridControl1.OlapConnectionString = "provider=msolap;data source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;initial catalog=Adventure Works DW Standard Edition;timeout=1200;Cube Name=Adventure Works;"

			pivotGridControl1.RetrieveFields(FieldArea.FilterArea, False)

		End Sub
	End Class
End Namespace
