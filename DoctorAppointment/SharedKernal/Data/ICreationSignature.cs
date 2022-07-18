using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Data
{
    public interface ICreationSignature<TForeignKey>
    {
        TForeignKey CreatedBy { get; set; }
        DateTime DateCreated { get; set; }
    }
}
