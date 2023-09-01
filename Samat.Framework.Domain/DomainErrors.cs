namespace Samat.Framework.Domain;

public static class DomainErrors
{
    public static string NotFound(long? id = null)
    {
        string forId = id == null ? "" : $" for Id '{id}'";
        return $"Record not found{forId}";
    }

    public static string ValueIsInvalid() => "Value is invalid";

    public static string ValueIsRequired() => "Value is required";

    public static string InvalidLength(string? name = null)
    {
        string label = name == null ? " " : " " + name + " ";
        return $"Invalid{label}length";
    }

    public static string CollectionIsTooSmall(int min, int current)
    {
        return $"The collection must contain {min} items or more. It contains {current} items.";
    }

    public static string CollectionIsTooLarge(int max, int current)
    {
        return $"The collection must contain {max} items or more. It contains {current} items.";
    }

    public static string InternalServerError(string message)
    {
        return message;
    }
}
