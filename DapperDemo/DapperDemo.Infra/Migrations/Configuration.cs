namespace DapperDemo.Infra.Migrations
{
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DapperDemo.Infra.Context.DapperDemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DapperDemo.Infra.Context.DapperDemoContext context)
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product() { ProductId = 1, Name = "Kindle" });
            products.Add(new Product() { ProductId = 2, Name = "Ultrabook" });
            products.Add(new Product() { ProductId = 3, Name = "Laptop" });
            products.Add(new Product() { ProductId = 4, Name = "Tablet" });

            foreach (Product prd in products)
                context.Products.Add(prd);

            IList<Supplier> suppliers = new List<Supplier>();
            suppliers.Add(new Supplier() { SupplierId = 1, Name = "Amazon" });
            suppliers.Add(new Supplier() { SupplierId = 2, Name = "Walmart" });
            suppliers.Add(new Supplier() { SupplierId = 3, Name = "eBay" });

            foreach (Supplier sup in suppliers)
                context.Suppliers.Add(sup);

            
            context.PurchaseOrders.AddOrUpdate(new PurchaseOrder()
            {
                PurchaseOrderId = 1,
                CreateDate = DateTime.Now.AddDays(-3),
                Status = "New",
                PurchaseOrderItems = new List<PurchaseOrderItem>
                {
                    new PurchaseOrderItem()
                    {
                        PurchaseOrderItemId = 1, Quantity = 7, PurchaseOrderId = 1, ProductId = 1,
                        QuoteRequests = new List<QuoteRequest>
                        {
                            new QuoteRequest()
                            {
                                QuoteRequestId = 1, QuantityQuoted = 7,
                                PriceQuoted = 700m, SupplierId = 1, PurchaseOrderId = 1,
                                PurchaseOrderItemId = 1, ProductId = 1
                            },
                            new QuoteRequest()
                            {
                                QuoteRequestId = 2, QuantityQuoted = 7,
                                PriceQuoted = 790m, SupplierId = 2, PurchaseOrderId = 1,
                                PurchaseOrderItemId = 1, ProductId = 1
                            },

                        }
                    },

                    new PurchaseOrderItem()
                    {
                        PurchaseOrderItemId = 2, Quantity = 5, PurchaseOrderId = 1, ProductId = 2,
                        QuoteRequests = new List<QuoteRequest>()
                        {
                            new QuoteRequest()
                            {
                                QuoteRequestId = 3, QuantityQuoted = 5,
                                PriceQuoted = 2500m, SupplierId = 1, PurchaseOrderId = 1,
                                PurchaseOrderItemId = 2, ProductId = 2
                            },
                            new QuoteRequest()
                            {
                                QuoteRequestId = 4, QuantityQuoted = 5,
                                PriceQuoted = 2700m, SupplierId = 2, PurchaseOrderId = 1,
                                PurchaseOrderItemId = 2, ProductId = 2
                            },
                            new QuoteRequest()
                            {
                                QuoteRequestId = 5, QuantityQuoted = 5,
                                PriceQuoted = 2300m, SupplierId = 3, PurchaseOrderId = 1,
                                PurchaseOrderItemId = 2, ProductId = 2
                            }
                        }
                    },
                    
                    new PurchaseOrderItem()
                    {
                        PurchaseOrderItemId = 3, Quantity = 10, PurchaseOrderId = 2, ProductId = 3,
                        QuoteRequests = new List<QuoteRequest>()
                        {
                            new QuoteRequest()
                            {
                                QuoteRequestId = 6, QuantityQuoted = 10,
                                PriceQuoted = 5000m, SupplierId = 1, PurchaseOrderId = 1,
                                PurchaseOrderItemId = 3, ProductId = 3
                            },
                            new QuoteRequest()
                            {
                                QuoteRequestId = 7, QuantityQuoted = 10,
                                PriceQuoted = 5500m, SupplierId = 2, PurchaseOrderId = 1,
                                PurchaseOrderItemId = 3, ProductId = 3
                            },
                            new QuoteRequest()
                            {
                                QuoteRequestId = 8, QuantityQuoted = 10,
                                PriceQuoted = 4800m, SupplierId = 3, PurchaseOrderId = 1,
                                PurchaseOrderItemId = 3, ProductId = 3
                            }
                        }
                    },
                }
                
            });
            context.PurchaseOrders.AddOrUpdate(new PurchaseOrder()
            {
                PurchaseOrderId = 2,
                CreateDate = DateTime.Now.AddDays(-2),
                Status = "New",
                PurchaseOrderItems = new List<PurchaseOrderItem>
                {
                    new PurchaseOrderItem()
                    {
                        PurchaseOrderItemId = 4, Quantity = 20, PurchaseOrderId = 2, ProductId = 4,
                        QuoteRequests = new List<QuoteRequest>
                        {
                            new QuoteRequest()
                            {
                                QuoteRequestId = 9, QuantityQuoted = 20,
                                PriceQuoted = 3200m, SupplierId = 2, PurchaseOrderId = 2,
                                PurchaseOrderItemId = 4, ProductId = 4
                            },
                            new QuoteRequest()
                            {
                                QuoteRequestId = 10, QuantityQuoted = 20,
                                PriceQuoted = 3000m, SupplierId = 3, PurchaseOrderId = 2,
                                PurchaseOrderItemId = 4, ProductId = 4
                            },
                        }
                    }
                }

            });
            context.Purchases.AddOrUpdate(new Purchase()
            {
                PurchaseId = 1, DatePurchase = DateTime.Now.AddDays(-1), Price = 700m, SupplierId = 1,
                ProductId = 1, PurchaseOrderItemId = 1, QuoteRequestId = 1
            });
            context.Purchases.AddOrUpdate(new Purchase()
            {
                PurchaseId = 2, DatePurchase = DateTime.Now.AddDays(-1), Price = 2300m, SupplierId = 3,
                ProductId = 2, PurchaseOrderItemId = 2, QuoteRequestId = 5
            });
            context.Purchases.AddOrUpdate(new Purchase()
            {
                PurchaseId = 3, DatePurchase = DateTime.Now, Price = 4800m, SupplierId = 3,
                ProductId = 3, PurchaseOrderItemId = 3, QuoteRequestId = 8
            });
            context.Purchases.AddOrUpdate(new Purchase()
            {
                PurchaseId = 4, DatePurchase = DateTime.Now, Price = 3000m, SupplierId = 3,
                ProductId = 4, PurchaseOrderItemId = 4, QuoteRequestId = 10
            });
            base.Seed(context);
        }
    }
}
