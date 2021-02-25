using System;
using System.Collections.Generic;

#nullable disable

namespace Notes
{
    public partial class Folder
    {
        public Folder()
        {
            InverseParentFolder = new HashSet<Folder>();
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public int? ParentFolderId { get; set; }
        public DateTime ModificationTime { get; set; }

        public virtual Folder ParentFolder { get; set; }
        public virtual ICollection<Folder> InverseParentFolder { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
