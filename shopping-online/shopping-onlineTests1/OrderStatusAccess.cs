using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using shopping_online.Context;
using System;
using System.Collections.Generic;
using shopping_online.Context;
using System.Linq;

namespace shopping_onlineTests1
{
    public interface IOrderStatusAccess
    {
        List<Order_status> GetOrder_Status();
        Order_status GetOrder_status(int id);
        void create_Oder_status(Order_status order_Status);
        void delete_Oder_status(int id);
        bool checkOrder_exist_status(int id);
    }
    public class OrderStatusAccess : IOrderStatusAccess
    {
        public OrderStatusAccess()
        {
        }
        DBContext DB = new DBContext();


        public List<Order_status> GetOrder_Status()
        {
            var orders = DB.Order_status.ToList();
            return orders;
        }

        public Order_status GetOrder_status(int id)
        {
            var orders = DB.Order_status.Find(id);
            return orders;
        }

        public bool checkOrder_exist_status(int id)
        {
            var order = DB.Order_status.Find(id);
            if (order != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void create_Oder_status(Order_status order_Status)
        {
            DB.Order_status.Add(order_Status);
            DB.SaveChanges();
        }

        public void delete_Oder_status(int id)
        {
            var order = DB.Order_status.Find(id);
            DB.Order_status.Add(order);
            DB.SaveChanges();
        }
    }
}