using Models_Controllers.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_Controllers
{
    public class BaseModels<T>
    {
        protected IMIC_SHOPEntities dbContext;
        public BaseModels()
        {
            dbContext = new IMIC_SHOPEntities();
        }

        public virtual List<T> getElements() { return null; }
        public virtual T getElementById(Guid id) { return default(T); }
        public virtual Boolean create(T obj) { return true; }
        public virtual Boolean update(T obj) { return true; }
        public virtual Boolean delete(Guid id) { return true; }
    }
}
