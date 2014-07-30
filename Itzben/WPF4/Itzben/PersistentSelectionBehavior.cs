using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace Itzben
{
    public class PersistentSelectionBehavior : Behavior<ListBox>
    {
        private object _lastSelection = null;
        private object _lastRemoved = null;
        private bool _isCleanedUp = false;

        private static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                "ItemsSourceProperty", 
                typeof(IEnumerable), 
                typeof(PersistentSelectionBehavior),
                new PropertyMetadata(OnItemSourcePropertyChanged));

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += AssociatedObject_Loaded;
            AssociatedObject.Unloaded += AssociatedObject_Unloaded;
        }

        protected override void OnDetaching()
        {
            Cleanup();

            base.OnDetaching();
        }

        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            AssociatedObject.SelectionChanged += ListBox_SelectionChanged;

            Binding binding = new Binding("ItemsSource");
            binding.Source = AssociatedObject;
            BindingOperations.SetBinding(this, ItemsSourceProperty, binding);
        }

        void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            Cleanup();
        }

        private void Cleanup()
        {
            if (_isCleanedUp)
                return;

            AssociatedObject.Loaded -= AssociatedObject_Loaded;
            AssociatedObject.Unloaded -= AssociatedObject_Unloaded;
            AssociatedObject.SelectionChanged -= ListBox_SelectionChanged;

            BindingOperations.ClearBinding(this, ItemsSourceProperty);
        }

        private static void OnItemSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var behavior = o as PersistentSelectionBehavior;
            if (behavior != null)
                behavior.OnItemsSourceChanged(e.OldValue, e.NewValue);
        }

        public void OnItemsSourceChanged(object oldValue, object newValue)
        {
            var oldItemSource = oldValue as INotifyCollectionChanged;
            if (oldItemSource != null)
            {
                oldItemSource.CollectionChanged -= ItemsSource_CollectionChanged;
            }
            var newItemSource = newValue as INotifyCollectionChanged;
            if (newItemSource != null)
            {
                newItemSource.CollectionChanged += ItemsSource_CollectionChanged;
            }
        }

        void ItemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var lostItem = e.OldItems.OfType<object>().FirstOrDefault();
                if (lostItem != null && Object.Equals(_lastSelection, lostItem))
                {
                    _lastRemoved = _lastSelection;
                    _lastSelection = null;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var newItem = e.NewItems.OfType<object>().FirstOrDefault();
                if (newItem != null && Object.Equals(_lastRemoved, newItem))
                {
                    AssociatedObject.SelectedItem = newItem;
                    _lastRemoved = null;
                }
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems != null && (e.AddedItems == null || e.AddedItems.Count == 0))
            {
                _lastSelection = e.RemovedItems.OfType<object>().FirstOrDefault();
            }
        }
    }
}
