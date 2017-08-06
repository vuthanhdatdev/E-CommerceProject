using System;
using System.Collections.Generic;
using System.Linq;
using Model.EF;

namespace Model.Data
{
    public class MenuData
    {
        private readonly OnlineSellerDbContext _db;

        public MenuData()
        {
            _db = new OnlineSellerDbContext();
        }

        public List<Menu> ListByGroupId(int groupId)
        {
            return _db.Menus.Where(x => x.TypeID == groupId &&  x.Status).OrderBy(x=>x.DisplayOrder).ToList();
        }

        public long InsertMenu(Menu entity)
        {
            _db.Menus.Add(entity);
            _db.SaveChanges();
            return entity.ID;
        }

        public bool UpdateMenu(Menu update)
        {
            try
            {
                var data = _db.Menus.Find(update.ID);
                data.Status = update.Status;
                data.Link = update.Link;
                data.Text = update.Text;
                data.TypeID = update.ID;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangeStatus(long id)
        {
            var menu = _db.Menus.Find(id);
            menu.Status = !menu.Status;
            _db.SaveChanges();
            return menu.Status;
        }
    }
}
