using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class OrderModel : BaseModel<Order>
    {
        public override List<Order> getElements()
        {
            var listData = dbContext.SP_Order_getElements();
            List<Order> listChosen = new List<Order>();
            foreach (var item in listData)
            {
                Order obj = new Order
                {
                    Id = item.Id,
                    Customer_Id = item.Customer_Id,
                    TotalMoney = item.TotalMoney,
                    Date = item.Date,
                    Status = item.Status,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override Order getElementById(int id)
        {
            var listData = dbContext.SP_Order_getElementsbyId(id);
            foreach (var item in listData)
            {
                Order obj = new Order
                {
                    Id = item.Id,
                    Customer_Id = item.Customer_Id,
                    TotalMoney = item.TotalMoney,
                    Date = item.Date,
                    Status = item.Status,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(Order obj)
        {
            try
            {
                return dbContext.SP_Order_Create(obj.Customer_Id, obj.TotalMoney, obj.Date, obj.Status, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(Order obj)
        {
            try
            {
                return dbContext.SP_Order_Update(obj.Id, obj.Customer_Id, obj.TotalMoney, obj.Date, obj.Status, false) > 0;
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
                return dbContext.SP_Order_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
