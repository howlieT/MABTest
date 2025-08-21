
namespace ToDoList;

public class TaskItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string DueDate { get; set; }
    public string Priority { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(string title, string description, string dueDate, string priority)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
        IsCompleted = false;
    }
}

