using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Schema.User
{
    public class UserAuthSchema
    {
        public enum EAuthLevel
        {
            Headadmin,
            Admin,
            Developer,
            Moderator,
            User,
            New
        }

        public int UserAuthId { get; set; }

        public string UserAuthName { get; set; }

        public bool CanCreateOrganisation { get; set; }

        public EAuthLevel AuthLevel { get; set; }
    }
}
