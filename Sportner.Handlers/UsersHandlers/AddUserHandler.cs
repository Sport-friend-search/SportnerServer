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
    public class AddUserHandler : BaseHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IUserRepository _repository;

        public AddUserHandler(IUserRepository userRepository = null)
        {
            _repository = userRepository ?? new UserRepository();
        }

        public override AddUserResponse HandleCore(AddUserRequest request)
        {
            var requestedUser = Mapper.MapToUser(request.User);

            _repository.Insert(requestedUser);

            return new AddUserResponse();
        }

        public override bool Validate(AddUserRequest request)
        {
            List<string> errors = new List<string>();

            Response = new AddUserResponse { Errors = errors };

            return true;
        }

    }
}
