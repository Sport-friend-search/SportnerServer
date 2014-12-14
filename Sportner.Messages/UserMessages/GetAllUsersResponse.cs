using System.Collections.Generic;
using Sportner.Dto;

namespace Sportner.Messages.UserMessages
{
    public class GetAllUsersResponse
    {
        public List<UserDto> Users { get; set; }

        public List<string> Errors { get; set; } 
    }
}
