using System;
using System.Collections.Generic;
using System.Text;
using MUNity.Extensions.ResolutionExtensions;

namespace MUNitySchema.Models.Resolution
{
    public class DeleteAmendment : AbstractAmendment
    {
        public override bool Apply(OperativeSection parentSection)
        {
            var paragraph = parentSection.FindOperativeParagraph(this.TargetSectionId);

            if (!parentSection.Paragraphs.Contains(paragraph))
                return false;

            parentSection.Paragraphs.Remove(paragraph);

            parentSection.AmendmentsForOperativeParagraph(this.TargetSectionId).ForEach(n => parentSection.RemoveAmendment(n));
            return true;
        }

        public override bool Deny(OperativeSection section)
        {
            var count = section.DeleteAmendments.RemoveAll(n =>
                n.TargetSectionId == this.TargetSectionId);

            return count > 0;
        }
    }
}
