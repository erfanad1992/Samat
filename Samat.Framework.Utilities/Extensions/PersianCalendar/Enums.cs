using System.ComponentModel;

namespace Samat.Framework.Utilities.Extensions.PersianCalendar;
public class Enums
{
    public enum DateRanges
    {
        [Description("امروز")]
        Today = 0,
        [Description("فردا")]
        Tomorrow = 1,
        [Description("دیروز")]
        Yesterday = 2,

        [Description("هفته جاری")]
        CurrentWeek = 3,
        [Description("هفته آینده")]
        NextWeek = 4,
        [Description("هفته گذشته")]
        LastWeek = 5,

        [Description("ماه جاری")]
        CurrentMonth = 6,
        [Description("ماه آینده")]
        NextMonth = 7,
        [Description("ماه گذشته")]
        LastMonth = 8,

        [Description("فصل جاری")]
        CurrentSeason = 9,
        [Description("فصل آینده")]
        NextSeason = 10,
        [Description("فصل گذشته")]
        LastSeason = 11,

        [Description("سال جاری")]
        CurrentYear = 12,
        [Description("سال آینده")]
        NextYear = 13,
        [Description("سال گذشته")]
        LastYear = 14
    }


    public enum Seasons
    {
        [Description("بهار")]
        Spring = 1,
        [Description("تابستان")]
        Summer = 2,
        [Description("پاییز")]
        Fall = 3,
        [Description("زمستان")]
        Winter = 4
    }
}