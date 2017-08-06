using Model.EF;
using System.Collections.Generic;
using System.Linq;
namespace Model.Data
{
    public class CategoryData
    {
        private OnlineSellerDbContext _db;

        public CategoryData()
        {
            _db = new OnlineSellerDbContext();
        }

        public List<Category> ListAll()
        {
            return _db.Categories.Where(x => x.Status == true).ToList();
        }

    }
}