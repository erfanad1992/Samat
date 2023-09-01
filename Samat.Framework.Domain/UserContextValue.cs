namespace Samat.Framework.Domain;

public class UserContextValue
{
    public long Id { get; set; }
    public string? Username { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }

    public UserContextValue(long id, string? username, string? fullName, string? email, string? mobile)
    {
        Id = id;
        Username = username;
        FullName = fullName;
        Email = email;
        Mobile = mobile;
    }

    public UserContextValue() { }
}