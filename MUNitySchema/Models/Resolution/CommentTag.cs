﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Models.Resolution
{
    /// <summary>
    /// A tag for a comment that could display: importand, question etc.
    /// </summary>
    public class CommentTag
    {
        /// <summary>
        /// To Identify the Tag later
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A Tag has a type, for example: success, danger, error etc.
        /// The types are inside a string and not an enum because they are a string
        /// and not an enum.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The Text of the Tag, should be short but is not limited by default.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Creates a new Comment Tag and will give it an id.
        /// </summary>
        public CommentTag()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
