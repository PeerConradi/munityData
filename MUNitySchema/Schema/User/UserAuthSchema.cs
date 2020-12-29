﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Schema.User
{
    /// <summary>
    /// The auth Schema of a MUNity User.
    /// </summary>
    public class UserAuthSchema
    {
        /// <summary>
        /// The power Rank of this user claim.
        /// </summary>
        public enum EAuthLevel
        {
            /// <summary>
            /// The highest rank, this user is allowed to see and change everything.
            /// </summary>
            Headadmin,
            /// <summary>
            /// This secound highest rank this user can do nearly everything a head admin can but this
            /// Claim is not allwed to change an otherones rank to admin.
            /// </summary>
            Admin,
            /// <summary>
            /// The developer is allowed to see a lot of technical information but not allowed to see or change
            /// everything.
            /// </summary>
            Developer,
            /// <summary>
            /// The moderator can like the Developer see a lot of information but not the same amount of technical information.
            /// </summary>
            Moderator,
            /// <summary>
            /// The user is allowed to complitly interact with the base logic of the munity platform.
            /// </summary>
            User,
            /// <summary>
            /// A new user is not verified yet and depending on the settings cant create an organization, project, conference or simulation.
            /// </summary>
            New
        }

        /// <summary>
        /// The AuthId
        /// </summary>
        public int UserAuthId { get; set; }

        /// <summary>
        /// The name of the auth.
        /// </summary>
        public string UserAuthName { get; set; }

        /// <summary>
        /// Can this user Auth create an Organization.
        /// </summary>
        public bool CanCreateOrganization { get; set; }

        /// <summary>
        /// The auth level.
        /// </summary>
        public EAuthLevel AuthLevel { get; set; }
    }
}
