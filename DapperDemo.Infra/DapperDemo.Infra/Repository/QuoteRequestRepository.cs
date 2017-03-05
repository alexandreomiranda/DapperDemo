using Dapper;
using DapperDemo.Domain.Entities;
using DapperDemo.Infra.Context;
using System.Collections.Generic;

namespace DapperDemo.Infra.Repository
{
    public class QuoteRequestRepository
    {
        protected DapperDemoContext Db;

        public QuoteRequestRepository(DapperDemoContext context)
        {
            Db = context;
        }
        public IEnumerable<QuoteRequest> GetQuotationsByPurchaseOrderId(int purchaseId)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT t1.QuoteRequestId, t1.PurchaseOrderId, t1.PriceQuoted, t1.QuantityQuoted " +
                ",t2.ProductId, t2.Name, t3.PurchaseOrderItemId, t3.Quantity " +
                ",t4.SupplierId,t4.Name " +
                "FROM QuoteRequest as t1 " +
                "INNER JOIN Product as t2 " +
                "ON t1.ProductId = t2.ProductId " +
                "INNER JOIN PurchaseOrderItem as t3 " +
                "ON t1.PurchaseOrderItemId = t3.PurchaseOrderItemId " +
                "INNER JOIN Supplier as t4 " +
                "ON t1.SupplierId = t4.SupplierId " +
                "WHERE t1.PurchaseOrderId = @sid ORDER BY t2.Name";

            var quotesList = cn.Query<QuoteRequest, Product, PurchaseOrderItem, Supplier, QuoteRequest>(sql,
                (quo, prod, item, supplier) =>
                {
                    quo.Product = prod;
                    quo.PurchaseOrderItem = item;
                    quo.Supplier = supplier;
                    return quo;
                }, new { sid = purchaseId }, splitOn: "QuoteRequestId, ProductId, PurchaseOrderItemId, SupplierId");

            return quotesList;
        }
    }
}
