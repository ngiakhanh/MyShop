using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace Models_Controllers
{
    class ContactModel:BaseModel<Contact>
    {
        public override List<Contact> getElements()
        {
            var listData = dbContext.SP_Contact_getElements();
            List<Contact> listChosen = new List<Contact>();
            foreach (var item in listData)
            {
                Contact obj = new Contact
                {
                    Id = item.Id,
                    Customer_Id = item.Customer_Id,
                    Summary = item.Summary,
                    Detail = item.Detail,
                    Date = item.Date,
                    isDel = item.isDel
                };
                listChosen.Add(obj);
            }
            return listChosen;
        }
        public override Contact getElementById(int id)
        {
            var listData = dbContext.SP_Contact_getElementsbyId(id);
            foreach (var item in listData)
            {
                Contact obj = new Contact
                {
                    Id = item.Id,
                    Customer_Id = item.Customer_Id,
                    Summary = item.Summary,
                    Detail = item.Detail,
                    Date = item.Date,
                    isDel = item.isDel
                };
                return obj;
            }
            return null;
        }
        public override bool create(Contact obj)
        {
            try
            {
                return dbContext.SP_Contact_Create(obj.Customer_Id, obj.Summary, obj.Detail, obj.Date, false) > 0;
            }
            catch
            {
                return false;
            }
        }
        public override bool update(Contact obj)
        {
            try
            {
                return dbContext.SP_Contact_Update(obj.Id, obj.Customer_Id, obj.Summary, obj.Detail, obj.Date, false) > 0;
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
                return dbContext.SP_Contact_deleteTemp(id) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
