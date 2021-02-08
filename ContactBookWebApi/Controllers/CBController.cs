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
    public class CBController : ApiController
    {
        public List<ContactCategory> Get()
        {
            BusinessLib bll = new BusinessLib();
            var lstcat = bll.GetAllCategories();
            return lstcat;
        }
        [Route("api/CB/GetContacts")]
        public List<Contacts> GetContacts()
        {
            BusinessLib bll = new BusinessLib();
            var lstcontacts = bll.GetAllContacts();
            return lstcontacts;
        }

        public void Post([FromBody]ContactCategory cat)
        {
            BusinessLib bll = new BusinessLib();
            bll.AddNewCategory(cat);
        }

        [Route("api/CB/GetContactById/{Id}")]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Recored Deleted Successfully");
            try
            {
                BusinessLib bll = new BusinessLib();
                var lstcontacts = bll.GetAllContactsById(id);
                return res = Request.CreateResponse<List<Contacts>>(lstcontacts);
            }
            catch(Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        [Route("api/CB/AddContact")]
        public HttpResponseMessage AddContact([FromBody]Contacts contact)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Record Inserted Successfully");
            try
            {
                BusinessLib bll = new BusinessLib();
                bll.AddContact(contact);
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        [Route("api/CB/DeleteContactById/{id}")]
        public HttpResponseMessage DeleteContactById(int id)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Record Deleted Successfully");
            try
            {
                BusinessLib bll = new BusinessLib();
                bll.DeleteCategoryByCategoryId(id);
            }
            catch(Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
    }
}
