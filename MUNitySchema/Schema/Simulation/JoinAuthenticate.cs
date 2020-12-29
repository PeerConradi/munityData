using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUNitySchema.Schema.Simulation
{
    /// <summary>
    /// The body of a join request.
    /// </summary>
    public class JoinAuthenticate
    {
        /// <summary>
        /// The password of the simulation you want to enter.
        /// </summary>
        [MaxLength(100)]
        public string Password { get; set; }

        /// <summary>
        /// The display name you want to enter with.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string DisplayName { get; set; }
    }
}
