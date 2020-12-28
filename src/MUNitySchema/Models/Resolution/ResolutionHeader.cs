﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Models.Resolution
{
    public class ResolutionHeader
    {
        public string Name { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Topic { get; set; } = "";
        public string AgendaItem { get; set; } = "";
        public string Session { get; set; } = "";
        public string SubmitterName { get; set; } = "";
        public string CommitteeName { get; set; } = "";

        public List<string> Supporters { get; set; }

        public ResolutionHeader()
        {
            Supporters = new List<string>();
        }
    }
}