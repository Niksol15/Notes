using System;
using System.Collections.Generic;

#nullable disable

namespace Notes
{
    public partial class TagsAtNoteRelationship
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public int TagId { get; set; }

        public virtual Note Note { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
