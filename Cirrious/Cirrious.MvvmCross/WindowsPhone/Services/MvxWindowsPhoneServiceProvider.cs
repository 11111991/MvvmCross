﻿#region Copyright

// <copyright file="MvxWindowsPhoneServiceProvider.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

#region using

using Cirrious.MvvmCross.Interfaces.IoC;
using Cirrious.MvvmCross.Interfaces.Localization;
using Cirrious.MvvmCross.Interfaces.Services;
using Cirrious.MvvmCross.Interfaces.Services.Lifetime;
using Cirrious.MvvmCross.Interfaces.Services.Location;
using Cirrious.MvvmCross.Interfaces.Services.SoundEffects;
using Cirrious.MvvmCross.Interfaces.Services.Tasks;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.WindowsPhone.Services.Bookmarks;
using Cirrious.MvvmCross.WindowsPhone.Services.Lifetime;
using Cirrious.MvvmCross.WindowsPhone.Services.Location;
using Cirrious.MvvmCross.WindowsPhone.Services.Tasks;

#endregion

namespace Cirrious.MvvmCross.WindowsPhone.Services
{
    [MvxServiceProvider]
    public class MvxWindowsPhoneServiceProvider : MvxPlatformIndependentServiceProvider
    {
        public MvxWindowsPhoneServiceProvider()
        {
        }

        public override void Initialize(IMvxIoCProvider iocProvider)
        {
            base.Initialize(iocProvider);
            SetupPlatformTypes();
        }

        private void SetupPlatformTypes()
        {
            RegisterServiceInstance<IMvxLifetime>(new MvxWindowsPhoneLifetimeMonitor());
            RegisterServiceInstance<IMvxTrace>(new MvxDebugTrace());
            RegisterServiceType<IMvxSimpleFileStoreService, MvxIsolatedStorageFileStoreService>();
            RegisterServiceType<IMvxWebBrowserTask, MvxWebBrowserTask>();
            RegisterServiceType<IMvxPhoneCallTask, MvxPhoneCallTask>();
            RegisterServiceType<IMvxPictureChooserTask, MvxPictureChooserTask>();
            RegisterServiceType<IMvxCombinedPictureChooserTask, MvxPictureChooserTask>();            
            RegisterServiceType<IMvxResourceLoader, MvxWindowsPhoneResourceLoader>();
            RegisterServiceType<IMvxBookmarkLibrarian, MvxWindowsPhoneLiveTileBookmarkLibrarian>();

#warning Would be nice if sound effects were optional so that not everyone has to link to xna!
            var soundEffectLoader = new SoundEffects.MvxSoundEffectObjectLoader();
            RegisterServiceInstance<IMvxResourceObjectLoaderConfiguration<IMvxSoundEffect>>(soundEffectLoader);
            RegisterServiceInstance<IMvxResourceObjectLoader<IMvxSoundEffect>>(soundEffectLoader);

#warning Would be very nice if GPS were optional!
            RegisterServiceInstance<IMvxGeoLocationWatcher>(new MvxWindowsPhoneGeoLocationWatcher());
        }
    }
}