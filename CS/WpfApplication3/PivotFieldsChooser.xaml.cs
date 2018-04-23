using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApplication3
{
    public partial class PivotFieldsChooser : ResourceDictionary
    {
        public PivotFieldsChooser()
        {
            InitializeComponent();
        }

        private void ClearIcon_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var icon = sender as Image;
            if(icon==null)
                return;
            var grid = icon.FindAncestor<Grid>();
            if(grid==null)
                return;
            var box = grid.FindVisualChild<TextBox>();
            if(box==null)
                return;
            box.Text = string.Empty;
        }
    }
}
