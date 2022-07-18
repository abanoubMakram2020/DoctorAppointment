using SharedKernal.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.RabbitMQ.OutputDTOs
{
    public class UpdateActionRequestResultDto
    {
        public CreateActionRequestResult Result { get; set; }
        public string Message { get; set; }
        public string ReferenceCode { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public ResponseStatusCode StatusCode { get; set; }
        public string StatusName => StatusCode.ToString();

    }

    public class CreateActionRequestResult
    {
        public int ActionId { get; set; }
    }
}

