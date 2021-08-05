 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Globalization;

namespace GigHup2.ViewModels
{
    public class MyValidDate :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
           var isValid =  DateTime.TryParseExact(Convert.ToString(value),
               "d MMM yyyy",
               CultureInfo.CurrentCulture,
               DateTimeStyles.None,
               out dateTime);

            return (isValid && dateTime>DateTime.Now);
        }
    }
}