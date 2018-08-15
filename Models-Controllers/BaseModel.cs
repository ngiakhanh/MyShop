using Models_Controllers.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_Controllers
{
    public class BaseModel<T>
    {
        protected MyShopDbEntities dbContext;
        public BaseModel()
        {
            dbContext = new MyShopDbEntities();
        }
        public virtual List<T> getElements() { return null; }
        public virtual T getElementById(int id) { return default(T); }
        public virtual Boolean create(T obj) { return true; }
        public virtual Boolean update(T obj) { return true; }
        public virtual Boolean delete(int id) { return true; }
    }
}
