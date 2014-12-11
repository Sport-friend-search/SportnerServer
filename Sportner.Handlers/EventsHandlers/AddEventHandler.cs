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
    public class AddEventHandler : BaseHandler<AddEventRequest, AddEventResponse>
    {
        private readonly IEventRepository _repository;

        public AddEventHandler(IEventRepository eventRepository = null)
        {
            _repository = eventRepository ?? new EventRepository();
        }

        public override AddEventResponse HandleCore(AddEventRequest request)
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

            _repository.Insert(requestEvent);

            return new AddEventResponse();
        }

        public override bool Validate(AddEventRequest request)
        {
            List<string> errors = new List<string>();

            Response = new AddEventResponse { Errors = errors };

            return true;
        }

    }
}
