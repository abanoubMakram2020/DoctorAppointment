using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Common.Configuration
{
    public static class AuthSettings
    {
        public static string Secret { get; set; }
        public static string Issuer { get; set; }
        public static bool RequireHttpsMetadata { get; set; }
        public static int TokenExpirationMinutes { get; set; }
        public static string WebAudiance { get; set; }
        public static string MobileAudiance { get; set; }
    }
}
