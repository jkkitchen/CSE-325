Console.WriteLine("Hello, World!");
//Written using interpolated string rather that string concatenation:
Console.WriteLine($"The current time is {DateTime.Now}");

//NUMBER OF DAYS UNTIL CHRISTMAS
//Format of DateTime is (year, month, day, hour, minute, second)
DateTime christmas = new DateTime(2026, 12, 25, 0, 0, 0);

//Timespan is the difference between two DateTimes
TimeSpan daysUntilChristmas = christmas - DateTime.Now;
//Using .Days extracts the whole day component of DateTime
Console.WriteLine($"There are {daysUntilChristmas.Days} days until Christmas!");
