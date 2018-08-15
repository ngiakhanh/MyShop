using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class ShopModel:BaseModel<Shop>
    {
        public override List<Shop> getElements()
        {
            var listData = dbContext.SP_Shop_getElements();
            List<Shop> listChosen = new List<Shop>();
            foreach (var item in listData)
            {
                Shop obj = new Shop
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Tel = item.Tel,
                    Province_Id = item.Province_Id,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override Shop getElementById(int id)
        {
            var listData = dbContext.SP_Shop_getElementsbyId(id);
            foreach (var item in listData)
            {
                Shop obj = new Shop
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Tel = item.Tel,
                    Province_Id = item.Province_Id,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(Shop obj)
        {
            try
            {
                return dbContext.SP_Shop_Create(obj.Name, obj.Address, obj.Tel, obj.Province_Id, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(Shop obj)
        {
            try
            {
                return dbContext.SP_Shop_Update(obj.Id, obj.Name, obj.Address, obj.Tel, obj.Province_Id, false) > 0;
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
                return dbContext.SP_Shop_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
