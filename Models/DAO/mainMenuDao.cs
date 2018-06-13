using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class mainMenuDao
    {
        OnlineShopDbContext db = null;
        public mainMenuDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Menu> ListGroupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId).ToList();
        }
    }
}
