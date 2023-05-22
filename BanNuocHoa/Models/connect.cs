using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BanNuocHoa.Models
{
    public partial class connect : DbContext
    {
        public connect()
            : base("name=connect")
        {
        }

        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<PHANQUYEN> PHANQUYENs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.CT_giaban)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.CT_giamgia)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.CT_thanhtien)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.Donhang_giatien)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.Sanpham_gia)
                .HasPrecision(10, 2);

            modelBuilder.Entity<THELOAI>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.THELOAI)
                .WillCascadeOnDelete(false);
        }
    }
}
