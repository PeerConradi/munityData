using MUNitySchema.Models.Resolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUNity.Extensions.ResolutionExtensions
{

    /// <summary>
    /// Methods to work with the Preamble of a resolution.
    /// </summary>
    public static class PreambleParagraphExtensions
    {
        /// <summary>
        /// Creates a new preamble paragraph.
        /// </summary>
        /// <param name="resolution"></param>
        /// <returns></returns>
        public static PreambleParagraph CreatePreambleParagraph(this Resolution resolution)
        {
            var paragraph = new PreambleParagraph();
            resolution.Preamble.Paragraphs.Add(paragraph);
            return paragraph;
        }

        /// <summary>
        /// Checks if the opertor is valid.
        /// NOTE THIS IS NOT IMPLEMENTED YET AND WILL ALWAYS RETURN FALSE!
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        public static bool HasValidOperator(this PreambleParagraph paragraph)
        {
            return false;
        }
    }
}
