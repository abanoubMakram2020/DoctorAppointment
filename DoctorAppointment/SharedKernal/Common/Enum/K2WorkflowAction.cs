using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Common.Enum
{
    public enum K2WorkflowAction : ushort
    {
        NA = 0,
        Approve = 1,
        Reject = 2,
        Close = 3,
        Send = 4,
        Resend = 5,
        Redirect = 6,
        ReOpen = 7,
        AutoApproval = 8,
        Exceptional = 9,
    }
}
