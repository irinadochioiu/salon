using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace proiect_maria
{
    public partial class SalonEntitiesModel : DbContext
    {
        public SalonEntitiesModel()
            : base("name=SalonEntitiesModel")
        {
        }

        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<Programari> Programari { get; set; }
        public virtual DbSet<Servicii> Servicii { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clienti>()
                .Property(e => e.NrTel)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Clienti>()
                .HasMany(e => e.Programari)
                .WithOptional(e => e.Clienti)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Servicii>()
                .HasMany(e => e.Programari)
                .WithOptional(e => e.Servicii)
                .HasForeignKey(e => e.ServId)
                .WillCascadeOnDelete();
        }
    }
}
