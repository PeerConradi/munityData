using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Models.Resolution
{

    /// <summary>
    /// A Preamble Paragraphs. This type of paragraph cannot have amendments or child paragraphs.
    /// </summary>
    public class PreambleParagraph
    {
        /// <summary>
        /// Delegate for the Text Changed Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="oldText"></param>
        /// <param name="newText"></param>
        public delegate void OnTextChanged(PreambleParagraph sender, string oldText, string newText);

        /// <summary>
        /// Delegate for the comment changed event
        /// </summary>
        /// <param name="sender"></param>
        public delegate void OnNoticesChanged(PreambleParagraph sender);

        /// <summary>
        /// Event if the Text has changed.
        /// </summary>
        public event OnTextChanged TextChanged;

        /// <summary>
        /// Event if the Comment (Notices) have changed.
        /// </summary>
        public event OnNoticesChanged NoticesChanged;

        /// <summary>
        /// The Id of the Preamble Paragraph.
        /// </summary>
        public string PreambleParagraphId { get; set; }

        private string _text = "";
        /// <summary>
        /// The Text (content) of the paragraph.
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                if (value == _text) return;
                var oldText = _text;
                _text = value;
                TextChanged?.Invoke(this, oldText, value);
            }
        }

        /// <summary>
        /// is the paragraph marked as locked. This will not effect the Text Property you can still change the Text or comments
        /// event if this property is set to true (locked).
        /// </summary>
        public bool IsLocked { get; set; } = false;

        /// <summary>
        /// Marks the paragraph as corrected. Note that this property will still keep its value even if the text is changed.
        /// </summary>
        public bool Corrected { get; set; }

        /// <summary>
        /// A List of comments for this paragraph. This will become an Observable collection in higher versions.
        /// </summary>
        public List<Comment> Comments { get; set; }

        /// <summary>
        /// A function to invoke the NoticesChanged from outside of the Function. This will be changed into 
        /// a property changed event in future implementations.
        /// </summary>
        public void InvokeNoticesChanged()
        {
            this.NoticesChanged?.Invoke(this);
        }

        /// <summary>
        /// Creates a new Preamble paragraph.
        /// </summary>
        public PreambleParagraph()
        {
            PreambleParagraphId = Guid.NewGuid().ToString();
            Comments = new List<Comment>();
        }
    }
}
