using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TodoApp
{
    public static class FileManager 
    {
        public static void SaveTasks(List<Task> tasks, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.Id}|{task.Title}|{task.Description}|{task.IsCompleted}");
                }
            }
        }
        public static List<Task> LoadTasks(string filePath)
        {
            var tasks = new List<Task>();

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');

                        if (parts.Length == 4)
                        {
                            int id = int.Parse(parts[0]);

                            string title = parts[1];

                            string description = parts[2];

                            bool isCompleted = bool.Parse(parts[3]);

                            var task = new Task(id, title, description)
                            {
                                IsCompleted = isCompleted
                            };
                            tasks.Add(task);
                        }
                    }
                }
            }
            return tasks;
        }
    }
}
