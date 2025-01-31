﻿using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TddBank.Tests")]

namespace TddBank
{
    public class OpeningHours
    {
        internal bool IsOpen(DateTime dt)
        {
            var start = new TimeSpan(10, 30, 0);
            var ende = new TimeSpan(19, 00, 0);
            var endeSa = new TimeSpan(14, 00, 0);

            //häßlich aber geht
            if (dt.DayOfWeek == DayOfWeek.Sunday) return false;
            else if (dt.DayOfWeek == DayOfWeek.Saturday && dt.TimeOfDay >= start && dt.TimeOfDay < endeSa)
                return true;
            else if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday && dt.TimeOfDay >= start && dt.TimeOfDay < ende)
                return true;

            return false;
        }

        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }

        public void ReadConfFile()
        {
            using var sr = new StreamReader(@"b:\eineTolleDatei.ini");
            var txt = sr.ReadToEnd();

            if (txt.Contains("Kaffee"))
                Debug.WriteLine(":-)");
            else
                Debug.WriteLine(":-(");
        }
    }
}
