﻿#region Copyright
// <copyright file="MvxPhoneViewsContainer.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using System;
using System.Linq;
using Cirrious.MvvmCross.Exceptions;
using Cirrious.MvvmCross.Interfaces.Views;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.WindowsPhone.Interfaces;
using Microsoft.Phone.Controls;
using Newtonsoft.Json;

namespace Cirrious.MvvmCross.WindowsPhone.Views
{
	public class MvxPhoneViewsContainer : MvxViewsContainer, IMvxWindowsPhoneViewModelRequestTranslator, IMvxViewDispatcherProvider
	{
        private const string QueryParameterKeyName = @"ApplicationUrl";

	    private readonly PhoneApplicationFrame _rootFrame;

	    public MvxPhoneViewsContainer(PhoneApplicationFrame frame)
		{
			_rootFrame = frame;
		}

	    public static MvxPhoneViewsContainer PhoneViewModelContainerInstance { get { return Instance as MvxPhoneViewsContainer; } }

	    #region IMvxViewDispatcherProvider Members

	    public override IMvxViewDispatcher Dispatcher
	    {
	        get { return new MvxPhoneViewDispatcher(_rootFrame); }
	    }

	    #endregion

	    #region IMvxWindowsPhoneViewModelRequestTranslator Members

	    public MvxShowViewModelRequest GetRequestFromXamlUri(Uri viewUri)
		{
#warning there is now an extension method to use for parsing query parameters
	        var parsed = viewUri.ParseQueryString();

	        string queryString;
            if (!parsed.TryGetValue(QueryParameterKeyName, out queryString))
			    throw new MvxException("Unable to find incoming MvxShowViewModelRequest");

			var text = Uri.UnescapeDataString(queryString);
			return JsonConvert.DeserializeObject<MvxShowViewModelRequest>(text);
		}

		public Uri GetXamlUriFor(MvxShowViewModelRequest request)
		{
            var viewType = GetViewType(request.ViewModelType);
			if (viewType == null)
			{
                throw new MvxException("View Type not found for " + request.ViewModelType);
			}

            var requestText = JsonConvert.SerializeObject(request);
            var viewUrl = string.Format("{0}?{1}={2}", GetBaseXamlUrlForView(viewType), QueryParameterKeyName, Uri.EscapeDataString(requestText));
			return new Uri(viewUrl, UriKind.Relative);
		}

	    #endregion

	    private static string GetBaseXamlUrlForView(Type viewType)
		{
			string viewUrl;
			var customAttribute =
				(MvxPhoneViewAttribute)
				viewType.GetCustomAttributes(typeof (MvxPhoneViewAttribute), false).FirstOrDefault();
			
			if (customAttribute == null)
			{
			    var splitName = viewType.FullName.Split('.');
			    var viewsAndBeyond = splitName.SkipWhile((segment) => segment != "Views");
                viewUrl = string.Format("/{0}.xaml", string.Join("/", viewsAndBeyond));
			}
			else
				viewUrl = customAttribute.Url;

			return viewUrl;
		}
	}
}