using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Models.Resolution
{
    public class PreambleParagraph
    {
        public delegate void OnTextChanged(PreambleParagraph sender, string oldText, string newText);

        public delegate void OnNoticesChanged(PreambleParagraph sender);

        public event OnTextChanged TextChanged;

        public event OnNoticesChanged NoticesChanged;

        public string PreambleParagraphId { get; set; }

        private string _text = "";
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
        public bool IsLocked { get; set; } = false;

        public bool Corrected { get; set; }

        public List<Comment> Comments { get; set; }

        public void InvokeNoticesChanged()
        {
            this.NoticesChanged?.Invoke(this);
        }

        public PreambleParagraph()
        {
            PreambleParagraphId = Guid.NewGuid().ToString();
            Comments = new List<Comment>();
        }
    }
}
