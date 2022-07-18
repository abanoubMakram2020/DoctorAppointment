using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Common.Configuration
{
    public class HealthCheckSettings
    {
        public HealthCheckSettings()
        {
            HealthChecks = new List<HealthCheck>();
            Webhooks = new List<Webhook>();
        }
        public static List<HealthCheck> HealthChecks { get; set; }
        public static List<Webhook> Webhooks { get; set; }
        public static int EvaluationTimeInSeconds { get; set; }
        public static int MinimumSecondsBetweenFailureNotifications { get; set; }
        public static int SetApiMaxActiveRequests { get; set; }
    }


    public class HealthCheck
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }

    public class Webhook
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Payload { get; set; }
        public string RestoredPayload { get; set; }
    }
}
