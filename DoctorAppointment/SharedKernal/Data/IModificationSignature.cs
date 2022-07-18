using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Data
{
    public interface IModificationSignature<TForeignKey>
    {
        TForeignKey ModifiedBy { get; set; }
        DateTime? DateModified { get; set; }
    }
}
