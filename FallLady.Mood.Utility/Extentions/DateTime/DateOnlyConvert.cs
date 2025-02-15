﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Utility.Extentions.Datetime
{
    public static class DateOnlyConvert
    {
        public static DateOnly AsDateOnly(this DateTime dt)
        {
            return DateOnly.FromDateTime(dt);
        }

        public static DateTime AsDateTime(this DateOnly dt)
        {
            return dt.ToDateTime(TimeOnly.Parse("10:00 AM"));
        }
        public static DateTime? AsDateTime(this DateOnly? dt)
        {
            return dt is null ? DateTime.UtcNow : dt.Value.AsDateTime();
        }
    }
}
