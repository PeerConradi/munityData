using System;
using System.Collections.Generic;
using System.Text;
using static MUNitySchema.Schema.Simulation.SimulationEnums;

namespace MUNitySchema.Schema.Simulation
{
    public class SimulationRoleItem
    {
        

        public int SimulationRoleId { get; set; }

        public string Name { get; set; }

        public RoleTypes RoleType { get; set; }

        public string Iso { get; set; }

        public IEnumerable<string> Users { get; set; }
    }
}
