using System;
using System.Collections.Generic;
using System.Linq;
using Model.Common;
using Model.EF;
using PagedList;
using PagedList.Mvc;
namespace Model.Data
{
    public class UserData
    {
        OnlineSellerDbContext db = null;

        public UserData()
        {
            db = new OnlineSellerDbContext();
        }


        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        public IPagedList<User> ListPaging(string searchStr, int page, int pagesize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchStr))
            {
                model = model.Where(x => x.UserName.Contains(searchStr) || x.Name.Contains(searchStr));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page,pagesize);
        }

        public User GetBy_UserName(string username)
        {
            return db.Users.SingleOrDefault(x=>x.UserName == username);
        }

        public User GetById(int id)
        {
            return db.Users.Find(id);
        }

        public bool UpdateUser(User update)
        {
            try
            {
                var user = db.Users.Find(update.ID);
                user.Name = update.Name;
                if (!string.IsNullOrEmpty(update.Password))
                {
                    user.Password = update.Password;
                }
                user.Email = update.Email;
                user.Address = update.Address;
                user.Phone = update.Phone;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = update.UserName;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public bool DeleteUser(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<string> GetListCredential(string userName)
        {
            var user = db.Users.Single(x => x.UserName == userName);
            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.UserGroupID equals b.ID
                        join c in db.Roles on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }


        //public int Login(string username, string password)
        //{
        //    var result = db.Users.SingleOrDefault(x=>x.UserName == username);
        //    if (result == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        if (result.Status == false)
        //        {
        //            return -1;
        //        }
        //        else
        //        {
        //            if (result.Password == password)
        //            {
        //                return 1;
        //            }
        //            else
        //            {
        //                return 2;
        //            }
        //        }
        //    }
        //}

        public int Login(string userName, string password, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == password)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == password)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }

        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }

    }
}
