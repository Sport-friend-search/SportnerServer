using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sportner.Messages.UserMessages;
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

            return new GetAllUsersResponse { Users = users };
        }

        public override bool Validate(GetAllUserRequest request)
        {
            List<string> errors = new List<string>();

            Response = new GetAllUsersResponse { Errors = errors };

            return true;
        }

    }
}
