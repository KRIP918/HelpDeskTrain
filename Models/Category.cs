using System;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskTrain.Models
{
    // Модель Активы
    public class Activ
    {
        public int Id { get; set; }
        // номер кабинета
        [Required]
        [Display(Name = "Номер кабинета")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string CabNumber { get; set; }

        // Внешний ключ
        // ID Отдела - обычное свойство
        [Required]
        [Display(Name = "Отдел")]
        public int? DepartmentId { get; set; }
        // Отдел - Навигационное свойство
        public Department Department { get; set; }
    }

    // модель отделы
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название отдела")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название категории")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }

    }
}
