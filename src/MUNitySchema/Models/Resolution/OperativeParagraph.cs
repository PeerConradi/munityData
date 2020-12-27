using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MUNitySchema.Models.Resolution
{
    public class OperativeParagraph : INotifyPropertyChanged
    {
        public delegate void TextChangedEventHandler(OperativeParagraph paragraph, string newText, string oldText);

        public event TextChangedEventHandler TextChanged;

        public string OperativeParagraphId { get; set; }
        public string Name { get; set; } = "";
        public bool IsLocked { get; set; } = false;

        /// <summary>
        /// Virtual is true when the Operative Paragraph comes from an AddAmendment and doesn't really count as an
        /// paragraph or if it is from a move amendment and is the paragraph where the orignal should be moved to.
        /// </summary>
        public bool IsVirtual { get; set; } = false;

        private string _text;

        

        public string Text
        {
            get => this._text;
            set
            {
                if (_text == value) return;
                var oldText = this._text;
                this._text = value;
                this.NotifyPropertyChanged(nameof(Text));
                this.TextChanged?.Invoke(this, value, oldText);
            }
        }
        public bool Visible { get; set; } = true;
        public bool Corrected { get; set; }

        public ObservableCollection<OperativeParagraph> Children { get; set; }

        public ObservableCollection<Comment> Comments { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public OperativeParagraph(string text = "")
        {
            this.Text = text;
        }
    }
}
