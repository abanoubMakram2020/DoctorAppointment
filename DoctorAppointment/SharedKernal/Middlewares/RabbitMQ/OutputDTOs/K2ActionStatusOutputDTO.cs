using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.RabbitMQ.OutputDTOs
{
    public class K2ActionStatusOutputDTO
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
