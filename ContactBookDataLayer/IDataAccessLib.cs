using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBookEntityLayer;
namespace ContactBookDataLayer
{
    interface IDataAccessLib
    {

        //Interface Method for Data Access Library 
        void AddContact(Contacts contact);
        
        List<Contacts> GetAllContactsById(int Id);

        void AddNewCategory(ContactCategory cat);

        //void DeleteContactById(int Id);
        void DeleteContactByContactId(int Id);

        
        List<ContactCategory> GetAllCategories();

        void UpdateContactByContactId(Contacts contact);
        void DeleteCategoryByCategoryId(int Id);

        List<Contacts> GetAllContacts();
        Contacts GetContactByContactId(int id);
    }
}
