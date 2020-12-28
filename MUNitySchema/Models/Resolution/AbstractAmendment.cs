using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Models.Resolution
{

    /// <summary>
    /// The abstraction of an amendment. The amendment is able to change Operative Paragraphs or interact with them.
    /// </summary>
    public class AbstractAmendment
    {
        /// <summary>
        /// The Id of the Amendment.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A Name title for the Amendment. This is mostly not used by now but could be.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Operative Paragraph Id that this Amendment should interact with.
        /// Note that this is an error in naming and doesnt target the Operative Section of a resolution.
        /// </summary>
        public string TargetSectionId { get; set; }

        /// <summary>
        /// Is the Amendment activated at the moment.
        /// This is used if the amendment should be marked in a different way on the views.
        /// </summary>
        public bool Activated { get; set; }

        /// <summary>
        /// The name of the person, country, delegation that started this amendment.
        /// </summary>
        public string SubmitterName { get; set; }

        /// <summary>
        /// The time this amendment was created.
        /// </summary>
        public DateTime SubmitTime { get; set; }

        /// <summary>
        /// A string Type to identify the type of amendment.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The action that should be called when the amendment is accepted and it should interact with
        /// the resolution and its target operative Paragraph.
        /// This method will return a NotImplemntedException if you call the base so keep in mind
        /// to override it.
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public virtual bool Apply(OperativeSection section)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// What should happen if the Amendment is decliened. Remember to override this Method when
        /// extending from Abstract Amendment.
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public virtual bool Deny(OperativeSection section)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new Instance of an amendment and generates a GUID for it.
        /// </summary>
        public AbstractAmendment()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
