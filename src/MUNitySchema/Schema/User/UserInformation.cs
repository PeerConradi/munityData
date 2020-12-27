using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Schema.User
{
    public class UserInformation
    {
        public string Username { get; set; }

        public string Forename { get; set; }

        public string Lastname { get; set; }

        public DateTime LastOnline { get; set; }
    }
}
