using System.Collections.Generic;

namespace DapperDemo.Domain.Entities
{
    public class PurchaseOrderItem
    {
        public PurchaseOrderItem()
        {
            QuoteRequests = new List<QuoteRequest>();
        }
        public int PurchaseOrderItemId { get; set; }
        public int Quantity { get; set; }
        public int PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<QuoteRequest> QuoteRequests { get; set; }
    }
}
