namespace SpecialApp.Entity2
{
    public interface IObjectWithState
    {
        State State { get; set; }
    }

    public enum State
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }
}