#region Copyright
// <copyright file="MvxBaseSplashScreenActivity.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using System.Threading;
using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Android.Platform;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.ViewModels;

namespace Cirrious.MvvmCross.Android.Views
{
    public abstract class MvxBaseSplashScreenActivity
        : MvxActivityView<MvxNullViewModel>
        , IMvxServiceConsumer<IMvxStartNavigation>
    {
        private const int NoContent = 0;

        private static bool _primaryInitialized = false;
        private static bool _secondaryInitialized = false;
        private static MvxBaseAndroidSetup _setup;

        private readonly int _resourceId;

        protected MvxBaseSplashScreenActivity(int resourceId = NoContent)
        {
            _resourceId = resourceId;
        }

        protected abstract MvxBaseAndroidSetup CreateSetup();

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            if (!_primaryInitialized)
            {
                _primaryInitialized = true;

                // initialize app
                _setup = CreateSetup();
                _setup.InitializePrimary();
            }

            base.OnCreate(bundle);

            if (_resourceId != NoContent)
            {
                // Set our view from the "splash" layout resource
                SetContentView(_resourceId);
            }
        }

        protected override void OnViewModelSet()
        {
            // ignored
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (!_secondaryInitialized)
            {
                _secondaryInitialized = true;
                ThreadPool.QueueUserWorkItem((ignored) =>
                                                                  {
                                                                      _setup.InitializeSecondary();
                                                                      TriggerFirstNavigate();
                                                                  });

            }
            else
            {
                TriggerFirstNavigate();
            }
        }

        private void TriggerFirstNavigate()
        {
            // trigger the first navigate...
            var starter = this.GetService<IMvxStartNavigation>();
            starter.Start();
        }
    }
}