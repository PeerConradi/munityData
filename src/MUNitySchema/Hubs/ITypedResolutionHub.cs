using MUNitySchema.Models.Resolution;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUNitySchema.Hubs
{
    public interface ITypedResolutionHub
    {
        Task ResolutionChanged(Resolution resolution);
        Task PreambleParagraphChanged(string resolutionId, PreambleParagraph para, string tan);
        Task OperativeParagraphChanged(string resolutionId, OperativeParagraph para, string tan);
    }
}
