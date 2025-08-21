using ToDoList;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace TaskActions;

public class TaskStore
{
    private readonly string _filePath = "tasks.json";
    public List<TaskItem> Tasks { get; set; } 

    public TaskStore()
    {
        Tasks = new List<TaskItem>(); 
        LoadTasks();
    }

    public void AddTask(string title, string description, string dueDate, string priority)
    {
        var task = new TaskItem(title, description, dueDate, priority);
        Tasks.Add(task); 
        SaveTasks();
    }

    public List<TaskItem> GetCompletedTasks()
    {
        return Tasks.Where(t => t.IsCompleted).ToList();
    }

    public List<TaskItem> GetIncompleteTasks()
    {
        return Tasks.Where(t => !t.IsCompleted).ToList();
    }

    public bool MarkTaskComplete(string title)
    {
        TaskItem? task = Tasks.FirstOrDefault(t => t.Title == title);
        if (task != null)
        {
            task.IsCompleted = true;
            SaveTasks();
            return true;
        }
        return false;
    }

    public void SaveTasks()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Tasks, options);
        File.WriteAllText(_filePath, jsonString);
    }

    private void LoadTasks()
    {
        if (File.Exists(_filePath))
        {
            string jsonString = File.ReadAllText(_filePath);
            Tasks = JsonSerializer.Deserialize<List<TaskItem>>(jsonString) ?? new List<TaskItem>();

            // Find the highest existing Id
            int highestId = 0;
            foreach (var task in Tasks)
            {
                if (task.Id > highestId)
                    highestId = task.Id;
            }

            TaskItem.SetNextId(highestId + 1);
        }
        else
        {
            Tasks = new List<TaskItem>();
        }
    }
}
