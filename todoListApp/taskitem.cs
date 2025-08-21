
namespace ToDoList;

public class TaskItem
{
    private static int _nextId = 1;
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string DueDate { get; set; }
    public string Priority { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(string title, string description, string dueDate, string priority)
    {
        Id = _nextId++;
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
        IsCompleted = false;
    }
    public static void SetNextId(int nextId)
        {
            _nextId = nextId;
        }
}
