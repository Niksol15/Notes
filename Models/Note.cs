using System;
using System.Collections.Generic;

#nullable disable

namespace Notes
{
    public partial class Note
    {
        public Note()
        {
            NoteToNoteReferences = new HashSet<NoteToNoteReference>();
            TagsAtNoteRelationships = new HashSet<TagsAtNoteRelationship>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public int? FolderId { get; set; }

        public virtual Folder Folder { get; set; }
        public virtual ICollection<NoteToNoteReference> NoteToNoteReferences { get; set; }
        public virtual ICollection<TagsAtNoteRelationship> TagsAtNoteRelationships { get; set; }
    }
}
