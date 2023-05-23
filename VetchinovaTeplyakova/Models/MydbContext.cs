using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VetchinovaTeplyakova.Models;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicationss> Applicationsses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Check> Checks { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ConsignmentNote> ConsignmentNotes { get; set; }

    public virtual DbSet<FeedbackAndWish> FeedbackAndWishes { get; set; }

    public virtual DbSet<GoodsFromTheCheck> GoodsFromTheChecks { get; set; }

    public virtual DbSet<Means> Means { get; set; }

    public virtual DbSet<OrdersApplication> OrdersApplications { get; set; }

    public virtual DbSet<OrdersCheck> OrdersChecks { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<RemedyApplication> RemedyApplications { get; set; }

    public virtual DbSet<ResourceGuideItem> ResourceGuideItems { get; set; }

    public virtual DbSet<ReturnNote> ReturnNotes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceApplication> ServiceApplications { get; set; }

    public virtual DbSet<ServiceProvided> ServiceProvideds { get; set; }

    public virtual DbSet<ServiceStaff> ServiceStaffs { get; set; }

    public virtual DbSet<ShiftSchedule> ShiftSchedules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost; user=root; database=mydb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicationss>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("applicationss");

            entity.HasIndex(e => e.ClientId, "FKrecords_clients_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("date_time");

            entity.HasOne(d => d.Client).WithMany(p => p.Applicationsses)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKapplications_clients");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Check>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("checks");

            entity.HasIndex(e => e.ClientId, "FK__Checks_Clients_idx");

            entity.HasIndex(e => e.ServiceProvidedId, "FK__Checks_ServiceProvideds_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Data)
                .HasColumnType("tinytext")
                .HasColumnName("data");
            entity.Property(e => e.Price)
                .HasMaxLength(45)
                .HasColumnName("price");
            entity.Property(e => e.ServiceProvidedId).HasColumnName("service _provided_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Checks)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checks_Clients");

            entity.HasOne(d => d.ServiceProvided).WithMany(p => p.Checks)
                .HasForeignKey(d => d.ServiceProvidedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checks_ServiceProvideds");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .HasColumnName("fio");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(16)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<ConsignmentNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("consignment_notes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfDelivery)
                .HasMaxLength(45)
                .HasColumnName("date_of_delivery");
            entity.Property(e => e.Number)
                .HasMaxLength(45)
                .HasColumnName("number");
        });

        modelBuilder.Entity<FeedbackAndWish>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("feedback_and_wishes");

            entity.HasIndex(e => e.ClientId, "FKFeedbackAndWishes_Clients_idx");

            entity.HasIndex(e => e.ServiceProvidedId, "FKFeedbackAndWishes_ServiceProvided_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Data)
                .HasColumnType("tinytext")
                .HasColumnName("data");
            entity.Property(e => e.ServiceProvidedId).HasColumnName("service_provided_id");

            entity.HasOne(d => d.Client).WithMany(p => p.FeedbackAndWishes)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFeedbackAndWishes_Clients");

            entity.HasOne(d => d.ServiceProvided).WithMany(p => p.FeedbackAndWishes)
                .HasForeignKey(d => d.ServiceProvidedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFeedbackAndWishes_ServiceProvided");
        });

        modelBuilder.Entity<GoodsFromTheCheck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("goods_from_the_check");

            entity.HasIndex(e => e.CheckId, "FKGoodsFromTheCheck_Cheks_idx");

            entity.HasIndex(e => e.MeansId, "FKGoodsFromTheCheck_Means_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckId).HasColumnName("check_id");
            entity.Property(e => e.MeansId).HasColumnName("means_id");
            entity.Property(e => e.Price)
                .HasMaxLength(45)
                .HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasMaxLength(45)
                .HasColumnName("quantity");

            entity.HasOne(d => d.Check).WithMany(p => p.GoodsFromTheChecks)
                .HasForeignKey(d => d.CheckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKGoodsFromTheCheck_Cheks");

            entity.HasOne(d => d.Means).WithMany(p => p.GoodsFromTheChecks)
                .HasForeignKey(d => d.MeansId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKGoodsFromTheCheck_Means");
        });

        modelBuilder.Entity<Means>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("means");

            entity.HasIndex(e => e.ConsignmentNote, "FKMeans_ConsigmentNotes_idx");

            entity.HasIndex(e => e.ToolFromTheGuideId, "FKMeans_ResourceGuideItems_idx");

            entity.HasIndex(e => e.ReturnNoteId, "FKMeans_ReturnNotes_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConsignmentNote).HasColumnName("consignment_note");
            entity.Property(e => e.Price)
                .HasMaxLength(45)
                .HasColumnName("price");
            entity.Property(e => e.ReturnNoteId).HasColumnName("return_note_id");
            entity.Property(e => e.ToolFromTheGuideId).HasColumnName("tool_from_the_guide_id");
            entity.Property(e => e.WholesalePrice)
                .HasMaxLength(45)
                .HasColumnName("wholesale_price");

            entity.HasOne(d => d.ConsignmentNoteNavigation).WithMany(p => p.Means)
                .HasForeignKey(d => d.ConsignmentNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMeans_ConsigmentNotes");

            entity.HasOne(d => d.ReturnNote).WithMany(p => p.Means)
                .HasForeignKey(d => d.ReturnNoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMeans_ReturnNotes");

            entity.HasOne(d => d.ToolFromTheGuide).WithMany(p => p.Means)
                .HasForeignKey(d => d.ToolFromTheGuideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMeans_ResourceGuideItems");
        });

        modelBuilder.Entity<OrdersApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders_applications");

            entity.HasIndex(e => e.ProviderId, "FKApplications_Providers_idx");

            entity.HasIndex(e => e.UserId, "FKApplications_Users_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(45)
                .HasColumnName("date");
            entity.Property(e => e.IsFulfilled)
                .HasMaxLength(45)
                .HasColumnName("is_fulfilled");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Provider).WithMany(p => p.OrdersApplications)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKApplications_Providers");

            entity.HasOne(d => d.User).WithMany(p => p.OrdersApplications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKApplications_Users");
        });

        modelBuilder.Entity<OrdersCheck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders_checks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("tinytext")
                .HasColumnName("data");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("providers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fio)
                .HasMaxLength(45)
                .HasColumnName("fio");
            entity.Property(e => e.Inn)
                .HasMaxLength(45)
                .HasColumnName("inn");
        });

        modelBuilder.Entity<RemedyApplication>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("remedy_applications");

            entity.HasIndex(e => e.ApplicationId, "FKRemedyApplication_Applications_idx");

            entity.HasIndex(e => e.ToolFromTheGuideId, "FKRemedyApplications_ResourceGuideItems_idx");

            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.ToolFromTheGuideId).HasColumnName("tool_from_the_guide_id");

            entity.HasOne(d => d.Application).WithMany()
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKRemedyApplications_Applications");

            entity.HasOne(d => d.ToolFromTheGuide).WithMany()
                .HasForeignKey(d => d.ToolFromTheGuideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKRemedyApplications_ResourceGuideItems");
        });

        modelBuilder.Entity<ResourceGuideItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("resource_guide_items");

            entity.HasIndex(e => e.CategoryId, "FKResourceGuideItens_Categories_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.ResourceGuideItems)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKResourceGuideItens_Categories");
        });

        modelBuilder.Entity<ReturnNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("return_notes");

            entity.HasIndex(e => e.UserId, "FKReturnNotes_Users_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ReturnNotes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKReturnNotes_Users");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("services");

            entity.HasIndex(e => e.MeansId, "FKServices_Means_idx");

            entity.HasIndex(e => e.ServiceStaffId, "FKServices_ServicesStaffs_idx");

            entity.HasIndex(e => e.Name, "name_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Price, "price_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MeansId).HasColumnName("means_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ServiceStaffId).HasColumnName("service_staff_id");

            entity.HasOne(d => d.Means).WithMany(p => p.Services)
                .HasForeignKey(d => d.MeansId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKServices_Means");

            entity.HasOne(d => d.ServiceStaff).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKServices_ServicesStaffs");
        });

        modelBuilder.Entity<ServiceApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("service_applications");

            entity.HasIndex(e => e.ApplicationId, "FKServiceApplications_Applicationss_idx");

            entity.HasIndex(e => e.ServiceId, "FKServiseApplications_Services_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Application).WithMany(p => p.ServiceApplications)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKServiceApplications_Applicationss");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceApplications)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKServiseApplications_Services");
        });

        modelBuilder.Entity<ServiceProvided>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("service_provideds");

            entity.HasIndex(e => e.ServiceApplicationId, "FKServiceProvideds_ServiceApplications_idx");

            entity.HasIndex(e => e.ServiceStaffId, "FKServiceProvideds_ServiceStaffs_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Check)
                .HasMaxLength(255)
                .HasColumnName("check");
            entity.Property(e => e.Price)
                .HasMaxLength(45)
                .HasColumnName("price");
            entity.Property(e => e.ServiceApplicationId).HasColumnName("service-application_id");
            entity.Property(e => e.ServiceStaffId).HasColumnName("service_staff_id");

            entity.HasOne(d => d.ServiceApplication).WithMany(p => p.ServiceProvideds)
                .HasForeignKey(d => d.ServiceApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKServiceProvideds_ServiceApplications");

            entity.HasOne(d => d.ServiceStaff).WithMany(p => p.ServiceProvideds)
                .HasForeignKey(d => d.ServiceStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKServiceProvideds_ServiceStaffs");
        });

        modelBuilder.Entity<ServiceStaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("service_staffs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Experience)
                .HasMaxLength(255)
                .HasColumnName("experience");
            entity.Property(e => e.Fio)
                .HasMaxLength(45)
                .HasColumnName("fio");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasColumnName("position");
        });

        modelBuilder.Entity<ShiftSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("shift_schedules");

            entity.HasIndex(e => e.ServiceStaffId, "FKShiftSchedules_ServiceStaffs_idx");

            entity.HasIndex(e => e.UserId, "FKShiftSchedules_Users_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("tinytext")
                .HasColumnName("data");
            entity.Property(e => e.ServiceStaffId).HasColumnName("service_staff_id");
            entity.Property(e => e.Time)
                .HasColumnType("tinytext")
                .HasColumnName("time");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ServiceStaff).WithMany(p => p.ShiftSchedules)
                .HasForeignKey(d => d.ServiceStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKShiftSchedules_ServiceStaffs");

            entity.HasOne(d => d.User).WithMany(p => p.ShiftSchedules)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKShiftSchedules_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Id, "iduser_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fio)
                .HasMaxLength(45)
                .HasColumnName("fio");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasColumnName("position");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
