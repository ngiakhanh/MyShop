using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class EmployeesModel:BaseModel<Employees>
    {
        public override List<Employees> getElements()
        {
            var listData = dbContext.SP_Employees_getElements();
            List<Employees> listChosen = new List<Employees>();
            foreach (var item in listData)
            {
                Employees obj = new Employees
                {
                    Id = item.Id,
                    User_Id = item.User_Id,
                    Name = item.Name,
                    Email = item.Email,
                    Address = item.Address,
                    Tel = item.Tel,
                    Type = item.Type,
                    Nick = item.Nick,
                    Status = item.Status,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override Employees getElementById(int id)
        {
            var listData = dbContext.SP_Employees_getElementsbyId(id);
            foreach (var item in listData)
            {
                Employees obj = new Employees
                {
                    Id = item.Id,
                    User_Id = item.User_Id,
                    Name = item.Name,
                    Email = item.Email,
                    Address = item.Address,
                    Tel = item.Tel,
                    Type = item.Type,
                    Nick = item.Nick,
                    Status = item.Status,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(Employees obj)
        {
            try
            {
                return dbContext.SP_Employees_Create(obj.User_Id, obj.Name, obj.Email, obj.Address, obj.Tel, obj.Type, obj.Nick, obj.Status, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(Employees obj)
        {
            try
            {
                return dbContext.SP_Employees_Update(obj.Id, obj.User_Id, obj.Name, obj.Email, obj.Address, obj.Tel, obj.Type, obj.Nick, obj.Status, false) > 0;
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
                return dbContext.SP_Employees_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
