using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Samat.Queries.EntityFramework.Entities;

[Table("Product")]
public partial class Product
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
