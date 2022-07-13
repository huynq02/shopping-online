using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace shopping_onlineTests1
{
    public interface IOrderAccess
    {
        List<Order> GetOrder();
        Order GetOrder(int id);
        void create_Oder(Order order);
        void delete_Oder(int id);
        bool checkOrder_exist(int id);
    }
    public class OrderAccess: IOrderAccess
    {
        public OrderAccess()
        {
        }
        DBContext DB = new DBContext();

       

       
        public List<Order> GetOrder()
        {
            var orders = DB.Orders.ToList();
            return orders;
        }

        public Order GetOrder(int id)
        {
            var orders = DB.Orders.Find(id);
            return orders;
        }

        public void create_Oder(Order order)
        {
            DB.Orders.Add(order);
            DB.SaveChanges();
        }
       

        public bool checkOrder_exist(int id)
        {
            var order = DB.Orders.Find(id);
            if (order != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void delete_Oder(int id)
        {
            Order order = DB.Orders.Find(id);
            DB.Orders.Remove(order);
            DB.SaveChanges();
        }
    }
}