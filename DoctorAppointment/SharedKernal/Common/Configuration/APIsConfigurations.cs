using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Common.Configuration
{
    public class APIsConfigurations
    {
        public static string GatewayBaseURL { get; set; }
        public static CommonAPI CommonAPI { get; set; }
    }
    public class CommonAPI
    {
        public string APIName { get; set; }
        public string Version { get; set; }
        public string GetServiceSettingDepartment { get; set; }
        public string GetUserById { get; set; }
        public string GetRequest { get; set; }
        public string GetDepartmentByIdz { get; set; }
        public string GetDepartmentByCodes { get; set; }
        public string GetOSEmployeeByJobCode { get; set; }
        public string GetEmployeeByJobCodeTbl { get; set; }
        public string GetOSEmployeeByEmail { get; set; }
        public string GetRequestActions { get; set; }
        public string GetAllbyServiceIdAndRequestIdz { get; set; }
        public string GetLatestRequestStatus { get; set; }
        public string GetRequestActionById { get; set; }
        public string GetK2RequestDestinationById { get; set; }
        public string GetRequestTypeActionById { get; set; }
        public string GetServiceSettingList { get; set; }
        public string GetServiceSettingByKeysAndServiceId { get; set; }
        public string GetSectionsDDL { get; set; }
        public string GetCollagesDDL { get; set; }
        public string GetExecuteViewEmployeeInfoFull { get; set; }
        public string GetExecuteViewEmployeeInfo { get; set; }
        public string Get { get; set; }
        public string GetUserByIdzFromOs { get; set; }
        public string GetDepartmentTreeByCode { get; set; }
        public string GetDepartmentByCode_View { get; set; }

    }
}
