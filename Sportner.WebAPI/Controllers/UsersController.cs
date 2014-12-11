using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sportner.Handlers.UsersHandlers;
using Sportner.Messages.UserMessages;

namespace Sportner.WebAPI.Controllers
{
    public class UsersController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            GetUserRequest getUserRequest = new GetUserRequest { UserId = id };

            var handler = new GetUserHandler();

            var response = handler.Handle(getUserRequest);

            if (response.User != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent, response);
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            GetAllUserRequest getAllUserRequest = new GetAllUserRequest();

            var handler = new GetAllUsersHandler();

            var response = handler.Handle(getAllUserRequest);

            if (response.Users != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent, response);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]AddUserRequest addUserRequest)
        {
            var handler = new AddUserHandler();

            var response = handler.Handle(addUserRequest);

            if (addUserRequest == null)
            {
                response.Errors.Add("Cannot deserialize request");

                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
                            
            if (response.Errors == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, response);

        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody] UpdateUserRequest updateUserRequest)
        {
            var handler = new UpdateUserHandler();

            var response = handler.Handle(updateUserRequest);

            if (updateUserRequest == null)
            {
                response.Errors.Add("Cannot deserialize request");

                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

            if (response.Errors == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }

    }
}
