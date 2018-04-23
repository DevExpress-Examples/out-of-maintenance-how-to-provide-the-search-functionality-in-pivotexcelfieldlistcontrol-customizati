# How to provide the search functionality in PivotExcelFieldListControl (Customization Form)


<p>This example illustrates how to add a search box to the field list control. <br />Our PivotExcelFieldListControl uses the TreeViewFieldsPresenter component to show fields in a tree-like view. In this example, we create a TreeViewFieldsPresenter control descendant and implement the filtering functionality at its level.  The default TreeViewFieldsPresenter is replaced with our descendant via styles.<br /><br /><strong>Important:</strong> The provided approach works when fields are grouped via <a href="https://documentation.devexpress.com/#WPF/CustomDocument11754">User Folders</a>. In OLAP mode, fields are grouped automatically. If fields are not grouped, PivotGrid uses another control (not TreeViewFieldsPresenter ) to manage hidden fields and custom style is not used.</p>

<br/>


