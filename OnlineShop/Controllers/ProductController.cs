using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ProductCategory()
        {
            var model = new ProductCategoryDao().List();
            return PartialView(model);
        }
        public ActionResult Category(long id)
        {
            var category = new CategoryDao().ViewDetail(id);
            ViewBag.Category = category;
            var model = new ProductDao().ListByCategory(id);
            return View(model);
        }
        public ActionResult Detail(long id)
        {
            var model = new ProductDao().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDao().Viewdetail(model.CategoryID.Value);
            ViewBag.product = new ProductDao().RelativeProduct(id,4);
            ViewBag.productCategory = new ProductCategoryDao().List();
            return View(model);
        }
    }
}