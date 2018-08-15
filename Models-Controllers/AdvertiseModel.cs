using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    public class AdvertiseModel:BaseModel<Advertise>
    {
        public override List<Advertise> getElements()
        {
            var listData = dbContext.SP_Advertise_getElements();
            List<Advertise> listChosen = new List<Advertise>();
            foreach (var item in listData)
            {
                Advertise obj = new Advertise
                {
                    Id = item.Id,
                    Name = item.Name,
                    Url = item.Url,
                    Width = item.Width,
                    Height = item.Height,
                    Link = item.Link,
                    Target = item.Target,
                    Postion = item.Postion,
                    Order = item.Order,
                    Status = item.Status,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override Advertise getElementById(int id)
        {
            var listData = dbContext.SP_Advertise_getElementsbyId(id);
            foreach (var item in listData)
            {
                Advertise obj = new Advertise
                {
                    Id = item.Id,
                    Name = item.Name,
                    Url = item.Url,
                    Width = item.Width,
                    Height = item.Height,
                    Link = item.Link,
                    Target = item.Target,
                    Postion = item.Postion,
                    Order = item.Order,
                    Status = item.Status,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(Advertise obj)
        {
            try
            {
                return dbContext.SP_Advertise_Create(obj.Name, obj.Url, obj.Width, obj.Height, obj.Link, obj.Target, obj.Postion, obj.Order, obj.Status, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(Advertise obj)
        {
            try
            {
                return dbContext.SP_Advertise_Update(obj.Id, obj.Name, obj.Url, obj.Width, obj.Height, obj.Link, obj.Target, obj.Postion, obj.Order, obj.Status, false) > 0;
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
                return dbContext.SP_Advertise_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
