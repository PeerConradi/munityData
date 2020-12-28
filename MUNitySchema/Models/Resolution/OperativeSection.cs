using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Models.Resolution
{
    /// <summary>
    /// The Operative Section of a resolution containing the Paragraphs and the Amendments.
    /// </summary>
    public class OperativeSection
    {
        public string OperativeSectionId { get; set; }
        public List<OperativeParagraph> Paragraphs { get; set; }
        public List<ChangeAmendment> ChangeAmendments { get; set; }
        public List<AddAmendment> AddAmendments { get; set; }
        public List<MoveAmendment> MoveAmendments { get; set; }
        public List<DeleteAmendment> DeleteAmendments { get; set; }

        public OperativeSection()
        {
            OperativeSectionId = Guid.NewGuid().ToString();
            Paragraphs = new List<OperativeParagraph>();
            ChangeAmendments = new List<ChangeAmendment>();
            AddAmendments = new List<AddAmendment>();
            MoveAmendments = new List<MoveAmendment>();
            DeleteAmendments = new List<DeleteAmendment>();
        }
    }
}
