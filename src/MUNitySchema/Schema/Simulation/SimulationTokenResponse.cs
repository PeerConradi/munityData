using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Schema.Simulation
{
    public class SimulationTokenResponse
    {
        public int SimulationId { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public string Pin { get; set; }
    }
}
