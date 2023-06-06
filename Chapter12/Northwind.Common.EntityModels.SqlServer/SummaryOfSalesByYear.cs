﻿using System;
using System.Collections.Generic;

namespace Northwind.Common.EntityModels.SqlServer;

public partial class SummaryOfSalesByYear
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
