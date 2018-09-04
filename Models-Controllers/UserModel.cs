using System;
using System.Collections.Generic;
using System.Linq;

namespace Models_Controllers
{
    public class UserModel:BaseModel<ValueObject.User>
    {
        public override List<ValueObject.User> getElements()
        {
            var listData = dbContext.SP_Users_getElements();
            List<ValueObject.User> listChosen = new List<ValueObject.User>();
            foreach (var item in listData)
            {
                ValueObject.User obj = new ValueObject.User
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
        public override ValueObject.User getElementById(int id)
        {
            var listData = dbContext.SP_Users_getElementsbyId(id);
            foreach (var item in listData)
            {
                ValueObject.User obj = new ValueObject.User
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
        public override bool create(ValueObject.User obj)
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
        public override bool update(ValueObject.User obj)
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

        public ValueObject.User checkLogin(string username, string password)
        {
            var user = (from s in dbContext.Users
                        where s.UserName == username && s.Password == password
                        select s).ToList();
            if (user.Count == 1)
            {
                ValueObject.User obj = new ValueObject.User
                {
                    Id = user[0].Id,
                    UserName = user[0].UserName,
                    Password = user[0].Password,
                    Rule = user[0].Rule,
                    Status = user[0].Status,
                    isDel = user[0].isDel
                };
                return obj;
            }
            return null;
        }

        public int maxPage(string query, int pageSize)
        {
            int total = (from s in dbContext.Users
                         where s.UserName.StartsWith(query)
                         orderby s.UserName
                         select s).Count();
            int maxPage = (int) Math.Ceiling((decimal)(total / pageSize));
            return maxPage;

        }

        public List<ValueObject.User> searchpageList(string query, int pageSize, int currentPage)
        {
            int total = (from s in dbContext.Users
                         where s.UserName.StartsWith(query)
                         orderby s.UserName
                         select s).Count(); 
            int skip = pageSize * (currentPage - 1);

            if (skip >= total) { return null; }

            var chosen = (from s in dbContext.Users
                          where s.UserName.StartsWith(query)
                          orderby s.UserName
                          select s).Skip(skip).Take(pageSize).ToList();

            List<ValueObject.User> listChosen = new List<ValueObject.User>();
            foreach (var item in chosen)
            {
                ValueObject.User obj = new ValueObject.User
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
    }
}
