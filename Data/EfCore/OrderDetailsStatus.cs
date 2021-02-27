using System;
using System.Collections.Generic;

#nullable disable

namespace ef_core_st.Data.EfCore
{
    public partial class OrderDetailsStatus
    {
        public OrderDetailsStatus()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
