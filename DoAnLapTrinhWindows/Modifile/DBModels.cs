using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAnLapTrinhWindows.Modifile
{
    public partial class DBModes : DbContext
    {
        public DBModes()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ADMIN_ACCOUNT> ADMIN_ACCOUNT { get; set; }
        public virtual DbSet<BOOK> BOOKs { get; set; }
        public virtual DbSet<INVOICE_DETAILS> INVOICE_DETAILS { get; set; }
        public virtual DbSet<USER_ACCOUNT> USER_ACCOUNT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN_ACCOUNT>()
                .Property(e => e.PASSWORD1)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.INVOICE_DETAILS)
                .WithRequired(e => e.BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_ACCOUNT>()
                .Property(e => e.PASSWORD1)
                .IsUnicode(false);

            modelBuilder.Entity<USER_ACCOUNT>()
                .HasMany(e => e.INVOICE_DETAILS)
                .WithRequired(e => e.USER_ACCOUNT)
                .WillCascadeOnDelete(false);
        }
    }
}
