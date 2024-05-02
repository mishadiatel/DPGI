using System;
using System.Collections.Generic;

namespace Lab5;

public partial class Product
{
    public int Id { get; set; }

    public string? Article { get; set; }

    public int? Unitcode { get; set; }

    public string? Quantity { get; set; }

    public string? Price { get; set; }

    public virtual Unit? UnitcodeNavigation { get; set; }
}
