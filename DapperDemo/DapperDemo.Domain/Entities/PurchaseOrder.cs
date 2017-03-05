using System;
using System.Collections.Generic;

namespace DapperDemo.Domain.Entities
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderItems = new List<PurchaseOrderItem>();
        }
        public int PurchaseOrderId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }
}
