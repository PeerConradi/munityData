using System;
using System.Collections.Generic;
using System.Text;
using MUNity.Extensions.ResolutionExtensions;

namespace MUNitySchema.Models.Resolution
{
    public class ChangeAmendment : AbstractAmendment
    {
        public string NewText { get; set; }

        public override bool Apply(OperativeSection parentSection)
        {
            parentSection.ChangeAmendments.Remove(this);
            var target = parentSection.FindOperativeParagraph(this.TargetSectionId);
            if (target == null) return false;
            target.Text = this.NewText;
            return true;
        }

        public override bool Deny(OperativeSection parentSection)
        {
            parentSection.ChangeAmendments.Remove(this);
            return true;
        }
    }
}
