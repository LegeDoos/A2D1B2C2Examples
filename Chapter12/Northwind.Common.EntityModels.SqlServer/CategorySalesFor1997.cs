using System;
using System.Collections.Generic;

namespace Northwind.Common.EntityModels.SqlServer;

public partial class CategorySalesFor1997
{
    public string CategoryName { get; set; } = null!;

    public decimal? CategorySales { get; set; }
}
