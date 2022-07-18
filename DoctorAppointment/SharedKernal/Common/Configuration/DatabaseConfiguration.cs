using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Common.Configuration
{
    public class DatabaseConfiguration
    {
        public static string ConnectionString { get; set; }
        public static bool AllowDropRecreateDatabase { get; set; }
    }
}
