using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sportner.Messages.EventMessages;
using Sportner.Models;
using Sportner.Repositories;

namespace Sportner.Handlers.EventsHandlers
{
    public class UpdateEventHandler : BaseHandler<UpdateEventRequest, UpdateEventResponse>
    {
        private readonly IEventRepository _repository;

        public UpdateEventHandler(IEventRepository eventRepository = null)
        {
            _repository = eventRepository ?? new EventRepository();
        }

        public override UpdateEventResponse HandleCore(UpdateEventRequest request)
        {
            // TODO: be excluded to separate mapper class
            Event requestEvent = new Event
            {
                Address = request.Event.Address,
                City = request.Event.City,
                Description = request.Event.Description,
                EndTime = request.Event.EndTime,
                StartTime = request.Event.StartTime,
                Latitude = request.Event.Latitude,
                Longitude = request.Event.Longitude,
                SportId = request.Event.SportId,
                UserId = request.Event.UserId
            };

            _repository.Update(requestEvent);

            return new UpdateEventResponse();
        }

        public override bool Validate(UpdateEventRequest request)
        {
            List<string> errors = new List<string>();

            Response = new UpdateEventResponse { Errors = errors };

            return true;
        }

    }
}
