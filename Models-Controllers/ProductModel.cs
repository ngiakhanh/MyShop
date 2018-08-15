using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class ProductModel : BaseModel<Product>
    {
        public override List<Product> getElements()
        {
            var listData = dbContext.SP_Product_getElements();
            List<Product> listChosen = new List<Product>();
            foreach (var item in listData)
            {
                Product obj = new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    Detail = item.Detail,
                    Price = item.Price,
                    Image = item.Image,
                    PriceNew = item.PriceNew,
                    Date = item.Date,
                    Order = item.Order,
                    Status = item.Status,
                    GroupProduct_Id = item.GroupProduct_Id,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override Product getElementById(int id)
        {
            var listData = dbContext.SP_Product_getElementsbyId(id);
            foreach (var item in listData)
            {
                Product obj = new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    Detail = item.Detail,
                    Price = item.Price,
                    Image = item.Image,
                    PriceNew = item.PriceNew,
                    Date = item.Date,
                    Order = item.Order,
                    Status = item.Status,
                    GroupProduct_Id = item.GroupProduct_Id,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(Product obj)
        {
            try
            {
                return dbContext.SP_Product_Create(obj.Name, obj.Detail, obj.Price, obj.Image, obj.PriceNew, obj.Date, obj.Order, obj.Status, obj.GroupProduct_Id, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(Product obj)
        {
            try
            {
                return dbContext.SP_Product_Update(obj.Id, obj.Name, obj.Detail, obj.Price, obj.Image, obj.PriceNew, obj.Date, obj.Order, obj.Status, obj.GroupProduct_Id, false) > 0;
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
                return dbContext.SP_Product_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
