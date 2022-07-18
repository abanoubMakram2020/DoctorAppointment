using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Common.Configuration
{
    public class CommonConfigurations
    {
        public static string BaseURL { get; set; }
        public static string Version { get; set; }
        public static string GetServiceSettingDepartment { get; set; }
        public static string GetUserByIdz { get; set; }
        public static string GetAllDepartmentsDDL { get; set; }
        public static string GetRequest { get; set; }
        public static string GetDepartmentByIdz { get; set; }
        public static string GetDepartmentByCodes { get; set; }
        public static string GetRequestActions { get; set; }
        public static string GetAllbyServiceIdAndRequestIdz { get; set; }
        public static string GetLatestRequestStatus { get; set; }
        public static string GetK2RequestDestinationById { get; set; }
        public static string GetRequestTypeActionById { get; set; }
    }
}
