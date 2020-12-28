using MUNitySchema.Schema.Simulation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static MUNitySchema.Schema.Simulation.SimulationEnums;

namespace MUNitySchema.Hubs
{

    /// <summary>
    /// The simulation hub is used for server and client communication over signalR to host a virtual committee.
    /// All methods within this Hub are called by the server and sent to the client.
    /// </summary>
    public interface ITypedSimulationHub
    {
        /// <summary>
        /// The available roles of the Simulation have changed.
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="Roles"></param>
        /// <returns></returns>
        Task RolesChanged(int simulationId, IEnumerable<SimulationRoleItem> Roles);

        /// <summary>
        /// Some user with the given id has picked a new role.
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task UserRoleChanged(int simulationId, int userId, int roleId);

        /// <summary>
        /// a new user has connected.
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task UserConnected(int simulationId, SimulationUserItem user);

        /// <summary>
        /// A user has disconnected.
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task UserDisconnected(int simulationId, SimulationUserItem user);

        /// <summary>
        /// The current phase of the simulation has changed.
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="phase"></param>
        /// <returns></returns>
        Task PhaseChanged(int simulationId, GamePhases phase);

        /// <summary>
        /// the status (text) of the simulation was updated.
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        Task StatusChanged(int simulationId, string newStatus);

        /// <summary>
        /// The mode of the lobby (if users can pick roles etc.) has changed.
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        Task LobbyModeChanged(int simulationId, LobbyModes mode);

        /// <summary>
        /// someone wrote into the chat
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="userId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        Task ChatMessageRecieved(int simulationId, int userId, string msg);

        /// <summary>
        /// A user has filed a request.
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UserRequest(int simulationId, int userId, string request);

        /// <summary>
        /// The request of a user has beed accepted.
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UserRequestAccepted(int simulationId, int userId, string request);

        /// <summary>
        /// the request of a user has been deleted or decliened.
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UserRequestDeleted(int simulationId, int userId, string request);
    }
}
