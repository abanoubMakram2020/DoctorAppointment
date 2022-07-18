using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.Handler
{
    public interface IPublisherEvent<TRequest, TResponse> where TResponse : class
    {
        Task<TResponse> Handle(TRequest model);
    }

    public interface IPublisherEvent<TRequest>
    {
        Task Handle(TRequest model);
    }
}
