using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Domain.Entities
{
    public class QuoteRequest
    {
        public int QuoteRequestId { get; set; }
        public int QuantityQuoted { get; set; }
        public decimal PriceQuoted { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public int PurchaseOrderItemId { get; set; }
        public virtual PurchaseOrderItem PurchaseOrderItem { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
