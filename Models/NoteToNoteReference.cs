using System;
using System.Collections.Generic;

#nullable disable

namespace Notes
{
    public partial class NoteToNoteReference
    {
        public int Id { get; set; }
        public int FromNoteId { get; set; }
        public int ToNoteId { get; set; }

        public virtual Note FromNote { get; set; }
    }
}
