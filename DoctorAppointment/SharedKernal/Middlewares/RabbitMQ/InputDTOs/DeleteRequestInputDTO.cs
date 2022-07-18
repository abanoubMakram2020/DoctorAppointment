using System;

namespace SharedKernal.Middlewares.RabbitMQ.InputDTOs
{
    public class DeleteRequestInputDTO
    {
        public Guid RequestId { get; set; }
        public string RequestCode { get; set; }
    }
}
