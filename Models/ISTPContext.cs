using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Notes
{
    public partial class ISTPContext : DbContext
    {
        public ISTPContext()
        {
        }

        public ISTPContext(DbContextOptions<ISTPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<NoteToNoteReference> NoteToNoteReferences { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagsAtNoteRelationship> TagsAtNoteRelationships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-EJRS4QR8; Database=ISTP; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ParentFolder)
                    .WithMany(p => p.InverseParentFolder)
                    .HasForeignKey(d => d.ParentFolderId)
                    .HasConstraintName("FK_Folders_Folders");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_Notes_Folders");
            });

            modelBuilder.Entity<NoteToNoteReference>(entity =>
            {
                entity.HasOne(d => d.FromNote)
                    .WithMany(p => p.NoteToNoteReferenceFromNotes)
                    .HasForeignKey(d => d.FromNoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NoteToNoteReferences_Notes");

                entity.HasOne(d => d.ToNote)
                    .WithMany(p => p.NoteToNoteReferenceToNotes)
                    .HasForeignKey(d => d.ToNoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NoteToNoteReferences_Notes1");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TagsAtNoteRelationship>(entity =>
            {
                entity.HasOne(d => d.Note)
                    .WithMany(p => p.TagsAtNoteRelationships)
                    .HasForeignKey(d => d.NoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagsAtNoteRelationships_Notes");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagsAtNoteRelationships)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagsAtNoteRelationships_Tags");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
