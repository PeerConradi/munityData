using System;
using System.Collections.Generic;
using System.Text;
using static MUNitySchema.Schema.Simulation.SimulationEnums;

namespace MUNitySchema.Schema.Simulation
{
    public class SimulationListItem
    {
        public int SimulationId { get; set; }

        public string Name { get; set; }

        public bool UsingPassword { get; set; }

        public GamePhases Phase { get; set; }
    }
}
