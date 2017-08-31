using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    public class FutureDateAttribute:RequiredAttribute
    {
            public override bool IsValid(object value)
            {
                if (base.IsValid(value))
                {
                    DateTime d = ((DateTime)value);
                    return d > DateTime.Now && d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday && d.Hour >= 9 && d.Hour <= 18;
                }
                else
                    return false;
            }
    }
}