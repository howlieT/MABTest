using ToDoList;

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

