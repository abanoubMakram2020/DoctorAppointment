using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Common.Enum
{
    public enum RequestTypeAction
    {

        [EnumMessage(messageAr: "تم إرسال الطلب")]
        Sent = 529401,
        [EnumMessage(messageAr: "إرسال الرفض")]
        ConfidentialBureauRejectSent = 529402,
        [EnumMessage(messageAr: "تم الرفض")]
        ConfidentialBureauReject = 529403,
        [EnumMessage(messageAr: "إرسال القبول")]
        ConfidentialBureauApproveSent = 529404,
        [EnumMessage(messageAr: "تم القبول")]
        ConfidentialBureauApprove = 529405,
        [EnumMessage(messageAr: "إرسال الأعادة")]
        ConfidentialBureauReturnSent = 529406,
        [EnumMessage(messageAr: "تم الأعادة")]
        ConfidentialBureauReturn = 529407,
    }
}
