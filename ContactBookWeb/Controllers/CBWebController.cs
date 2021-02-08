using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactBookEntityLayer;
using ContactBookDataLayer;
using ContactBookBusinessLayer;

namespace ContactBookWebApi.Controllers
{
    public class CBWebController : ApiController
    {
        public List<ContactCategory> Get()
        {
            BusinessLib bll = new BusinessLib();
            var lstcat = bll.GetAllCategories();
            return lstcat;
        }
        [Route("api/CBWeb/GetContacts")]
        public List<Contacts> GetContacts()
        {
            BusinessLib bll = new BusinessLib();
            var lstcontacts = bll.GetAllContacts();
            return lstcontacts;
        }
        [Route("api/CBWeb/AddCategory")]
        public void Post([FromBody] ContactCategory cat)
        {
            BusinessLib bll = new BusinessLib();
            bll.AddNewCategory(cat);
        }

        [Route("api/CBWeb/GetContactById/{Id}")]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Recored Got Successfully");
            try
            {
                BusinessLib bll = new BusinessLib();
                var lstcontacts = bll.GetAllContactsById(id);
                return res = Request.CreateResponse<List<Contacts>>(lstcontacts);
            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        [Route("api/CBWeb/AddContact")]
        public HttpResponseMessage AddContact([FromBody] Contacts contact)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Record Inserted Successfully");
            try
            {
                BusinessLib bll = new BusinessLib();
                bll.AddContact(contact);
            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Record Deleted Successfully");
            try
            {
                BusinessLib bll = new BusinessLib();
                bll.DeleteCategoryByCategoryId(id);

            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            } 
            return res;
        }
        [Route("api/CBWeb/DeleteContactById/{id}")]
        public HttpResponseMessage DeleteContactById(int id)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Record Deleted Successfully");
            try
            {
                BusinessLib bll = new BusinessLib();
                bll.DeleteContactByContactId(id);
            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        [Route("api/CBWeb/UpdateContactByContactId/")]
        public HttpResponseMessage UpdateContactByContactId([FromBody] Contacts contact)
        {

            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Record Inserted Successfully");
            try
            {
                BusinessLib bll = new BusinessLib();
                bll.UpdateContactByContactId(contact);
            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }

        [Route("api/CBWeb/GetContactByContactId/{id}")]
        public HttpResponseMessage GetContactByContactId(int id)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Recored Got Successfully");
            try
            {
                BusinessLib bll = new BusinessLib();
                var lstcontact = bll.GetContactByContactId(id);
                return res = Request.CreateResponse<Contacts>(lstcontact);
            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
    }
}
