using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Cirrious.MvvmCross.Binding.Interfaces;
using Cirrious.MvvmCross.Binding.Interfaces.Binders;
using Cirrious.MvvmCross.Binding.Touch.Interfaces.Views;
using Cirrious.MvvmCross.ExtensionMethods;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Commands;

namespace Cirrious.MvvmCross.Binding.Touch.Views
{
    public class MvxBindableTableViewSource : UITableViewSource
    {
        private static readonly NSString DefaultCellIdentifier = new NSString("BindableTableViewCell");
        private static readonly MvxBindingDescription[] DefaultBindingDescription = new MvxBindingDescription[]
                                                                                        {
                                                                                            new MvxBindingDescription()
                                                                                                {
                                                                                                    TargetName = "TitleText",
                                                                                                    SourcePropertyPath = string.Empty
                                                                                                }, 
                                                                                        };
        private readonly UITableView _tableView;
        private readonly NSString _cellIdentifier;
        private readonly IEnumerable<MvxBindingDescription> _bindingDescriptions;
        private readonly UITableViewCellStyle _cellStyle;

        protected MvxBindableTableViewSource(UITableView tableView)
            : this(tableView, UITableViewCellStyle.Default, DefaultCellIdentifier, DefaultBindingDescription)
        {
        }

        public MvxBindableTableViewSource(UITableView tableView, UITableViewCellStyle style, NSString cellIdentifier, string bindingText)
            : this(tableView, style, cellIdentifier, ParseBindingText(bindingText))
        {
        }

        private static IEnumerable<MvxBindingDescription> ParseBindingText(string bindingText)
        {
            if (string.IsNullOrEmpty(bindingText))
                return DefaultBindingDescription;

            return MvxServiceProviderExtensions.GetService<IMvxBindingDescriptionParser>().Parse(bindingText);
        }

        public MvxBindableTableViewSource(UITableView tableView, UITableViewCellStyle style, NSString cellIdentifier, IEnumerable<MvxBindingDescription> descriptions)
        {
            _tableView = tableView;
            _cellStyle = style;
            _cellIdentifier = cellIdentifier;
            _bindingDescriptions = descriptions;
        }
		
        public event EventHandler<MvxSimpleSelectionChangedEventArgs> SelectionChanged;

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (ItemsSource == null)
                return;

            var item = ItemsSource[indexPath.Row];
            var selectionChangedArgs = MvxSimpleSelectionChangedEventArgs.JustAddOneItem(item);

            var handler = SelectionChanged;
            if (handler != null)
                handler(this, selectionChangedArgs);
        }		

        private IList _itemsSource;
        public IList ItemsSource
        {
            get { return _itemsSource; }
            set
            {
                if (_itemsSource == value)
                    return;

                var collectionChanged = _itemsSource as INotifyCollectionChanged;
                if (collectionChanged != null)
                    collectionChanged.CollectionChanged -= CollectionChangedOnCollectionChanged;
                _itemsSource = value;
                collectionChanged = _itemsSource as INotifyCollectionChanged;
                if (collectionChanged != null)
                    collectionChanged.CollectionChanged += CollectionChangedOnCollectionChanged;
			    ReloadTableData ();
            }
        }

		public void ReloadTableData ()
		{
			_tableView.ReloadData();
			// begin and end updates are left over from a painful and failed attempt to get row height to work after ReloadData has been called
        	//_tableView.BeginUpdates();
            //_tableView.EndUpdates();
		}

        private void CollectionChangedOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
			ReloadTableData ();
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            if (ItemsSource == null)
                return 0;

            return ItemsSource.Count;
        }
		
        protected virtual UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var reuse = tableView.DequeueReusableCell(_cellIdentifier);
            if (reuse != null)
                return reuse;

            var toReturn = new MvxBindableTableViewCell(_bindingDescriptions, _cellStyle, _cellIdentifier);
            return toReturn;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (ItemsSource == null)
                return null;

            var item = ItemsSource[indexPath.Row];
            var cell = GetOrCreateCellFor(tableView, indexPath, item);

            var bindable = cell as IMvxBindableView;
            if (bindable != null)
                bindable.BindTo(item);

            return cell;
        }

        public override int NumberOfSections(UITableView tableView)
        {
            return 1;
        }
    }
}