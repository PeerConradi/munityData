using System;
using System.Collections.Generic;
using System.Text;
using static MUNitySchema.Schema.Simulation.SimulationEnums;

namespace MUNitySchema.Schema.Simulation
{
    public class SimulationResponse
    {
        

        public int SimulationId { get; set; }

        public string Name { get; set; }

        public GamePhases Phase { get; set; }

        public IEnumerable<SimulationRoleItem> Roles { get; set; }

        public IEnumerable<SimulationUserItem> Users { get; set; }
    }
}
