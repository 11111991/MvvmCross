﻿#region Copyright
// <copyright file="MvxPhoneViewDispatcher.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion
#region using

using System;
using System.Threading;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.Views;
using Cirrious.MvvmCross.Platform.Diagnostics;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.WindowsPhone.Interfaces;
using Microsoft.Phone.Controls;

#endregion

namespace Cirrious.MvvmCross.WindowsPhone.Views
{
    public class MvxPhoneViewDispatcher 
        : MvxMainThreadDispatcher
        , IMvxViewDispatcher
        , IMvxServiceConsumer<IMvxWindowsPhoneViewModelRequestTranslator>
    {
        private readonly PhoneApplicationFrame _rootFrame;

        public MvxPhoneViewDispatcher(PhoneApplicationFrame rootFrame)
            : base(rootFrame.Dispatcher)
        {
            _rootFrame = rootFrame;
        }

        #region IMvxViewDispatcher Members

        public bool RequestNavigate(MvxShowViewModelRequest request)
        {
            var requestTranslator = this.GetService<IMvxWindowsPhoneViewModelRequestTranslator>();
            var xamlUri = requestTranslator.GetXamlUriFor(request);
            return InvokeOrBeginInvoke(() =>
                                           {
                                               try
                                               {
                                                   _rootFrame.Navigate(xamlUri);
                                               }
                                               catch (ThreadAbortException)
                                               {
                                                   throw;
                                               }
                                               catch (Exception exception)
                                               {
                                                   MvxTrace.Trace("Error seen during navigation request to {0} - error {1}", request.ViewModelType.Name, exception.ToLongString());
                                               }
                                           });
        }

        public bool RequestNavigateBack()
        {
            return InvokeOrBeginInvoke(() => _rootFrame.GoBack());
        }

        public bool RequestRemoveBackStep()
        {
            return InvokeOrBeginInvoke(() => _rootFrame.RemoveBackEntry());
        }

        #endregion
    }
}