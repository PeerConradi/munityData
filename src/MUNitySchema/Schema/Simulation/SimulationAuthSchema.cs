using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Schema.Simulation
{
    public class SimulationAuthSchema
    {
        public int SimulationUserId { get; set; }

        public bool CanCreateRole { get; set; }

        public bool CanSelectRole { get; set; }

        public bool CanEditResolution { get; set; }

        public bool CanEditListOfSpeakers { get; set; }
    }
}
