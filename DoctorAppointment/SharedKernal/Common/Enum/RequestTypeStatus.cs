using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Common.Enum
{
    public enum RequestTypeStatus : int
    {
        [EnumMessage(messageAr: "لا يوجد إختيار", messageEn: "New request")]
        NOTSET = -1,
        [EnumMessage(messageAr: "طلب جديد", messageEn: "New request")]
        Draft = 0,
        [EnumMessage(messageAr: "تم ارسال الطلب", messageEn: "Request is sent")]
        Sent = 529401,
        [EnumMessage(messageAr: "تم إرجاع الطلب لمقدم الطلب", messageEn: "Return to requester")]
        ReturnToUser = 529402,
        [EnumMessage(messageAr: "تم رفض الطلب", messageEn: "Request is rejected")]
        Reject = 529403,
        [EnumMessage(messageAr: "إرسال لمدير المكتب السري", messageEn: "Send to CB Head")]
        SendToCBHead = 529404,
        [EnumMessage(messageAr: "إرسال لمدير المكتب السري", messageEn: "Send to CB Head")]
        SendToLBHead = 529405,
        [EnumMessage(messageAr: "إرسال لمدير المكتب السري", messageEn: "Send to CB Head")]
        SendToHRHead = 529406,
    }

}
