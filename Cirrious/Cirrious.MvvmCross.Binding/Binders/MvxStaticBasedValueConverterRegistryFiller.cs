using System;
using System.Linq;
using Cirrious.MvvmCross.Binding.Interfaces.Binders;
using Cirrious.MvvmCross.Interfaces.Converters;

namespace Cirrious.MvvmCross.Binding.Binders
{
    public class MvxStaticBasedValueConverterRegistryFiller
    {
        private readonly IMvxValueConverterRegistry _registry;

        public MvxStaticBasedValueConverterRegistryFiller(IMvxValueConverterRegistry registry)
        {
            _registry = registry;
        }

        public void AddStaticFieldConverters(Type type)
        {
            var pairs = from field in type.GetFields()
                        where field.IsStatic
                        where field.IsPublic
                        where typeof (IMvxValueConverter).IsAssignableFrom(field.FieldType)
                        let converter = field.GetValue(null) as IMvxValueConverter
                        where converter != null
                        select new {
                                       Name = field.Name,
                                       Converter = converter
                                   };

            foreach (var pair in pairs)
            {
                _registry.AddOrOverwrite(pair.Name, pair.Converter);
            }
        }
    }
}