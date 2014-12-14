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
    public class UpdateEventHandler : BaseHandler<UpdateEventRequest, UpdateEventResponse>
    {
        private readonly IEventRepository _repository;

        public UpdateEventHandler(IEventRepository eventRepository = null)
        {
            _repository = eventRepository ?? new EventRepository();
        }

        public override UpdateEventResponse HandleCore(UpdateEventRequest request)
        {
            var requestedEvent = Mapper.MapToEvent(request.Event);

            _repository.Update(requestedEvent);

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
