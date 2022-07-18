using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Common.Configuration
{
    public class EventBusSettings
    {
        public static string HostIpAddress { get; set; }
        public static ushort HostPort { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }

        public static string Request_Create_Queue { get; set; }
        public static string Request_Delete_Queue { get; set; }
        public static string Request_UpdateAction_Queue { get; set; }
        public static string Start_WorkflowAction_Queue { get; set; }
        public static string Take_WorkflowAction_Queue { get; set; }
        public static object Request_DeleteRequestAction_Queue { get; set; }
    }
}
