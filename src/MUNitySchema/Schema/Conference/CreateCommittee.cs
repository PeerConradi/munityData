using System.ComponentModel.DataAnnotations;

namespace MUNitySchema.Schema.Conference
{
    public class CreateCommittee
    {
        [Required]
        [MaxLength(80)]
        public string ConferenceId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(10)]
        public string Abbreviation { get; set; }

        [Required]
        [MaxLength(10)]
        public string Article { get; set; }

        public string ResolutlyCommitteeId { get; set; }
    }
}
