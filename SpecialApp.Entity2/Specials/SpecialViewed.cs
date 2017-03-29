using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Specials
{
    public class SpecialViewed
    {
        public int SpecialId { get; set; }
        public Special Special { get; set; }
        public string ViewedById { get; set; }
        public SpecialAppUsers ViewedBy { get; set; }
        public DateTimeOffset ViewedDate { get; set; }
    }
}
