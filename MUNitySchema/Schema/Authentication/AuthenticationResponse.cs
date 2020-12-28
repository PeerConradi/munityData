using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Schema.Authentication
{
    public class AuthenticationResponse
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Token { get; set; }
    }
}
