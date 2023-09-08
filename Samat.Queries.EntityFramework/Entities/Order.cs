using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Samat.Queries.EntityFramework.Entities;

[Table("Order")]
[Index("CustomerId", Name = "IX_Order_CustomerId")]
public partial class Order
{
    [Key]
    public long Id { get; set; }

    public long CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Orders")]
    public virtual Customer Customer { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
