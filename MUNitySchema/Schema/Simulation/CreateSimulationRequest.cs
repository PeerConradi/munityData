using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUNitySchema.Schema.Simulation
{
    public class CreateSimulationRequest
    {
        [Required]
        public string Name { get; set; }

        public string Password { get; set; }

        [Required]
        public string AdminPassword { get; set; }

        [Required]
        public string UserDisplayName { get; set; }
    }
}
