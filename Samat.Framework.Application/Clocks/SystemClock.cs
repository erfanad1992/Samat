using Samat.Framework.Domain;

namespace Samat.Framework.Application.Clocks;

public class SystemClock : IClock
{
    private DateTimeOffset? _dateTimeOffset;
    public DateTimeOffset Now()
    {
        if (_dateTimeOffset.HasValue)
            return _dateTimeOffset.Value;
        return DateTimeOffset.Now;
    }

    public void SetDate(DateTimeOffset? dateTimeOffset)
    {
        _dateTimeOffset = dateTimeOffset;
    }
}