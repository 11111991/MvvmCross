#region Copyright

// <copyright file="IMvxAndroidView.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using System;
using Android.Content;
using Cirrious.MvvmCross.Android.LifeTime;
using Cirrious.MvvmCross.Android.Views;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.Interfaces.Views;

namespace Cirrious.MvvmCross.Android.Interfaces
{
    public interface IMvxAndroidView
        : IMvxTrackedView
    {
        void MvxInternalStartActivityForResult(Intent intent, int requestCode);
        event EventHandler<MvxIntentResultEventArgs> MvxIntentResultReceived;
    }

    public interface IMvxAndroidView<TViewModel>
        : IMvxTrackedView<TViewModel>
        , IMvxAndroidView
        , IMvxServiceConsumer<IMvxViewModelLoader>
        , IMvxServiceConsumer<IMvxAndroidViewModelRequestTranslator>
        , IMvxServiceConsumer<IMvxAndroidActivityLifetimeListener>
        where TViewModel : class, IMvxViewModel
    {
        new TViewModel ViewModel { get; set; }
    }
}