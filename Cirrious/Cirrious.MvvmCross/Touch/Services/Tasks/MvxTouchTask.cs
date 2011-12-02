#region Copyright

// <copyright file="MvxTouchTask.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using System;
using Cirrious.MvvmCross.Touch.Interfaces;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.Views;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Cirrious.MvvmCross.Touch.Services.Tasks
{
    public class MvxTouchTask
        : IMvxServiceConsumer<IMvxViewDispatcherProvider>
    {
        protected bool DoUrlOpen(NSUrl url)
		{
#warning What exceptions could be thrown here?
#warning Does this need to be on UI thread?
			return UIApplication.SharedApplication.OpenUrl(url);
		}
    }
}