using System.Globalization;
using System.Runtime.CompilerServices;

namespace Samat.Framework.Utilities.Extensions.PersianCalendar;
public static class PersianCalendarExtensions
{
    public static DateRange GetDateRange(this Enums.DateRanges range, DateTimeOffset? relativeDate = null)
    {
        var currentDate = relativeDate ?? DateTimeOffset.Now;
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time");

        var persianCalendar = new System.Globalization.PersianCalendar();
        switch (range)
        {
            case Enums.DateRanges.Today:
                {
                    var from = new DateTimeOffset(currentDate.Year,
                        currentDate.Month,
                        currentDate.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(1).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.Tomorrow:
                {
                    var nextDay = currentDate.AddDays(1);
                    var from = new DateTimeOffset(nextDay.Year,
                        nextDay.Month,
                        nextDay.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(1).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.Yesterday:
                {
                    var lastDay = currentDate.AddDays(-1);
                    var from = new DateTimeOffset(lastDay.Year,
                        lastDay.Month,
                        lastDay.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(1).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.CurrentWeek:
                {
                    var dayOfWeek = persianCalendar.GetDayOfWeek(currentDate.LocalDateTime);
                    var diffFromSaturday = dayOfWeek switch
                    {
                        DayOfWeek.Saturday => 0,
                        DayOfWeek.Sunday => -1,
                        DayOfWeek.Monday => -2,
                        DayOfWeek.Tuesday => -3,
                        DayOfWeek.Wednesday => -4,
                        DayOfWeek.Thursday => -5,
                        DayOfWeek.Friday => -6,
                        _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), $"Not expected value: {dayOfWeek}"),
                    };

                    var startDate = currentDate.AddDays(diffFromSaturday);
                    var from = new DateTimeOffset(startDate.Year,
                        startDate.Month,
                        startDate.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(7).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.NextWeek:
                {
                    var nextWeek = currentDate.AddDays(7);
                    var dayOfWeek = persianCalendar.GetDayOfWeek(nextWeek.LocalDateTime);
                    var diffFromSaturday = dayOfWeek switch
                    {
                        DayOfWeek.Saturday => 0,
                        DayOfWeek.Sunday => -1,
                        DayOfWeek.Monday => -2,
                        DayOfWeek.Tuesday => -3,
                        DayOfWeek.Wednesday => -4,
                        DayOfWeek.Thursday => -5,
                        DayOfWeek.Friday => -6,
                        _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), $"Not expected value: {dayOfWeek}"),
                    };

                    var startDate = nextWeek.AddDays(diffFromSaturday);
                    var from = new DateTimeOffset(startDate.Year,
                        startDate.Month,
                        startDate.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(7).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.LastWeek:
                {
                    var lastWeek = currentDate.AddDays(-7);
                    var dayOfWeek = persianCalendar.GetDayOfWeek(lastWeek.LocalDateTime);
                    var diffFromSaturday = dayOfWeek switch
                    {
                        DayOfWeek.Saturday => 0,
                        DayOfWeek.Sunday => -1,
                        DayOfWeek.Monday => -2,
                        DayOfWeek.Tuesday => -3,
                        DayOfWeek.Wednesday => -4,
                        DayOfWeek.Thursday => -5,
                        DayOfWeek.Friday => -6,
                        _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), $"Not expected value: {dayOfWeek}"),
                    };

                    var startDate = lastWeek.AddDays(diffFromSaturday);
                    var from = new DateTimeOffset(startDate.Year,
                        startDate.Month,
                        startDate.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(7).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.CurrentMonth:
                {
                    var dayOfMonth = persianCalendar.GetDayOfMonth(currentDate.LocalDateTime);
                    var diff = dayOfMonth - 1;
                    var startOfMonth = currentDate.AddDays(-1 * diff);

                    var from = new DateTimeOffset(startOfMonth.Year,
                        startOfMonth.Month,
                        startOfMonth.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(persianCalendar.GetDaysInMonth(
                        persianCalendar.GetYear(from.LocalDateTime),
                        persianCalendar.GetMonth(from.LocalDateTime))).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.NextMonth:
                {
                    var nextMonth = currentDate.AddMonths(1);
                    var dayOfMonth = persianCalendar.GetDayOfMonth(nextMonth.LocalDateTime);
                    var diff = dayOfMonth - 1;
                    var startOfMonth = nextMonth.AddDays(-1 * diff);

                    var from = new DateTimeOffset(startOfMonth.Year,
                        startOfMonth.Month,
                        startOfMonth.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(persianCalendar.GetDaysInMonth(
                        persianCalendar.GetYear(from.LocalDateTime),
                        persianCalendar.GetMonth(from.LocalDateTime))).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.LastMonth:
                {
                    var lastMonth = currentDate.AddMonths(-1);
                    var dayOfMonth = persianCalendar.GetDayOfMonth(lastMonth.LocalDateTime);
                    var diff = dayOfMonth - 1;
                    var startOfMonth = lastMonth.AddDays(-1 * diff);

                    var from = new DateTimeOffset(startOfMonth.Year,
                        startOfMonth.Month,
                        startOfMonth.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(persianCalendar.GetDaysInMonth(
                        persianCalendar.GetYear(from.LocalDateTime),
                        persianCalendar.GetMonth(from.LocalDateTime))).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.CurrentSeason:
                {
                    var currentSeason = currentDate.GetSeason();
                    var fromTo = currentSeason.GetSeasonFromTo(persianCalendar.GetYear(currentDate.LocalDateTime));

                    var startOfYear = persianCalendar.ToDateTime(persianCalendar.GetYear(currentDate.LocalDateTime),
                        1,
                        1, 0, 0, 0, 0);

                    var from = startOfYear.AddDays(fromTo.Item1 - 1);
                    var to = startOfYear.AddDays(fromTo.Item2).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.NextSeason:
                {
                    var nextSeason = currentDate.AddMonths(3);
                    var currentSeason = nextSeason.GetSeason();
                    var fromTo = currentSeason.GetSeasonFromTo(persianCalendar.GetYear(nextSeason.LocalDateTime));

                    var startOfYear = persianCalendar.ToDateTime(persianCalendar.GetYear(nextSeason.LocalDateTime),
                        1,
                        1, 0, 0, 0, 0);

                    var from = startOfYear.AddDays(fromTo.Item1 - 1);
                    var to = startOfYear.AddDays(fromTo.Item2).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.LastSeason:
                {
                    var lastSeason = currentDate.AddMonths(-3);
                    var currentSeason = lastSeason.GetSeason();
                    var fromTo = currentSeason.GetSeasonFromTo(persianCalendar.GetYear(lastSeason.LocalDateTime));

                    var startOfYear = persianCalendar.ToDateTime(persianCalendar.GetYear(lastSeason.LocalDateTime),
                        1,
                        1, 0, 0, 0, 0);

                    var from = startOfYear.AddDays(fromTo.Item1 - 1);
                    var to = startOfYear.AddDays(fromTo.Item2).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.CurrentYear:
                {
                    var currentYear = persianCalendar.ToDateTime(persianCalendar.GetYear(currentDate.LocalDateTime),
                        1,
                        1, 0, 0, 0, 0);

                    var from = new DateTimeOffset(currentYear.Year,
                        currentYear.Month,
                        currentYear.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(persianCalendar.GetDaysInYear(
                        persianCalendar.GetYear(from.LocalDateTime))).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.NextYear:
                {
                    var nextYear = currentDate.AddYears(1);
                    var nextYearDate = persianCalendar.ToDateTime(persianCalendar.GetYear(nextYear.LocalDateTime),
                        1,
                        1, 0, 0, 0, 0);

                    var from = new DateTimeOffset(nextYearDate.Year,
                        nextYearDate.Month,
                        nextYearDate.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(persianCalendar.GetDaysInYear(
                        persianCalendar.GetYear(from.LocalDateTime))).AddTicks(-1);

                    return new DateRange(from, to);
                }
            case Enums.DateRanges.LastYear:
                {
                    var lastYear = currentDate.AddYears(-1);
                    var lastYearDate = persianCalendar.ToDateTime(persianCalendar.GetYear(lastYear.LocalDateTime),
                        1,
                        1, 0, 0, 0, 0);

                    var from = new DateTimeOffset(lastYearDate.Year,
                        lastYearDate.Month,
                        lastYearDate.Day,
                        0,
                        0,
                        0,
                        timeZone.BaseUtcOffset);
                    var to = from.AddDays(persianCalendar.GetDaysInYear(
                        persianCalendar.GetYear(from.LocalDateTime))).AddTicks(-1);

                    return new DateRange(from, to);
                }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    public static Enums.Seasons GetSeason(this DateTimeOffset dateTimeOffset)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        var currentMonth = persianCalendar.GetMonth(dateTimeOffset.LocalDateTime);
        return currentMonth switch
        {
            <= 3 => Enums.Seasons.Spring,
            <= 6 => Enums.Seasons.Summer,
            <= 9 => Enums.Seasons.Fall,
            _ => Enums.Seasons.Winter
        };
    }

    public static Tuple<int, int> GetSeasonFromTo(this Enums.Seasons season, int year)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();

        int from;
        int to;

        switch (season)
        {
            case Enums.Seasons.Spring:
                {
                    from = 1;
                    to = persianCalendar.GetDaysInMonth(year, 1) +
                            persianCalendar.GetDaysInMonth(year, 2) +
                            persianCalendar.GetDaysInMonth(year, 3);
                }
                break;
            case Enums.Seasons.Summer:
                {
                    from = Enums.Seasons.Spring.GetSeasonFromTo(year).Item2 + 1;

                    to = from + persianCalendar.GetDaysInMonth(year, 4) +
                            persianCalendar.GetDaysInMonth(year, 5) +
                            persianCalendar.GetDaysInMonth(year, 6) - 1;
                }
                break;
            case Enums.Seasons.Fall:
                {
                    from = Enums.Seasons.Summer.GetSeasonFromTo(year).Item2 + 1;

                    to = from + persianCalendar.GetDaysInMonth(year, 7) +
                        persianCalendar.GetDaysInMonth(year, 8) +
                        persianCalendar.GetDaysInMonth(year, 9) - 1;
                }
                break;
            case Enums.Seasons.Winter:
                {
                    from = Enums.Seasons.Fall.GetSeasonFromTo(year).Item2 + 1;

                    to = from + persianCalendar.GetDaysInMonth(year, 10) +
                        persianCalendar.GetDaysInMonth(year, 11) +
                        persianCalendar.GetDaysInMonth(year, 12) - 1;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(season), season, null);
        }

        return new Tuple<int, int>(from, to);
    }
}
