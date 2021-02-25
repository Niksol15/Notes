using System;
using System.Collections.Generic;

#nullable disable

namespace Notes
{
    public partial class Note
    {
        public Note()
        {
            NoteToNoteReferenceFromNotes = new HashSet<NoteToNoteReference>();
            NoteToNoteReferenceToNotes = new HashSet<NoteToNoteReference>();
            TagsAtNoteRelationships = new HashSet<TagsAtNoteRelationship>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public int? FolderId { get; set; }

        public virtual Folder Folder { get; set; }
        public virtual ICollection<NoteToNoteReference> NoteToNoteReferenceFromNotes { get; set; }
        public virtual ICollection<NoteToNoteReference> NoteToNoteReferenceToNotes { get; set; }
        public virtual ICollection<TagsAtNoteRelationship> TagsAtNoteRelationships { get; set; }
    }
}
