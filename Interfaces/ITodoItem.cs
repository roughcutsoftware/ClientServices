namespace Interfaces
{
    public interface ITodoItem
    {
        long? UserId { get; set; }
        long? Id { get; set; }
        string Title { get; set; }
        bool? Completed { get; set; }
    }
}