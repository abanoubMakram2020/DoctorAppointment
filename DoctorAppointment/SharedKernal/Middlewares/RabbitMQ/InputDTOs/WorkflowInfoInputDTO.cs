using SharedKernal.Common.Enum;
using System;
using System.Collections.Generic;

namespace SharedKernal.Middlewares.RabbitMQ.InputDTOs
{
    public class WorkflowInfoInputDTO
    {
        public WorkflowInfoInputDTO()
        {
            DataField = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }
        public string AccountOwnerUser { get; set; }
        public string WorkFlowPath { get; set; }
        public Dictionary<string, object> DataField { get; set; }
        public bool IsAsync { get; set; }
        public string Folio { get; set; }
        public bool IsUserAuthorized { get; set; }
        public WorkflowManager Workflow { get; set; }
        public string WorkflowActionName { get; set; }
        public string ProcessId { get; set; }
        public string ActionFiledKeyName { get; set; }
    }
}