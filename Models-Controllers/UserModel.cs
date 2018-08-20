using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class UserModel:BaseModel<User>
    {
        public override List<User> getElements()
        {
            var listData = dbContext.SP_Users_getElements();
            List<User> listChosen = new List<User>();
            foreach (var item in listData)
            {
                User obj = new User
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Password = item.Password,
                    Rule = item.Rule,
                    Status = item.Status,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override User getElementById(int id)
        {
            var listData = dbContext.SP_Users_getElementsbyId(id);
            foreach (var item in listData)
            {
                User obj = new User
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Password = item.Password,
                    Rule = item.Rule,
                    Status = item.Status,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(User obj)
        {
            try
            {
                return dbContext.SP_Users_Create(obj.UserName, obj.Password, obj.Rule, obj.Status, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(User obj)
        {
            try
            {
                return dbContext.SP_Users_Update(obj.Id, obj.UserName, obj.Password, obj.Rule, obj.Status, false) > 0;
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
                return dbContext.SP_Users_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
