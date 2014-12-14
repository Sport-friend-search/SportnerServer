using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Sportner.Dto;
using Sportner.Messages.EventMessages;
using Sportner.Models;
using Sportner.Repositories;

namespace Sportner.Handlers.EventsHandlers
{
    public class GetFilterEventsHandler : BaseHandler<GetFilteredEventsRequest, GetFilteredEventsResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;

        public GetFilterEventsHandler(IEventRepository eventRepository = null, IUserRepository userRepository = null)
        {
            _eventRepository = eventRepository ?? new EventRepository();
            _userRepository = userRepository ?? new UserRepository();
        }

        public override GetFilteredEventsResponse HandleCore(GetFilteredEventsRequest request)
        {
            var allEvents = _eventRepository.GetAll();
            IEnumerable<Event> filteredEvents = new List<Event>();
            List<EventWithUserDto> filteredEventsWithUsers = new List<EventWithUserDto>();

            if (request.City != null)
            {
                filteredEvents = allEvents.Where(e => e.City == request.City);
            }
            if (request.SportId != null)
            {
                filteredEvents = allEvents.Where(e => e.SportId == request.SportId);
            }
            if (request.UserId != null)
            {
                filteredEvents = allEvents.Where(e => e.UserId == request.UserId);
            }
            if (request.StartTime != null)
            {
                filteredEvents = allEvents.Where(e => e.StartTime > request.StartTime);
            }

            if (request.EndTime != null)
            {
                filteredEvents = allEvents.Where(e => e.EndTime < request.EndTime);
            }

            if (filteredEvents.Any())
            {
                var users = _userRepository.GetAll();

                filteredEventsWithUsers = filteredEvents.Join(
                    users, 
                    e => e.UserId, 
                    u => u.UserId, 
                    (e, u) =>
                        new EventWithUserDto
                        {
                            Event = Mapper.MapToEventDto(e),
                            User = Mapper.MapToUserDto(u)
                        }
                    ).ToList();

            }

            return new GetFilteredEventsResponse {EventsWithUsers = filteredEventsWithUsers};
        }

        public override bool Validate(GetFilteredEventsRequest request)
        {
            List<string> errors = new List<string>();

            Response = new GetFilteredEventsResponse { Errors = errors };

            return true;
        }

    }
}
