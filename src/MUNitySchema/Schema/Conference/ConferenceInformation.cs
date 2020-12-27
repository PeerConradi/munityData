using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Schema.Conference
{
    public class ConferenceInformation
    {
        public string ConferenceId { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string ConferenceShort { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ProjectId { get; set; }

        public IEnumerable<CommitteeSmallInfo> CommitteeIds { get; set; }
    }
}
