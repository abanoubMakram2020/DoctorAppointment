using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Common.Enum
{
    public enum GenderTypeEnum
    {
        [EnumMessage(messageAr: "ذكر")]
        Male = 0,

        [EnumMessage(messageAr: "أنثى")]
        Female = 1,

        [EnumMessage(messageAr: "NotSet")]
        NotSet = 2
    }
}
