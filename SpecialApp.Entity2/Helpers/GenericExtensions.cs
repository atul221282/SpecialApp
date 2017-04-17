using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Helpers
{
    public static class GenericExtensions
    {
        public static T SetDefaults<T>(this T value, string loggedInUser = "") where T : BaseEntity
        {
            value.AuditCreatedBy = string.IsNullOrWhiteSpace(loggedInUser) ? "system" : loggedInUser;
            value.AuditCreatedDate = DateTimeOffset.Now;
            value.AuditLastUpdatedBy = string.IsNullOrWhiteSpace(loggedInUser) ? "system" : loggedInUser;
            value.AuditLastUpdatedDate = DateTimeOffset.Now;
            value.IsDeleted = false;
            return value;
        }
    }
}
