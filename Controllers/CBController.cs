using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactBookEntityLayer;
using ContactBookDataLayer;
using ContactBookBusinessLayer;

using System.Net.Http;
using Newtonsoft.Json;


namespace ContactBookMVC.Controllers
{
    public class CBController : Controller
    {
        // GET: CB

        Uri uri = new Uri("http://localhost:50377/api/");
        [HttpGet]
        public ActionResult Index()
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("CBWeb").Result;
                var lcategory = JsonConvert.DeserializeObject<List<ContactCategoryM>>(result);
                return View(lcategory);
            }
            
            
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(ContactCategoryM c)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PostAsJsonAsync("CBWeb/AddCategory", c).Result;
                if(result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData.Add("msg", "Record is not inserted as error occured");
                }
                return View();
            }
        }
        public ActionResult ContactDetails(int id ) 
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("CBWeb/GetContactById/" + id).Result;
                var con = JsonConvert.DeserializeObject<List<ContactsM>>(result);
                return View(con);
            }
        }
        public ActionResult DetailsOfContact(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("CBWeb/GetContactByContactId/" + id).Result;
                //var con = JsonConvert.DeserializeObject<List<ContactsM>>(result);
                var co = JsonConvert.DeserializeObject<ContactsM>(result);
                return View(co);
            }
        }
        public ActionResult AllContacts()
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("CBWeb/").Result;
                var lcontacts = JsonConvert.DeserializeObject<List<ContactsM>>(result);

                return View();
            }
        }
        [HttpGet]
        public ActionResult CreateContact()
        {
            Contacts c = new Contacts();
            return View();
        }
        [HttpPost]
        public ActionResult CreateContact(Contacts c )
        {
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PostAsJsonAsync("CBWeb/AddContact",c).Result;
                if (result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewData.Add("msg", "Record is not inserted as error occured");
                }
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.DeleteAsync("CBWeb/" + id).Result;
                if(result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData.Add("msg", "Record Deleted Successfully");
                }

                return View(id);
            }

        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.DeleteAsync("CBWeb/DeleteContactById/"+id).Result;
                if(result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");
                    //ViewData.Add("msg", "Record deleted successfuly");
                }
                else
                {
                    ViewData.Add("msg", "Record Deleted Successfully");
                }

                return View(id);
            }

        }
        [HttpGet]
        public ActionResult UpdateContactByContactId(int id)
        {
            Contacts c = new Contacts();
            return View();
        }
        [HttpPost]
        public ActionResult UpdateContactByContactId(Contacts contact)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PostAsJsonAsync("CBWeb/UpdateContactByContactId/",contact).Result;
                if (result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewData.Add("msg", "Record is not inserted as error occured");
                }
                return View();
            }
        }
    }
}