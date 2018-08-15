using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class CustomerModel: BaseModel<Customer>
    {
        public override List<Customer> getElements()
        {
            var listData = dbContext.SP_Customers_getElements();
            List<Customer> listChosen = new List<Customer>();
            foreach (var item in listData)
            {
                Customer obj = new Customer
                {
                    Id = item.Id,
                    Name = item.Name,
                    BirthDay = item.BirthDay,
                    Province = item.Province,
                    Address = item.Address,
                    Tel = item.Tel,
                    Email = item.Email,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override Customer getElementById(int id)
        {
            var listData = dbContext.SP_Customers_getElementsbyId(id);
            foreach (var item in listData)
            {
                Customer obj = new Customer
                {
                    Id = item.Id,
                    Name = item.Name,
                    BirthDay = item.BirthDay,
                    Province = item.Province,
                    Address = item.Address,
                    Tel = item.Tel,
                    Email = item.Email,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(Customer obj)
        {
            try
            {
                return dbContext.SP_Customers_Create(obj.Name, obj.BirthDay, obj.Province, obj.Address, obj.Tel, obj.Email, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(Customer obj)
        {
            try
            {
                return dbContext.SP_Customers_Update(obj.Id, obj.Name, obj.BirthDay, obj.Province, obj.Address, obj.Tel, obj.Email, false) > 0;
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
                return dbContext.SP_Customers_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
