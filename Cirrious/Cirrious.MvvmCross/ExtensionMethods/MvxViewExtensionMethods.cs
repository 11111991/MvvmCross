#region Copyright
// <copyright file="MvxViewExtensionMethods.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using System;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.Interfaces.Views;

namespace Cirrious.MvvmCross.ExtensionMethods
{
    public static class MvxViewExtensionMethods
    {
        public static void OnViewCreate<TViewModel>(this IMvxView<TViewModel> view, Func<TViewModel> viewModelLoader)
            where TViewModel : class, IMvxViewModel
        {
            if (view.ViewModel != null)
                return;

            var viewModel = viewModelLoader();
            viewModel.RegisterView(view);
            view.ViewModel = (TViewModel)viewModel;
        }

        public static void OnViewDestroy<TViewModel>(this IMvxView<TViewModel> view)
            where TViewModel : class, IMvxViewModel
        {
            if (view.ViewModel != null)
                view.ViewModel.UnRegisterView(view);
        }

        public static void FixupTracking<T>(this IMvxView<T> view, T viewModel, Action setViewModelCallback)
            where T : class, IMvxViewModel
        {
            if (view.ViewModel == viewModel)
                return;

            if (view.ViewModel != null)
                view.TryUnregisterView();

            setViewModelCallback();
            view.TryRegisterView();
        }

        private static bool TryRegisterView<T>(this IMvxView<T> view)
            where T : class, IMvxViewModel
        {
            if (view.ViewModel == null)
                return false;
            view.ViewModel.RegisterView(view);
            return true;
        }

        private static bool TryUnregisterView<T>(this IMvxView<T> view)
            where T : class, IMvxViewModel
        {
            if (view.ViewModel == null)
                return false;
            view.ViewModel.UnRegisterView(view);
            return true;
        }
    }
}