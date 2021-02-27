﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ef_core_st.Data.EfCore
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public double Discount { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateAllocated { get; set; }
        public int? PurchaseOrderId { get; set; }
        public int? InventoryId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual OrderDetailsStatus Status { get; set; }
    }
}
