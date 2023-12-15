using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UI.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = EmployeeService.GetEmployeeAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = EmployeeService.GetEmployee(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(EmployeeDTO emp)
        {
            try
            {
                if(EmployeeService.CreateEmployee(emp))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Created" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Failed" });
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if(EmployeeService.DeleteEmployee(id))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Deleted" });

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Failed" });

                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex);

            }
        }

    }
}
