using System.Collections.Generic;
using System.Linq;
using Model.EF;

namespace Model.Data
{
    public class FooterData
    {
        private readonly OnlineSellerDbContext _db;

        public FooterData()
        {
            _db = new OnlineSellerDbContext();
        }

        public List<Footer> GetFooter()
        {
            return _db.Footers.Where(x =>x.Status).ToList();
        }
    }
}
