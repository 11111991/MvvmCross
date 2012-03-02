#region Copyright
// <copyright file="MvxTouchBindingSetup.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using System;
using Cirrious.MvvmCross.Binding.Interfaces.Binders;
using Cirrious.MvvmCross.Binding.Interfaces.Bindings.Target.Construction;
using Cirrious.MvvmCross.Touch.Interfaces;
using Cirrious.MvvmCross.Touch.Platform;

namespace Cirrious.MvvmCross.Binding.Touch
{
    public abstract class MvxBaseTouchBindingSetup
    : MvxBaseTouchSetup
    {
        protected MvxBaseTouchBindingSetup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override void InitializeLastChance()
        {
            var bindingBuilder = new MvxTouchBindingBuilder(FillTargetFactories, FillValueConverters);
            bindingBuilder.DoRegistration();

            base.InitializeLastChance();
        }

        protected virtual void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            // nothing to do in this base class
        }

        protected virtual void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            // nothing to do in this base class
        }
    }

    public class MvxTouchBindingBuilder 
        : MvxBaseBindingBuilder
    {
        private readonly Action<IMvxTargetBindingFactoryRegistry> _fillRegistryAction;
        private readonly Action<IMvxValueConverterRegistry> _fillValueConvertersAction;

        public MvxTouchBindingBuilder(Action<IMvxTargetBindingFactoryRegistry> fillRegistryAction, Action<IMvxValueConverterRegistry> fillValueConvertersAction)
        {
            _fillRegistryAction = fillRegistryAction;
            _fillValueConvertersAction = fillValueConvertersAction;
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            if (_fillRegistryAction != null)
                _fillRegistryAction(registry);
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);

            if (_fillValueConvertersAction != null)
                _fillValueConvertersAction(registry);
        }
    }
}