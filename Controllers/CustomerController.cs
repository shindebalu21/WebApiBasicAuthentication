using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiBasicAuthentication.Filters;

namespace WebApiBasicAuthentication.Controllers
{
    public class CustomerController : ApiController
    {
        /// <summary>
        /// Get All Customer
        /// </summary>
        /// <returns></returns>
        [BasicAuthentication]
        public HttpResponseMessage Get()
        {
            using (NORTHWNDEntities1 db=new NORTHWNDEntities1())
            {
               return Request.CreateResponse(HttpStatusCode.OK, db.Customers1.ToList());
            }
        }
    }
}
