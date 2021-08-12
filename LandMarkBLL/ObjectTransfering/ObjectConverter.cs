using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LandMarkBLL.ObjectTransfering
{
    public class ObjectConverter<TSource, TDestination>
    {
        public TDestination CopyProperties(TSource Source)
        {
            TDestination destination = (TDestination)Activator.CreateInstance(typeof(TDestination), new object[] { });
            foreach (PropertyInfo p in typeof(TSource).GetProperties()
                               .Where(ps => typeof(TDestination).GetProperties().Any(pd => pd.Name == ps.Name)))
            {
                typeof(TDestination).GetProperty(p.Name).SetValue(destination,
                    typeof(TSource).GetProperty(p.Name).GetValue(Source));
            }

            return destination;
        }
    }
}
