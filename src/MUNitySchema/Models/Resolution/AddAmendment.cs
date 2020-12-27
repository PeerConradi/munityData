using System;
using System.Collections.Generic;
using System.Text;
using MUNity.Extensions.ResolutionExtensions;

namespace MUNitySchema.Models.Resolution
{
    public class AddAmendment : AbstractAmendment
    {
        public override bool Apply(OperativeSection parentSection)
        {
            var targetParagraph = parentSection.FindOperativeParagraph(this.TargetSectionId);
            if (targetParagraph == null)
                return false;

            targetParagraph.IsVirtual = false;
            targetParagraph.Visible = true;
            parentSection.AddAmendments.Remove(this);
            return true;
        }

        public override bool Deny(OperativeSection parentResolution)
        {
            parentResolution.RemoveAmendment(this);
            return true;
        }
    }
}
