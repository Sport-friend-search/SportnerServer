﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Sportner.Messages.UserMessages;
using Sportner.Repositories;

namespace Sportner.Handlers.UsersHandlers
{
    public class GetUserHandler : BaseHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IUserRepository _repository;

        public GetUserHandler(IUserRepository userRepository = null)
        {
            _repository = userRepository ?? new UserRepository();
        }

        public override GetUserResponse HandleCore(GetUserRequest request)
        {
            var user = _repository.Get(request.UserId);

            var requestedUser = Mapper.MapToUserDto(user);

            return new GetUserResponse { User = requestedUser };
        }

        public override bool Validate(GetUserRequest request)
        {
            List<string> errors = new List<string>();

            Response = new GetUserResponse { Errors = errors };

            return true;
        }

    }
}
