using System.Collections.Generic;
using Sportner.Dto;

namespace Sportner.Messages.UserMessages
{
    public class GetUserResponse
    {
        public UserDto User { get; set; }

        public List<string> Errors { get; set; }
    }
}
