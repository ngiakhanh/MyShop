using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class MenuModel : BaseModel<Menu>
    {
        public override List<Menu> getElements()
        {
            var listData = dbContext.SP_Menu_getElements();
            List<Menu> listChosen = new List<Menu>();
            foreach (var item in listData)
            {
                Menu obj = new Menu
                {
                    Id = item.Id,
                    Name = item.Name,
                    Link = item.Link,
                    Order = item.Order,
                    ParentId = item.ParentId,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override Menu getElementById(int id)
        {
            var listData = dbContext.SP_Menu_getElementsbyId(id);
            foreach (var item in listData)
            {
                Menu obj = new Menu
                {
                    Id = item.Id,
                    Name = item.Name,
                    Link = item.Link,
                    Order = item.Order,
                    ParentId = item.ParentId,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(Menu obj)
        {
            try
            {
                return dbContext.SP_Menu_Create(obj.Name, obj.Link, obj.Order, obj.ParentId, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(Menu obj)
        {
            try
            {
                return dbContext.SP_Menu_Update(obj.Id, obj.Name, obj.Link, obj.Order, obj.ParentId, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool delete(int id)
        {
            try
            {
                return dbContext.SP_Menu_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
