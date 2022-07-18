
using Microsoft.AspNetCore.Http.Extensions;
using SharedKernal.Common.Configuration;
using SharedKernal.Common.Enum;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.Handler
{
    public class CommonHandle : ICommonHandle
    {

        public IHttpClientFactory HttpClientFactory { get; set; }

        public async Task<TResponse> Handle<TResponse, TRequest>(TRequest body, string methodUrl, SharedKernal.Common.Enum.HttpMethod methodType, QueryBuilder qs)
        {
            var client = HttpClientFactory.CreateClient(nameof(CommonConfigurations));
            HttpResponseMessage responseMessage = null;
            switch (methodType)
            {
                case SharedKernal.Common.Enum.HttpMethod.Post:
                    responseMessage = await client.PostAsJsonAsync(requestUri: $"api/{CommonConfigurations.Version}/{methodUrl}", body);
                    break;
                case SharedKernal.Common.Enum.HttpMethod.Get:
                    responseMessage = await client.GetAsync(requestUri: $"api/{CommonConfigurations.Version}/{methodUrl}{qs}");
                    break;
                case SharedKernal.Common.Enum.HttpMethod.Delete:
                    responseMessage = await client.DeleteAsync(requestUri: $"api/{CommonConfigurations.Version}/{methodUrl}{qs}");
                    break;
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                TResponse result = await responseMessage.Content.ReadFromJsonAsync<TResponse>();
                return result;
            }
            return default;
        }
    }
}
