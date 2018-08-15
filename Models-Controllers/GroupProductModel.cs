using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class GroupProductModel:BaseModel<GroupProduct>
    {
        public override List<GroupProduct> getElements()
        {
            var listData = dbContext.SP_GroupProduct_getElements();
            List<GroupProduct> listChosen = new List<GroupProduct>();
            foreach (var item in listData)
            {
                GroupProduct obj = new GroupProduct
                {
                    Id = item.Id,
                    Name = item.Name,
                    Content = item.Content,
                    Images = item.Images,
                    Order = item.Order,
                    Status = item.Status,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override GroupProduct getElementById(int id)
        {
            var listData = dbContext.SP_GroupProduct_getElementsbyId(id);
            foreach (var item in listData)
            {
                GroupProduct obj = new GroupProduct
                {
                    Id = item.Id,
                    Name = item.Name,
                    Content = item.Content,
                    Images = item.Images,
                    Order = item.Order,
                    Status = item.Status,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(GroupProduct obj)
        {
            try
            {
                return dbContext.SP_GroupProduct_Create(obj.Name, obj.Content, obj.Images, obj.Order, obj.Status, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(GroupProduct obj)
        {
            try
            {
                return dbContext.SP_GroupProduct_Update(obj.Id, obj.Name, obj.Content, obj.Images, obj.Order, obj.Status, false) > 0;
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
                return dbContext.SP_GroupProduct_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
