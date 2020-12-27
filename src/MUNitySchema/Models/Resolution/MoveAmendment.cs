using System;
using System.Collections.Generic;
using System.Text;
using MUNity.Extensions.ResolutionExtensions;

namespace MUNitySchema.Models.Resolution
{
    public class MoveAmendment : AbstractAmendment
    {
        public string NewTargetSectionId { get; set; }

        public override bool Apply(OperativeSection parentSection)
        {
            var placeholder = parentSection.FindOperativeParagraph(NewTargetSectionId);
            var target = parentSection.FindOperativeParagraph(TargetSectionId);

            if (target == null || placeholder == null)
                return false;

            placeholder.Children = target.Children;
            placeholder.Corrected = target.Corrected;
            placeholder.IsLocked = false;
            placeholder.IsVirtual = false;
            placeholder.Name = target.Name;
            placeholder.OperativeParagraphId = target.OperativeParagraphId;
            target.OperativeParagraphId = Guid.NewGuid().ToString();
            this.TargetSectionId = target.OperativeParagraphId;
            placeholder.Text = target.Text;
            placeholder.Visible = true;
            parentSection.RemoveOperativeParagraph(target);
            return true;
        }

        public override bool Deny(OperativeSection parentSection)
        {
            parentSection.RemoveAmendment(this);
            return true;
        }
    }
}
