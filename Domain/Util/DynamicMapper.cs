using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Util
{
    public static class DynamicMapper
    {
        public static TDestination Map<TSource, TDestination>(this TSource source) where TDestination : new()
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var destination = (TDestination?)Activator.CreateInstance(typeof(TDestination));
            var sourceType = source.GetType();
            var destinationType = typeof(TDestination);

            foreach (var sourceProperty in sourceType.GetProperties())
            {
                var destinationProperty = destinationType.GetProperty(sourceProperty.Name);
                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    var value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }

            return destination;
        }

        // Método para mapear una lista de objetos de origen a una lista de objetos de destino
        public static List<TDestination> Map<TSource, TDestination>(this List<TSource> sourceList) where TDestination : new()
        {
            if (sourceList == null) throw new ArgumentNullException(nameof(sourceList));

            return sourceList.Select(source => Map<TSource, TDestination>(source)).ToList();
        }
    }
}
