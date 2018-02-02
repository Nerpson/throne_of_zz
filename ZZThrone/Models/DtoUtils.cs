using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZZThrone.Models
{
    public static class DtoUtils
    {
        public static D toDto<D>(this object model) where D : new()
        {
            D result = new D();

            Type sourceType = model.GetType();
            Type destType = result.GetType();

            var sourceProperties = sourceType.GetProperties();
            var destionationProperties = destType.GetProperties();

            var commonproperties = from sp in sourceProperties
                                   join dp in destionationProperties on new { sp.Name, sp.PropertyType } equals
                                       new { dp.Name, dp.PropertyType }
                                   select new { sp, dp };

            foreach (var match in commonproperties)
            {
                match.dp.SetValue(result, match.sp.GetValue(model, null), null);
            }

            return result;
        }
    }
}