using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Domain.Entities
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public DateTime DatePurchase { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int PurchaseOrderItemId { get; set; }
        public virtual PurchaseOrderItem PurchaseOrderItem { get; set; }
        public int QuoteRequestId { get; set; }
        public virtual QuoteRequest QuoteRequest { get; set; }
    }
}
