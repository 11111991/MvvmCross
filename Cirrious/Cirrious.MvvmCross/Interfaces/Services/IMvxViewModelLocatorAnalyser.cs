﻿#region Copyright

// ----------------------------------------------------------------------
// // <copyright file="IMvxViewModelLocatorAnalyser.cs" company="Cirrious">
// //     (c) Copyright Cirrious. http://www.cirrious.com
// //     This source is subject to the Microsoft Public License (Ms-PL)
// //     Please see license.txt on http://opensource.org/licenses/ms-pl.html
// //     All other rights reserved.
// // </copyright>
// // 
// // Author - Stuart Lodge, Cirrious. http://www.cirrious.com
// // ------------------------------------------------------------------------

#endregion

#region using

using System;
using System.Collections.Generic;
using System.Reflection;

#endregion

namespace Cirrious.MvvmCross.Interfaces.Services
{
    public interface IMvxViewModelLocatorAnalyser
    {
        Dictionary<string, MethodInfo> GenerateLocatorMap(Type locatorType, Type viewModelType);
    }
}