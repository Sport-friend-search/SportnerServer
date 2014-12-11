using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Sportner.Messages;

namespace Sportner.Handlers
{
    public abstract class BaseHandler<TRequest, TResponse>
    {
        protected TResponse Response;

        public TResponse Handle(TRequest request)
        {
            try
            {
                if (Validate(request))
                {
                    return HandleCore(request);
                }
            }
            catch (Exception exception)
            {
                // Log error
                return Response;
            }

            return Response;
        }

        public abstract bool Validate(TRequest request);
        public abstract TResponse HandleCore(TRequest request);


    }
}