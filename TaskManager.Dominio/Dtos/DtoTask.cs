namespace TaskManager.Domain.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using TaskManager.Domain.Enums;
    public class DtoTask
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Titulo debe ser minimo 1 y maximo 60 caracteres")]
        public string Title { get; set; }
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Debe agregar una breve descripción. Maximo 150 caracteres")]
        public string Description { get; set; }
        [Required]
        [EnumDataType(typeof(TaskStatusEnum), ErrorMessage = "El estado de la tarea ingresada no es valido")]
        public TaskStatusEnum Status { get; set; }
    }
}
