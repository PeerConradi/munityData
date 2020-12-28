using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Schema.Project
{
    public class ProjectInformation
    {
        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectShort { get; set; }

        public string OrganizationId { get; set; }

        public IEnumerable<Conference.ConferenceSmallInfo> Conferences { get; set; }
    }
}
