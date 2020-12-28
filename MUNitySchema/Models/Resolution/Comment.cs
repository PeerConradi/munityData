using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Models.Resolution
{
    /// <summary>
    /// A Comment for an operative paragraph or a preamble paragraph to allow a discussion about the paragraphs.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// The Id of the comment
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The author name of the Comment
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// The Id of the author if you can use if the author is logged in.
        /// </summary>
        public string AuthorId { get; set; }

        /// <summary>
        /// The date the comment has been created, you can also use this a last Changed date.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// The title of the comment. This can be set and will not be generated automaticaly.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The text of the comment.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Tags that are added to the comment.
        /// </summary>
        public List<CommentTag> Tags { get; set; }

        /// <summary>
        /// List of names that have marked to comment as read.
        /// </summary>
        public List<string> ReadBy { get; set; }

        /// <summary>
        /// Creates a new Instance of a comment for operative paragraphs or preamble paragraphs and give them a new guid.
        /// </summary>
        public Comment()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
