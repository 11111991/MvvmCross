#region Copyright

// <copyright file="MvxTouchSingleViewsContainer.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using System.Linq;
using Cirrious.MvvmCross.Touch.Interfaces;
using Cirrious.MvvmCross.Exceptions;
using Cirrious.MvvmCross.Platform.Diagnostics;


namespace Cirrious.MvvmCross.Touch.Views.Presenters
{
    public class MvxTouchViewPresenter : MvxBaseTouchViewPresenter
	{
		private readonly UIApplicationDelegate _applicationDelegate;
		private readonly UIWindow _window;
		
		private UINavigationController _masterNavigationController;
		
		public MvxTouchViewPresenter (UIApplicationDelegate applicationDelegate, UIWindow window)
		{
			_applicationDelegate = applicationDelegate;
			_window = window;
		} 
			
		public override bool ShowView (IMvxTouchView view)
		{			
			var viewController = view as UIViewController;
			if (viewController == null)
				throw new MvxException("Passed in IMvxTouchView is not a UIViewController");
			
			if (_masterNavigationController == null)
				ShowFirstView(viewController);
			else
                _masterNavigationController.PushViewController(viewController, true /*animated*/);
		
            return true;
		}

        public override bool GoBack()
		{
			_masterNavigationController.PopViewControllerAnimated(true);
		    return true;
		}

        public override void ClearBackStack()
        {
			if (_masterNavigationController == null)
				return;
			
            _masterNavigationController.PopToRootViewController (true);
			_masterNavigationController = null;
        }

        public override bool PresentNativeModalViewController(UIViewController viewController, bool animated)
	    {
            _masterNavigationController.TopViewController.PresentModalViewController(viewController, animated);
            return true;
	    }

	    protected virtual void ShowFirstView (UIViewController viewController)
		{
			foreach (var view in _window.Subviews)
				view.RemoveFromSuperview();
			
			_masterNavigationController = CreateNavigationController(viewController);

            OnMasterNavigationControllerCreated();

            _window.AddSubview(_masterNavigationController.View);
	    }
		
		protected virtual void OnMasterNavigationControllerCreated ()
		{
		}
		
		protected virtual UINavigationController CreateNavigationController(UIViewController viewController)
		{
			return new UINavigationController(viewController);			
		}
	}	
}
