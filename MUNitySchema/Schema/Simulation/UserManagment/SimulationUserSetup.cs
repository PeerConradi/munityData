using System;
using System.Collections.Generic;
using System.Text;

namespace MUNity.Schema.Simulation
{
    /// <summary>
    /// User Package for the administrators that can see and edit the users.
    /// </summary>
    public class SimulationUserSetup : IUserItem
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

        /// <summary>
        /// Returns of the user is connected or not. This is known if there is an active Hub Connection.
        /// </summary>
        public bool IsOnline { get; set; }


        /// <summary>
        /// The Public Id of the user.
        /// </summary>
        public string PublicId { get; set; }

        /// <summary>
        /// The password of the user.
        /// </summary>
        public string Password { get; set; }
    }
}
