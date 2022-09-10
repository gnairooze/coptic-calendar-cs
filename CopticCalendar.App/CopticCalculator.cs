using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopticCalendar.App
{
    internal class CopticCalculator
    {
        private List<CopticCalendarMapping> _Mappings;

        public CopticCalculator(List<CopticCalendarMapping> mappings)
        {
            _Mappings = mappings;
        }

        public (int coptcYear, int copticMonth, int copticDay) CalculateCopticDate(DateTime gregorianDate)
        {
            var gregorianYearType = DayTypes.notset;
            var copticFirstDay = default(int);
            var copticYear = default(int);

            if(gregorianDate.Year % 4 == 0)
            {
                gregorianYearType = DayTypes.leap;
                copticFirstDay = 11;
            }
            else if((gregorianDate.Year + 1) % 4 == 0)
            {
                gregorianYearType = DayTypes.preleap;
                copticFirstDay = 12;
            }
            else
            {
                gregorianYearType = DayTypes.normal;
                copticFirstDay = 11;
            }

            var mapping = _Mappings.Single(m=> 
                m.DayType == gregorianYearType
                && m.GregorianMonth == gregorianDate.Month
                && m.GregorianDay == gregorianDate.Day);

            var copticFormulaDate = new DateTime(gregorianDate.Year, 8, copticFirstDay);

            if (copticFormulaDate <= gregorianDate)
            {
                copticYear = gregorianDate.Year - 283;
            }
            else
            {
                copticYear = gregorianDate.Year - 284;
            }

            return (copticYear, mapping.CopticMonth, mapping.CopticDay);
        }
    }
}
