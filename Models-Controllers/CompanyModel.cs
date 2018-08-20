using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
namespace Models_Controllers
{
    class CompanyModel:BaseModel<Company>
    {
        public override List<Company> getElements()
        {
            var listData = dbContext.SP_Company_getElements();
            List<Company> listChosen = new List<Company>();
            foreach (var item in listData)
            {
                Company obj = new Company
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    PhoneNumber = item.PhoneNumber,
                    Fax = item.Fax,
                    Email = item.Email,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override Company getElementById(int id)
        {
            var listData = dbContext.SP_Company_getElementsbyId(id);
            foreach (var item in listData)
            {
                Company obj = new Company
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    PhoneNumber = item.PhoneNumber,
                    Fax = item.Fax,
                    Email = item.Email,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(Company obj)
        {
            try
            {
                return dbContext.SP_Company_Create(obj.Name, obj.Address, obj.PhoneNumber, obj.Fax, obj.Email, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(Company obj)
        {
            try
            {
                return dbContext.SP_Company_Update(obj.Id, obj.Name, obj.Address, obj.PhoneNumber, obj.Fax, obj.Email, false) > 0;
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
                return dbContext.SP_Company_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
