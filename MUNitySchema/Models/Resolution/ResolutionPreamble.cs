﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MUNitySchema.Models.Resolution
{
    /// <summary>
    /// The preamble of a resolution containing a list of paragraphs.
    /// </summary>
    public class ResolutionPreamble
    {
        /// <summary>
        /// The id of the preamble
        /// </summary>
        public string PreambleId { get; set; }

        /// <summary>
        /// a list of paragraphs of the preamble.
        /// </summary>
        public ObservableCollection<PreambleParagraph> Paragraphs { get; set; }

        /// <summary>
        /// creates a new preamble.
        /// </summary>
        public ResolutionPreamble()
        {
            PreambleId = Guid.NewGuid().ToString();
            Paragraphs = new ObservableCollection<PreambleParagraph>();
        }
    }
}
