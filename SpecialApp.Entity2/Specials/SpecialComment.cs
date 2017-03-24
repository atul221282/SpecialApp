using System;
using System.Collections.Generic;

namespace SpecialApp.Entity.Specials
{
    public class SpecialComment : BaseEntity
    {
        public int SpecialId { get; set; }
        public Special Special { get; set; }

        public string Comment { get; set; }

        public string CommentById { get; set; }
        public SpecialAppUsers CommentBy { get; set; }

        public DateTimeOffset CommentDate { get; set; }

        public ICollection<SpecialComment> Replies { get; set; }

        public int? ParentCommentId { get; set; }
        public virtual SpecialComment ParentComment { get; set; }
    }
}
