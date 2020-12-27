using MUNitySchema.Schema.Simulation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static MUNitySchema.Schema.Simulation.SimulationEnums;

namespace MUNitySchema.Hubs
{
    public interface ITypedSimulationHub
    {
        Task RolesChanged(int simulationId, IEnumerable<SimulationRoleItem> Roles);

        Task UserRoleChanged(int simulationId, int userId, int roleId);

        Task UserConnected(int simulationId, SimulationUserItem user);

        Task UserDisconnected(int simulationId, SimulationUserItem user);

        Task PhaseChanged(int simulationId, GamePhases phase);

        Task StatusChanged(int simulationId, string newStatus);

        Task LobbyModeChanged(int simulationId, LobbyModes mode);

        Task ChatMessageRecieved(int simulationId, int userId, string msg);

        Task UserRequest(int simulationId, int userId, string request);

        Task UserRequestAccepted(int simulationId, int userId, string request);

        Task UserRequestDeleted(int simulationId, int userId, string request);
    }
}
