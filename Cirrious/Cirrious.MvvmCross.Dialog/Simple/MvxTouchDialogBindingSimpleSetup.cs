#region Copyright
// <copyright file="MvxTouchDialogBindingSimpleSetup.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.Application;

namespace Cirrious.MvvmCross.Dialog.Touch.Simple
{
    public class MvxTouchDialogBindingSimpleSetup
        : MvxTouchDialogBindingSetup
    {
        private readonly IEnumerable<Type> _converterTypes;

        public MvxTouchDialogBindingSimpleSetup(params Type[] converterTypes)
            : base(null, null)
        {
            _converterTypes = converterTypes;
        }

        #region Overrides of MvxBaseSetup

        protected override IEnumerable<Type> ValueConverterHolders
        {
            get
            {
                return _converterTypes;
            }
        }

        protected override MvxApplication CreateApp()
        {
            var app = new MvxEmptyApp();
            return app;
        }

        #endregion

        public static void Initialise(params Type[] converterTypes)
        {
            var setup = new MvxTouchDialogBindingSimpleSetup(converterTypes);
            setup.Initialize();
        }
    }
}