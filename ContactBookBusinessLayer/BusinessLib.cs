using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBookEntityLayer;
using ContactBookDataLayer;

namespace ContactBookBusinessLayer
{
    public class BusinessLib : IBusinessLib
    {
        /// <summary>
        /// connecting to the data layer for adding contact
        /// </summary>
        /// <param name="contacts">contact will be added</param>
       public void AddContact(Contacts contacts)
        {
            //Accessing  the data layer 
            DataAccessLib dll = new DataAccessLib();
            //accessing add contact method from data layer
            dll.AddContact(contacts);
        }


       
        public void DeleteContactById(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connecting to the data layer for deleting contact by contact id 
        /// </summary>
        /// <param name="Id">contact will be deleted from data base</param>
        public void DeleteContactByContactId(int Id)
        {
            //accessing data layer
            DataAccessLib dll = new DataAccessLib();
            //accessing delete contact by contact id method from data layer
            dll.DeleteContactByContactId(Id);
        }


        /// <summary>
        /// Getting all contacts from the data layer in the list format
        /// </summary>
        /// <returns>list of contacts will be returned</returns>
        public List<Contacts> GetAllContacts()
        {
            //accessing the data lyer 
            DataAccessLib dll = new DataAccessLib();
            //getting list of cantacts 
            List<Contacts> lcontacts = dll.GetAllContacts();
            //returning list of contacts
            return lcontacts;

        }

        /// <summary>
        /// Getting All Categories from the data layer
        /// </summary>
        /// <returns>list of categories will be returned </returns>
        public List<ContactCategory> GetAllCategories()
        {
            //accessing data layer
            DataAccessLib dll = new DataAccessLib();
            //getting all categories
            var lcategories = dll.GetAllCategories();
            //returning list of categories
            return lcategories;
        }

        /// <summary>
        /// Adding new category to the data base 
        /// </summary>
        /// <param name="c">new category added</param>
        public void AddNewCategory(ContactCategory c)
        {
            //accessing data layer
            DataAccessLib dll = new DataAccessLib();
            //adding new category to data base
            dll.AddNewCategory(c);

        }


        /// <summary>
        /// Deleting category by category id 
        /// </summary>
        /// <param name="Id">category will be deleted from data base</param>
        public void DeleteCategoryByCategoryId(int Id)
        {
            //access data layer
            DataAccessLib dll = new DataAccessLib();
            //deletein the category from the data base
            dll.DeleteCategoryByCategoryId(Id);

        }

        /// <summary>
        /// Getting All Contacts by Category ID
        /// </summary>
        /// <param name="Id"> List of contacts will be access from data base</param>
        /// <returns>list of contacts will be returned</returns>
        public List<Contacts> GetAllContactsById(int Id)
        {
            //accessing data layer
            DataAccessLib dll = new DataAccessLib();
            //getting list of contacts
            var lcontacts = dll.GetAllContactsById(Id);
            //list of contacts is returned 
            return lcontacts;
        }

        /// <summary>
        /// Updating the contact by contact id 
        /// </summary>
        /// <param name="contact">contact details will be updtated in the data base</param>
        public void UpdateContactByContactId(Contacts contact)
        {
            //accessing data layer
            DataAccessLib dll = new DataAccessLib();
            //updating contact in data base from data layer
            dll.UpdateContactByContactId(contact);
        }


        /// <summary>
        /// Getting contact by contact id from data base 
        /// </summary>
        /// <param name="id">contact details will be accessed</param>
        /// <returns>one contact detail will be returned</returns>
        public Contacts GetContactByContactId(int id)
        {
            //accessing data layer
            DataAccessLib dll = new DataAccessLib();
            //getting contact details
            var contact = dll.GetContactByContactId(id);
            //returning contact details
            return contact;
        }
    }
}
