using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
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
            var requestedEvent = Mapper.MapToEvent(request.Event);

            _repository.Insert(requestedEvent);

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
