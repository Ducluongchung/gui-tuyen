using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ContentDao
    {
        OnlineShopDbContext db = null;

        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(Content entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Content entity)
        {
            try
            {
                var user = db.Contents.Find(entity.ID);
                user.Name = entity.Name;
                user.Description = entity.Description;
                user.Image = entity.Image;
                user.MetaTitle = entity.MetaTitle;
                user.MetaKeywords = entity.MetaKeywords;
                user.CategoryID = user.CategoryID;
                user.Status = user.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Content> ListAll(int page, int Pagesize)
        {
            return db.Contents.OrderByDescending(x => x.CreatedDate).ToPagedList(page, Pagesize);
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
        public bool Delete(Content entity)
        {
            try
            {
                var user = db.Contents.Find(entity.ID);
                db.Contents.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
