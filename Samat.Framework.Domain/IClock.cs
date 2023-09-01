namespace Samat.Framework.Domain;

public interface IClock
{
    DateTimeOffset Now();
    void SetDate(DateTimeOffset? dateTimeOffset);
}