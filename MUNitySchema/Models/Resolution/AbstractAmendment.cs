using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Models.Resolution
{
    public class AbstractAmendment
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TargetSectionId { get; set; }
        public bool Activated { get; set; }
        public string SubmitterName { get; set; }
        public DateTime SubmitTime { get; set; }
        public string Type { get; set; }

        public virtual bool Apply(OperativeSection section)
        {
            throw new NotImplementedException();
        }

        public virtual bool Deny(OperativeSection section)
        {
            throw new NotImplementedException();
        }

        public AbstractAmendment()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
