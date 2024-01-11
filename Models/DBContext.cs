

using Microsoft.EntityFrameworkCore;


namespace  AppGestionFranca.Models {

    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Subsidiary> Subsidiaries { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Technician> Technicians { get; set; } = null!;
        public virtual DbSet<TechnicianItem> TechnicianItems { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("data source=FERNANDO\\SQLEXPRESS;database=DbGestionFranca;Integrated Security=SSPI;persist security info=True; TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemId).HasName("PK__Item__727E838B4B0CBDD1");

                entity.ToTable("Item");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subsidiary>(entity =>
            {
                entity.HasKey(e => e.SubsidiaryId).HasName("PK__Subsidia__5E27442B6E3A97A9");

                entity.ToTable("Subsidiary");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Technician>(entity =>
            {
                entity.HasKey(e => e.TechnicianId).HasName("PK__Technici__301F812152E7B466");

                entity.ToTable("Technician");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Salary).HasColumnType("DECIMAL");

                entity.HasOne(d => d.Subsidiary).WithMany(p => p.Technicians)
                    .HasForeignKey(d => d.SubsidiaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Technicia__Subsi__38996AB5");
            });

            modelBuilder.Entity<TechnicianItem>(entity =>
            {
                entity.HasKey(e => e.TechnicianItemId).HasName("PK__Technici__401A85273232D968");

                entity.ToTable("TechnicianItem");

                entity.HasIndex(e => new { e.TechnicianId, e.ItemId }, "UQ_TechnicianItem").IsUnique();

                entity.HasOne(d => d.Item).WithMany(p => p.TechnicianItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Technicia__ItemI__3E52440B");

                entity.HasOne(d => d.Technician).WithMany(p => p.TechnicianItems)
                    .HasForeignKey(d => d.TechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Technicia__Techn__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}