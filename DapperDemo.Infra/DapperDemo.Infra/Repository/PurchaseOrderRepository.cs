using Dapper;
using DapperDemo.Domain.Entities;
using DapperDemo.Infra.Context;
using System.Collections.Generic;
using System.Data;

namespace DapperDemo.Infra.Repository
{
    public class PurchaseOrderRepository
    {
        protected DapperDemoContext Db;

        public PurchaseOrderRepository(DapperDemoContext context)
        {
            Db = context;
        }

        public IEnumerable<PurchaseOrder> GetItemsByPurchaseOrderId(int purchaseOrderId)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT t1.PurchaseOrderId, t1.CreateDate, t1.Status " +
				",t2.PurchaseOrderItemId, t2.Quantity " +
                ",t3.ProductId, t3.Name " +
                "FROM PurchaseOrder as t1 " +
                "INNER JOIN PurchaseOrderItem as t2 " +
                "ON t1.PurchaseOrderId = t2.PurchaseOrderID " +
                "INNER JOIN Product as t3 " +
                "ON t2.ProductId = t3.ProductId " +
                "WHERE t1.PurchaseOrderId = @sid";

            var orderItemsList = cn.Query<PurchaseOrder, PurchaseOrderItem, Product, PurchaseOrder>(sql,
                (order, item, prod) =>
                {
                    order.PurchaseOrderItems.Add(item);
                    item.Product = prod;
                    return order;
                }, new { sid = purchaseOrderId }, splitOn: "PurchaseOrderId, PurchaseOrderItemId, ProductId");

            return orderItemsList;
        }

        public IEnumerable<PurchaseOrder> spGetItemsByPurchaseOrderId(int purchaseOrderId)
        {
            var cn = Db.Database.Connection;

            var orderItemsList = cn.Query<PurchaseOrder, PurchaseOrderItem, Product, PurchaseOrder>("spGetItemsByOrder",
                (order, item, prod) =>
                {
                    order.PurchaseOrderItems.Add(item);
                    item.Product = prod;
                    return order;
                }, new { Id = purchaseOrderId }, splitOn: "PurchaseOrderId, PurchaseOrderItemId, ProductId", commandType: CommandType.StoredProcedure);

            return orderItemsList;
        }
    }
}
