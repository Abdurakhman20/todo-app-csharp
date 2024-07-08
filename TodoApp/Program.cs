using static TodoApp.FileManager;


namespace TodoApp
{
    public class Program
    {
        private static TaskManager taskManager = new TaskManager();
        private static string filePath = "tasks.txt";
        static void Main(string[] args)
        {
            LoadTasks();
            while (true)
            {
                DisplayMenu();
                HandleUserInput();
            }
        }
        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\tTask Managment System\n");
            Console.WriteLine("\t1. Add Task");
            Console.WriteLine("\t2. Remove Task");
            Console.WriteLine("\t3. Toggle Task Status (True or False)");
            Console.WriteLine("\t4. View All Tasks");
            Console.WriteLine("\t5. View Completed Tasks");
            Console.WriteLine("\t6. View Pending Tasks");
            Console.WriteLine("\t7. Save and Exit\n");
            Console.WriteLine("\tSelect an option: ");
        }

        private static void HandleUserInput()
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    RemoveTask();
                    break;
                case "3":
                    CompleteTask();
                    break;
                case "4":
                    ViewTasks(taskManager.GetAllTasks());
                    break;
                case "5":
                    ViewTasks(taskManager.GetCompletedTasks());
                    break;
                case "6":
                    ViewTasks(taskManager.GetPendingTasks());
                    break;
                case "7":
                    SaveTasks();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private static void AddTask()
        {
            Console.WriteLine("Enter task title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Enter task description: ");
            var description = Console.ReadLine();

            if(title != null && description != null)
            {
                taskManager.AddTask(title, description);
            }
            
        }

        private static void RemoveTask()
        {
            Console.WriteLine("Enter task ID to remove: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                taskManager.RemoveTask(id);
            }
        }

        private static void CompleteTask()
        {
            Console.WriteLine("Enter task ID to complete: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                taskManager.ToggleTaskStatus(id);
            }
        }

        private static void ViewTasks(List<Task> tasks)
        {
            Console.Clear();

            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }

            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private static void SaveTasks()
        {
            FileManager.SaveTasks(taskManager.GetAllTasks(), filePath);
        }

        private static void LoadTasks()
        {
            var tasks = FileManager.LoadTasks(filePath);

            foreach (var task in tasks)
            {
                taskManager.AddTask(task.Title, task.Description);

                if (task.IsCompleted)
                {
                    taskManager.ToggleTaskStatus(task.Id);
                }
            }
        }

    }
}
