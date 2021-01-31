using System;
using System.Collections.Generic;
using System.Text;

namespace MUNity.Schema.Simulation
{
    public class UserRoleChangedEventArgs : EventArgs
    {
        public int SimulationId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}
