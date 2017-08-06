using System;
using System.Collections.Generic;
using System.Linq;
using Model.EF;

namespace Model.Data
{
    public class ProductCategoryData
    {
        readonly OnlineSellerDbContext _db;

        public ProductCategoryData()
        {
            _db = new OnlineSellerDbContext();
        }

        public long Insert(ProductCat entity)
        {
            _db.ProductCats.Add(entity);
            _db.SaveChanges();
            return entity.ID;
        }

        public List<ProductCat> ListChild(long id)
        {
            return _db.ProductCats.Where(x => x.ParrentID == id).OrderBy(x=>x.DisplayOrder).ToList();
        } 

        public bool UpdateProductCat(ProductCat update)
        {
            try
            {
                var productCats = _db.ProductCats.Find(update.ID);
                productCats.Name = update.Name;
                productCats.ModifiedDate = DateTime.Now;
                productCats.Status = update.Status;
                productCats.DisplayOrder = update.DisplayOrder;
                productCats.MetaKeywords = update.MetaKeywords;
                productCats.MetaDescription = update.MetaDescription;
                productCats.ParrentID = update.ParrentID;
                
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<ProductCat> ListAll()
        {
            return _db.ProductCats.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public List<ProductCat> ListAllForAdmin()
        {
            return _db.ProductCats.Where(x => x.Status == true && x.ParrentID == null).OrderBy(x => x.DisplayOrder).ToList();
        }

        public List<ProductCat> ListChildById(long selectedValue)
        {
            return _db.ProductCats.Where(x => x.ParrentID == selectedValue).ToList();
        }

        public ProductCat ViewDetail(long id)
        {
            return _db.ProductCats.Find(id);
        }
    }
}
