using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUNitySchema.Schema.Organization
{
    public class CreateOrganizationRequest
    {
        [Required]
        [MaxLength(300)]
        public string OrganisationName { get; set; }

        [Required]
        [MaxLength(16)]
        public string Abbreviation { get; set; }
    }
}
