using System;

namespace IGR.Core.Domain.Commons
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
    }
}