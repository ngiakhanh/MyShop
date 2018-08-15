using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class SupportModel:BaseModel<Support>
    {
        public override List<Support> getElements()
        {
            var listData = dbContext.SP_Support_getElements();
            List<Support> listChosen = new List<Support>();
            foreach (var item in listData)
            {
                Support obj = new Support
                {
                    Id = item.Id,
                    Name = item.Name,
                    Tel = item.Tel,
                    Type = item.Type,
                    Nick = item.Nick,
                    Order = item.Order,
                    Status = item.Status,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override Support getElementById(int id)
        {
            var listData = dbContext.SP_Support_getElementsbyId(id);
            foreach (var item in listData)
            {
                Support obj = new Support
                {
                    Id = item.Id,
                    Name = item.Name,
                    Tel = item.Tel,
                    Type = item.Type,
                    Nick = item.Nick,
                    Order = item.Order,
                    Status = item.Status,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(Support obj)
        {
            try
            {
                return dbContext.SP_Support_Create(obj.Name, obj.Tel, obj.Type, obj.Nick, obj.Order, obj.Status, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(Support obj)
        {
            try
            {
                return dbContext.SP_Support_Update(obj.Id, obj.Name, obj.Tel, obj.Type, obj.Nick, obj.Order, obj.Status, false) > 0;
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
                return dbContext.SP_Support_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
