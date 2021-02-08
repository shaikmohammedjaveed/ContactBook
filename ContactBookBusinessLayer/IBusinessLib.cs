using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBookEntityLayer;
using ContactBookDataLayer;

namespace ContactBookBusinessLayer
{
    interface IBusinessLib
    {
        //interface methods to get accessed all
        void AddContact(Contacts contacts);
        void DeleteContactById(int Id);
        void DeleteContactByContactId(int Id);
        List<Contacts> GetAllContacts();
        List<ContactCategory> GetAllCategories();
        void AddNewCategory(ContactCategory c);
        void DeleteCategoryByCategoryId(int Id);
        List<Contacts> GetAllContactsById(int Id);
        void UpdateContactByContactId(Contacts contact);
        Contacts GetContactByContactId(int id);


    }
}
