using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class Task
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int id, string title, string description) 
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
            IsCompleted = false;
        }

        public void ToggleTaskStatus()
        {
            bool status = IsCompleted;
            IsCompleted = !status;
        }

        public override string ToString()
        {
            return $"[{(IsCompleted ? "X" : " ")}] {Id}: {Description}";
        }
    }
}
