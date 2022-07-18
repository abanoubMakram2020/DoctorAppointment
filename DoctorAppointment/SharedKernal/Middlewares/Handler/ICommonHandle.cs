using Microsoft.AspNetCore.Http.Extensions;
using SharedKernal.Common.Enum;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.Handler
{
    public interface ICommonHandle
    {
        Task<TResponse> Handle<TResponse, TRequest>(TRequest body, string methodUrl, SharedKernal.Common.Enum.HttpMethod methodType, QueryBuilder qs);
    }
}
