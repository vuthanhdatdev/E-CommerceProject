using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Data
{
    public class SlideData
    {
        private readonly OnlineSellerDbContext _db;

        public SlideData()
        {
            _db= new OnlineSellerDbContext();
        }

        public List<Slide> GetSlides()
        {
            return _db.Slides.Where(x => x.Status == true).ToList();
        }
    }
}
