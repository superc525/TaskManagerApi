namespace TaskManager.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public TaskStatus TaskStatus { get; set; }
    }
}
