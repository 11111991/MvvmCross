using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Dialog.Touch;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Interfaces;
using Cirrious.MvvmCross.Application;
using CustomerManagement.Core;
using CustomerManagement.Core.ViewModels;
using CustomerManagement.Touch.Views;

namespace CustomerManagement.Touch
{
    public class Setup
        : MvxTouchDialogBindingSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        #region Overrides of MvxBaseSetup

        protected override MvxApplication CreateApp()
        {
            var app = new App();
            return app;
        }

        protected override IDictionary<Type, Type> GetViewModelViewLookup()
        {
            return new Dictionary<Type, Type>()
                       {
                            { typeof(CustomerListViewModel), typeof(CustomerListView)},
                            { typeof(DetailsCustomerViewModel), typeof(CustomerView)},
                            { typeof(EditCustomerViewModel), typeof(CustomerEditView)},
                            { typeof(NewCustomerViewModel), typeof(CustomerNewView)},
                       };
        }

        #endregion
    }
}