using System.Windows;
using System.Windows.Media;

namespace WpfApplication3
{
    public static class VisualHelper
    {
        private static DependencyObject GetParent(this DependencyObject obj)
        {
            if (obj == null)
                return null;
            var ce = obj as ContentElement;
            if (ce != null)
            {
                var parent = ContentOperations.GetParent(ce);
                if (parent != null)
                    return parent;
                var fce = ce as FrameworkContentElement;
                return fce != null ? fce.Parent : null;
            }
            var fe = obj as FrameworkElement;
            if (fe != null)
            {
                var parent = fe.Parent;
                if (parent != null)
                    return parent;
            }
            return VisualTreeHelper.GetParent(obj);
        }

        public static T FindAncestor<T>(this DependencyObject descendant) where T : DependencyObject
        {
            if (descendant == null)
                return null;
            var current = descendant.GetParent();
            while (current != null && !(current is T))
                current = current.GetParent();
            return current as T;
        }

        public static TChild FindVisualChild<TChild>(this DependencyObject obj) where TChild : DependencyObject
        {
            if (obj == null)
                return null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is TChild)
                    return (TChild)child;
                else
                {
                    var childOfChild = FindVisualChild<TChild>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}