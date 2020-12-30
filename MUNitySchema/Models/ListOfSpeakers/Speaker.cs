using System;
using System.Collections.Generic;
using System.Text;

namespace MUNity.Models.ListOfSpeakers
{

    /// <summary>
    /// A Speaker is someone who can be added to the Speakers or Questions inside a List of Speakers.
    /// You can give any time of name, so you could set it to a person a Country or Delegation.
    /// </summary>
    public class Speaker
    {
        /// <summary>
        /// The Id of the Speaker. This can and should change every time
        /// even if the same person is in one of the lists twice to be able to identify it exact.
        /// The Id has nothing to do with the Paricipant, Delegation, Country etc.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The Name that will be displayed.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An Iso code because mostly Counties will be used in this list. You could use the
        /// Iso to identify an icon.
        /// </summary>
        public string Iso { get; set; }
    }
}
