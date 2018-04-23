using System.Data;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.PivotGrid;


namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            pivotGridControl1.OlapConnectionString = "provider=msolap;data source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;initial catalog=Adventure Works DW Standard Edition;timeout=1200;Cube Name=Adventure Works;";

            pivotGridControl1.RetrieveFields(FieldArea.FilterArea, false);

        }
    }
}
