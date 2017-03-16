using System;

namespace SpecialApp.Entity2
{
    public abstract class BaseEntity<T> : IObjectWithState
    {
        private DateTime? _auditCreatedDate;
        private DateTime? _auditLastUpdatedDate;
        /// <summary>
        ///
        /// </summary>
        private byte[] _rowVersion;

        /// <summary>
        /// Gets or sets the Id
        /// </summary>

        public T Id { get; set; }
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

        public DateTime? AuditCreatedDate
        {
            get { return _auditCreatedDate; }
            set { _auditCreatedDate = value; }
        }

        /// <summary>
        /// Gets or sets the user AuditCreatedDate
        /// </summary>

        public DateTime? AuditLastUpdatedDate
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