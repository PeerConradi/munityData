using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Models.Resolution
{
    public class Resolution
    {
        public string ResolutionId { get; set; }

        public DateTime Date { get; set; }

        public ResolutionHeader Header { get; set; }

        public ResolutionPreamble Preamble { get; set; }
        public OperativeSection OperativeSection { get; set; }

        public Resolution()
        {
            ResolutionId = Guid.NewGuid().ToString();
            Preamble = new ResolutionPreamble();
            OperativeSection = new OperativeSection();
            Header = new ResolutionHeader();
            Date = DateTime.Now;
        }
    }
}
