using System;
using System.ComponentModel.DataAnnotations;

namespace MUNitySchema.Schema.Conference
{
    public class ChangeConferenceDate
    {
        [Required]
        [MaxLength(80)]
        public string ConferenceId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
