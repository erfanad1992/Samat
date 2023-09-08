using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Samat.Queries.EntityFramework.Entities;

[Table("OrderItem")]
[Index("OrderId", Name = "IX_OrderItem_OrderId")]
[Index("ProductId", Name = "IX_OrderItem_ProductId")]
public partial class OrderItem
{
    [Key]
    public long Id { get; set; }

    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public int Quantity { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order Order { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("OrderItems")]
    public virtual Product Product { get; set; }
}
