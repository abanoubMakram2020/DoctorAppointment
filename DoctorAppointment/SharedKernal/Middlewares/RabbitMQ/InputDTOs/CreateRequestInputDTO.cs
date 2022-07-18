using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.RabbitMQ.InputDTOs
{
    public class CreateRequestInputDTO
    {
        public string CreatePath { get; set; }
        public string KsuSuitCurrentUser { get; set; }
        public uint RequesterEmployeeNo { get; set; }
        public int ServiceId { get; set; }
        public int RequestTypeId { get; set; }
        public bool CreateUserAccountIfNotExistFrom_OSBuilder { get; set; }
    }
}
