namespace DocumentsProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelDocumentDb")
        {
        }

        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .Property(e => e.Subject)
                .IsFixedLength();

            modelBuilder.Entity<Table>()
                .Property(e => e.DocumentType)
                .IsFixedLength();

            modelBuilder.Entity<Table>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<Table>()
                .Property(e => e.File)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<DocumentsProject.Models.DocumentModel> Documents { get; set; }
    }
}
