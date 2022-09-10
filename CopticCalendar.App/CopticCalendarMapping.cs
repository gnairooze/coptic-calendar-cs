using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopticCalendar.App
{
    public class CopticCalendarMapping
    {
        public int Id { get; set; }
        public int GregorianMonth { get; set; }
        public int GregorianDay { get; set; }
        public DayTypes DayType { get; set; }
        public int CopticMonth { get; set; }
        public int CopticDay { get; set; }
    }

    public enum DayTypes
    {
        notset,
        normal,
        leap,
        preleap
    }
}
