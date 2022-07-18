using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Data
{
    public interface IVirtualDelete<TForeignKey>
    {
        bool IsDeleted { get; set; }
        TForeignKey DeletedBy { get; set; }
        DateTime? DeletedStamp { get; set; }
    }
}
