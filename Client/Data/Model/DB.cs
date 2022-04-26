using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Client.Data.Model
{
    public partial class DB : DbContext
    {
        public DB()
        {
        }

        public DB(DbContextOptions<DB> options)
            : base(options)
        {
        }

        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestHotel> RequestHotels { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SubSkill> SubSkills { get; set; }
        public virtual DbSet<SubSkillMark> SubSkillMarks { get; set; }
        public virtual DbSet<SubSkillTask> SubSkillTasks { get; set; }
        public virtual DbSet<SubSkillTaskResolving> SubSkillTaskResolvings { get; set; }
        public virtual DbSet<TestProject> TestProjects { get; set; }
        public virtual DbSet<TestProjectSession> TestProjectSessions { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TrainingDay> TrainingDays { get; set; }
        public virtual DbSet<TrainingPlace> TrainingPlaces { get; set; }
        public virtual DbSet<UnitType> UnitTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDocument> UserDocuments { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<UserTrainingDay> UserTrainingDays { get; set; }
        public virtual DbSet<WSOS> WSOS { get; set; }
        public virtual DbSet<Training> training { get; set; }

        public virtual DbSet<SubSkillCriterion> SubSkillCriteria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.ToTable("Catalog");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.EditDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.CatalogNavigation)
                    .WithMany(p => p.InverseCatalogNavigation)
                    .HasForeignKey(d => d.CatalogId)
                    .HasConstraintName("FK_Catalog_Catalog");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Catalogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalog_User");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Country");
            });

            modelBuilder.Entity<SubSkillCriterion>(entity =>
            {
                entity.ToTable("SubSkillCriterion");
                entity.HasOne(d => d.SubSkill)
                    .WithMany(p => p.SubSkillCriteria)
                    .HasForeignKey(d => d.SubSkillId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_SubSkillCritetion_SubSkill");
                    

            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.ToTable("Expense");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ExpenseType)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.ExpenseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expense_ExpenseType");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expense_Training");

                entity.HasOne(d => d.UnitType)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.UnitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expense_UnitType");
            });

            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.ToTable("ExpenseType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("File");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.EditDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.CatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_File_Catalog");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasKey(e => new { e.TrainingId, e.UserId });

                entity.ToTable("Participant");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participant_Training");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participant_User");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.CheckInDate).HasColumnType("date");

                entity.Property(e => e.CheckOutDate).HasColumnType("date");

                entity.Property(e => e.EarlyCheckInDateTime).HasColumnType("datetime");

                entity.Property(e => e.HotelPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LateCheckOutDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_User");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Training");

                entity.HasOne(d => d.UserDocument)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.UserDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_UserDocument");
            });

            modelBuilder.Entity<RequestHotel>(entity =>
            {
                entity.ToTable("RequestHotel");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestHotels)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestHotel_Request");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Skill");

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.InternationalExpert)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.InternationalExpertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Skill_User");
            });

            modelBuilder.Entity<SubSkill>(entity =>
            {
                entity.ToTable("SubSkill");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ParentSubSkill)
                    .WithMany(p => p.InverseParentSubSkill)
                    .HasForeignKey(d => d.ParentSubSkillId)
                    .HasConstraintName("FK_SubSkill_SubSkill")
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.WSOS)
                    .WithMany(p => p.SubSkills)
                    .HasForeignKey(d => d.WSOSId)
                    .HasConstraintName("FK_SubSkill_WSOS")
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SubSkillMark>(entity =>
            {
                entity.ToTable("SubSkillMark");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.Competitor)
                    .WithMany(p => p.SubSkillMarks)
                    .HasForeignKey(d => d.CompetitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubSkillMark_User");

                entity.HasOne(d => d.SubSkill)
                    .WithMany(p => p.SubSkillMarks)
                    .HasForeignKey(d => d.SubSkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubSkillMark_SubSkill");
            });

            modelBuilder.Entity<SubSkillTask>(entity =>
            {
                entity.ToTable("SubSkillTask");

                entity.Property(e => e.AttachmentPath).HasMaxLength(100);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.SubSkillTasks)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubSkillTask_User");

                entity.HasOne(d => d.SubSkill)
                    .WithMany(p => p.SubSkillTasks)
                    .HasForeignKey(d => d.SubSkilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubSkillTask_SubSkill");

                entity.HasOne(d => d.TestProject)
                    .WithMany(p => p.SubSkillTasks)
                    .HasForeignKey(d => d.TestProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubSkillTask_TestProject");
            });

            modelBuilder.Entity<SubSkillTaskResolving>(entity =>
            {
                entity.ToTable("SubSkillTaskResolving");

                

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.ResolvingDuration).HasColumnType("time(0)");

                entity.Property(e => e.SolutionPath).HasMaxLength(100);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Competitor)
                    .WithMany(p => p.SubSkillTaskResolvings)
                    .HasForeignKey(d => d.CompetitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubSkillTaskResolving_User");

                entity.HasOne(d => d.SubSkillTask)
                    .WithMany(p => p.SubSkillTaskResolvings)
                    .HasForeignKey(d => d.SubSkillTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubSkillTaskResolving_SubSkillTask");
            });

            modelBuilder.Entity<TestProject>(entity =>
            {
                entity.ToTable("TestProject");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.IssueDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TestProjectSession>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TestProjectSession");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FileStorage).IsRequired();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.TestProject)
                    .WithMany()
                    .HasForeignKey(d => d.TestProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestProjectSession_TestProject");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.ArrivalDateTim).HasColumnType("datetime");

                entity.Property(e => e.BaggageInfo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DepartureDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.ArrivalCity)
                    .WithMany(p => p.TicketArrivalCities)
                    .HasForeignKey(d => d.ArrivalCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_City1");

                entity.HasOne(d => d.DepartureCity)
                    .WithMany(p => p.TicketDepartureCities)
                    .HasForeignKey(d => d.DepartureCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_City");

                entity.HasOne(d => d.Expensive)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ExpensiveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Expense");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Request");
            });

            modelBuilder.Entity<TrainingDay>(entity =>
            {
                entity.ToTable("TrainingDay");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.TrainingDays)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainingDay_Training");
            });

            modelBuilder.Entity<TrainingPlace>(entity =>
            {
                entity.ToTable("TrainingPlace");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TrainingPlaces)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainingPlace_City");
            });

            modelBuilder.Entity<UnitType>(entity =>
            {
                entity.ToTable("UnitType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullNameEN)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FullNameRU).HasMaxLength(200);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.PhotoPath).HasMaxLength(256);
            });

            modelBuilder.Entity<UserDocument>(entity =>
            {
                entity.ToTable("UserDocument");

                entity.Property(e => e.ScanPath).HasMaxLength(256);

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.UserDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDocument_DocumentType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDocuments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDocument_User");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("UserRole");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => e.Token);

                entity.ToTable("UserToken");

                entity.Property(e => e.Token).HasMaxLength(300);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserToken_User");
            });

            modelBuilder.Entity<UserTrainingDay>(entity =>
            {
                entity.ToTable("UserTrainingDay");

                entity.HasOne(d => d.TrainingDay)
                    .WithMany(p => p.UserTrainingDays)
                    .HasForeignKey(d => d.TrainingDayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTrainingDay_TrainingDay");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTrainingDays)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTrainingDay_User");
            });

            modelBuilder.Entity<WSOS>(entity =>
            {
                entity.ToTable("WSOS");

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.SkillCodeNavigation)
                    .WithMany(p => p.WSOS)
                    .HasForeignKey(d => d.SkillCode)
                    .HasConstraintName("FK_WSOS_Skill");
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.ToTable("Training");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.SkillCodeNavigation)
                    .WithMany(p => p.training)
                    .HasForeignKey(d => d.SkillCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Training_Skill");

                entity.HasOne(d => d.TrainingPlace)
                    .WithMany(p => p.training)
                    .HasForeignKey(d => d.TrainingPlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Training_TrainingPlace");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
