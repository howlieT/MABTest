using ToDoList;

namespace ToDoList;

public class Program
{
    public static void Main(string[] args)
    {
        var store = new TaskStore();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n==== TO-DO LIST ====");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List all Tasks");
            Console.WriteLine("3. List Completed Tasks");
            Console.WriteLine("4. List Incomplete Tasks");
            Console.WriteLine("5. Mark Task Complete");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Title: ");
                    string title = Console.ReadLine() ?? "";

                    Console.WriteLine("Description: ");
                    string desc = Console.ReadLine() ?? "";

                    Console.WriteLine("Due Date: ");
                    string due = Console.ReadLine() ?? "";

                    Console.WriteLine("Priority: ");
                    string priority = Console.ReadLine() ?? "";

                    store.AddTask(title, desc, due, priority);
                    Console.WriteLine("Task added!");
                    break;

                case "2":
                    Console.WriteLine("\n--- Tasks ---");
                    foreach (var task in store.TaskList)
                    {
                        Console.WriteLine($"[{(task.IsCompleted ? "X" : " ")}] {task.Title} (Due: {task.DueDate}, Priority: {task.Priority})");
                    }
                    break;

                case "3":
                    Console.WriteLine("\n--- Completed Tasks ---");
                    foreach (var task in store.TaskList)
                    if (task.IsCompleted)
                    {
                        Console.WriteLine($"[{(task.IsCompleted ? "X" : " ")}] {task.Title} (Due: {task.DueDate}, Priority: {task.Priority})");
                    }
                    else
                    {
                        Console.WriteLine("No completed tasks found.");
                    }
                    break;
                
                case "4":
                    Console.WriteLine("\n--- Incomplete Tasks ---");    
                    foreach (var task in store.TaskList)
                    if (!task.IsCompleted)
                    {
                        Console.WriteLine($"[{(!task.IsCompleted ? "X" : " ")}] {task.Title} (Due: {task.DueDate}, Priority: {task.Priority})");
                    }
                    else
                    {
                        Console.WriteLine("No incomplete tasks found.");
                    }
                    break;
    
                 case "5":
                    Console.WriteLine("Enter the title of the task to mark as complete: "); 
                    string taskTitle = Console.ReadLine() ?? "";
                    store.MarkTaskComplete(taskTitle);  
                    Console.WriteLine("Task marked as complete!");
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}
