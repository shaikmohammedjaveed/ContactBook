using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ContactBookEntityLayer;// for refering the content from Entity Layer

namespace ContactBookDataLayer
{
    public class DataAccessLib : IDataAccessLib
    {
        /// <summary>
        /// Add Contact method which gets data from user and the data will be inserted into the 
        /// table contacts with referance key of Category ID
        /// </summary>
        /// <param name="contact"></param>
        public void AddContact(Contacts contact)
        {
            // configuring the Connection Object
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Initial Catalog=HCLDB;Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // configure comman for Insert Statement
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText="insert into contacts values(@id,@fn,@ln,@pn,@em)";

            //supply values to the parameters of the command
            
            cmd.Parameters.AddWithValue("@id", contact.CategoryId);
            cmd.Parameters.AddWithValue("@fn", contact.FirstName);
            cmd.Parameters.AddWithValue("@ln", contact.LastName);
            cmd.Parameters.AddWithValue("@pn", contact.PhoneNo);
            cmd.Parameters.AddWithValue("@em", contact.Email);

            //specify the type of command
            cmd.CommandType = CommandType.Text;

            //attach connection with the command
            cmd.Connection = con;

            // open connection
            con.Open();

            // execute the command
            cmd.ExecuteNonQuery();

            //close the connection
            con.Close();


        }

        //public void DeleteContactById(int Id)
        //{

        //}


        /// <summary>
        /// Get All Contacts By Category Id In which we get the contacts for respective Category Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>List Of Contacts occording to the Category </returns>
        public List<Contacts> GetAllContactsById(int Id)
        {
            //TODO select All
            List<Contacts> lcontacts = new List<Contacts>();

            // configuring the Connection Object
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Initial Catalog=HCLDB;Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            //Configuring Select Command for selecting the all items from table
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select contacts.categoryid, contacts.contactid, contacts.firstname,contacts.lastname,contacts.phoneNo,contacts.email " +
                              "from contacts "+
                              "join category on category.categoryid=contacts.categoryid and contacts.categoryid=@ci";
            cmd.Parameters.Clear();

            //supply values to the parameters of the command
            cmd.Parameters.AddWithValue("@ci", Id);

            //specify the type of command
            cmd.CommandType = CommandType.Text;

            //Attach Connection With Command
            cmd.Connection = con;

            //Open the connection
            con.Open();

            //execute the command
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                //read the record
                Contacts c = new Contacts()
                {
                    CategoryId = (int)sdr[0],
                    ContactId = (int)sdr[1],
                    FirstName = sdr[2].ToString(),
                    LastName = sdr[3].ToString(),
                    PhoneNo = sdr[4].ToString(),
                    Email = sdr[5].ToString()

                };
                lcontacts.Add(c);
            }

            //Close the Connection
            sdr.Close();
            con.Close();

            // return the record values
            return lcontacts;
        }



        /// <summary>
        /// Adding New Category to the table
        /// </summary>
        /// <param name="cat">new category will be created in the table with category name and id </param>
       
        public void AddNewCategory(ContactCategory cat)
        {
            //configuring the connection object
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Initial Catalog=HCLDB;Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //configure comman for Insert Statement
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into category values(@ci,@cn)";
            cmd.Parameters.Clear();

            //supply values to the parameters of the command
            cmd.Parameters.AddWithValue("@ci", cat.categoryId);
            cmd.Parameters.AddWithValue("@cn", cat.CategoryName);

            //specify the type of command
            cmd.CommandType = CommandType.Text;

            //attach connection with the command
            cmd.Connection = con;

            //Open the connection
            con.Open();

            //Execute the command
            cmd.ExecuteNonQuery();

            //Close the Connection
            con.Close();
        }


        /// <summary>
        /// Deleting the Contact By Contact ID, supplying the Contact Id and It will be deleted 
        /// </summary>
        /// <param name="Id">Deleting the Command the by passing the ID of Contact</param>

        public void DeleteContactByContactId(int Id)
        {
            //configuring the connection object
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Initial Catalog=HCLDB;Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //configure command for DELETE
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from contacts where contactid=@id";
            cmd.Parameters.Clear();

            //pass value to the parameter
            cmd.Parameters.AddWithValue("@id", Id);

            //specify the type of command
            cmd.CommandType = CommandType.Text;

            //attach the connection with the command
            cmd.Connection = con;

            //Open the connection
            con.Open();

            //execute the command
            cmd.ExecuteNonQuery();

            //close the connection
            con.Close();
        }

