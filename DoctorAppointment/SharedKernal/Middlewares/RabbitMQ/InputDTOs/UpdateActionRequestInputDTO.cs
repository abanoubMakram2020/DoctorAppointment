using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.RabbitMQ.InputDTOs
{
    public class UpdateActionRequestInputDTO
    {
        public Guid RequestId { get; set; }
        public int RequestTypeActionId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? SenderId { get; set; }
        public int? SenderRole { get; set; }
        public long? StatusChangedId { get; set; }
        public string RejectReason { get; set; }
        public DateTime? CreationDate { get; set; }

    }
}
