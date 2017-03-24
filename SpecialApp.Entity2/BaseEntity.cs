using System;

namespace SpecialApp.Entity
{
    public abstract class BaseEntity : IObjectWithState
    {
        public int? Id { get; set; }
        public string AuditCreatedBy { get; set; }
        public string AuditLastUpdatedBy { get; set; }
        public DateTimeOffset? AuditCreatedDate { get; set; }
        public DateTimeOffset? AuditLastUpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public State State { get; set; }
        public byte[] RowVersion { get; set; }
    }
}