using System.ComponentModel;

namespace ToDoApp.Models
{
    public class ToDoModel
    {
        public int TaskId { get; set; }
        [DisplayName("Task")]
        public string Name { get; set; }
        [DisplayName("Description (optional)")]
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
