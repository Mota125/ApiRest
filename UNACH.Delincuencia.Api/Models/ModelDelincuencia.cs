using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace UNACH.Delincuencia.Api.Models
{
    public partial class ModelDelincuencia : DbContext
    {
        public ModelDelincuencia()
            : base("name=ConexionDelincuencia")
        {
        }

        public virtual DbSet<table_reportes> table_reportes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<table_reportes>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<table_reportes>()
                .Property(e => e.Primer_ap)
                .IsUnicode(false);

            modelBuilder.Entity<table_reportes>()
                .Property(e => e.Segundo_ap)
                .IsUnicode(false);

            modelBuilder.Entity<table_reportes>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<table_reportes>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<table_reportes>()
                .Property(e => e.Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<table_reportes>()
                .Property(e => e.Municipio)
                .IsUnicode(false);

            modelBuilder.Entity<table_reportes>()
                .Property(e => e.Referencias)
                .IsUnicode(false);

            modelBuilder.Entity<table_reportes>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<table_reportes>()
                .Property(e => e.Narracion)
                .IsUnicode(false);
        }
    }
}
