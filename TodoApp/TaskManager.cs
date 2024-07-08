using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();
        private int nextId = 1;

        public void AddTask(string title, string description)
        {
            var task = new Task(nextId++, title, description);
            tasks.Add(task);
        }

        public void RemoveTask(int id)
        {
            tasks.RemoveAll(t => t.Id == id);
        }

        public void ToggleTaskStatus(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            task?.ToggleCompleted();
        }
        public List<Task> GetAllTasks()
        {
            return tasks;
        }

        public List<Task> GetCompletedTasks()
        {
            return tasks.Where(t => t.IsCompleted).ToList();
        }

        public List<Task> GetPendingTasks()
        {
            return tasks.Where(t => !t.IsCompleted).ToList();
        }
    }
}
