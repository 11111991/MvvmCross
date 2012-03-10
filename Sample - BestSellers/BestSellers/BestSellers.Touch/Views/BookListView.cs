using System.Collections.Generic;
using BestSellers.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.ExtensionMethods;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace BestSellers.Touch.Views
{
    public class BookListView : MvxBindingTouchTableViewController<BookListViewModel>
    {
        public BookListView(MvxShowViewModelRequest request)
            : base(request)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxBindableTableViewSource(
                TableView,
                UITableViewCellStyle.Subtitle,
                new NSString("BookListView"),
                "{'TitleText':{'Path':'Title'},'DetailText':{'Path':'Author'}, 'SelectedCommand':{'Path':'ViewDetailCommand'}}",
                UITableViewCellAccessory.DisclosureIndicator);

            this.AddBindings(
                new Dictionary<object, string>()
                    {
                        { source, "{'ItemsSource':{'Path':'List'}}" }
                    });
            
            TableView.Source = source;
            TableView.ReloadData();
        }
    }
}

