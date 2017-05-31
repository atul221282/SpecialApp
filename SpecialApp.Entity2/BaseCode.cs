namespace SpecialApp.Entity
{
    public abstract class BaseCode : BaseEntity, IBaseCode
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}