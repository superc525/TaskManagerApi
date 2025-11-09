namespace TaskManager.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class TaskStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }

        // Relación 1:N
        public ICollection<Task> Tasks { get; set; }
    }
}
