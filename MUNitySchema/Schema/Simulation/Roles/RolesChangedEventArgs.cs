using System;
using System.Collections.Generic;
using System.Text;

namespace MUNity.Schema.Simulation
{
    public class RolesChangedEventArgs : EventArgs
    {
        public int SimulationId { get; set; }

        public List<SimulationRoleItem> Roles { get; set; }
    }
}
