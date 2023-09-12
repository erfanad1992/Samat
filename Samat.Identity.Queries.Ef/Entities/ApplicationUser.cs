using Microsoft.AspNetCore.Identity;

namespace Samat.Identity.Queries.Ef.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FamilyName { get; set; }
    public string? FirstName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? NationalId { get; set; }
    public int? StateId { get; set; }



    public Guid? UserRoleId { get; set; }
}




