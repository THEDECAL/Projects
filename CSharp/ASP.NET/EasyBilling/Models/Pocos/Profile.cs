using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBilling.Models.Pocos
{
    public class Profile
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string SecondName { get; set; }
        [MaxLength(100)]
        public string Patronymic { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(300)]
        public string Comment { get; set; } = string.Empty;
        [Required]
        public double AmountOfCash { get; set; } = 0;
        public int? TarrifId { get; set; }
        public Tariff Tarrif { get; set; }
        public DateTime DateBeginOfUseOfTarrif { get; set; }
        public int UsedTraffic { get; set; } = 0;
        [MaxLength(100)]
        public string CustomField1 { get; set; } = string.Empty;
        [MaxLength(100)]
        public string CustomField2 { get; set; } = string.Empty;
        [MaxLength(100)]
        public string CustomField3 { get; set; } = string.Empty;
        [MaxLength(100)]
        public string CustomField4 { get; set; } = string.Empty;
        [MaxLength(100)]
        public string CustomField5 { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; }
        [Required]
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public DateTime DateOfUpdate { get; set; }
        [Required]
        public bool IsHolded { get; set; } = false;
    }
}