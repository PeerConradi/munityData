using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Models.Resolution
{
    public class Comment
    {
        public string Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<CommentTag> Tags { get; set; }
        public List<string> ReadBy { get; set; }

        public Comment()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
