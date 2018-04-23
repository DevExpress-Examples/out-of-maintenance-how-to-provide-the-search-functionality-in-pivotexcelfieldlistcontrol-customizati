using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.PivotGrid.Internal;

namespace WpfApplication3
{
    public class TreeViewFieldsPresenterEx : TreeViewFieldsPresenter
    {
        public static readonly DependencyProperty FilterCriteriaProperty =
            DependencyProperty.Register("FilterCriteria", typeof (string), typeof (TreeViewFieldsPresenterEx), 
            new PropertyMetadata(default(string), FilterCriteriaChanged));

        private static void FilterCriteriaChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var control = dependencyObject as TreeViewFieldsPresenterEx;
            if(control==null)
                return;
            control.ApplyFilter();
        }

        private void ApplyFilter()
        {
            if(!IsLoaded || Items.Count==0)
                return;

            foreach (TreeViewItem item in Items)
            {
                
                FilterChildNodes(item);
            }
        }

        private void FilterChildNodes(TreeViewItem node)
        {
            if (node.HasItems)
            {
                var visibleNodeCount = node.Items.Cast<TreeViewItem>()
                    .Select(i =>
                        {
                            FilterChildNodes(i);
                            return i;
                        })
                        .Where(i => i.Visibility == System.Windows.Visibility.Visible)
                    .ToArray();

                if (visibleNodeCount.Count() == 0)
                    node.Visibility = System.Windows.Visibility.Collapsed;
                else
                    node.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                var header = node.Header as TreeViewFieldHeader;
                if (header != null)
                {
                    node.Visibility = header.DisplayText.ToLower().Contains(FilterCriteria.ToLower()) ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        public string FilterCriteria
        {
            get { return (string) GetValue(FilterCriteriaProperty); }
            set { SetValue(FilterCriteriaProperty, value); }
        }

    }
}
