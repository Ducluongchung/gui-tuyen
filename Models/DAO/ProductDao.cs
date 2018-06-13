using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;

        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Product entity)
        {
            try
            {
                var user = db.Products.Find(entity.ID);
                user.Name = entity.Name;
                user.Price = entity.Price;
                user.Image = entity.Image;
                user.MetaTitle = entity.MetaTitle;
                user.MetaKeywords = entity.MetaKeywords;
                user.CategoryID = user.CategoryID;
                user.Status = user.Status;
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public IEnumerable<Product> ListAll(int page, int Pagesize)
        {
            return db.Products.OrderByDescending(x => x.ID).ToPagedList(page, Pagesize);
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
        public bool Delete(Product entity)
        {
            try
            {
                var user = db.Products.Find(entity.ID);
                db.Products.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //san phâm  mơi
        public List<Product> NewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        //san pham hot
        public List<Product>FutureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
        //sản phẩm liên quan
        public List<Product> RelativeProduct(long id,int top)
        {
             var product = db.Products.Find(id);
            return db.Products.Where(x => x.ID != id && x.CategoryID == product.CategoryID).Take(top).ToList();
        }
        public List<Product> ListByCategory(long CategoryID)
        {
            return db.Products.Where(x => x.CategoryID == CategoryID).ToList();
        }
    }
}
