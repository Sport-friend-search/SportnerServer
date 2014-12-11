using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sportner.Handlers.EventsHandlers;
using Sportner.Handlers.UsersHandlers;
using Sportner.Messages.EventMessages;
using Sportner.Messages.UserMessages;

namespace Sportner.WebAPI.Controllers
{
    public class EventsController : ApiController
    {

        [Route("api/GetFilteredEvents")]
        [HttpPost]
        public HttpResponseMessage GetFilteredUsers([FromBody]GetFilteredEventsRequest getFilteredEventsRequest)
        {
            var handler = new GetFilterEventsHandler();
            var response = handler.Handle(getFilteredEventsRequest);

            if (getFilteredEventsRequest == null)
            {
                response.Errors.Add("Cannot deserialize request");

                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

            if (response.EventsWithUsers != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent, response);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]AddEventRequest addEventRequest)
        {
            var handler = new AddEventHandler();

            var response = handler.Handle(addEventRequest);

            if (addEventRequest == null)
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
        public HttpResponseMessage Put([FromBody] UpdateEventRequest updateEventRequest)
        {
            var handler = new UpdateEventHandler();

            var response = handler.Handle(updateEventRequest);

            if (updateEventRequest == null)
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

        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int eventId)
        {
            DeleteEventRequest deleteEventRequest = new DeleteEventRequest { EventId = eventId };

            var handler = new DeleteEventHandler();

            var response = handler.Handle(deleteEventRequest);

            if (response.Errors != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent, response);
        }

    }
}
