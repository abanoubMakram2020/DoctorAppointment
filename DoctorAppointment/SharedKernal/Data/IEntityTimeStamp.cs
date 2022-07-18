using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Data
{
    public interface IEntityTimeStamp
    {
        DateTime CreationDateTime { get; set; }
        // DateTime? ModificationDateTime { get; set; }
    }
}
