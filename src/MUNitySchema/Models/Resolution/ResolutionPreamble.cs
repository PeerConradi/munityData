using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Models.Resolution
{
    public class ResolutionPreamble
    {
        public string PreambleId { get; set; }
        public List<PreambleParagraph> Paragraphs { get; set; }

        public ResolutionPreamble()
        {
            PreambleId = Guid.NewGuid().ToString();
            Paragraphs = new List<PreambleParagraph>();
        }
    }
}
