using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.RabbitMQ.InputDTOs
{
    public class AddAndUpdateServiceSettingInputDTO
    {
        public int ServiceId { get; set; }
        public IDictionary<string, string> ServiceSettings { get; set; }
    }
}
