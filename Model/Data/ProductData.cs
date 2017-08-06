using System;
using System.Collections.Generic;
using System.Linq;
using Model.EF;
using PagedList;
namespace Model.Data
{
    public class ProductData
    {
        private OnlineSellerDbContext _db;

        public ProductData()
        {
            _db = new OnlineSellerDbContext();
        }

        public Product GetbyId(long id)
        {
            return _db.Products.Find(id);
        }

        public IPagedList<Product> ProductList(string searchStr, int page, int pagesize)
        {
            IQueryable<Product> model = _db.Products;
            if (!string.IsNullOrEmpty(searchStr))
            {
                model = model.Where(x => x.Name.Contains(searchStr) || x.Description.Contains(searchStr));
            }
            return model.OrderByDescending(x => x.ViewCount).ToPagedList(page, pagesize);
        }

        public IPagedList<Product> ListByCateId(long cateId,int page = 1, int pageSize = 10)
        {
            IQueryable<Product> model = _db.Products;
            return model.Where(x=>x.CatID == cateId).OrderByDescending(x => x.ViewCount).ToPagedList(page, pageSize);
        }

        public List<Product> ListNewProduct(int top)
        {
            return _db.Products.OrderByDescending(x=>x.CreatedDate).Take(top).ToList();
        }

        public long Insert(Product entity)
        {
            _db.Products.Add(entity);
            _db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Product updateProduct)
        {
            try
            {
                var product = _db.Products.Find(updateProduct.ID);
                product.Name = updateProduct.Name;
                product.Details = updateProduct.Details;
                product.Description = updateProduct.Description;
                product.CatID = updateProduct.CatID;
                product.Img = updateProduct.Img;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var product = _db.Products.Find(id);
                _db.Products.Remove(product);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<string> ListName(string keyword)
        {
            return _db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

        public List<Product> ListFeatureProduct(int top)
        {
            return _db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListRelatedProducts(long productId)
        {
            var product = _db.Products.Find(productId);
            return _db.Products.Where(x => x.ID != productId && x.CatID == product.CatID).ToList();
        }

        public Product Detail(long id)
        {
            return _db.Products.Find(id);
        }

        public List<Product> ListByCateId(long cateId,ref int totalRecord,int pageIndex = 1, int pageSize = 10)
        {
            totalRecord = _db.Products.Count(x => x.CatID == cateId);
            return _db.Products.Where(x => x.CatID == cateId && x.Status == true).OrderByDescending(x=>x.CreatedDate).Skip((pageSize-1)*pageIndex).Take(pageSize).ToList();
        }
    }
}