        //public void UpdateContactByContactId(int Id)
        //{

        //}


        /// <summary>
        /// Getting All Categories from the table gategory
        /// </summary>
        /// <returns>List of Category</returns>
        public List<ContactCategory> GetAllCategories()
        {
            // create instance to the category of contact
            List<ContactCategory> lcategories = new List<ContactCategory>();

            //configuring the connection object
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Initial Catalog=HCLDB;Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            //Configuring command for select all 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select *from category";
            
            //configure connection for command
            cmd.Connection = con;

            //open the connection
            con.Open();

            //execute the command
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                //read the record
                ContactCategory c = new ContactCategory()
                {
                    categoryId = (int)sdr[0],
                    CategoryName = sdr[1].ToString()
                };
                lcategories.Add(c);
            }
            sdr.Close();

            //close the connection
            con.Close();

            //return the category list
            return lcategories;
        }


        /// <summary>
        /// Deleting the category by its ID from the data base, we get the id from the user as which category should
        /// be deleted
        /// </summary>
        /// <param name="Id">one category list will be deleted </param>
        public void DeleteCategoryByCategoryId(int Id)
        {
            //configure the connection object
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Initial Catalog=HCLDB;Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           
            //configure the comand for delete
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from category where categoryid=@id";
            cmd.Parameters.Clear();

            //supply values to the parameters of the command
            cmd.Parameters.AddWithValue("@id", Id);
            
            //specify the command type
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            
            //open connection
            con.Open();
            
            //execute the command
            cmd.ExecuteNonQuery();

            //Close the connection
            con.Close();
        }


        /// <summary>
        /// to update contac details by contact id, user send the id of contact which he wants to edit
        /// the we change the data in data base according to users need
        /// </summary>
        /// <param name="contact">Update is done in data base and nothing will be return</param>
        public void UpdateContactByContactId(Contacts contact)
        {

            //configure the connection object
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Initial Catalog=HCLDB;Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           
            //configure the command for update
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update contacts set firstname=@fn,lastname=@ln,phoneNo=@pn, email=@em where contactId=@ci";
            
            //supply values to the parameters of the command
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ci", contact.ContactId);
            cmd.Parameters.AddWithValue("@fn", contact.FirstName);
            cmd.Parameters.AddWithValue("@ln", contact.LastName);
            cmd.Parameters.AddWithValue("@pn", contact.PhoneNo);
            cmd.Parameters.AddWithValue("@em", contact.Email);

            //configure the command type
            cmd.CommandType = System.Data.CommandType.Text;
            
            //configure the connection
            cmd.Connection = con;

            //open the connection
            con.Open();
            
            //execute the command 
            cmd.ExecuteNonQuery();

            //close the connection
            con.Close();
        }


        /// <summary>
        /// Getting all contacts
        /// </summary>
        /// <returns>lost of contact will be returned here</returns>
        public List<Contacts> GetAllContacts()
        {
            throw new NotImplementedException();
        }


        public Contacts GetContactByContactId(int id)
        {
            Contacts c = new Contacts();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Initial Catalog=HCLDB;Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select categoryId,contactId,firstname,lastname,phoneNo,email from contacts where contactId=@ci";
                //configure command parameters
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ci", id);
                cmd.CommandType = System.Data.CommandType.Text;

                //attach connection
                cmd.Connection = con;

                //open connection
                con.Open();

                //execute the command
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    //read the record
                    c.CategoryId = (int)sdr[0];
                    c.ContactId = (int)sdr[1];
                    c.FirstName= sdr[2].ToString();
                    c.LastName = sdr[3].ToString();
                    c.PhoneNo = sdr[4].ToString();
                    c.Email = sdr[5].ToString();

                    sdr.Close();

                    //close the connection
                    con.Close();
                }
                else
                {
                    //if not done then an exception will be thrown
                    throw new Exception("Contact ID does not exist, check ur input");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return the record value
            return c;

        }
        
    }
}
