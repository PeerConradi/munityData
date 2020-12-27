using MUNitySchema.Models.Resolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUNity.Extensions.ResolutionExtensions
{
    public static class PreambleParagraphExtensions
    {
        public static PreambleParagraph CreatePreambleParagraph(this Resolution resolution)
        {
            var paragraph = new PreambleParagraph();
            resolution.Preamble.Paragraphs.Add(paragraph);
            return paragraph;
        }

        public static bool HasValidOperator(this PreambleParagraph paragraph)
        {
            return false;
        }
    }
}
