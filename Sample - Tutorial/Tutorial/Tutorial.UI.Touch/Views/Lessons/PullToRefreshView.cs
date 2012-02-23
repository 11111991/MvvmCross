using System.Collections.Generic;
using Cirrious.MvvmCross.Binding.Interfaces;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Tutorial.Core.ViewModels;
using Cirrious.MvvmCross.Touch.Views;
using Tutorial.Core.ViewModels.Lessons;

namespace Tutorial.UI.Touch.Views.Lessons
{
    public class PullToRefreshView
        : MvxTouchTableViewController<PullToRefreshViewModel>
        , IMvxServiceConsumer<IMvxBinder>
    {
        private readonly List<IMvxUpdateableBinding> _bindings;

        public PullToRefreshView(MvxShowViewModelRequest request)
            : base(request)
        {
            _bindings = new List<IMvxUpdateableBinding>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bindings.ForEach(x => x.Dispose());
            }

            base.Dispose(disposing);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // This class currently unfinished

            /*
            Title = "Views";

            var tableDelegate = new MvxBindableTableViewDelegate();
            tableDelegate.SelectionChanged += (sender, args) => ViewModel.ShowItemCommand.Execute(args.AddedItems[0]);
            var tableSource = new TableViewDataSource(TableView);

            var binder = this.GetService<IMvxBinder>();
            _bindings.AddRange(binder.Bind(ViewModel, tableDelegate, "{'ItemsSource':{'Path':'Items'}}"));
            _bindings.AddRange(binder.Bind(ViewModel, tableSource, "{'ItemsSource':{'Path':'Items'}}"));

            TableView.Delegate = tableDelegate;
            TableView.DataSource = tableSource;
            TableView.ReloadData();
             */
        }

        #region Nested classes for the table

        public sealed class TableViewCell
            : MvxBindableTableViewCell
        {
            public static readonly MvxBindingDescription[] BindingDescriptions
                = new[]
                  {
                      new MvxBindingDescription()
                          {
                              TargetName = "TitleText",
                              SourcePropertyPath = "Name"
                          },
                      new MvxBindingDescription()
                          {
                              TargetName = "DetailText",
                              SourcePropertyPath = "FullName"
                          },
                  };

            // if you don't want to code the MvxBindingDescription in C#, then a string could instead be used instead:
            //public const string BindingText = @"{'TitleText':{'Path':'Name'},'DetailText':{'Path':'FullName'}}";

            public TableViewCell(UITableViewCellStyle cellStyle, NSString cellIdentifier)
                : base(BindingDescriptions, cellStyle, cellIdentifier)
            {
                Accessory = UITableViewCellAccessory.DisclosureIndicator;
            }
        }

        public class TableViewDataSource : MvxBindableTableViewDataSource
        {
            static readonly NSString CellIdentifier = new NSString("TableViewCell");

            public TableViewDataSource(UITableView tableView)
                : base(tableView)
            {
            }

            protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
            {
                var reuse = tableView.DequeueReusableCell(CellIdentifier);
                if (reuse != null)
                    return reuse;

                var toReturn = new TableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
                return toReturn;
            }
        }

        #endregion
    }
}

