using System;
using System.Collections.Generic;
using System.Text;

namespace MUNity.Schema.Simulation
{
    /// <summary>
    /// The user of a simulation.
    /// </summary>
    public class SimulationUserItem
    {
        /// <summary>
        /// The simulation user Id.
        /// </summary>
        public int SimulationUserId { get; set; }

        /// <summary>
        /// The display name of the user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The current role this user has picked.
        /// </summary>
        public int RoleId { get; set; }
    }
}
