<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/WpfApplication3/MainWindow.xaml) (VB: [MainWindow.xaml.vb](./VB/WpfApplication3/MainWindow.xaml.vb))
* [MainWindow.xaml.cs](./CS/WpfApplication3/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication3/MainWindow.xaml.vb))
* [PivotFieldsChooser.xaml](./CS/WpfApplication3/PivotFieldsChooser.xaml) (VB: [PivotFieldsChooser.xaml](./VB/WpfApplication3/PivotFieldsChooser.xaml))
* [PivotFieldsChooser.xaml.cs](./CS/WpfApplication3/PivotFieldsChooser.xaml.cs) (VB: [PivotFieldsChooser.xaml](./VB/WpfApplication3/PivotFieldsChooser.xaml))
* [TreeViewFieldsPresenterEx.cs](./CS/WpfApplication3/TreeViewFieldsPresenterEx.cs) (VB: [TreeViewFieldsPresenterEx.vb](./VB/WpfApplication3/TreeViewFieldsPresenterEx.vb))
* [VisualHelper.cs](./CS/WpfApplication3/VisualHelper.cs) (VB: [VisualHelper.vb](./VB/WpfApplication3/VisualHelper.vb))
<!-- default file list end -->
# How to provide the search functionality in PivotExcelFieldListControl (Customization Form)


<p>This example illustrates how to add a search box to the field list control. <br />Our PivotExcelFieldListControl uses the TreeViewFieldsPresenter component to show fields in a tree-like view. In this example, we create a TreeViewFieldsPresenter control descendant and implement the filtering functionality at its level.  The default TreeViewFieldsPresenter is replaced with our descendant via styles.<br /><br /><strong>Important:</strong> The provided approach works when fields are grouped via <a href="https://documentation.devexpress.com/#WPF/CustomDocument11754">User Folders</a>. In OLAP mode, fields are grouped automatically. If fields are not grouped, PivotGrid uses another control (not TreeViewFieldsPresenter ) to manage hidden fields and custom style is not used.</p>

<br/>


