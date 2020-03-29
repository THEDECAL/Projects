using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Web.Mvc;

namespace week2.Models
{
    public partial class Ticket
    {
        public enum prio { VERY_LOW, LOW, MIDDLE, HIGH, VERY_HIGH };
        public static readonly string[] prioNames = { "Очень низкий", "Низкий", "Средний", "Высокий", "Очень высокий" };
        static readonly Color[] prioColors = { Color.Yellow, Color.Green, Color.White, Color.Red, Color.Purple };

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; } = 0;

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Название должно быть введено.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина названия должна быть не меньше 5 символово и не больше 50.")]
        public string Title { get; set; } = "";

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Описание должно быть введено.")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "Длина описания должна быть не меньше 5 символово и не больше 300.")]
        public string Description { get; set; } = "";

        [Display(Name = "Приоритет")]
        [Required(ErrorMessage = "Приоритет должно быть введён.")]
        public prio Priority { get; set; } = prio.MIDDLE;

        [Display(Name = "Дата создания")]
        [Required(ErrorMessage = "Дата создания должна быть введена.")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Display(Name = "Дата завершения")]
        [Required(ErrorMessage = "Дата завершения должна быть введена.")]
        public DateTime EndDate { get; set; } = (DateTime.Now).AddDays(1);

        [Display(Name = "Статус")]
        [Required]
        public bool Status { get; set; } = false;

        [ScaffoldColumn(false)]
        [Required]
        public bool IsDelete { get; set; } = false;

        public string PriorityColor()
        {
            Color color = prioColors[(int)this.Priority];
            return $"rgba({color.R.ToString()}, {color.G.ToString()}, {color.B.ToString()}, 0.3)";
        }
        public string StatusName() => (this.Status) ? "Выполнена" : "В работе";
        public string PriorityName() => prioNames[(int)this.Priority];
    }
}