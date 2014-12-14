using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Sportner.Dto;
using Sportner.Messages.UserMessages;
using Sportner.Models;
using Sportner.Repositories;

namespace Sportner.Handlers.UsersHandlers
{
    public class GetAllUsersHandler : BaseHandler<GetAllUserRequest, GetAllUsersResponse>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersHandler(IUserRepository userRepository = null)
        {
            _repository = userRepository ?? new UserRepository();
        }

        public override GetAllUsersResponse HandleCore(GetAllUserRequest request)
        {
            var users = _repository.GetAll();

            var mappedUsers = new List<UserDto>();

            foreach (var user in users)
            {
                mappedUsers.Add(Mapper.MapToUserDto(user));
            }

            return new GetAllUsersResponse { Users = mappedUsers };
        }

        public override bool Validate(GetAllUserRequest request)
        {
            List<string> errors = new List<string>();

            Response = new GetAllUsersResponse { Errors = errors };

            return true;
        }

    }
}
