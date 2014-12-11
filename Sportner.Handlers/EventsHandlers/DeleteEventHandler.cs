using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sportner.Messages.EventMessages;
using Sportner.Repositories;

namespace Sportner.Handlers.EventsHandlers
{
    public class DeleteEventHandler : BaseHandler<DeleteEventRequest, DeleteEventResponse>
    {
        private readonly IEventRepository _repository;

        public DeleteEventHandler(IEventRepository eventRepository = null)
        {
            _repository = eventRepository ?? new EventRepository();
        }

        public override DeleteEventResponse HandleCore(DeleteEventRequest request)
        {
            _repository.Delete(request.EventId);

            return new DeleteEventResponse();
        }

        public override bool Validate(DeleteEventRequest request)
        {
            List<string> errors = new List<string>();

            Response = new DeleteEventResponse { Errors = errors };

            return true;
        }

    }
}
