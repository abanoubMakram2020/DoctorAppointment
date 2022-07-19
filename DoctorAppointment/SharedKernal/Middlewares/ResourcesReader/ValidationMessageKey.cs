using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.ResourcesReader
{
    public class ValidationMessageKey
    {
        public const string PatientNameRequired         = "PatientNameRequired"        ;
        public const string PatientPhoneNumberRequired  = "PatientPhoneNumberRequired" ;
        public const string AppointmentDateRequired     = "AppointmentDateRequired"    ;
        public const string AppointmentTimeFromRequired = "AppointmentTimeFromRequired";
        public const string AppointmentTimeToRequired   = "AppointmentTimeToRequired"  ;
        public const string InvalidMobileNumber         = "InvalidMobileNumber"        ;
        public const string TimeNotAvaliable = "TimeNotAvaliable";
        public const string TimeToShouldBeMorethanTimeFrom = "TimeToShouldBeMorethanTimeFrom";
    }
}
