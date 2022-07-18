using System;

namespace SharedKernal.Data
{
    public interface IEntity<PrimaryKey>
    {
        PrimaryKey Id { get; set; }
    }
}
