using System;

namespace SpecialApp.Entity2
{
    public abstract class BaseEntity : IObjectWithState
    {
        private DateTimeOffset? _auditCreatedDate;
        private DateTimeOffset? _auditLastUpdatedDate;

        /// <summary>
        ///
        /// </summary>
        private byte[] _rowVersion;

        /// <summary>
        /// Gets or sets the Id
        /// </summary>

        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets the user AuditCreatedBy
        /// </summary>

        public string AuditCreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user AuditLastUpdatedBy
        /// </summary>

        public string AuditLastUpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user AuditCreatedDate
        /// </summary>

        public DateTimeOffset? AuditCreatedDate
        {
            get { return _auditCreatedDate; }
            set { _auditCreatedDate = value; }
        }

        /// <summary>
        /// Gets or sets the user AuditCreatedDate
        /// </summary>

        public DateTimeOffset? AuditLastUpdatedDate
        {
            get { return _auditLastUpdatedDate; }
            set { _auditLastUpdatedDate = value; }
        }

        /// <summary>
        /// Gets or sets the user IsDeleted
        /// </summary>

        public bool? IsDeleted { get; set; }

        /// <summary>
        ///
        /// </summary>

        public State State { get; set; }

        /// <summary>
        ///
        /// </summary>

        public byte[] RowVersion
        {
            get { return _rowVersion; }
            set { _rowVersion = value; }
        }
    }
}