using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Samat.Queries.EntityFramework.Entities;

[Table("Customer")]
public partial class Customer
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(100)]
    public string NationalCode { get; set; }

    [Required]
    [StringLength(200)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(200)]
    public string LastName { get; set; }

    public DateTime LastPurchaseDate { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
