using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Sportner.Messages.UserMessages;
using Sportner.Repositories;

namespace Sportner.Handlers.UsersHandlers
{
    public class UpdateUserHandler : BaseHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUserRepository _repository;

        public UpdateUserHandler(IUserRepository userRepository = null)
        {
            _repository = userRepository ?? new UserRepository();
        }

        public override UpdateUserResponse HandleCore(UpdateUserRequest request)
        {

            var requestedUser = Mapper.MapToUser(request.User);

            _repository.Update(requestedUser);

            return new UpdateUserResponse();
        }

        public override bool Validate(UpdateUserRequest request)
        {
            List<string> errors = new List<string>();

            Response = new UpdateUserResponse { Errors = errors };

            return true;
        }

    }
}
