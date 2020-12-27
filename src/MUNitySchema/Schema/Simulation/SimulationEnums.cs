using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Schema.Simulation
{
    public static class SimulationEnums
    {
        public enum RoleTypes
        {
            Spectator,
            Chairman,
            Delegate,
            Moderator,
            Ngo
        }

        public enum GamePhases
        {
            Offline,
            Lobby,
            Online
        }

        public enum LobbyModes
        {
            /// <summary>
            /// Allows to Join the game with a role token and will then give
            /// you the role.
            /// </summary>
            WithRoleKey,
            /// <summary>
            /// You can join the lobby and pick a role
            /// </summary>
            PickRole,
            /// <summary>
            /// Allow everyone inside the Lobby to create a role
            /// </summary>
            CreateAnyRole,
            /// <summary>
            /// the lobby is closed you cannot join.
            /// </summary>
            Closed
        }
    }
}
