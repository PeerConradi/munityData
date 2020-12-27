using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUNitySchema.Schema.Simulation
{
    public class JoinAuthenticate
    {
        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(50)]
        [Required]
        public string DisplayName { get; set; }
    }
}
