using MUNity.Models.Resolution;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUNity.Hubs
{

    /// <summary>
    /// The HUB used by the API for SignalR communication when talking to the clients.
    /// </summary>
    public interface ITypedResolutionHub
    {
        /// <summary>
        /// Something within the Resolution has changed and the client should refresh the views.
        /// </summary>
        /// <param name="resolution">The latest state of the resolution.</param>
        /// <returns></returns>
        Task ResolutionChanged(Resolution resolution);

        /// <summary>
        /// Something within the given PreambleParagraph has changed. This could be the Text or the Comments.
        /// </summary>
        /// <param name="resolutionId"></param>
        /// <param name="para"></param>
        /// <param name="tan"></param>
        /// <returns></returns>
        Task PreambleParagraphChanged(string resolutionId, PreambleParagraph para, string tan);

        /// <summary>
        /// Something within the Operative Paragraph has changed this could be the text or the comments.
        /// </summary>
        /// <param name="resolutionId"></param>
        /// <param name="para"></param>
        /// <param name="tan"></param>
        /// <returns></returns>
        Task OperativeParagraphChanged(string resolutionId, OperativeParagraph para, string tan);
    }
}
