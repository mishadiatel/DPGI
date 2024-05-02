using System;
using System.Collections.Generic;

namespace Lab5;

public partial class Unit
{
    public int Id { get; set; }

    public string? Unit1 { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}