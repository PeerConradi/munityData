﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUNitySchema.Schema.Conference
{
    public class CreateConferenceRequest
    {
        [Required]
        public string ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Abbreviation { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public DateTime GetStartDate() => DateTime.Parse(StartDate);

        public DateTime GetEndDate() => DateTime.Parse(EndDate);
    }
}
