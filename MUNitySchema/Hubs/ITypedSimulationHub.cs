﻿using MUNity.Schema.Simulation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static MUNity.Schema.Simulation.SimulationEnums;

namespace MUNity.Hubs
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
        /// <param name="args"></param>
        /// <returns></returns>
        Task RolesChanged(RolesChangedEventArgs args);

        /// <summary>
        /// Some user with the given id has picked a new role.
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task UserRoleChanged(UserRoleChangedEventArgs args);

        /// <summary>
        /// Should be called or gets called when the List of Users has changed. (User has been added or removed)
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="Users"></param>
        /// <returns></returns>
        Task UsersChanged(UsersChangedEventArgs args);

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
        /// <param name="petition"></param>
        /// <returns></returns>
        Task UserPetition(Petition petition);

        /// <summary>
        /// The request of a user has beed accepted.
        /// </summary>
        /// <param name="petition"></param>
        /// <returns></returns>
        Task UserPetitionAccepted(Petition petition);

        /// <summary>
        /// the request of a user has been deleted or decliened.
        /// </summary>
        /// <param name="petition"></param>
        /// <returns></returns>
        Task UserPetitionDeleted(Petition petition);

        /// <summary>
        /// Gets called when the list of speakers has changed and will send the id of the new List of speakers.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task ListOfSpeakerChanged(string id);

        /// <summary>
        /// Gets called when the current Resolution has changed and will return the Id of the new resolution
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task ResolutionChanged(string id);

        /// <summary>
        /// Was a new Voting created.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task VoteCreated(CreatedVoteModel model);

        /// <summary>
        /// Has someone voted in something.
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns></returns>
        Task Voted(VotedEventArgs args);
    }
}
