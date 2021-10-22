using System.ComponentModel.DataAnnotations;

namespace CarParking.Core.Entities.Base
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        [Key] public virtual TId Id { get; protected set; }

        public bool IsDeleted { get; set; }
    }
}
