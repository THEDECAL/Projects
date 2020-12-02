using EasyBilling.Models.Pocos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.AspNetCore.Identity
{
    public class IdentityAccount : IdentityUser
    {
        [Required]
        public Profile Profile { get; set; }
        public DateTime LastLogin { get; set; }
        [Required]
        public bool IsEnabled { get; set; } = true;
    }
}