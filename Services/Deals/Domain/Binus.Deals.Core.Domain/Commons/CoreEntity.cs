using System;

namespace Binus.Deals.Core.Domain.Commons
{
    public abstract class CoreEntity
    {
        #region Entity Properties

        public int Id { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModifiedDateTime { get; set; }

        public string LastModifiedBy { get; set; }

        #endregion

        public void AttachAuditableEntity(
            CoreEntity attachedEntity)
        {
            Id = attachedEntity.Id;
            CreatedDateTime = attachedEntity.CreatedDateTime;
            CreatedBy = attachedEntity.CreatedBy;
            LastModifiedDateTime = attachedEntity.LastModifiedDateTime;
            LastModifiedBy = attachedEntity.LastModifiedBy;
        }
    }
}