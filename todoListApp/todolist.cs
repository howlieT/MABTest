using system;
using system.collections.generic;
using system.linq;

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

public class TaskStore
{
    public List<TaskItem> TaskList { get; set; }

    public TaskStore()
    {
        TaskList = new List<TaskItem>();
    }

    public void AddTask(string title, string description, string dueDate, string priority)
    {
        var task = new TaskItem(title, description, dueDate, priority);
        TaskList.Add(task);
    }

    public List<TaskItem> GetCompletedTasks()
    {
        return TaskList.Where(t => t.IsCompleted).ToList();
    }

    public List<TaskItem> GetIncompleteTasks()
    {
        return TaskList.Where(t => !t.IsCompleted).ToList();
    }

    public void MarkTaskComplete(string title)
    {
        var task = TaskList.FirstOrDefault(t => t.Title == title);
        if (task != null)
        {
            task.IsCompleted = true;
        }
    }
}

