using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class 数据库 : DbContext
    {
        #region 183. 从不订购的客户

        public void 从不订购的客户()
        {
            from customer in Customers
            where Orders.FirstOrDefault(order => order.CustomerId == customer.Id) == null
            select customer;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Order
        {
            public int Id { get; set; }
            public int CustomerId { get; set; }
        } 
        #endregion
    }
}
