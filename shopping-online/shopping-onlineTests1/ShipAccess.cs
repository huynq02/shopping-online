using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_onlineTests1
{
    public interface IShipAccess
    {
        List<shipping> Getship();
        shipping Getship(int id);
        void create_ship(shipping shipping);
        void delete_ship(int id);
        bool check_ship_exist_status(int id);
    }
    class ShipAccess : IShipAccess
    {
        DBContext DB = new DBContext();
        public ShipAccess()
        {
        }
        public bool check_ship_exist_status(int id)
        {
            var shipping = DB.shippings.Find(id);
            if (shipping != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void create_ship(shipping shipping)
        {
            DB.shippings.Add(shipping);
            DB.SaveChanges();
        }

      

        public void delete_ship(int id)
        {
            shipping shipping = DB.shippings.Find(id);
            DB.shippings.Remove(shipping);
            DB.SaveChanges();
        }

        public List<shipping> Getship()
        {
            var shippings = DB.shippings.ToList();
            return shippings;
        }

        public shipping Getship(int id)
        {
            var shippings = DB.shippings.Find(id);
            return shippings;
        }
    }
}
