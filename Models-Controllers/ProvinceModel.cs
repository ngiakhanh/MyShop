using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class ProvinceModel : BaseModel<Province>
    {
        public override List<Province> getElements()
        {
            var listData = dbContext.SP_Province_getElements();
            List<Province> listChosen = new List<Province>();
            foreach (var item in listData)
            {
                Province obj = new Province
                {
                    Id = item.Id,
                    Name = item.Name,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override Province getElementById(int id)
        {
            var listData = dbContext.SP_Province_getElementsbyId(id);
            foreach (var item in listData)
            {
                Province obj = new Province
                {
                    Id = item.Id,
                    Name = item.Name,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(Province obj)
        {
            try
            {
                return dbContext.SP_Province_Create(obj.Name, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(Province obj)
        {
            try
            {
                return dbContext.SP_Province_Update(obj.Id, obj.Name, false) > 0;
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
                return dbContext.SP_Province_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
