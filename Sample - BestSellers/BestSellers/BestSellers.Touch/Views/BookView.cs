using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Views;
using BestSellers.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.ExtensionMethods;
using System.Collections.Generic;
using Cirrious.MvvmCross.Platform.Images;

namespace BestSellers.Touch.Views
{
	public partial class BookView : MvxBindingTouchViewController<BookViewModel>
	{
        private MvxDynamicImageHelper<UIImage> _imageHelper;
		
		public BookView (MvxShowViewModelRequest request) : base (request, "BookView", null)
		{
			_imageHelper = new MvxDynamicImageHelper<UIImage>();
			_imageHelper.ImageChanged += HandleImageHelperImageChanged;
		}

		void HandleImageHelperImageChanged (object sender, Cirrious.MvvmCross.Platform.MvxValueEventArgs<UIImage> e)
		{
			if (BookImage != null)
			{
				BookImage.Image = e.Value;
			}			
		}
				
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
						
			this.AddBindings(
                new Dictionary<object, string>()
                    {
                        { TitleLabel, "{'Text':{'Path':'Book.Title'}}" },
                        { AuthorLabel, "{'Text':{'Path':'Book.Author'}}" },
                        { DescriptionLabel, "{'Text':{'Path':'Book.Description'}}" },
                        { _imageHelper, "{'HttpImageUrl':{'Path':'Book.AmazonImageUrl'}}" },
                        { ActivityIndicator, "{'Hidden':{'Path':'IsLoading','Converter':'InvertedVisibility'}}" },
                    });
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();					
			ReleaseDesignerOutlets ();
			_imageHelper.ImageChanged -= HandleImageHelperImageChanged;
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

