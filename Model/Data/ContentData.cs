using System.Collections.Generic;
using System.Linq;
using Model.EF;
using PagedList;
namespace Model.Data
{
    public class ContentData
    {
        readonly OnlineSellerDbContext _db;

        public static string USER_SESSION = "USER_SESSION";

        public ContentData()
        {
            _db = new OnlineSellerDbContext();
        }

        public long InsertContent(Content model)
        {
            _db.Contents.Add(model);
            _db.SaveChanges();
            return model.ID;
        }

        public IEnumerable<Content> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Content> model = _db.Contents;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public IEnumerable<Content> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Content> model = _db.Contents;
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public IEnumerable<Content> ListAllByTag(string tag, int page, int pageSize)
        {
            var model = (from a in _db.Contents
                         join b in _db.ContentTags
                         on a.ID equals b.ContentID
                         where b.TagID == tag
                         select new
                         {
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Image = a.Image,
                             Description = a.Description,
                             CreatedDate = a.CreatedDate,
                             CreatedBy = a.CreatedBy,
                             ID = a.ID

                         }).AsEnumerable().Select(x => new Content()
                         {
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Image = x.Image,
                             Description = x.Description,
                             CreatedDate = x.CreatedDate,
                             CreatedBy = x.CreatedBy,
                             ID = x.ID
                         });
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public Content GetById(long id)
        {
            return _db.Contents.Find(id);
        }

        public Tag GetTag(string id)
        {
            return _db.Tags.Find(id);
        }
        
    }
}
