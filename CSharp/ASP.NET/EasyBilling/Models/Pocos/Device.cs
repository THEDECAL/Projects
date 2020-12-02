using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBilling.Models.Pocos
{
    public class Device
    {
        public int Id { get; set; }
        [Required]
        public int TypeId { get; set; } = 0;
        [Required]
        public int CurrentStateId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Brand { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string MAC { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
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
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public DateTime DateOfUpdate { get; set; } = DateTime.Now;
    }
}