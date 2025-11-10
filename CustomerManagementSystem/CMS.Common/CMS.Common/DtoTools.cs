using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common
{
    public class DtoTools
    {
        public static void CopyFields(object fromObj, object toObj)
        {
            var srcProp = fromObj.GetType().GetProperties();
            var desProp = toObj.GetType().GetProperties();

            foreach (var prop in desProp)
            {
                var src = srcProp.FirstOrDefault(x => x.Name.Equals(prop.Name, StringComparison.InvariantCultureIgnoreCase));
                if (src != null)
                {
                    if (prop.Name != "Count")
                    {
                        prop.SetValue(toObj, src.GetValue(fromObj, null), null);
                    }
                }
            }

        }
        public static void CopyAll<TSource, TTarget>(ICollection<TSource> source, ICollection<TTarget> target)
        where TSource : class
        where TTarget : class, new()
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var sourceProps = typeof(TSource)
                .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Where(p => p.CanRead)
                .ToList();

            var targetProps = typeof(TTarget)
                .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Where(p => p.CanWrite)
                .ToDictionary(p => p.Name);

            foreach (var srcItem in source)
            {
                if (srcItem == null) continue;

                var newItem = new TTarget();

                foreach (var srcProp in sourceProps)
                {
                    if (targetProps.TryGetValue(srcProp.Name, out var targetProp) &&
                        targetProp.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                    {
                        var value = srcProp.GetValue(srcItem, null);
                        targetProp.SetValue(newItem, value, null);
                    }
                }

                target.Add(newItem);
            }
        }
        public static void CopyAll<T>(ICollection<T> source, ICollection<T> target)
        where T : class, new()
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            // Get all public readable & writable properties
            var properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite)
                .ToList();

            foreach (var srcItem in source)
            {
                if (srcItem == null) continue;

                // Create a new instance of T
                var newItem = new T();

                // Copy matching property values
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(srcItem, null);
                    prop.SetValue(newItem, value, null);
                }

                target.Add(newItem);
            }
        }

        public static void CopyAll<T>(T source, T target)
        {
            var type = typeof(T);
            foreach (var sourceProperty in type.GetProperties())
            {
                var targetProperty = type.GetProperty(sourceProperty.Name);
                targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
            }
            foreach (var sourceField in type.GetFields())
            {
                var targetField = type.GetField(sourceField.Name);
                targetField.SetValue(target, sourceField.GetValue(source));
            }
        }
    }
}
