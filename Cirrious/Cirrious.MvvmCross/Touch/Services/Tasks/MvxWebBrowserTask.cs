﻿#region Copyright

// <copyright file="MvxWebBrowserTask.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

#region using

using Cirrious.MvvmCross.Interfaces.Services.Tasks;
using MonoTouch.Foundation;

#endregion

namespace Cirrious.MvvmCross.Touch.Services.Tasks
{
    public class MvxWebBrowserTask : MvxTouchTask, IMvxWebBrowserTask
    {
        #region IMvxWebBrowserTask Members

        public void ShowWebPage(string url)
        {
           	var nsurl = new NSUrl(url);
            DoUrlOpen(nsurl);
        }

        #endregion
    }
}