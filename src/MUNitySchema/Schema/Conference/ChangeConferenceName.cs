using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUNitySchema.Schema.Conference
{
    public class ChangeConferenceName
    {
        [Required]
        [MaxLength(80)]
        public string ConferenceId { get; set; }

        [Required]
        [MaxLength(150)]
        public string NewName { get; set; }
    }
}
