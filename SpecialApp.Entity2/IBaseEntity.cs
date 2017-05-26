using System;

namespace SpecialApp.Entity
{
    public interface IBaseEntity : IObjectWithState
    {
        int? Id { get; set; }
        string AuditCreatedBy { get; set; }
        string AuditLastUpdatedBy { get; set; }
        DateTimeOffset? AuditCreatedDate { get; set; }
        DateTimeOffset? AuditLastUpdatedDate { get; set; }
        bool? IsDeleted { get; set; }
        byte[] RowVersion { get; set; }
    }
}