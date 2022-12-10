// See https://aka.ms/new-console-template for more information
using CopticCalendar.App;

int GregorianYear, GregorianMonth, GregorianDay;
GregorianYear = GregorianMonth = GregorianDay = default(int);

bool parseYearSucceeded, parseMonthSucceeded, parseDaySucceeded;
parseYearSucceeded = parseMonthSucceeded = parseDaySucceeded = false;

if(args.Count() != 3)
{
    Console.WriteLine("invalid syntax.");
    Console.WriteLine("CopticCalendar.App [gregorian year] [gregorian month] [gregorian day]");
    //Environment.Exit(-1);

    Console.WriteLine("example:");

    DateTime runDate = DateTime.Now;
    GregorianYear = runDate.Year;
    GregorianMonth = runDate.Month;
    GregorianDay = runDate.Day;
    parseYearSucceeded = parseMonthSucceeded = parseDaySucceeded = true;

    Console.WriteLine($"CopticCalendar.App {GregorianYear} {GregorianMonth} {GregorianDay}");
}
else
{
    parseYearSucceeded = int.TryParse(args[0], out GregorianYear);
    parseMonthSucceeded = int.TryParse(args[1], out GregorianMonth);
    parseDaySucceeded = int.TryParse(args[2], out GregorianDay);
}

if (!parseYearSucceeded) Console.WriteLine($"invalid gregorian year {args[0]}");
if (!parseMonthSucceeded) Console.WriteLine($"invalid gregorian month {args[1]}");
if (!parseDaySucceeded) Console.WriteLine($"invalid gregorian day {args[2]}");

if (!parseYearSucceeded || !parseMonthSucceeded || !parseDaySucceeded) Environment.Exit(-2);

ConfigurationHelper _Config = new();

CopticCalculator _Calculator = new(_Config.Mappings);
var (copticYear, copticMonth, copticDay) = _Calculator.CalculateCopticDate(new DateTime(GregorianYear, GregorianMonth, GregorianDay));

Console.WriteLine($"coptic date: {copticYear}-{copticMonth}-{copticDay}");
