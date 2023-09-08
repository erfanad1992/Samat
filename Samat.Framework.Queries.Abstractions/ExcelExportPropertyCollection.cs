namespace Samat.Framework.Queries.Abstractions;

public abstract class ExcelExportPropertyCollection : ISortablePropertyCollection
{
    const string Id = "Id";

    public string GetDefault()
    {
        return Id;
    }
}