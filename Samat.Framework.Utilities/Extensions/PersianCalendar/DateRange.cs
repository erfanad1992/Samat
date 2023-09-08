namespace Samat.Framework.Utilities.Extensions.PersianCalendar;
public class DateRange
{
    public DateRange(DateTimeOffset fromDate, DateTimeOffset toDate)
    {
        FromDate = fromDate;
        ToDate = toDate;
    }

    public DateTimeOffset FromDate { get; private set; }
    public DateTimeOffset ToDate { get; private set; }
}
