using DapperDemo.Domain.Entities;
using DapperDemo.Infra.Context;
using DapperDemo.Infra.Repository;
using System;
using System.Collections.Generic;

namespace DapperDemo.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var cn = new DapperDemoContext();

            Console.WriteLine("Dapper Multi Mapping");
            var quotesRepository = new QuoteRequestRepository(cn);
            Console.WriteLine("\nGet Quotations By Purchase Order Id - Objects inside QuoteRequest object");
            foreach (var item in quotesRepository.GetQuotationsByPurchaseOrderId(1))
                Console.WriteLine(item.PurchaseOrderId.ToString() + "|" + item.PriceQuoted + "|" + item.QuantityQuoted
                    + "|" + item.Product.Name + "|" + item.PurchaseOrderItem.Quantity + "|" + item.Supplier.Name);


            var orderRepository = new PurchaseOrderRepository(cn);
            var itemList = new List<PurchaseOrder>(orderRepository.GetItemsByPurchaseOrderId(1));
            Console.WriteLine("\nGet Itens By Purchase Order Id - Collection inside PurchaseOrder object - SQL hard coded");
            bool first = true;
            foreach (var order in itemList) 
            {
                if(first)
                    Console.WriteLine(order.PurchaseOrderId + "|" + order.CreateDate + "|" + order.Status);
                first = false;
                
                foreach (var item in order.PurchaseOrderItems)
                    Console.WriteLine("\t" + item.Product.Name + "| Quantity: " + item.Quantity);
            }

            var spItemList = new List<PurchaseOrder>(orderRepository.spGetItemsByPurchaseOrderId(1));
            Console.WriteLine("\nGet Itens By Purchase Order Id - Collection inside PurchaseOrder object - Store Procedure");
            bool spFirst = true;
            foreach (var order in spItemList)
            {
                if (spFirst)
                    Console.WriteLine(order.PurchaseOrderId + "|" + order.CreateDate + "|" + order.Status);
                spFirst = false;

                foreach (var item in order.PurchaseOrderItems)
                    Console.WriteLine("\t" + item.Product.Name + "| Quantity: " + item.Quantity);
            }
            Console.ReadKey();
        }
    }
}
