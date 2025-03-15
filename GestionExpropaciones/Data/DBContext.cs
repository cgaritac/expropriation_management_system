using Microsoft.EntityFrameworkCore;
using GestionExpropaciones.Models;

namespace GestionExpropaciones.Data;

public class AppDbContext : DbContext
{
    public DbSet<FileModel> Files { get; set; }
    public DbSet<ProjectModel> Project { get; set; }
    public DbSet<OwnerModel> Owners { get; set; }
    public DbSet<OwnerPropertyModel> OwnerProperties { get; set; }
    public DbSet<PaperWorkModel> PaperWorks { get; set; }
    public DbSet<AppraisalModel> Appraisals { get; set; }
    public DbSet<ExpropiatedPropertyModel> ExpropiatedProperties { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FileModel>(entity =>
        {
            entity.ToTable("Files");
            entity.HasKey(f => f.Id);
            entity.Property(f => f.Id).ValueGeneratedOnAdd().IsRequired();
            entity.Property(f => f.Number).HasColumnName("Number").HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(f => f.Project_Number).HasColumnName("Project_Number").HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(f => f.Section).HasColumnName("Section").HasColumnType("int").IsRequired();
            entity.Property(f => f.Km).HasColumnName("Km").HasColumnType("nvarchar(20)").IsRequired();
            entity.Property(f => f.Fase).HasColumnName("Fase").HasColumnType("int").IsRequired();
            entity.Property(f => f.Status).HasColumnName("Status").HasColumnType("int").IsRequired();
            entity.Property(f => f.Start_Date).HasColumnName("Start_Date").HasColumnType("date").IsRequired();
            entity.Property(f => f.Finish_Date).HasColumnName("Finish_Date").HasColumnType("date").IsRequired(false);
            entity.Property(f => f.Comments).HasColumnName("Comments").HasColumnType("nvarchar(2100)").IsRequired(false);
            entity.Property(f => f.Created_By).HasColumnName("Created_By").HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(f => f.Is_Active).HasColumnName("Is_Active").HasColumnType("bit").IsRequired();

            entity.HasMany(f => f.Owners)
                  .WithOne(o => o.File)
                  .HasForeignKey(o => o.FileId)
                  .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<OwnerModel>(entity =>
        {
            entity.ToTable("Owners");
            entity.HasKey(o => o.Id);
            entity.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            entity.Property(o => o.First_Name).HasColumnName("First_Name").HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(o => o.Last_Name1).HasColumnName("Last_Name1").HasColumnType("nvarchar(50)");
            entity.Property(o => o.Last_Name2).HasColumnName("Last_Name2").HasColumnType("nvarchar(50)");
            entity.Property(o => o.Phone1).HasColumnName("Phone1").HasColumnType("nvarchar(100)");
            entity.Property(o => o.Phone2).HasColumnName("Phone2").HasColumnType("nvarchar(100)");
            entity.Property(o => o.Email1).HasColumnName("Email1").HasColumnType("nvarchar(100)");
            entity.Property(o => o.Email12).HasColumnName("Email12").HasColumnType("nvarchar(100)");
            entity.Property(o => o.Address).HasColumnName("Address").HasColumnType("nvarchar(200)");
            entity.Property(o => o.Identification_Number).HasColumnName("Identification_Number").HasColumnType("nvarchar(10)").IsRequired();
            entity.Property(o => o.Owner_Type).HasColumnName("Owner_Type").HasColumnType("int").IsRequired();
            entity.Property(o => o.Comments).HasColumnName("Comments").HasColumnType("nvarchar(2000)");
            entity.Property(o => o.Created_By).HasColumnName("Created_By").HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(o => o.Created_On).HasColumnName("Created_On").HasColumnType("date").IsRequired();
            entity.Property(o => o.Is_Active).HasColumnName("Is_Active").HasColumnType("bit").IsRequired();

            entity.HasOne(o => o.File)
                  .WithMany(f => f.Owners)
                  .HasForeignKey(o => o.FileId)
                  .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<OwnerPropertyModel>(entity =>
        {
            entity.ToTable("OwnerProperties");
            entity.HasKey(op => op.Id);
            entity.Property(op => op.Id).ValueGeneratedOnAdd().IsRequired();
            entity.Property(op => op.CadastralMap_Number).HasColumnName("CadastralMap_Number").HasColumnType("nvarchar(20)").IsRequired();
            entity.Property(op => op.Folio_Number).HasColumnName("Folio_Number").HasColumnType("nvarchar(20)").IsRequired();
            entity.Property(op => op.Area).HasColumnName("Area").HasColumnType("int").IsRequired();
            entity.Property(op => op.Annotation).HasColumnName("Annotation").HasColumnType("int").IsRequired();
            entity.Property(op => op.Province).HasColumnName("Province").HasColumnType("int").IsRequired();
            entity.Property(op => op.Canton).HasColumnName("Canton").HasColumnType("int").IsRequired();
            entity.Property(op => op.District).HasColumnName("District").HasColumnType("nvarchar(20)");
            entity.Property(op => op.Comments).HasColumnName("Comments").HasColumnType("nvarchar(2000)");
            entity.Property(op => op.Created_By).HasColumnName("Created_By").HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(op => op.Created_On).HasColumnName("Created_On").HasColumnType("date").IsRequired();
            entity.Property(op => op.Is_Active).HasColumnName("Is_Active").HasColumnType("bit").IsRequired();

            entity.HasOne(op => op.File)
                  .WithMany(f => f.OwnerProperties)
                  .HasForeignKey(op => op.FileId)
                  .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<PaperWorkModel>(entity =>
        {
            entity.ToTable("PaperWorks");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            entity.Property(p => p.Document_Number).HasColumnName("Document_Number").HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(p => p.Document_Date).HasColumnName("Document_Date").HasColumnType("date").IsRequired();
            entity.Property(p => p.PaperWork_type).HasColumnName("PaperWork_type").HasColumnType("int").IsRequired();
            entity.Property(p => p.Comments).HasColumnName("Comments").HasColumnType("nvarchar(2000)");
            entity.Property(p => p.Created_By).HasColumnName("Created_By").HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(p => p.Created_On).HasColumnName("Created_On").HasColumnType("date").IsRequired();
            entity.Property(p => p.Is_Active).HasColumnName("Is_Active").HasColumnType("bit").IsRequired();
            entity.Property(p => p.FileId).HasColumnName("FileId").HasColumnType("int").IsRequired();

            entity.HasOne(p => p.File)
                  .WithMany(f => f.PaperWorks)
                  .HasForeignKey(p => p.FileId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<AppraisalModel>(entity =>
        {
            entity.ToTable("Appraisals");
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).ValueGeneratedOnAdd().IsRequired();
            entity.Property(a => a.Appraisal_Number).HasColumnName("Appraisal_Number").HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(a => a.Appraisal_Date).HasColumnName("Appraisal_Date").HasColumnType("date").IsRequired();
            entity.Property(a => a.Estimated_Appraisal).HasColumnName("Estimated_Appraisal").HasColumnType("float").IsRequired();
            entity.Property(a => a.Real_Appraisal).HasColumnName("Real_Appraisal").HasColumnType("float");
            entity.Property(a => a.Payment_Status).HasColumnName("Payment_Status").HasColumnType("int").IsRequired();
            entity.Property(a => a.Comments).HasColumnName("Comments").HasColumnType("nvarchar(2000)");
            entity.Property(a => a.Created_By).HasColumnName("Created_By").HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(a => a.Created_On).HasColumnName("Created_On").HasColumnType("date").IsRequired();
            entity.Property(a => a.Is_Active).HasColumnName("Is_Active").HasColumnType("bit").IsRequired();
            entity.Property(a => a.FileId).HasColumnName("FileId").HasColumnType("int").IsRequired();

            entity.HasOne(a => a.File)
                  .WithMany(f => f.Appraisals)
                  .HasForeignKey(a => a.FileId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ExpropiatedPropertyModel>(entity =>
        {
            entity.ToTable("ExpropiatedProperties");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
            entity.Property(e => e.Folio_Number).HasColumnName("Folio_Number").HasColumnType("nvarchar(20)").IsRequired();
            entity.Property(e => e.Cadastral_Map).HasColumnName("Cadastral_Map").HasColumnType("nvarchar(20)").IsRequired();
            entity.Property(e => e.Area).HasColumnName("Area").HasColumnType("int").IsRequired();
            entity.Property(e => e.Province).HasColumnName("Province").HasColumnType("int").IsRequired();
            entity.Property(e => e.Canton).HasColumnName("Canton").HasColumnType("int").IsRequired();
            entity.Property(e => e.District).HasColumnName("District").HasColumnType("nvarchar(20)");
            entity.Property(e => e.Comments).HasColumnName("Comments").HasColumnType("nvarchar(2000)");
            entity.Property(e => e.Created_By).HasColumnName("Created_By").HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(e => e.Created_On).HasColumnName("Created_On").HasColumnType("date").IsRequired();
            entity.Property(e => e.Is_Active).HasColumnName("Is_Active").HasColumnType("bit").IsRequired();
            entity.Property(e => e.FileId).HasColumnName("FileId").HasColumnType("int").IsRequired();

            entity.HasOne(e => e.File)
                  .WithMany(f => f.ExpropiatedProperties)
                  .HasForeignKey(e => e.FileId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ProjectModel>(entity =>
        {
            entity.ToTable("Project");
            entity.HasKey(f => f.Id);
            entity.Property(f => f.Id).ValueGeneratedOnAdd().IsRequired();
            entity.Property(f => f.Number).HasColumnName("Number").HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(f => f.Name).HasColumnName("Name").HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(f => f.Comments).HasColumnName("Comments").HasColumnType("nvarchar(2100)").IsRequired(false);
            entity.Property(f => f.Created_By).HasColumnName("Created_By").HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(f => f.Created_On).HasColumnName("Created_On").HasColumnType("date").IsRequired();
            entity.Property(f => f.Is_Active).HasColumnName("Is_Active").HasColumnType("bit").IsRequired();
        });
    }
}