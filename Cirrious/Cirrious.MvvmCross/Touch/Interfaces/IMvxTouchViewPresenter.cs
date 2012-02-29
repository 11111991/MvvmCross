#region Copyright

// <copyright file="IMvxTouchViewPresenter.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.Touch.Interfaces;
using MonoTouch.UIKit;

namespace Cirrious.MvvmCross.Touch.Interfaces
{
	public interface IMvxTouchViewPresenter
	{
		bool ShowView(IMvxTouchView view);
		bool GoBack();
	    void ClearBackStack();

        bool PresentNativeModalViewController(UIViewController controller, bool animated);
	}
}