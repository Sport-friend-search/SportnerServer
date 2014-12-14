using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sportner.Dto;
using Sportner.Models;

namespace Dto
{
    static class Mapper
    {
        static public Event MapToEvent(EventDto eventDto)
        {
            return new Event
            {
                EventId = eventDto.EventId,
                Address = eventDto.Address,
                City = eventDto.City,
                Description = eventDto.Description,
                EndTime = eventDto.EndTime,
                Latitude = eventDto.Latitude,
                Longitude = eventDto.Longitude,
                SportId = eventDto.SportId,
                StartTime = eventDto.StartTime,
                EventTypeId = eventDto.EventTypeId
            };
        }

        static public EventDto MapToEventDto(Event eventToMap)
        {
            return new EventDto
            {
                EventId = eventToMap.EventId,
                Address = eventToMap.Address,
                City = eventToMap.City,
                Description = eventToMap.Description,
                EndTime = eventToMap.EndTime,
                Latitude = eventToMap.Latitude,
                Longitude = eventToMap.Longitude,
                SportId = eventToMap.SportId,
                StartTime = eventToMap.StartTime,
                EventTypeId = eventToMap.EventTypeId
            };
        }

        static public User MapToUser(UserDto userToMap)
        {
            return new User
            {
                UserId = userToMap.UserId,
                Username = userToMap.Username,
                BirthDate = userToMap.BirthDate,
                City = userToMap.City,
                Description = userToMap.Description,
                Email = userToMap.Email,
                FacebookId = userToMap.FacebookId,
                FacebookToken = userToMap.FacebookToken,
                InterestedSportsIds = userToMap.InterestedSportsIds,
                Password = userToMap.Password
            };
        }

        static public UserDto MapToUserDto(User userToMap)
        {
            return new UserDto
            {
                UserId = userToMap.UserId,
                Username = userToMap.Username,
                BirthDate = userToMap.BirthDate,
                City = userToMap.City,
                Description = userToMap.Description,
                Email = userToMap.Email,
                FacebookId = userToMap.FacebookId,
                FacebookToken = userToMap.FacebookToken,
                InterestedSportsIds = userToMap.InterestedSportsIds,
                Password = userToMap.Password
            };
        }
    }
}
