using System;
using System.Collections.Generic;

namespace SharedKernal.Middlewares.RabbitMQ.InputDTOs
{
    public class TakeWorkflowActionInputDTO
    {

        public TakeWorkflowActionInputDTO()
        {
            DataField = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        public string ProcessId { get; set; }
        public Dictionary<string, object> DataField { get; set; }
        public string AccountOwnerUser { get; set; }
        public bool IsAsync { get; set; }
        public string WorkflowActionName { get; set; }
    }
}
