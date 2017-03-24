namespace SpecialApp.Entity.Specials
{
    public class SpecialComment : BaseEntity
    {
        public int SpecialId { get; set; }
        public Special Special { get; set; }
        public string Comment { get; set; }
        public int CommentById { get; set; }
        public SpecialAppUsers CommentBy { get; set; }
    }
}
