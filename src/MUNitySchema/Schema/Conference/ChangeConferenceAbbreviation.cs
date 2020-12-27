using System.ComponentModel.DataAnnotations;

namespace MUNitySchema.Schema.Conference
{
    public class ChangeConferenceAbbreviation
    {
        [Required]
        [MaxLength(80)]
        public string ConferenceId { get; set; }

        [Required]
        [MaxLength(18)]
        public string NewAbbreviation { get; set; }
    }
}
