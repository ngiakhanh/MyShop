using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class OrderDetailModel : BaseModel<OrderDetail>
    {
        public override List<OrderDetail> getElements()
        {
            var listData = dbContext.SP_OrderDetail_getElements();
            List<OrderDetail> listChosen = new List<OrderDetail>();
            foreach (var item in listData)
            {
                OrderDetail obj = new OrderDetail
                {
                    Id = item.Id,
                    Order_Id = item.Order_Id,
                    Product_Id = item.Product_Id,
                    Quantity = item.Quantity,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override OrderDetail getElementById(int id)
        {
            var listData = dbContext.SP_OrderDetail_getElementsbyId(id);
            foreach (var item in listData)
            {
                OrderDetail obj = new OrderDetail
                {
                    Id = item.Id,
                    Order_Id = item.Order_Id,
                    Product_Id = item.Product_Id,
                    Quantity = item.Quantity,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(OrderDetail obj)
        {
            try
            {
                return dbContext.SP_OrderDetail_Create(obj.Order_Id, obj.Product_Id, obj.Quantity, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(OrderDetail obj)
        {
            try
            {
                return dbContext.SP_OrderDetail_Update(obj.Id, obj.Order_Id, obj.Product_Id, obj.Quantity, false) > 0;
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
                return dbContext.SP_OrderDetail_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
