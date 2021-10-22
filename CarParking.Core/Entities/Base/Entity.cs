using System;

namespace CarParking.Core.Entities.Base
{
    public abstract class Entity : EntityBase<int>
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
