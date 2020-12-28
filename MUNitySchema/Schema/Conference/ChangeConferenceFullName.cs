using System.ComponentModel.DataAnnotations;

namespace MUNitySchema.Schema.Conference
{
    public class ChangeConferenceFullName
    {
        [Required]
        [MaxLength(80)]
        public string ConferenceId { get; set; }

        [Required]
        [MaxLength(250)]
        public string NewFullName { get; set; }
    }
}
