namespace SpecialApp.Entity
{
    public interface IBaseCode : IBaseEntity
    {
        string Code { get; set; }
        string Description { get; set; }
    }
}