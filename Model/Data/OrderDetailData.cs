using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Data
{
    public class OrderDetailData
    {
        private OnlineSellerDbContext _db;
        public OrderDetailData()
        {
            _db = new OnlineSellerDbContext();
        }
        public bool Insert(OrderDetail detail)
        {
            try
            {
                _db.OrderDetails.Add(detail);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
