using System;
using System.Collections.Generic;

#nullable disable

namespace Notes
{
    public partial class Tag
    {
        public Tag()
        {
            TagsAtNoteRelationships = new HashSet<TagsAtNoteRelationship>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TagsAtNoteRelationship> TagsAtNoteRelationships { get; set; }
    }
}
