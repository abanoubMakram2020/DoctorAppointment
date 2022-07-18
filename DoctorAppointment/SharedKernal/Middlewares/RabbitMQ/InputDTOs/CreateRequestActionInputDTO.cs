using System;

namespace SharedKernal.Middlewares.RabbitMQ.InputDTOs
{
    public class CreateRequestActionInputDTO
    {
        public int Id { get; set; }
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
