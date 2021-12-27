using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataAcessLayer.Models;


namespace DataAcessLayer
{

    public static class FullDataManager
    {
        public static dynamic GetUsersCards()
        {
            var result = from c in DBManager.Instance().DB.Cards
                         join
u in DBManager.Instance().DB.Users on c.UserId equals u.Id

                         select new
                         {
                             UserName = u.Name,
                             UserSurname = u.Surname,
                             Card = c.Number
                         }
                         ;

            return result.ToList();
        }

        public static dynamic GetAvailableOrders()
        {
            var resTemp = from orders in DBManager.Instance().DB.Orders
                          join users in DBManager.Instance().DB.Users on orders.UserId equals users.Id

                          select new
                          {
                              Id = orders.Id,
                              ClientName = users.Name,
                              AddressFrom = orders.AddressFrom,
                              AddressTo = orders.AddressTo,
                              Description = orders.Description,
                              Price = orders.Price,
                              Cash = orders.PayCash,
                              StartTime = orders.StartTime


                          }


                         ;

            var result = resTemp.Where(r => r.StartTime == null);

            return result.ToList();
        }


        public static Cars FoundedDriver(int orderId)
        {
            //DBManager.Instance().DB.Entry(DBManager.Instance().DB.Orders).Reload();
            var result = DBManager.Instance().DB.Orders.Where(r => r.Id == orderId);
            result = result.Where(r => r.CarId != null);

            if (result.Count() > 0)
            {
                Orders order = result.First();

                if (order.CarId == null)
                    return null;

                int CarId = (int)order.CarId;

                Cars car = DBManager.Instance().DB.Cars.Find(CarId);

                return car;
            }
            return null;
        }


        public static Orders FoundedOrder(int userId)
        {

            var result = DBManager.Instance().DB.Orders.Where(r => r.UserId == userId);
            result = result.Where(r => r.CarId == null);
            result = result.Where(r => r.StartTime == null);

            if (result.Count() > 0)
            {
                Orders order = result.First();

              
                return order;
            }
            return null;
        }


    }
}
