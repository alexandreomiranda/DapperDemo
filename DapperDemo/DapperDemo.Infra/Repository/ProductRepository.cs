using Dapper;
using DapperDemo.Domain.Entities;
using DapperDemo.Infra.Context;
using System.Collections.Generic;

namespace DapperDemo.Infra.Repository
{
    public class ProductRepository
    {
        protected DapperDemoContext Db;
        public ProductRepository(DapperDemoContext context)
        {
            Db = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Product";
            return cn.Query<Product>(sql);
        }
    }

}
