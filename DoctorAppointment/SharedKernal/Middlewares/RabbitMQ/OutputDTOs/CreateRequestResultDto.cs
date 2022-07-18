using SharedKernal.Common.Enum;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace SharedKernal.Middlewares.RabbitMQ.OutputDTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class CreateRequestResultDto
    {

        public CreateRequestResult Result { get; set; }
        public string Message { get; set; }
        public string ReferenceCode { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public ResponseStatusCode StatusCode { get; set; }
        public string StatusName => StatusCode.ToString();

    }

    public class CreateRequestResult
    {
        public Guid RequestId { get; set; }
        public string RequestCode { get; set; }
    }
}
